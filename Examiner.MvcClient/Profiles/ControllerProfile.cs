using AutoMapper;
using Examiner.Core.DTOs;
using Examiner.MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examiner.MvcClient.Profiles
{
    public class ControllerProfile : Profile
    {
        public ControllerProfile()
        {
            CreateMap<QuestionDTO, QuestionForListViewModel>().ForMember(dest => dest.NumberOfAnswers, 
                s => s.MapFrom(source => source.AnswerDTOs.Count));
            CreateMap<QuestionDTO, QuestionViewModel>().ForMember(dest => dest.Answers, s => s.MapFrom(source => source.AnswerDTOs));
            CreateMap<QuestionViewModel, QuestionDTO>();
            CreateMap<AnswerDTO, AnswerViewModel>();
        }
    }
}