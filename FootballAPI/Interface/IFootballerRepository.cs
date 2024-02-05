using FootballAPI.Models;

namespace FootballAPI.Interface {
    public interface IFootballerRepository {
        Task<ICollection<Footballer>> GetFootballers();
        Task<Footballer> GetFootballerById(int id);
        Task<Footballer> GetFootballerByIdAsNoTracking(int id);
        Task<ICollection<Footballer>> GetFootballersByCountry(int countryId);
        Task<ICollection<Footballer>> GetFootballersByClub(int clubId);
        Task<bool> FootballerExists(int id);
        Task<bool> CreateFootballer(Footballer footballer);
        Task<bool> UpdateFootballer(Footballer footballer);
        Task<bool> DeleteFootballer(Footballer footballer);
        Task<bool> Save();
    }
}
