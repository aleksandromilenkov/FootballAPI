
using FootballAPI.ApplicationDBContext;
using FootballAPI.Models;

namespace FootballAPI {
    public class Seed {
        private readonly ApplicationDbContext dataContext;
        public Seed(ApplicationDbContext context) {
            this.dataContext = context;
        }
        public void SeedDataContext() {
            if (!dataContext.Footballers.Any()) {
                var footballers = new List<Footballer>()
                {
                         new Footballer()
                        {
                             FirstName="Harry",
                             LastName = "Kane",
                             Age=30,
                             Country = new Country{Name="England", Continent=Enums.Continent.Europe, WcWon=1},
                             Club = new Club{Name="Bayern Munich", League = Enums.League.BundesLiga,}
                        },


                };
                dataContext.Footballers.AddRange(footballers);
                dataContext.SaveChanges();
            }
        }
    }
}
