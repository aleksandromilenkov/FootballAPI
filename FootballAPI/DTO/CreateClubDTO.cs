using FootballAPI.Enums;

namespace FootballAPI.DTO {
    public class CreateClubDTO {
        public string Name { get; set; } = String.Empty;
        public League League { get; set; } = League.PremierLeague;
        public int? CountryId { get; set; }
    }
}
