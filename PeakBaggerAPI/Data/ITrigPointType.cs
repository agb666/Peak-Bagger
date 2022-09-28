using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
public interface ITrigPointTypeRepo
{
    bool SaveChanges();
    IEnumerable<TrigPointType> GetTrigPointTypes();
    TrigPointType GetTrigPointTypeById(int id);
    void CreateTrigPointType(TrigPointType trigPointType);
    void UpdateTrigPointType(TrigPointType trigPointType);
    void DeleteTrigPointType(TrigPointType trigPointType);
}
}