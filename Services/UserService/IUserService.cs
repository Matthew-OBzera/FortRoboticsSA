using FortRoboticsSA.DTOs.SubwayStations;
using FortRoboticsSA.Models;

namespace FortRoboticsSA.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetSubwayStationDTO>>> AddFreqUsedSubwayStation(int subwayStationId);
        Task<ServiceResponse<List<GetSubwayStationDTO>>> RemoveFreqUsedSubwayStation(int subwayStationId);
        Task<ServiceResponse<List<GetSubwayStationDTO>>> GetFreqUsedSubwayStation();
    }
}
