using ViajesAPI.Models;

namespace ViajesAPI.Repositories.Interfaces
{
    public interface IViajeRepository
    {
        Task<List<Viaje>> GetAll();
        Task<Viaje> GetByEstado(string estado);
    }
}
