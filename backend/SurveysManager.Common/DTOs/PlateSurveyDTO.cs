using System;


namespace SurveysManager.Common.DTOs
{
    //Plate Survey model for dashboard
    public class PlateSurveyDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
    }
}
