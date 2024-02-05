using AutoMapper;
using FootballAPI.DTO.ClubsDTOs;
using FootballAPI.DTO.CountrysDTOs;
using FootballAPI.DTO.FootballersDTOs;
using FootballAPI.Models;

namespace FootballAPI.Helper {
    public class MappingProfiles : Profile {
        public MappingProfiles() {
            CreateMap<Footballer, CreateFootballerDTO>().ReverseMap();
            CreateMap<Footballer, FootballerDTO>().ReverseMap();
            CreateMap<Club, ClubDTO>().ReverseMap();
            CreateMap<Club, CreateClubDTO>().ReverseMap();
            CreateMap<Club, UpdateClubDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
        }

    }
}
