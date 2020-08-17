using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchAddress.Entities.Enums;
using SearchAddress.Entities.Models;
using SearchAddress.Service.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchAddress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        [HttpGet("Search")]
        public async Task<IActionResult> SearchLocation(string query, SortBy? sortBy = SortBy.Address)
        {
            try
            {
                if (query.Length < 3 || String.IsNullOrWhiteSpace(query))
                {
                    return BadRequest("Please provide correct query parameter");

                }

                return Ok(await _locationService.Search(query, sortBy.Value));
            }
            catch
            {
                return StatusCode(500, "Failure occured while processing this request");
            }
            
        }


        // POST api/<LocationController>
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] Location location)
        {
            try
            {
                await _locationService.Create(location);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Failure occured while processing this request");

            }
        }

    }
}
