using PeakBaggerAPI.Models;

namespace PeakBaggerAPI.Data
{
    public interface IBaggedRepo
    {
        bool SaveChanges();
        IEnumerable<Bagged> GetBagged();
        Bagged GetBaggedById(int id);

        void CreateBagged(Bagged bagged);
        void UpdateBagged(Bagged bagged);
        void DeleteBagged(Bagged bagged);
    }
}
