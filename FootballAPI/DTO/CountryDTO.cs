using FootballAPI.Enums;

namespace FootballAPI.DTO {
    public class CountryDTO {
        public string Name { get; set; }
        public Continent Continent { get; set; }
        public int WcWon { get; set; }
    }
}
