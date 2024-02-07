using System.ComponentModel.DataAnnotations;

namespace FootballAPI.DTO.AccountDTOs {
    public class LoginDTO {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
