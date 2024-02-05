using FootballAPI.Enums;

namespace FootballAPI.DTO {
    public class CreateCountryDTO {
        public string Name { get; set; } = String.Empty;
        public Continent Continent { get; set; } = Continent.Europe;
        public int WcWon { get; set; } = 0;
    }
}
