
using SearchAddress.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchAddress.Repository.Abstraction
{
    public interface ILocationRepository
    {
        Task Create(Location location);
        Task<IEnumerable<Location>> Search(string query);
    }
}
