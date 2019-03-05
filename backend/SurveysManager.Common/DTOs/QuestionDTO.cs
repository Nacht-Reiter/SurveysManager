using System.Collections.Generic;

namespace SurveysManager.Common.DTOs
{
    public class QuestionDTO : BaseDTO
    {
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string Comment { get; set; }
        public IEnumerable<AnswerDTO> Answers { get; set; }

        public SurveyDTO Survey { get; set; }

        public QuestionDTO()
        {
            Answers = new List<AnswerDTO>();
        }
    }
}
