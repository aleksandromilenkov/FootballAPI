using FootballAPI.Enums;
using FootballAPI.Models;

namespace FootballAPI.DTO.CountrysDTOs {
    public class CountryDTO {
        public string Name { get; set; }
        public Continent Continent { get; set; }
        public int WcWon { get; set; }
        public List<Footballer> Footballers { get; set; } = new List<Footballer>();
        public List<Club> Clubs { get; set; } = new List<Club>();
    }
}
