using Microsoft.EntityFrameworkCore;
using ViajesAPI.Models;
using ViajesAPI.Repositories.Interfaces;
using ViajesAPI.Services.Interfaces;

namespace ViajesAPI.Services.Implementations
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _repository;
        public ViajeService(IViajeRepository repository)
        {
            _repository = repository;
        }

        

        public async Task<List<Viaje>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Viaje?> GetByEstado(string estado)
        {
            return await _repository.GetByEstado(estado);
        }

        public async Task<bool> ActualizarFecha(Viaje viaje, int id)
        {
            return await _repository.ActualizarFecha(viaje, id);
        }
    }
}
