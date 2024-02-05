using AutoMapper;
using FootballAPI.DTO;
using FootballAPI.Models;

namespace FootballAPI.Helper {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Footballer, CreateFootballerDTO>().ReverseMap();
            CreateMap<Footballer, FootballerDTO>().ReverseMap();
            CreateMap<Club, ClubDTO>().ReverseMap();
            CreateMap<Club, CreateClubDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
        }

    }
}
