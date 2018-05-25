using AutoMapper;
using Examiner.Core.DomainModels;
using Examiner.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Core.Profiles
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Test, TestDTO>();
            CreateMap<TestDTO, Test>();
            CreateMap<TestCategory, TestCategoryDTO>();
            CreateMap<TestCategoryDTO, TestCategory>();
            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionDTO, Question>();
            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, Answer>();
        }
    }
}
