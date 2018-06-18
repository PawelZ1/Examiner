using Examiner.Core.DomainModels;
using Examiner.Core.Interfaces.Repositories;
using Examiner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Infrastructure.Repositories
{
    public class TestComponentRepository : ITestComponentRepository
    {
        private readonly ExaminerDBContext _context;

        public TestComponentRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TestComponent testComponent)
        {
            _context.TestComponents.Add(testComponent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TestComponent testComponent)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TestComponent testComponent)
        {
            throw new NotImplementedException();
        }
    }
}
