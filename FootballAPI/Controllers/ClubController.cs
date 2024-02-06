using AutoMapper;
using FootballAPI.DTO.ClubsDTOs;
using FootballAPI.DTO.FootballersDTOs;
using FootballAPI.Helper;
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
        public async Task<IActionResult> GetClubs([FromQuery] ClubQueryObject clubQueryObject) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var clubs = _mapper.Map<List<ClubDTO>>(await _clubRepository.GetClubs(clubQueryObject));
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

        [HttpPut("{clubId:int}")]
        public async Task<IActionResult> UpdateClub([FromRoute] int clubId, [FromBody] UpdateClubDTO updateClubDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (!await _clubRepository.ClubExists(clubId)) {
                return NotFound();
            }
            var clubToUpdate = _mapper.Map<Club>(updateClubDTO);
            clubToUpdate.Id = clubId;
            if (clubToUpdate == null) {
                return BadRequest(ModelState);
            }
            if (!await _clubRepository.UpdateClub(clubToUpdate)) {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{clubId:int}")]
        public async Task<IActionResult> DeleteClub([FromRoute] int clubId) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (clubId < 0) {
                return BadRequest(ModelState);
            }

            if (!await _clubRepository.ClubExists(clubId)) {
                return BadRequest("Club does not exists");
            }

            var club = await _clubRepository.GetClubByIdAsNoTracking(clubId);
            if (!await _clubRepository.DeleteClub(club)) {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
