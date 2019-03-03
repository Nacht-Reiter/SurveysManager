using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveysManager.DataAccess.Entities
{
    public class Question : Entity
    {
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string Comment { get; set; }
        public virtual IEnumerable<Answer> Answers { get; set; }

        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }
        public int? SurveyId { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}
