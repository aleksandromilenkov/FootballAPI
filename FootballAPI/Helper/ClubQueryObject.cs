using FootballAPI.Enums;

namespace FootballAPI.Helper {
    public class ClubQueryObject {
        public string Name { get; set; } = String.Empty;
        public League? League { get; set; } = null;
        public string? CountryName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }
}
