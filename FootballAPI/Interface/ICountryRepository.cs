﻿using FootballAPI.Models;

namespace FootballAPI.Interface {
    public interface ICountryRepository {
        Task<ICollection<Country>> GetCountries();
        Task<Country> GetCountryById(int id);
        Task<bool> CountryExists(int id);
        Task<bool> CreateCountry(Country country);
        Task<bool> UpdateCountry(Country country);
        Task<bool> DeleteCountry(Country country);
        Task<bool> Save();
    }
}