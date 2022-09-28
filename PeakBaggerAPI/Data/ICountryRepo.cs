using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
public interface ICountryRepo
{
    bool SaveChanges();
    IEnumerable<Country> GetCountries();
    Country GetCountryById(int id);
    void CreateCountry(Country country);
    void UpdateCountry(Country country);
    void DeleteCountry(Country country);
}
}