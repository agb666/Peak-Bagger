using Microsoft.EntityFrameworkCore;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class SQLAreaRepo: IAreaRepo
    {

        private readonly AppDbContext _context;

        public SQLAreaRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateArea(Area area)
        {
            if(area == null)
            {
                throw new ArgumentNullException(nameof(area));            
            }
             _context.Add(area);
        }

        public void DeleteArea(Area area)
        {
            if(area == null)
            {
                throw new ArgumentNullException(nameof(area));            
            }
            _context.Areas.Remove(area);
        }

        public Area GetAreaById(int id)
        {
            return _context.Areas.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Area> GetAreas()
        {
            var retVal = _context.Areas.Include(c => c.Country).ToList();

            return retVal; 
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void UpdateArea(Area area)
        {
           // Do Nothing
        }
    }
}