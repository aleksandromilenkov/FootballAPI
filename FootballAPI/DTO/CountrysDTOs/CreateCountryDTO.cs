using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.DTO.CountrysDTOs {
    public class CreateCountryDTO {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be over 50 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Continent Continent { get; set; } = Continent.Europe;
        public int WcWon { get; set; } = 0;
    }
}
