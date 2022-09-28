using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data 
{
public interface ITagRepo
{
    bool SaveChanges();
    IEnumerable<Tag> GetTags();
    Tag GetTagById(int id);
    void CreateTag(Tag tag);
    void UpdateTag(Tag tag);
    void DeleteTag(Tag tag);
}
}