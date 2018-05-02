﻿using Examiner.Core.DomainModels;
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

        public async Task DeleteAsync(Guid answerId)
        {
            Answer answerToDelete = await _context.Answers.SingleOrDefaultAsync(p => p.AnswerId == answerId);
            _context.Answers.Remove(answerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Answer>> GetAllForQuestion(Guid questionId)
        {
            return await _context.Answers.Where(p => p.QuestionId == questionId).ToListAsync();
        }

        public async Task<Answer> GetAsync(Guid answerId)
        {
            return await _context.Answers.SingleOrDefaultAsync(p => p.AnswerId == answerId);
        }

        public async Task UpdateAsync(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}