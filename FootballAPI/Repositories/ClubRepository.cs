﻿using FootballAPI.ApplicationDBContext;
using FootballAPI.Helper;
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

        public async Task<ICollection<Club>> GetClubs(ClubQueryObject clubQueryObject) {
            var clubs = _context.Clubs.Include(c => c.Footballers).Include(c => c.Country).ThenInclude(c => c.Footballers).AsQueryable();
            if (!string.IsNullOrWhiteSpace(clubQueryObject.Name) && clubQueryObject.Name != "null") {
                clubs = clubs.Where(c => c.Name == clubQueryObject.Name);
            }
            if (clubQueryObject.League != null) {
                clubs = clubs.Where(c => c.League == clubQueryObject.League);
            }
            if (!string.IsNullOrWhiteSpace(clubQueryObject.CountryName) && clubQueryObject.CountryName != "null") {
                clubs = clubs.Where(c => c.Country.Name.ToLower() == clubQueryObject.CountryName.Trim().ToLower());
            }
            if (!string.IsNullOrWhiteSpace(clubQueryObject.SortBy) && clubQueryObject.SortBy != "null") {
                if (clubQueryObject.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                    clubs = clubQueryObject.IsDescending ? clubs.OrderByDescending(c => c.Name) : clubs.OrderBy(c => c.Name);
                }
                if (clubQueryObject.SortBy.Equals("CountryName", StringComparison.OrdinalIgnoreCase)) {
                    clubs = clubQueryObject.IsDescending ? clubs.OrderByDescending(c => c.Country.Name) : clubs.OrderBy(c => c.Country.Name);
                }
            }
            var skipNumber = (clubQueryObject.PageNumber - 1) * clubQueryObject.PageSize;
            return await clubs.Skip(skipNumber).Take(clubQueryObject.PageSize).ToListAsync();
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
