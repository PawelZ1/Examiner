using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Repositories
{
    public interface ITestRepository
    {
        Task AddAsync(Test test);
        Task<Test> GetAsync(Guid id);
        Task UpdateAsync(Test test);
        Task DeleteAsync(Test test);
    }
}
