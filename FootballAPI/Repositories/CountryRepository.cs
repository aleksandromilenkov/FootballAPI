using FootballAPI.ApplicationDBContext;
using FootballAPI.Helper;
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

        public async Task<ICollection<Country>> GetCountries(CountryQueryObject countryQueryObject) {
            var countries = _context.Countries.Include(c => c.Footballers).Include(c => c.Clubs).AsQueryable();
            if (!string.IsNullOrWhiteSpace(countryQueryObject.Name)) {
                countries = countries.Where(c => c.Name == countryQueryObject.Name);
            }
            if (countryQueryObject.Continent != null) {
                countries = countries.Where(c => c.Continent == countryQueryObject.Continent);
            }
            if (countryQueryObject.WcWon != null) {
                countries = countries.Where(c => c.WcWon == countryQueryObject.WcWon);
            }
            if (!string.IsNullOrWhiteSpace(countryQueryObject.SortBy)) {
                if (countryQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                    countries = countryQueryObject.IsDescending ? countries.OrderByDescending(c => c.Name) : countries.OrderBy(c => c.Name);
                }
                if (countryQueryObject.SortBy.Equals("Continent", StringComparison.OrdinalIgnoreCase)) {
                    countries = countryQueryObject.IsDescending ? countries.OrderByDescending(c => c.Continent) : countries.OrderBy(c => c.Continent);
                }
                if (countryQueryObject.SortBy.Equals("WcWon", StringComparison.OrdinalIgnoreCase)) {
                    countries = countryQueryObject.IsDescending ? countries.OrderBy(c => c.WcWon) : countries.OrderByDescending(c => c.WcWon);
                }
            }
            var skipNumber = (countryQueryObject.PageNumber - 1) * countryQueryObject.PageSize;
            return await countries.Skip(skipNumber).Take(countryQueryObject.PageSize).ToListAsync();
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
