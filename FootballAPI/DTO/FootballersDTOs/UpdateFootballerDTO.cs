using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.DTO.FootballersDTOs {
    public class UpdateFootballerDTO {
        [MaxLength(50, ErrorMessage = "FirstName cannot be over 50 characters")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50, ErrorMessage = "LastName cannot be over 50 characters")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public int? Age { get; set; }
        public int? ClubId { get; set; }
        public Position Position { get; set; } = Position.Goalkeeper;
    }
}
