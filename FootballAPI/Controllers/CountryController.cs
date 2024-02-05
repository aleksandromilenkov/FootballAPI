﻿using AutoMapper;
using FootballAPI.DTO;
using FootballAPI.Interface;
using FootballAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountryController(IClubRepository clubRepository, IMapper mapper, ICountryRepository countryRepository) {
            _clubRepository = clubRepository;
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries() {
            var countries = await _countryRepository.GetCountries();
            if (countries == null) {
                return BadRequest(ModelState);
            }
            return Ok(countries);
        }
        [HttpGet("{id:int}"), ActionName("GetCountryById")]
        [ProducesResponseType(200, Type = typeof(FootballerDTO))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryById([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var country = await _countryRepository.GetCountryById(id);
            if (country == null) {
                return NotFound();
            }
            var countryToReturn = _mapper.Map<CountryDTO>(country);

            return Ok(countryToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO createCountryDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var country = _mapper.Map<Country>(createCountryDTO);
            if (!await _countryRepository.CreateCountry(country)) {
                return BadRequest(ModelState);
            }
            else {
                var countryToReturn = _mapper.Map<CountryDTO>(country);
                return CreatedAtAction("GetCountryById", new { id = country.Id }, countryToReturn);
            }

        }
    }
}