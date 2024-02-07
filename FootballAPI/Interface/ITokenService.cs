using FootballAPI.Models;

namespace FootballAPI.Interface {
    public interface ITokenService {
        string CreateToken(AppUser appUser);
    }
}
