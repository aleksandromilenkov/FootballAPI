using AutoMapper;
using FootballAPI.DTO;
using FootballAPI.Interface;
using FootballAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public ClubController(IClubRepository clubRepository, IMapper mapper) {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClubs() {
            var clubs = await _clubRepository.GetClubs();
            if (clubs == null) {
                return BadRequest(ModelState);
            }
            return Ok(clubs);
        }

        [HttpGet("{id:int}"), ActionName("GetClubById")]
        [ProducesResponseType(200, Type = typeof(FootballerDTO))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetClubById([FromRoute] int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var club = await _clubRepository.GetClubById(id);
            if (club == null) {
                return NotFound();
            }
            var clubToReturn = _mapper.Map<ClubDTO>(club);

            return Ok(clubToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateClubDTO createClubDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var club = _mapper.Map<Club>(createClubDTO);
            if (!await _clubRepository.CreateClub(club)) {
                return BadRequest(ModelState);
            }
            else {
                var clubToReturn = _mapper.Map<ClubDTO>(club);
                return CreatedAtAction("GetClubById", new { id = club.Id }, clubToReturn);
            }

        }
    }
}
