using AutoMapper;
using FortRoboticsSA.Data;
using FortRoboticsSA.DTOs.SubwayStations;
using FortRoboticsSA.Models;
using Microsoft.EntityFrameworkCore;
using FortRoboticsSA.Utils;

namespace FortRoboticsSA.Services.SubwayStationService
{
    public class SubwayStationService : ISubwayStationService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public SubwayStationService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<ServiceResponse<List<GetSubwayStationDTO>>> AddSubwayStation(AddSubwayStationDTO newSubwayStation)
        {
            var serviceResponse = new ServiceResponse<List<GetSubwayStationDTO>>();
            SubwayStation subwayStation = _mapper.Map<SubwayStation>(newSubwayStation);
            _context.Subways.Add(subwayStation);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Subways.Select(s => _mapper.Map<GetSubwayStationDTO>(s)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<double>> CalculateDistanceToSubway(int subwayId1, int subwayId2)
        {
            var serviceResponse = new ServiceResponse<double>();
            var subwayStation1 = _context.Subways.First(x => x.SubwayStationId == subwayId1);
            var subwayStation2 = _context.Subways.First(x => x.SubwayStationId == subwayId2);
            var distance = Distance.Calculate(subwayStation1.Latitude, subwayStation1.Longitude, subwayStation2.Latitude, subwayStation2.Longitude);
            serviceResponse.Data = distance;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSubwayStationDTO>>> GetAllSubwayStations()
        {
            var serviceResponse = new ServiceResponse<List<GetSubwayStationDTO>>();
            var subwayStations = await _context.Subways.ToListAsync();
            serviceResponse.Data = subwayStations.Select(s => _mapper.Map<GetSubwayStationDTO>(s)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSubwayStationDTO>> GetSubwayStation(int id)
        {
            var serviceResponse = new ServiceResponse<GetSubwayStationDTO>();
            var subwayStation = _context.Subways.First(x => x.SubwayStationId == id);
            serviceResponse.Data = _mapper.Map<GetSubwayStationDTO>(subwayStation);
            return serviceResponse;
        }

    }
}
