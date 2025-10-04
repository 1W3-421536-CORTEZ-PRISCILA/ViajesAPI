using ViajesAPI.Models;

namespace ViajesAPI.Services.Interfaces
{
    public interface IViajeService
    {
        Task<List<Viaje>> GetAll();
        Task<Viaje?> GetByEstado(string estado);
        Task<bool> ActualizarFecha(Viaje viaje, int id);
    }
}
