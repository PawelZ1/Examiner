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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExaminerDBContext _context;

        public QuestionRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Question question)
        {
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Question>> GetAllForCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Question> GetAsync(Guid questionId)
        {
            return await _context.Questions.SingleOrDefaultAsync(p => p.QuestionId == questionId);
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
