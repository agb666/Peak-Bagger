using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class SQLTagRepo : ITagRepo
    {

          private readonly AppDbContext _context;

        public SQLTagRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTag(Tag tag)
        {
            if(tag == null)
            {
                throw new ArgumentNullException(nameof(tag));            
            }
             _context.Add(tag);
        }

        public void DeleteTag(Tag tag)
        {
            if(tag == null)
            {
                throw new ArgumentNullException(nameof(tag));            
            }
            _context.Tags.Remove(tag);
        }

        public Tag GetTagById(int id)
        {
              return _context.Tags.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Tag> GetTags()
        {
                 return _context.Tags.ToList();
        }

        public bool SaveChanges()
        {
             return(_context.SaveChanges() >= 0);
        }

        public void UpdateTag(Tag ctag)
        {
            // Do Nothing
        }
    }
}