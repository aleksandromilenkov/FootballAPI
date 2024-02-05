using FootballAPI.Enums;

namespace FootballAPI.DTO.FootballersDTOs {
    public class UpdateFootballerDTO {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Age { get; set; }
        public int? ClubId { get; set; }
        public Position Position { get; set; } = Position.Goalkeeper;
    }
}
