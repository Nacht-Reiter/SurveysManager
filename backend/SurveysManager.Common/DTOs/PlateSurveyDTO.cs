using System;


namespace SurveysManager.Common.DTOs
{
    public class PlateSurveyDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
    }
}
