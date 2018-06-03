using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Repositories
{
    public interface ITestBaseRepository
    {
        Task AddAsync(TestBase testBase);
        Task<TestBase> GetAsync(Guid id);
        Task UpdateAsync(TestBase testBase);
        Task DeleteAsync(TestBase testBase);
    }
}
