using AutoMapper;
using HC.Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using HC.Template.Interface.ServiceModels;
using HC.Template.Infrastructure.ConfigModels;

namespace HC.Template.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TestObj, TestObjResponse>();
            CreateMap<AppSettings, ExampleResponse>();
        }
    }
}
