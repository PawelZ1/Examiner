using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface ITestCategoryRepository
    {
        Task AddAsync(TestCategory testCategory);
        Task<TestCategory> GetAsync(Guid testCategoryId);
        Task<IEnumerable<TestCategory>> GetAllForUserAsync(string userId);
        Task UpdateAsync(TestCategory testCategory);
        Task DeleteAsync(TestCategory testCategory);
    }
}
