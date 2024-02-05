using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAPI.DTO.ClubsDTOs {
    public class UpdateClubDTO {
        public string Name { get; set; } = string.Empty;
        public League League { get; set; } = League.PremierLeague;
        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }
    }
}
