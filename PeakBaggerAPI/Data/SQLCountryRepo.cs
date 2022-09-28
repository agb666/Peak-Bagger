using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class SQLCountryRepo: ICountryRepo
    {

        private readonly AppDbContext _context;

        public SQLCountryRepo(AppDbContext context)
        {
            _context = context;
        }
        public Country GetCountryById(int id)
        {
          return _context.Countries.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Country> GetCountries()
        {
           return _context.Countries.ToList();
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

        public void CreateCountry(Country country)
        {
            if(country == null)
            {
                throw new ArgumentNullException(nameof(country));            
            }
            _context.Add(country);
        }

        public void UpdateCountry(Country country)
        {
            //Do Nothing
        }

        public void DeleteCountry(Country country)
        {
            if(country == null)
            {
                throw new ArgumentNullException(nameof(country));            
            }
            _context.Countries.Remove(country);
        }
    }
}