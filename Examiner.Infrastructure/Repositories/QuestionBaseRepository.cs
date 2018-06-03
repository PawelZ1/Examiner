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
    public class QuestionBaseRepository : IQuestionBaseRepository
    {
        private readonly ExaminerDBContext _context;

        public QuestionBaseRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(QuestionBase questionBase)
        {
            _context.QuestionBases.Add(questionBase);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(QuestionBase questionBase)
        {
            _context.QuestionBases.Remove(questionBase);
            await _context.SaveChangesAsync();
        }

        public async Task<QuestionBase> GetAsync(Guid id)
        {
            return await _context.QuestionBases.SingleOrDefaultAsync(p => p.QuestionBaseId == id);
        }

        public async Task UpdateAsync(QuestionBase questionBase)
        {
            _context.Entry(questionBase).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
