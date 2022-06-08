using System.Collections.Generic;
using System.Threading.Tasks;
using ICABAPI.Models;
using static ICABAPI.Data.MarksRepository;

namespace ICABAPI.Interfaces
{
    public interface IMarks
    {
        Task<MarksModel11> GetPreviewOfSubjectWiseMarksForMultipleMarksEditFromMarksAllotAsync(List<MarksAllot> input, decimal? targetNumberBelow, int changeType, decimal? graceAmount, int? refNo);
        Task<List<MarksAllot>> GetSubjectWiseMarksForMultipleMarksEditFromMarksAllotAsync(MarksModel5 input);
        Task<bool> UpdateSingleMarksWithGraceAsync(MarksModel8 input);
        Task<List<MarksAllot>> GetSubjectWiseMarksForSingleMarksEditFromMarksAllotAsync(MarksModel7 input);
        Task<List<MarksModel4>> GetAllSubjectWiseMarksFromMarksAllotAsync(MarksModel5 input);
        Task<List<MarksModel4>> GetSubjectWiseMarksFromMarksAllotAsync(MarksModel2 input);
        Task<List<MarksModel4>> GetSubjectWiseMarksFromBarcodeAllotAsync(MarksModel2 input);
        Task<bool> CreateMarksAsync(MarksModel3 input);
        Task<bool> UpdateMarksAsync(MarksModel3 input);
    }
}