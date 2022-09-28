using Microsoft.EntityFrameworkCore;
using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class SQLPeakRepo : IPeakRepo
    {
        private readonly AppDbContext _context;

        public SQLPeakRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePeak(Peak peak)
        {
            if(peak == null)
            {
                throw new ArgumentNullException(nameof(peak));            
            }
            _context.Add(peak);
        }

        public void DeletePeak(Peak peak)
        {
            if(peak == null)
            {
                throw new ArgumentNullException(nameof(peak));            
            }
            _context.Peaks.Remove(peak);
        }

        public Peak GetPeakById(int id)
        {
            return _context.Peaks.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Peak> GetPeaks()
        {
            var ret =  _context.Peaks.Include(a => a.Area).ThenInclude(c => c.Country).ToList();

            return ret;


        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void UpdatePeak(Peak peak)
        {
            //Do Nothing
        }
    }
}

