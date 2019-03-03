using SurveysManager.Common.DTOs;
using SurveysManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveysManager.BusinessLogic.Interfaces
{
    public interface ISurveyService : ICRUDService<Survey, SurveyDTO>
    {
        Task<IEnumerable<PlateSurveyDTO>> GetAllPlateAsync();
        Task<SurveyDTO> AddQuestionToSurveyAsync(int id, QuestionDTO question);
        Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync(int id);
        Task<bool> RemoveAllQuestionsAsync(int id);
    }
}
