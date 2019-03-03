using System;
using System.Collections.Generic;

namespace SurveysManager.DataAccess.Entities
{
    public class Survey : Entity
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }

        public virtual IList<Question> Questions { get; set; }

        public Survey()
        {
            Questions = new List<Question>();
        }
    }
}
