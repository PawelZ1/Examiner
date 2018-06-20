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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public Task AddAnswer(AnswerDTO answerDTO, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteQuestion(Guid id)
        {
            Question question = await _questionRepository.GetAsync(id);

            if (question == null)
                throw new ArgumentException("Question with given id does not exists");

            await _questionRepository.DeleteAsync(question);
        }

        public async Task<QuestionDTO> GetQuestion(Guid id)
        {
            Question question = await _questionRepository.GetAsync(id);

            return _mapper.Map<Question, QuestionDTO>(question);
        }

        public async Task<IEnumerable<QuestionDTO>> GetUserQuestions(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("UserId cannot be null or empty");

            IEnumerable<Question> questions = await _questionRepository.GetAllForUserAsync(userId);

            return _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionDTO>>(questions);
        }
    }
}
