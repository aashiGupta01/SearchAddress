using SearchAddress.Entities.Models;
using SearchAddress.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SearchAddress.Repository.Abstraction;
using SearchAddress.Entities.Enums;
using System.Linq;
using System.Diagnostics;

namespace SearchAddress.Service
{
    public class LocationService : ILocationService
    {
        private ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task Create(Location location)
        {
            await _locationRepository.Create(location);
           
        }

        public async Task<IEnumerable<Location>> Search(string query, SortBy sortBy)
        {
            IEnumerable<Location> result = null;
            switch(sortBy)
            {
                case SortBy.Address:
                    result = (await _locationRepository.Search(query)).OrderBy(x => x.Address);
                    break;
                case SortBy.Frequency:
                    result = SortByFrequency(await _locationRepository.Search(query), query);
                    break;
            }
            return result;
        }

        private IEnumerable<Location> SortByFrequency(IEnumerable<Location> locations, string query)
        {
            IEnumerable<Location> result;
            List<LocationFrequency> locationFrequencies = new List<LocationFrequency>();
            foreach(Location loc in locations)
            {
                locationFrequencies.Add(new LocationFrequency
                {
                    Address = loc.Address,
                    City = loc.City,
                    State = loc.State,
                    Zip = loc.Zip,
                    Frequency = GetFrequency(loc, query)
                });
            }
            result = locationFrequencies.OrderByDescending(x => x.Frequency);
            return result;
        }

        private int GetFrequency(Location location, string query)
        {
            int result = 0;
            int qLength = query.Length;
            if (location.Address.ToLower().Contains(query.ToLower()))
                result = result + qLength;
            if (location.State.ToLower().Contains(query.ToLower()))
                result = result + (qLength * 3);
            if (location.City.ToLower().Contains(query.ToLower()))
                result = result + (qLength * 2);
            return result;
        }
    }}
