using Examiner.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDTO>> GetUserQuestions(string userId);
        Task<QuestionDTO> GetQuestion(Guid id);
    }
}
