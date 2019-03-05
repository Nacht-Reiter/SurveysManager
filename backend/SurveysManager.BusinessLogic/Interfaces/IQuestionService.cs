using SurveysManager.Common.DTOs;
using SurveysManager.DataAccess.Entities;

namespace SurveysManager.BusinessLogic.Interfaces
{
    public interface IQuestionService : ICRUDService<Question, QuestionDTO>
    {
    }
}
