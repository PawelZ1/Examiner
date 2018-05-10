using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface IQuestionRepository
    {
        Task AddAsync(Question question);
        Task<Question> GetAsync(Guid questionId);
        Task<IEnumerable<Question>> GetAll();
        Task<IEnumerable<Question>> GetAllForUserAsync(string userId);
        Task UpdateAsync(Question question);
        Task DeleteAsync(Question question);
    }
}
