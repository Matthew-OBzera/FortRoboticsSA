using FortRoboticsSA.Models;
using Microsoft.VisualBasic.FileIO;

namespace FortRoboticsSA.Data
{
    internal class DbInitializer
    {
        internal static void Initialize(DataContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Subways.Any()) return;

            var subways = new List<SubwayStation>();
            var path = Environment.CurrentDirectory + "/Assests/subways.csv";
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.ReadLine(); //skip header
                while (!parser.EndOfData)
                {
                    try 
                    { 
                        //Process row
                        string[] fields = parser.ReadFields();
                        int id = Int32.Parse(fields[1]);
                        string name = fields[2];
                        string[] latlon = fields[3].Split();
                        string lat = latlon[1].Substring(1, latlon[1].Length - 1);
                        double la = double.Parse(lat);
                        string lon = latlon[2].Substring(0, latlon[1].Length - 2);
                        double lo = double.Parse(lon);
                        string line = fields[4];
                        string notes = fields[5];
                        var newSubway = new SubwayStation();
                        //newSubway.SubwayStationId = id;
                        newSubway.SubwayStationName = name;
                        newSubway.Longitude = lo;
                        newSubway.Latitude = la;
                        newSubway.Notes = notes;
                        newSubway.Line = line;
                        subways.Add(newSubway);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    
                }
            }

            foreach (var subway in subways)
                dbContext.Subways.Add(subway);

            dbContext.SaveChanges();
        }
    }
}
