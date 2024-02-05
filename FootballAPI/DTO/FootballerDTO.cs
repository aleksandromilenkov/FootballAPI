using FootballAPI.Enums;
using FootballAPI.Models;

namespace FootballAPI.DTO {
    public class FootballerDTO {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public int? Age { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public int? ClubId { get; set; }
        public Club? Club { get; set; }
        public Position Position { get; set; } = Position.Goalkeeper;
    }
}
