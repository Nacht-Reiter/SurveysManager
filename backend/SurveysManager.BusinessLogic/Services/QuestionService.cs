using AutoMapper;
using SurveysManager.BusinessLogic.Interfaces;
using SurveysManager.Common.DTOs;
using SurveysManager.DataAccess.Entities;
using SurveysManager.DataAccess.Repository;

namespace SurveysManager.BusinessLogic.Services
{
    public class QuestionService : CRUDService<Question, QuestionDTO>, IQuestionService
    {
        public QuestionService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }
    }
}
