using FootballAPI.ApplicationDBContext;
using FootballAPI.Interface;
using FootballAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballAPI.Repositories {
    public class FootballerRepository : IFootballerRepository {
        private readonly ApplicationDbContext _context;

        public FootballerRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<bool> CreateFootballer(Footballer footballer) {
            await _context.Footballers.AddAsync(footballer);
            return await Save();
        }

        public async Task<bool> DeleteFootballer(Footballer footballer) {
            _context.Footballers.Remove(footballer);
            return await Save();
        }

        public async Task<bool> FootballerExists(int id) {
            return await _context.Footballers.AnyAsync(f => f.Id == id);
        }

        public async Task<Footballer> GetFootballerById(int id) {
            return await _context.Footballers.Where(f => f.Id == id).Include(f => f.Country).Include(f => f.Club).FirstOrDefaultAsync();
        }

        public async Task<Footballer> GetFootballerByIdAsNoTracking(int id) {
            return await _context.Footballers.Where(f => f.Id == id).Include(f => f.Country).Include(f => f.Club).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ICollection<Footballer>> GetFootballers() {
            return await _context.Footballers.Include(f => f.Country).Include(f => f.Club).ToListAsync();
        }

        public async Task<ICollection<Footballer>> GetFootballersByClub(int clubId) {
            return await _context.Footballers.Where(f => f.ClubId == clubId).Include(f => f.Country).Include(f => f.Club).ToListAsync();
        }

        public async Task<ICollection<Footballer>> GetFootballersByCountry(int countryId) {
            return await _context.Footballers.Where(f => f.CountryId == countryId).Include(f => f.Country).Include(f => f.Club).ToListAsync();
        }

        public async Task<bool> Save() {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFootballer(Footballer footballer) {
            _context.Footballers.Update(footballer);
            return await Save();
        }
    }
}
