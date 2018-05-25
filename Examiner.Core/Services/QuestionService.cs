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

        public Task<IEnumerable<QuestionDTO>> GetCategoryQuestionsAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<QuestionDTO> GetQuestionAsync(Guid questionId)
        {
            Question question = await _repository.GetAsync(questionId);

            return _mapper.Map<Question, QuestionDTO>(question);
        }
    }
}
