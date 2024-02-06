namespace FootballAPI.Helper {
    public class FootballerQueryObject {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? CountryName { get; set; } = null;
        public string? ClubName { get; set; } = null;
        public string? SortBy { get; set; } = "LastName";
        public int? Age { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
