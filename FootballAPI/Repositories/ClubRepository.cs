using FootballAPI.ApplicationDBContext;
using FootballAPI.Interface;
using FootballAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballAPI.Repositories {
    public class ClubRepository : IClubRepository {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<bool> ClubExists(int id) {
            return await _context.Clubs.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateClub(Club club) {
            await _context.Clubs.AddAsync(club);
            return await Save();
        }

        public async Task<bool> DeleteClub(Club club) {
            _context.Clubs.Remove(club);
            return await Save();
        }

        public async Task<Club> GetClubById(int id) {
            return await _context.Clubs.Where(c => c.Id == id).Include(c => c.Footballers).Include(c => c.Country).FirstOrDefaultAsync();
        }

        public async Task<Club> GetClubByIdAsNoTracking(int id) {
            return await _context.Clubs.Where(c => c.Id == id).Include(c => c.Footballers).Include(c => c.Country).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ICollection<Club>> GetClubs() {
            return await _context.Clubs.Include(c => c.Footballers).Include(c => c.Country).ToListAsync();
        }

        public async Task<ICollection<Club>> GetClubsByCountryId(int countryId) {
            return await _context.Clubs.Where(c => c.CountryId == countryId).Include(c => c.Country).Include(c => c.Footballers).ToListAsync();
        }

        public async Task<bool> Save() {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateClub(Club club) {
            _context.Clubs.Update(club);
            return await Save();
        }
    }
}
