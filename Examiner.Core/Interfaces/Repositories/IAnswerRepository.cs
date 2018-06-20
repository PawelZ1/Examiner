using Examiner.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Repositories
{
    public interface IAnswerRepository
    {
        Task UpdateAsync(Answer answer);
    }
}
