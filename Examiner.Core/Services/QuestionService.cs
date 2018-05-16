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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddQuestionAsync(QuestionDTO question)
        {
            if (question == null)
                throw new ArgumentNullException("Given question argument is null");

            Question questionToAdd = await _repository.GetAsync(question.QuestionId);
            if (questionToAdd != null)
                throw new ArgumentException("Question with given id already exists");

            questionToAdd = _mapper.Map<QuestionDTO, Question>(question);
            await _repository.AddAsync(questionToAdd);
        }

        public async Task DeleteQuestionAsync(Guid questionId)
        {
            Question questionToDelete = await _repository.GetAsync(questionId);
            if (questionToDelete == null)
                throw new ArgumentException("Question with given id does not exists");

            await _repository.DeleteAsync(questionToDelete);
        }

        public async Task<QuestionDTO> GetQuestionAsync(Guid questionId)
        {
            Question question = await _repository.GetAsync(questionId);

            return _mapper.Map<Question, QuestionDTO>(question);
        }

        public async Task<IEnumerable<QuestionDTO>> GetUserQuestionsAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("Given userId cannot be null");

            IEnumerable<Question> questions = await _repository.GetAllForUserAsync(userId);

            return _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(questions);
        }
    }
}
