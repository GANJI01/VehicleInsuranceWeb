using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZVehicleLibrary.Models;

namespace ABZVehicleLibrary.Repos
{
    public interface IVehicleRepoAsync
    {
        Task InsertVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(string regNo);
        Task UpdateVehicleAsync(string regNo,Vehicle vehicle);
        Task<Vehicle> GetVehicleAsync(string regNo);
        Task<List<Vehicle>> GetAllVehiclesAsync();
        Task<List<Vehicle>> GetVehiclesByCustomerAsync(string customerId);

    }
}
