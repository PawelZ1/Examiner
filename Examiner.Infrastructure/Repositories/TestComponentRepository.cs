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
    public class TestComponentRepository : ITestComponentRepository
    {
        private readonly ExaminerDBContext _context;

        public TestComponentRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TestComponent component)
        {
            _context.TestComponents.Add(component);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TestComponent component)
        {
            _context.TestComponents.Remove(component);
            await _context.SaveChangesAsync();
        }

        public async Task<TestComponent> GetAsync(Guid id)
        {
            return await _context.TestComponents.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(TestComponent component)
        {
            _context.Entry(component).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
