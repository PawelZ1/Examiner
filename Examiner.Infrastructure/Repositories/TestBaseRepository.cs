using Examiner.Core.DomainModels;
using Examiner.Core.Interfaces.Repositories;
using Examiner.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Infrastructure.Repositories
{
    public class TestBaseRepository : ITestBaseRepository
    {
        private readonly ExaminerDBContext _context;

        public TestBaseRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TestBase testBase)
        {
            _context.TestBases.Add(testBase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TestBase testBase)
        {
            _context.TestBases.Remove(testBase);
            await _context.SaveChangesAsync();
        }

        public async Task<TestBase> GetAsync(Guid id)
        {
            return await _context.TestBases.SingleOrDefaultAsync(p => p.TestBaseId == id);
        }

        public async Task UpdateAsync(TestBase testBase)
        {
            _context.Entry(testBase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
