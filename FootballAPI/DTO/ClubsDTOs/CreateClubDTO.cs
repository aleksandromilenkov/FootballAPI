using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAPI.DTO.ClubsDTOs {
    public class CreateClubDTO {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be over 50 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public League League { get; set; } = League.PremierLeague;
        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }
    }
}
