using Examiner.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Interfaces.Services
{
    public interface IAnswerService
    {
        Task AddAnswerAsync(AnswerDTO answer);
    }
}
