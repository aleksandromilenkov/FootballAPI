using FootballAPI.Enums;

namespace FootballAPI.Helper {

    public class CountryQueryObject {
        public string? Name { get; set; } = String.Empty;
        public Continent? Continent { get; set; } = null;
        public int? WcWon { get; set; }
        public string? SortBy { get; set; } = "Name";
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
