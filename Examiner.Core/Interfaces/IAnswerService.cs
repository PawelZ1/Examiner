using Examiner.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface IAnswerService
    {
        Task AddAnswerAsync(AnswerDTO answer);
        Task<AnswerDTO> GetAnswerAsync(Guid answerId);
        Task<IEnumerable<AnswerDTO>> GetUserAnswersAsync(string userId);
        Task DeleteAnswerAsync(Guid answerId);
    }
}
