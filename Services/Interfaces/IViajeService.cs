using ViajesAPI.Models;

namespace ViajesAPI.Services.Interfaces
{
    public interface IViajeService
    {
        Task<List<Viaje>> GetAll();
    }
}
