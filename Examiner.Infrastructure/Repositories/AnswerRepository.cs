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

        public Task UpdateAsync(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
