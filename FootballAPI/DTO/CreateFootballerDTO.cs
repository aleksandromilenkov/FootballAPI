using FootballAPI.Enums;

namespace FootballAPI.DTO {
    public class CreateFootballerDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Position Position { get; set; }
        public int CountryId { get; set; }
        public int ClubId { get; set; }

    }
}
