﻿using FootballAPI.Enums;

namespace FootballAPI.Models {
    public class Country {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public Continent Continent { get; set; } = Continent.Europe;
        public int WcWon { get; set; } = 0;
        public List<Footballer> Footballers { get; set; } = new List<Footballer>();
        public List<Club> Clubs { get; set; } = new List<Club>();
    }
}
