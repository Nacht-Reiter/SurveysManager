using System;
using System.Collections.Generic;

namespace SurveysManager.Common.DTOs
{
    public class SurveyDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }

        public IList<QuestionDTO> Questions { get; set; }

        public SurveyDTO()
        {
            Questions = new List<QuestionDTO>();
        }
    }
}
