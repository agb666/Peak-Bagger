// using PeakBaggerAPI.Models;

// namespace PeakBaggerAPI.Data 
// {
//     public class MockPeakRepo : IPeakRepo
//     {
//         public void CreatePeak(Peak peak)
//         {
//             throw new NotImplementedException();
//         }

//         public void DeletePeak(Peak peak)
//         {
//             throw new NotImplementedException();
//         }

//         public Peak GetPeakById(int id)
//         {
//          return new Peak{Id=0, Name="Big Hill", Height="101m", LoactionRefernce="OutSide", Description="Its a Hill", AreaId=0, Tag=0};
//         }

//         public IEnumerable<Peak> GetPeaks()
//         {
//            var peaks = new List<Peak>
//            {
//                 new Peak{Id=0, Name="Big Hill", Height="101m", LoactionRefernce="OutSide", Description="Its a Hill", AreaId=0, Tag=0},
//                 new Peak{Id=0, Name="Big Hill", Height="101m", LoactionRefernce="OutSide", Description="Its a Hill", AreaId=0, Tag=0},
//                 new Peak{Id=0, Name="Big Hill", Height="101m", LoactionRefernce="OutSide", Description="Its a Hill", AreaId=0, Tag=0}
//            };
//         return peaks;
//         }

//         public bool SaveChanges()
//         {
//             throw new NotImplementedException();
//         }

//         public void UpdatePeak(Peak peak)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }