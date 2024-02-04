using FootballAPI.Enums;
using FootballAPI.Models;

namespace FootballAPI.DTO {
    public class FootballerDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Country Country { get; set; }
        public ClubDTO Club { get; set; }
        public Position Position { get; set; }

    }
}
