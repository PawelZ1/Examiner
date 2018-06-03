using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Repositories
{
    public interface ITestComponentRepository
    {
        Task AddAsync(TestComponent component);
        Task<TestComponent> GetAsync(Guid id);
        Task UpdateAsync(TestComponent component);
        Task DeleteAsync(TestComponent component);
    }
}
