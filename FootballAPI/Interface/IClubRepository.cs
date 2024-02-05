using FootballAPI.Models;

namespace FootballAPI.Interface {
    public interface IClubRepository {
        Task<ICollection<Club>> GetClubs();
        Task<Club> GetClubById(int id);
        Task<ICollection<Club>> GetClubsByCountryId(int countryId);
        Task<bool> ClubExists(int id);
        Task<bool> CreateClub(Club club);
        Task<bool> UpdateClub(Club club);
        Task<bool> DeleteClub(Club club);
        Task<bool> Save();
    }
}
