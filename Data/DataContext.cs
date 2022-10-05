using FortRoboticsSA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System.Reflection.Metadata.Ecma335;

namespace FortRoboticsSA.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
        
        public DbSet<SubwayStation> Subways { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
