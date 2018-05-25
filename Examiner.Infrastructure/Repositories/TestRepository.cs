using Examiner.Core.DomainModels;
using Examiner.Core.Interfaces;
using Examiner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Infrastructure.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ExaminerDBContext _context;

        public TestRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Test test)
        {
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Test>> GetAllForCategoryAsync(Guid categoryId)
        {
            return await _context.Tests.Where(p => p.TestCategoryId == categoryId).ToListAsync();
        }


        public async Task<Test> GetAsync(Guid testId)
        {
            return await _context.Tests.SingleOrDefaultAsync(p => p.TestId == testId);
        }

        public async Task UpdateAsync(Test test)
        {
            _context.Entry(test).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
