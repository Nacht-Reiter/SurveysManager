using AutoMapper;
using SurveysManager.Common.DTOs;
using SurveysManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveysManager.Common
{
    public class AutoMapper
    {
        public static IMapper GetDefaultMapper()
        {
            return new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<SurveyDTO, Survey>()
                    .ForMember(e => e.Questions, opt => opt.MapFrom(dto => dto.Questions));
                cfg.CreateMap<Survey, SurveyDTO>()
                    .ForMember(dto => dto.Questions, opt => opt.MapFrom(e => e.Questions));

                cfg.CreateMap<Survey, PlateSurveyDTO>();

                cfg.CreateMap<QuestionDTO, Question>()
                    .ForMember(e => e.Answers, opt => opt.MapFrom(dto => dto.Answers))
                    .ForMember(e => e.Survey, opt => opt.MapFrom(dto => dto.Survey));
                cfg.CreateMap<Question, QuestionDTO>()
                    .ForMember(dto => dto.Answers, opt => opt.MapFrom(e => e.Answers))
                    .ForMember(dto => dto.Survey, opt => opt.MapFrom(e => e.Survey));

                cfg.CreateMap<AnswerDTO, Answer>();
                cfg.CreateMap<Answer, AnswerDTO>();


            }).CreateMapper();
        }
    }
}
