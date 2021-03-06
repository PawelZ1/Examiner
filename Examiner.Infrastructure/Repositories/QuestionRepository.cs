﻿using Examiner.Core.DomainModels;
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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExaminerDBContext _context;

        public QuestionRepository(ExaminerDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Question question)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Question question)
        {
             _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllForUserAsync(string userId)
        {
            return await _context.Questions.Include(p => p.Answers).Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Question> GetAsync(Guid id)
        {
            return await _context.Questions.Include(p => p.Answers).FirstAsync(p => p.QuestionId == id);
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
