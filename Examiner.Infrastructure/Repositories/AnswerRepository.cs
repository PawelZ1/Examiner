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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ExaminerDBContext _context;

        public AnswerRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Answer answer)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<Answer> GetAsync(Guid id)
        {
            return await _context.Answers.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
