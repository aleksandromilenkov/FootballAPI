using FootballAPI.ApplicationDBContext;
using FootballAPI.Interface;
using FootballAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballAPI.Repositories {
    public class CountryRepository : ICountryRepository {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<bool> CountryExists(int id) {
            return await _context.Countries.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateCountry(Country country) {
            await _context.Countries.AddAsync(country);
            return await Save();
        }

        public async Task<bool> DeleteCountry(Country country) {
            _context.Countries.Remove(country);
            return await Save();
        }

        public async Task<ICollection<Country>> GetCountries() {
            return await _context.Countries.Include(c => c.Footballers).Include(c => c.Clubs).ToListAsync();
        }



        public async Task<Country> GetCountryById(int id) {
            return await _context.Countries.Where(c => c.Id == id).Include(c => c.Clubs).Include(c => c.Footballers).FirstOrDefaultAsync();
        }

        public async Task<Country> GetCountryByIdAsNoTracking(int id) {
            return await _context.Countries.Where(c => c.Id == id).Include(c => c.Clubs).Include(c => c.Footballers).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> Save() {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCountry(Country country) {
            _context.Countries.Update(country);
            return await Save();
        }
    }
}
