using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAPI.DTO.FootballersDTOs {
    public class CreateFootballerDTO {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Position Position { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        [ForeignKey("ClubId")]
        public int ClubId { get; set; }

    }
}
