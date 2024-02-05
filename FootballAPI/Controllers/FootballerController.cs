using AutoMapper;
using FootballAPI.DTO.FootballersDTOs;
using FootballAPI.Interface;
using FootballAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerController : ControllerBase {
        private readonly IFootballerRepository _footballerRepository;
        private readonly IMapper _mapper;
        private readonly IClubRepository _clubRepository;
        private readonly ICountryRepository _countryRepository;

        public FootballerController(IFootballerRepository footballerRepository, IMapper mapper, IClubRepository clubRepository, ICountryRepository countryRepository) {
            _footballerRepository = footballerRepository;
            _mapper = mapper;
            _clubRepository = clubRepository;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFootballers() {
            var footballers = _mapper.Map<List<FootballerDTO>>(await _footballerRepository.GetFootballers());
            if (footballers == null) {
                return BadRequest("Something went wrong");
            }
            return Ok(footballers);
        }

        [HttpGet("{id:int}"), ActionName("GetFootballerById")]
        [ProducesResponseType(200, Type = typeof(FootballerDTO))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFootballerById([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var footballer = await _footballerRepository.GetFootballerById(id);
            if (footballer == null) {
                return NotFound();
            }
            var footballerToReturn = _mapper.Map<FootballerDTO>(footballer);

            return Ok(footballerToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFootballer([FromBody] CreateFootballerDTO footballer) {
            if (!ModelState.IsValid) {
                return BadRequest("Cannot create footballer.");
            }
            var country = _countryRepository.GetCountryById(footballer.CountryId);
            var club = _clubRepository.GetClubById(footballer.ClubId);
            var footballerToCreate = _mapper.Map<Footballer>(footballer);
            if (!await _footballerRepository.CreateFootballer(footballerToCreate)) {
                return BadRequest("Something went wrong");
            }
            else {
                var footballerToReturn = _mapper.Map<FootballerDTO>(footballerToCreate);
                return CreatedAtAction("GetFootballerById", new { id = footballerToCreate.Id }, footballerToReturn);
            }
        }
    }
}
