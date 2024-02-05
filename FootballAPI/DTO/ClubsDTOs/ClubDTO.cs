using FootballAPI.Enums;
using FootballAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballAPI.DTO.ClubsDTOs {
    public class ClubDTO {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public League League { get; set; } = League.PremierLeague;
        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public List<Footballer> Footballers { get; set; } = new List<Footballer>();
    }
}
