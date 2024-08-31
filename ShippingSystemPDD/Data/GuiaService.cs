using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystemPDD.Data
{
    public class GuiaService
    {
        private readonly ApplicationDbContext _context;

        public GuiaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paquete>> ObtenerPaquetesAsync()
        {
            return await _context.Paquetes
                .Include(p => p.TipoDePaquete)
                .Include(p => p.Remitente)
                .Include(p => p.Destinario)
                .ThenInclude(d => d.Direccion)
                .ToListAsync();
        }

        public async Task<Paquete> ObtenerPaquetePorIdAsync(int id)
        {
            return await _context.Paquetes
                .Include(p => p.TipoDePaquete)
                .Include(p => p.Remitente)
                .Include(p => p.Destinario)
                .ThenInclude(d => d.Direccion)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AgregarPaqueteAsync(Paquete paquete)
        {
            _context.Paquetes.Add(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPaqueteAsync(Paquete paquete)
        {
            _context.Paquetes.Update(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPaqueteAsync(int id)
        {
            var paquete = await ObtenerPaquetePorIdAsync(id);
            if (paquete != null)
            {
                _context.Paquetes.Remove(paquete);
                await _context.SaveChangesAsync();
            }
        }
    }

}
