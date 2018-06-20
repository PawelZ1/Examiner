using AutoMapper;
using Examiner.Core.DomainModels;
using Examiner.Core.DTOs;
using Examiner.Core.Interfaces.Repositories;
using Examiner.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task AddAnswerAsync(AnswerDTO answerDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<AnswerDTO> GetAnswerAsync(Guid id)
        {
            Answer answer = await _answerRepository.GetAsync(id);

            return _mapper.Map<Answer, AnswerDTO>(answer);
        }

        public async Task RemoveAnswerAsync(Guid id)
        {
            Answer answer = await _answerRepository.GetAsync(id);
            if (answer == null)
                throw new ArgumentException("Answer with given id does not exists");

            await _answerRepository.DeleteAsync(answer);
        }
    }
}
