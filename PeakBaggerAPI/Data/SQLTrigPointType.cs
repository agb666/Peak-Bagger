using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class SQLTrigPointTypeRepo : ITrigPointTypeRepo
    {
        private readonly AppDbContext _context;

        public SQLTrigPointTypeRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTrigPointType(TrigPointType trigPointType)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrigPointType(TrigPointType trigPointType)
        {
            throw new NotImplementedException();
        }

        public TrigPointType GetTrigPointTypeById(int id)
        {
            return _context.TrigPointTypes.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TrigPointType> GetTrigPointTypes()
        {
             return _context.TrigPointTypes.ToList();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTrigPointType(TrigPointType trigPointType)
        {
            throw new NotImplementedException();
        }
    }
}