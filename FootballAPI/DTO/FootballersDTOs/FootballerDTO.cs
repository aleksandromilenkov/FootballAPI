using FootballAPI.Enums;
using FootballAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAPI.DTO.FootballersDTOs {
    public class FootballerDTO {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? Age { get; set; }
        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        [ForeignKey("ClubId")]
        public int? ClubId { get; set; }
        public Club? Club { get; set; }
        public Position Position { get; set; } = Position.Goalkeeper;
    }
}
