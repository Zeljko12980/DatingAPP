using API.Data;

using Microsoft.EntityFrameworkCore;
namespace API.Services.Destinacija
{
    public class DestinacijaService:IDestinacijaService
    {
         private readonly DataContext _context;

        public DestinacijaService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<API.Entities.Destinacija>> GetAllAsync()
        {
            return await _context.Destinacije.ToListAsync();
        }

        public async Task<API.Entities.Destinacija> GetByIdAsync(int id)
        {
            return await _context.Destinacije.FindAsync(id);
        }

        public async Task<API.Entities.Destinacija> CreateAsync(API.Entities.Destinacija destinacija)
        {
            _context.Destinacije.Add(destinacija);
            await _context.SaveChangesAsync();
            return destinacija;
        }

        public async Task<bool> UpdateAsync(API.Entities.Destinacija destinacija)
        {
            if (!_context.Destinacije.Any(e => e.Id == destinacija.Id))
                return false;

            _context.Entry(destinacija).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var destinacija = await _context.Destinacije.FindAsync(id);
            if (destinacija == null)
                return false;

            _context.Destinacije.Remove(destinacija);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}