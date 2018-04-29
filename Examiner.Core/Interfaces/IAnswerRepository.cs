using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface IAnswerRepository
    {
        Task AddAsync(Answer answer);
        Task<Answer> GetAsync(Guid answerId);
        Task<IEnumerable<Answer>> GetAllForQuestion(Guid questionId);
        Task UpdateAsync(Answer answer);
        Task DeleteAsync(Guid answerId);
    }
}
