using FootballAPI.Helper;
using FootballAPI.Models;

namespace FootballAPI.Interface {
    public interface IClubRepository {
        Task<ICollection<Club>> GetClubs(ClubQueryObject clubQueryObject);
        Task<Club> GetClubById(int id);
        Task<Club> GetClubByIdAsNoTracking(int id);
        Task<ICollection<Club>> GetClubsByCountryId(int countryId);
        Task<bool> ClubExists(int id);
        Task<bool> CreateClub(Club club);
        Task<bool> UpdateClub(Club club);
        Task<bool> DeleteClub(Club club);
        Task<bool> Save();
    }
}
