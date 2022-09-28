using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class MockCountryRepo: ICountryRepo
    {
        public Country GetCountryById(int id)
        {
         return  new Country {Id=1, Name = "England"};
        }

        public IEnumerable<Country> GetCountries()
        {
           var countries = new List<Country>
           {
                    new Country {Id=1, Name = "England"},
                    new Country {Id=2, Name = "Scotland"},
                    new Country {Id=3, Name = "Wales"},
                    new Country {Id=4, Name = "Northen Ireland"}
           };
        return countries;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public void UpdateCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public void DeleteCountry(Country country)
        {
            throw new NotImplementedException();
        }
    }
}