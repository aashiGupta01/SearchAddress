using SearchAddress.Entities.Enums;
using SearchAddress.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchAddress.Service.Abstraction
{
    public interface ILocationService
    {
        Task Create(Location location);
        Task<IEnumerable<Location>> Search(string query, SortBy sortBy);

    }
}
