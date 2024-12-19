using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZVehicleLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZVehicleLibrary.Repos
{
    public class EFVehicleRepoAsync : IVehicleRepoAsync
    {
        ABZVehicleDBContext ctx = new ABZVehicleDBContext();
        public async Task DeleteVehicleAsync(string regNo)
        {
            Vehicle vehicle = await GetVehicleAsync(regNo);
            ctx.Vehicles.Remove(vehicle);
            await ctx.SaveChangesAsync();
        }
        public async Task<List<Vehicle>> GetAllVehiclesAsync()
        {
            List<Vehicle> vehicles = await ctx.Vehicles.ToListAsync();
            return vehicles;
        }
        public async Task<Vehicle> GetVehicleAsync(string regNo)
        {
            try
            {
                Vehicle vehicle = await (from v in ctx.Vehicles where regNo == v.RegNo select v).FirstAsync();
                return vehicle;
            }
            catch (Exception ex)
            {

                throw new Exception("No such RegNo exist");
            }
        }
        public async Task<List<Vehicle>> GetVehiclesByCustomerAsync(string customerId)
        {
            List<Vehicle> vehicles = await (from v in ctx.Vehicles where customerId == v.OwnerId select v).ToListAsync();
            if (vehicles.Count == 0)
                throw new Exception("No such customer id");
            else
                return vehicles;
        }
        public async Task InsertVehicleAsync(Vehicle vehicle)
        {
            await ctx.Vehicles.AddAsync(vehicle);
            await ctx.SaveChangesAsync();
        }
        public async Task UpdateVehicleAsync(string regNo, Vehicle vehicle)
        {
            Vehicle vehicle1 = await GetVehicleAsync(regNo);
            vehicle1.EngineNo = vehicle.EngineNo;
            vehicle1.RegDate = vehicle.RegDate;
            vehicle1.SeatingCapacity = vehicle.SeatingCapacity;
            vehicle1.EngineCapacity = vehicle.EngineCapacity;
            vehicle1.BodyType = vehicle.BodyType;
            vehicle1.RegAuthority = vehicle.RegAuthority;
            vehicle1.ChassisNo = vehicle.ChassisNo;
            vehicle1.FuelType = vehicle.FuelType;
            vehicle1.LeasedBy = vehicle.LeasedBy;
            vehicle1.Make = vehicle.Make;
            vehicle1.MfgYear = vehicle.MfgYear;
            vehicle1.Model = vehicle.Model;
            vehicle1.Variant = vehicle.Variant;
            await ctx.SaveChangesAsync();
        }
    }
}
