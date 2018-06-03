using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Repositories
{
    public interface IQuestionBaseRepository
    {
        Task AddAsync(QuestionBase questionBase);
        Task<QuestionBase> GetAsync(Guid id);
        Task UpdateAsync(QuestionBase questionBase);
        Task DeleteAsync(QuestionBase questionBase);
    }
}
