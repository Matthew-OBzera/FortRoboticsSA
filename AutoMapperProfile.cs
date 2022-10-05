using AutoMapper;
using FortRoboticsSA.DTOs.SubwayStations;
using FortRoboticsSA.Models;

namespace FortRoboticsSA
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SubwayStation, GetSubwayStationDTO>();
            CreateMap<AddSubwayStationDTO, SubwayStation>();
        }
    }
}
