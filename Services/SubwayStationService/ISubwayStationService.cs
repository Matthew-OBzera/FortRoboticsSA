using FortRoboticsSA.DTOs.SubwayStations;
using FortRoboticsSA.Models;

namespace FortRoboticsSA.Services.SubwayStationService
{
    public interface ISubwayStationService
    {
        Task<ServiceResponse<List<GetSubwayStationDTO>>> GetAllSubwayStations();

        Task<ServiceResponse<GetSubwayStationDTO>> GetSubwayStation(int id);

        Task<ServiceResponse<List<GetSubwayStationDTO>>> AddSubwayStation(AddSubwayStationDTO subwayStation);
        Task<ServiceResponse<double>> CalculateDistanceToSubway(int subwayId1, int subwayId2);
    }
}
