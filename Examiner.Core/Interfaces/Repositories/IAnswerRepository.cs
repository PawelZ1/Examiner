using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        Task AddAsync(Answer answer);
        Task<Answer> GetAsync(Guid id);
        Task UpdateAsync(Answer answer);
        Task DeleteAsync(Answer answer);
    }
}
