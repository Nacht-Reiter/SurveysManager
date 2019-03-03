using SurveysManager.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveysManager.Tests.WebApiTests
{
    public static class FakeServicesMethods
    {
        public async static Task<IEnumerable<PlateSurveyDTO>> GetAllSurveys()
        {
            return new List<PlateSurveyDTO>
            {
                new PlateSurveyDTO
                {
                    Id = 1,
                    Creator = "John",
                    Date = DateTime.Now,
                    Views = 3,
                    Title = "Survey 1"
                },
                new PlateSurveyDTO
                {
                    Id = 2,
                    Creator = "John",
                    Date = DateTime.Now,
                    Views = 4,
                    Title = "Survey 2"
                },
                new PlateSurveyDTO
                {
                    Id = 3,
                    Creator = "John",
                    Date = DateTime.Now,
                    Views = 3,
                    Title = "Survey 3"
                }
            };
        }

        public async static Task<SurveyDTO> GetSurvey(int id)
        {
            if(id == 1)
            {
                return new SurveyDTO
                {
                    Id = 1,
                    Creator = "John",
                    Date = DateTime.Now,
                    Views = 3,
                    Title = "Survey 1",
                    Questions = new List<QuestionDTO>()
                };
            }
            return null;
        }

        public async static Task<bool> DeleteSurvey(int id)
        {
            return id == 1;
        }

        public async static Task<SurveyDTO> AddSurvey(SurveyDTO survey)
        {
            return survey;
        }

        public async static Task<SurveyDTO> ChangeSurvey(int id, SurveyDTO survey)
        {
            if(survey != null)
            {
                survey.Id = id;
            }
            return survey;
        }
    }
}
