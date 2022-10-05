using FortRoboticsSA.Models;

namespace FortRoboticsSA.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(String username, string password);
        Task<bool> UserExists(string username);
    }
}
