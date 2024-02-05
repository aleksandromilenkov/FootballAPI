using FootballAPI.ApplicationDBContext;
using FootballAPI.DTO;
using FootballAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FootballerController : ControllerBase {
        private readonly ApplicationDbContext context;

        public FootballerController(ApplicationDbContext context) {
            this.context = context;
        }

        [HttpPost]
        public IActionResult CreateFootballer([FromBody] FootballerDTO footballer) {
            var foot = new Footballer() {
                FirstName = footballer.FirstName,
                LastName = footballer.LastName,
                Age = footballer.Age,
            };
            context.Footballers.Add(foot);
            return Ok(context.Footballers.ToList());
        }
    }
}
