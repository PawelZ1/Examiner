using AutoMapper;
using Examiner.Core.DomainModels;
using Examiner.Core.DTOs;
using Examiner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _repository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAnswerAsync(AnswerDTO answer)
        {
            if (answer == null)
                throw new ArgumentNullException("Given answer argument is null");

            Answer answerToAdd = await _repository.GetAsync(answer.AnswerId);
            if (answerToAdd != null)
                throw new ArgumentException("Answer with given id already exists");

            answerToAdd = _mapper.Map<AnswerDTO, Answer>(answer);
            await _repository.AddAsync(answerToAdd);
        }

        public async Task DeleteAnswerAsync(Guid answerId)
        {
            Answer answerToDelete = await _repository.GetAsync(answerId);
            if (answerToDelete == null)
                throw new ArgumentException("Answer with given id does not exists");

            await _repository.DeleteAsync(answerToDelete);
        }

        public async Task<AnswerDTO> GetAnswerAsync(Guid answerId)
        {
            Answer answer = await _repository.GetAsync(answerId);

            return _mapper.Map<Answer, AnswerDTO>(answer);
        }

        public async Task<IEnumerable<AnswerDTO>> GetQuestionAnswersAsync(Guid questionId)
        {
            IEnumerable<Answer> answers = await _repository.GetAllForQuestion(questionId);

            return _mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerDTO>>(answers);
        }
    }
}
