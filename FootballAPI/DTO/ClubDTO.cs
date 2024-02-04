using FootballAPI.Enums;
using FootballAPI.Models;

namespace FootballAPI.DTO {
    public class ClubDTO {
        public string Name { get; set; }
        public League League { get; set; }
        public Country Country { get; set; }
        public List<Footballer> Footballers { get; set; } = new List<Footballer>();
    }
}
