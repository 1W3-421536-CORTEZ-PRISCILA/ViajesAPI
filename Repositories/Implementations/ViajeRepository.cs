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
        public async Task<bool> ActualizarFecha(Viaje viaje, int id)
        {
            var entity = await _context.Viajes.FindAsync(id);
            if (entity == null) return false;
            entity.FechaFin = viaje.FechaInicio;
            _context.Viajes.Update(entity);
            return await _context.SaveChangesAsync() > 0;
                      
        }

    }
}
