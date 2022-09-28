using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
public interface IAreaRepo
{

    bool SaveChanges();
    IEnumerable<Area> GetAreas();
    Area  GetAreaById(int id);
    void CreateArea(Area area);
    void UpdateArea(Area area);
    void DeleteArea(Area area);


}
}