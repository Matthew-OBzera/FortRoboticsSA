using AutoMapper;
using FortRoboticsSA.Data;
using FortRoboticsSA.DTOs.SubwayStations;
using FortRoboticsSA.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FortRoboticsSA.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetSubwayStationDTO>>> AddFreqUsedSubwayStation(int subwayStationId)
        {
            var response = new ServiceResponse<List<GetSubwayStationDTO>>();
            try
            {
                var userId = GetUserId();
                var user = await _context.Users.Include(u=> u.FreqSubwayStations).FirstOrDefaultAsync(u => u.UserId == userId);

                if(user == null)
                {
                    response.Success = false;
                    response.Message = "User not found";
                    return response;
                }
                
                var subwayStation = await _context.Subways.FirstOrDefaultAsync(s => s.SubwayStationId == subwayStationId);

                if(subwayStation == null)
                {
                    response.Success = false;
                    response.Message = "Subway Station not found";
                    return response;
                }
                if(user.FreqSubwayStations.Contains(subwayStation))
                {
                    response.Success = false;
                    response.Message = "Subway Station already in frequently used subway stations";
                    return response;
                }
                user.FreqSubwayStations.Add(subwayStation);
                await _context.SaveChangesAsync();
                response.Data = user.FreqSubwayStations.Select(s => _mapper.Map<GetSubwayStationDTO>(s)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetSubwayStationDTO>>> GetFreqUsedSubwayStation()
        {
            var response = new ServiceResponse<List<GetSubwayStationDTO>>();
            try
            {
                var userId = GetUserId();
                var user = await _context.Users.Include(u => u.FreqSubwayStations).FirstOrDefaultAsync(u => u.UserId == userId);

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User not found";
                    return response;
                }
                response.Data = user.FreqSubwayStations.Select(s => _mapper.Map<GetSubwayStationDTO>(s)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetSubwayStationDTO>>> RemoveFreqUsedSubwayStation(int subwayStationId)
        {
            var response = new ServiceResponse<List<GetSubwayStationDTO>>();
            try
            {
                var userId = GetUserId();
                var user = await _context.Users.Include(u => u.FreqSubwayStations).FirstOrDefaultAsync(u => u.UserId == userId);

                if (user == null)
                {
                    response.Success = false;
                    response.Message = "User not found";
                    return response;
                }

                var subwayStation = await _context.Subways.FirstOrDefaultAsync(s => s.SubwayStationId == subwayStationId);

                if (subwayStation == null)
                {
                    response.Success = false;
                    response.Message = "Subway Station not found";
                    return response;
                }
                
                var found = user.FreqSubwayStations.Remove(subwayStation);
                if (!found)
                {
                    response.Success = false;
                    response.Message = "Subway Station not found in frequently used subway stations";
                }
                await _context.SaveChangesAsync();
                response.Data = user.FreqSubwayStations.Select(s => _mapper.Map<GetSubwayStationDTO>(s)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
