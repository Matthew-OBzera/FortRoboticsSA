namespace FortRoboticsSA.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public  byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 
        public List<SubwayStation> FreqSubwayStations { get; set; }
    }
}
