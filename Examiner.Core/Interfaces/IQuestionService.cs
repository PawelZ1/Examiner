using Examiner.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(QuestionDTO question);
        Task<QuestionDTO> GetQuestionAsync(Guid questionId);
        Task<IEnumerable<QuestionDTO>> GetUserQuestionsAsync(string userId);
        Task DeleteQuestionAsync(Guid questionId);
    }
}
