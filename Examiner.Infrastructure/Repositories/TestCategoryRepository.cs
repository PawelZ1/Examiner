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
    public class TestCategoryRepository : ITestCategoryRepository
    {
        private readonly ExaminerDBContext _context;

        public TestCategoryRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TestCategory testCategory)
        {
            _context.TestCategories.Add(testCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TestCategory testCategory)
        {
            _context.TestCategories.Remove(testCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TestCategory>> GetAllForUserAsync(string userId)
        {
            return await _context.TestCategories.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<TestCategory> GetAsync(Guid testCategoryId)
        {
            return await _context.TestCategories.SingleOrDefaultAsync(p => p.TestCategoryId == testCategoryId);
        }

        public async Task UpdateAsync(TestCategory test)
        {
            _context.Entry(test).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
