using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.DTO.CountrysDTOs {
    public class UpdateCountryDTO {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be over 50 characters")]
        public string Name { get; set; }
        [Required]
        public Continent Continent { get; set; }
        public int WcWon { get; set; }
    }
}
