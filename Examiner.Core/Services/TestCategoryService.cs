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
    public class TestCategoryService : ITestCategoryService
    {
        private readonly ITestCategoryRepository _repository;
        private readonly IMapper _mapper;

        public TestCategoryService(ITestCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddTestCategoryAsync(TestCategoryDTO testCategory)
        {
            if (testCategory == null)
                throw new ArgumentNullException("Given test category argument is null");

            TestCategory testCAtegoryToAdd = await _repository.GetAsync(testCategory.TestCategoryId);
            if (testCAtegoryToAdd != null)
                throw new ArgumentException("Test with given id already exists");

            testCAtegoryToAdd = _mapper.Map<TestCategoryDTO, TestCategory>(testCategory);
            await _repository.AddAsync(testCAtegoryToAdd);
        }

        public async Task DeleteTestCategoryAsync(Guid testId)
        {
            TestCategory testCategoryToRemove = await _repository.GetAsync(testId);
            if (testCategoryToRemove == null)
                throw new ArgumentException("Test category with given id does not exists");

            await _repository.DeleteAsync(testCategoryToRemove);
        }

        public async Task<TestCategoryDTO> GetTestCategoryAsync(Guid testCategoryId)
        {
            TestCategory testCategory = await _repository.GetAsync(testCategoryId);

            return _mapper.Map<TestCategory, TestCategoryDTO>(testCategory);
        }

        public async Task<IEnumerable<TestCategoryDTO>> GetUserTestCategoriesAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("UserId cannot be null");

            IEnumerable<TestCategory> testCategories = await _repository.GetAllForUserAsync(userId);

            return _mapper.Map<IEnumerable<TestCategory>, IEnumerable<TestCategoryDTO>>(testCategories);
        }
    }
}
