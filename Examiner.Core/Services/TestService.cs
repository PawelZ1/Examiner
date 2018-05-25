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
    public class TestService : ITestService
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddTestAsync(TestDTO test)
        {
            if (test == null)
                throw new ArgumentNullException("Given test argument is null");

            Test testToAdd = await _repository.GetAsync(test.TestId);
            if (testToAdd != null)
                throw new ArgumentException("Test with given id already exists");

            testToAdd = _mapper.Map<TestDTO, Test>(test);
            await _repository.AddAsync(testToAdd);
        }

        public async Task DeleteTestAsync(Guid testId)
        {
            Test testToRemove = await _repository.GetAsync(testId);
            if (testToRemove == null)
                throw new ArgumentException("Test with given id does not exists");

            await _repository.DeleteAsync(testToRemove);
        }

        public Task<IEnumerable<TestDTO>> GetCategoryTestsAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<TestDTO> GetTestAsync(Guid testId)
        {
            Test test = await _repository.GetAsync(testId);

            return _mapper.Map<Test, TestDTO>(test);
        }
    }
}
