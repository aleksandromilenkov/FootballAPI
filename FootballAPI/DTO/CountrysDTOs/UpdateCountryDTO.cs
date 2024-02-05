using FootballAPI.Enums;

namespace FootballAPI.DTO.CountrysDTOs {
    public class UpdateCountryDTO {
        public string Name { get; set; }
        public Continent Continent { get; set; }
        public int WcWon { get; set; }
    }
}
