using Microsoft.EntityFrameworkCore;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class SQLBaggedRepo : IBaggedRepo
    {
        private readonly AppDbContext _context;

        public SQLBaggedRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateBagged(Bagged bagged)
        {
             if(bagged == null)
            {
                throw new ArgumentNullException(nameof(bagged));            
            }
            _context.Add(bagged);
        }

        public void DeleteBagged(Bagged bagged)
        {
             if(bagged == null)
            {
                throw new ArgumentNullException(nameof(bagged));            
            }
            _context.Bagged.Remove(bagged);
        }

        public IEnumerable<Bagged> GetBagged()
        {
            var retVal =   _context.Bagged.Include(p => p.Peak).ThenInclude(a => a.Area).ThenInclude(c => c.Country).ToList();

           return retVal;
        }

        public Bagged GetBaggedById(int id)
        {
            var retVal = _context.Bagged.Include(p => p.Peak).ThenInclude(a => a.Area).ThenInclude(c => c.Country).FirstOrDefault(i => i.Id == id);
    
            return retVal;

        }

        public bool SaveChanges()
        {
             return(_context.SaveChanges() >= 0);
        }

        public void UpdateBagged(Bagged bagged)
        {
                   // Do Nothing
        }
    }
}