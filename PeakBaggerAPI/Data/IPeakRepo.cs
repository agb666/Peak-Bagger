using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
public interface IPeakRepo
{
    bool SaveChanges();
    IEnumerable<Peak> GetPeaks();
    Peak  GetPeakById(int id);
    void CreatePeak(Peak peak);
    void UpdatePeak(Peak peak);
    void DeletePeak(Peak peak);
}
}