﻿using FootballAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.Models {
    public class Club {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public League League { get; set; } = League.PremierLeague;
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public List<Footballer> Footballers { get; set; } = new List<Footballer>();
    }
}
