using FootballAPI.Enums;

namespace FootballAPI.DTO.CountrysDTOs {
    public class CreateCountryDTO {
        public string Name { get; set; } = string.Empty;
        public Continent Continent { get; set; } = Continent.Europe;
        public int WcWon { get; set; } = 0;
    }
}
