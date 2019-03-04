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

        public async static Task<IEnumerable<QuestionDTO>> GetAllQuestions()
        {
            return new List<QuestionDTO>
            {
                new QuestionDTO
                {
                    Id = 1,
                    Title = "Question 1",
                    QuestionText = "text",
                    Comment = "",
                    Answers = new List<AnswerDTO>()
                },
                new QuestionDTO
                {
                    Id = 2,
                    Title = "Question 2",
                    QuestionText = "text",
                    Comment = "",
                    Answers = new List<AnswerDTO>()
                },
                new QuestionDTO
                {
                    Id = 3,
                    Title = "Question 3",
                    QuestionText = "text",
                    Comment = "",
                    Answers = new List<AnswerDTO>()
                }
            };
        }

        public async static Task<QuestionDTO> GetQuestion(int id)
        {
            if (id == 1)
            {
                return new QuestionDTO
                {
                    Id = 1,
                    Title = "Question 1",
                    QuestionText = "text",
                    Comment = "",
                    Answers = new List<AnswerDTO>()
                };
            }
            return null;
        }

        public async static Task<bool> DeleteQuestion(int id)
        {
            return id == 1;
        }

        public async static Task<QuestionDTO> AddQuestion(QuestionDTO question)
        {
            return question;
        }

        public async static Task<QuestionDTO> ChangeQuestion(int id, QuestionDTO question)
        {
            if (question != null)
            {
                question.Id = id;
            }
            return question;
        }

        public async static Task<IEnumerable<QuestionDTO>> GetAllQuestionsOfSurvey(int id)
        {
            if(id == 1)
            {
                return new List<QuestionDTO>
                {
                    new QuestionDTO
                    {
                        Id = 1,
                        Title = "Question 1",
                        QuestionText = "text",
                        Comment = "",
                        Answers = new List<AnswerDTO>()
                    },
                    new QuestionDTO
                    {
                        Id = 2,
                        Title = "Question 2",
                        QuestionText = "text",
                        Comment = "",
                        Answers = new List<AnswerDTO>()
                    },
                    new QuestionDTO
                    {
                        Id = 3,
                        Title = "Question 3",
                        QuestionText = "text",
                        Comment = "",
                        Answers = new List<AnswerDTO>()
                    }
                };
            }
            return null;
        }

        public async static Task<SurveyDTO> AddQuestionToSurvey(int id, QuestionDTO question)
        {
            if(id == 1 && question != null)
            {
                return new SurveyDTO
                {
                    Id = 1,
                    Creator = "John",
                    Date = DateTime.Now,
                    Views = 3,
                    Title = "Survey 1",
                    Questions = new List<QuestionDTO>
                    {
                        question
                    }
                };
            }
            return null;
        }

        public async static Task<bool> DeleteQuestionFromSurvey(int id)
        {

            return id == 1;
        }
    }
}
