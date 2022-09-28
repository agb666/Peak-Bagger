using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class MockAreaRepo: IAreaRepo
    {
        public void CreateArea(Area area)
        {
            throw new NotImplementedException();
        }

        public void DeleteArea(Area area)
        {
            throw new NotImplementedException();
        }

        public Area GetAreaById(int id)
        {
             return  new Area {Id=1, Name = "Peak District"};
        }

        public IEnumerable<Area> GetAreas()
        {
           var areas = new List<Area>
           {
                //    new Area {Id=1, Name = "Peak District", CountryID = 1 },
                //    new Area {Id=2, Name = "Lake District", CountryID = 1},
                //    new Area {Id=3, Name = "Northern Pennines", CountryID = 1},
                //    new Area {Id=4, Name = "Yorkshire Dales", CountryID = 1},
                //    new Area {Id=5, Name = "North York Mores", CountryID = 1},
                //    new Area {Id=6, Name = "Dartmore", CountryID = 1}
           };
        return areas;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateArea(Area area)
        {
            throw new NotImplementedException();
        }
    }
}