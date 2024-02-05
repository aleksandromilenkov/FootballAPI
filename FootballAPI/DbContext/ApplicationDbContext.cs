using FootballAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballAPI.ApplicationDBContext {
    public class ApplicationDbContext : IdentityDbContext<AppUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Footballer>()
       .HasOne(e => e.Country)
        .WithMany(e => e.Footballers)
        .HasForeignKey(e => e.CountryId)
        .IsRequired(false);
            builder.Entity<Footballer>()
      .HasOne(e => e.Club)
       .WithMany(e => e.Footballers)
       .HasForeignKey(e => e.ClubId)
       .IsRequired(false);
            builder.Entity<Club>()
       .HasOne(e => e.Country)
        .WithMany(e => e.Clubs)
        .HasForeignKey(e => e.CountryId)
        .IsRequired(false);
            builder.Entity<Country>().HasData(new Country { Id = 1, Name = "England", Continent = Enums.Continent.Europe, WcWon = 1 });
            builder.Entity<Club>().HasData(new Club { Id = 1, Name = "Chelsea", League = Enums.League.PremierLeague, CountryId = 1 });
            builder.Entity<Footballer>().HasData(new Footballer { Id = 1, FirstName = "Cole", LastName = "Palmer", Age = 20, Position = Enums.Position.Midfielder, CountryId = 1, ClubId = 1 });
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole{
                    Name="User",
                    NormalizedName="USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
