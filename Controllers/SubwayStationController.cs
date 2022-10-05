using Microsoft.AspNetCore.Mvc;
using FortRoboticsSA.Models;
using FortRoboticsSA.Services.SubwayStationService;
using FortRoboticsSA.DTOs.SubwayStations;
using Microsoft.AspNetCore.Authorization;

namespace FortRoboticsSA.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SubwayStationController : ControllerBase
    {
        private readonly ISubwayStationService _subwayStationService;

        public SubwayStationController(ISubwayStationService subwayStationService)
        {
            _subwayStationService = subwayStationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<ServiceResponse<List<GetSubwayStationDTO>>>> GetAllSubwayStations()
        {
            return Ok(await _subwayStationService.GetAllSubwayStations());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSubwayStationDTO>>> Get(int id)
        {
            return Ok(await _subwayStationService.GetSubwayStation(id));
        }

        [HttpGet("distance")]
        public async Task<ActionResult<ServiceResponse<GetSubwayStationDTO>>> GetDistance(int subwayId1, int subwayId2)
        {
            return Ok(await _subwayStationService.CalculateDistanceToSubway(subwayId1, subwayId2));
        }

    }
}
