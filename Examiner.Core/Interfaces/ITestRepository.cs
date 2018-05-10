using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface ITestRepository
    {
        Task AddAsync(Test test);
        Task<Test> GetAsync(Guid testId);
        Task<IEnumerable<Test>> GetAll();
        Task<IEnumerable<Test>> GetAllForUserAsync(string userId);
        Task UpdateAsync(Test test);
        Task DeleteAsync(Test test);
    }
}
