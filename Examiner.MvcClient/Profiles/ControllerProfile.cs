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
            CreateMap<TestDTO, TestViewModel>();
        }
    }
}