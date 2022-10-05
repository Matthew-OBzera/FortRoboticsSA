using FortRoboticsSA.DTOs.SubwayStations;
using FortRoboticsSA.Models;
using FortRoboticsSA.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FortRoboticsSA.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("FreqSubway")]
        public async Task<ActionResult<ServiceResponse<List<GetSubwayStationDTO>>>> AddFreqUsedSubway(int subwayStationId)
        {
            return Ok(await _userService.AddFreqUsedSubwayStation(subwayStationId));
        }
        [HttpGet("FreqSubway")]
        public async Task<ActionResult<ServiceResponse<List<GetSubwayStationDTO>>>> GetFreqUsedSubway()
        {
            return Ok(await _userService.GetFreqUsedSubwayStation());
        }
        [HttpDelete("FreqSubway")]
        public async Task<ActionResult<ServiceResponse<List<GetSubwayStationDTO>>>> RemoveFreqUsedSubway(int subwayStationId)
        {
            return Ok(await _userService.RemoveFreqUsedSubwayStation(subwayStationId));
        }
    }
}
