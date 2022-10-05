namespace FortRoboticsSA.Models
{
    public class SubwayStation
    {
        public int SubwayStationId { get; set; }
        public string SubwayStationName { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Line { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public List<User> Users { get; set; }
    }
}
