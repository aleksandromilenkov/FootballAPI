using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAPI.DTO.FootballersDTOs {
    public class CreateFootballerDTO {
        [MaxLength(50, ErrorMessage = "FirstName cannot be over 50 characters")]
        public string FirstName { get; set; } = "";
        [Required]
        [MaxLength(50, ErrorMessage = "LastName cannot be over 50 characters")]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public Position Position { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        [ForeignKey("ClubId")]
        public int ClubId { get; set; }

    }
}
