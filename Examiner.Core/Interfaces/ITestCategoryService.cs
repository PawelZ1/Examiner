using Examiner.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface ITestCategoryService
    {
        Task AddTestCategoryAsync(TestCategoryDTO testCategory);
        Task<TestCategoryDTO> GetTestCategoryAsync(Guid testCategoryId);
        Task<IEnumerable<TestCategoryDTO>> GetUserTestCategoriesAsync(string userId);
        Task DeleteTestCategoryAsync(Guid testId);
    }
}
