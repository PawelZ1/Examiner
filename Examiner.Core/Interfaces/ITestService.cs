using Examiner.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces
{
    public interface ITestService
    {
        Task AddTestAsync(TestDTO test);
        Task<TestDTO> GetTestAsync(Guid testId);
        Task<IEnumerable<TestDTO>> GetCategoryTestsAsync(Guid categoryId);
        Task DeleteTestAsync(Guid testId);
    }
}
