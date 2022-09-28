using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
    public class MockTagRepo : ITagRepo
    {
        public void CreateTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(Tag ctag)
        {
            throw new NotImplementedException();
        }

        public Tag GetTagById(int id)
        {
               return new Tag {Id=1, Name = "Trail 100 2022"};
        }

        public IEnumerable<Tag> GetTags()
        {
              var countries = new List<Tag>
           {
                    new Tag {Id=1, Name = "Trail 100 2022"},
                    new Tag {Id=2, Name = "Favorate"},

           };
        return countries;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTag(Tag ctag)
        {
            throw new NotImplementedException();
        }
    }
}