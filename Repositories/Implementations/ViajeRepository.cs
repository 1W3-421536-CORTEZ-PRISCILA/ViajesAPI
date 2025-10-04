using Microsoft.EntityFrameworkCore;
using ViajesAPI.Models;
using ViajesAPI.Repositories.Interfaces;

namespace ViajesAPI.Repositories.Implementations
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly ViajesContext _context;
        public ViajeRepository(ViajesContext context)
        {
            _context = context;
        }
        public async Task<List<Viaje>> GetAll()
        {
           return await _context.Viajes.
                Where(x => x.PrecioTotal >  100000).ToListAsync();
        }

        public async Task<Viaje?> GetByEstado(string estado)
        {
            return await _context.Viajes
                .Include(x => x.ViajeDetalles)
                .FirstOrDefaultAsync(e => e.Estado == estado);
                
        }

        
    }
}
