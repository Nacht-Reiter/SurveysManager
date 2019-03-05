using AutoMapper;
using SurveysManager.BusinessLogic.Interfaces;
using SurveysManager.Common.DTOs;
using SurveysManager.DataAccess.Entities;
using SurveysManager.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SurveysManager.BusinessLogic.Services
{
    public class SurveyService : CRUDService<Survey, SurveyDTO>, ISurveyService
    {
        public SurveyService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {

        }

        public override async Task<SurveyDTO> AddAsync(SurveyDTO item)
        {
            if(item != null)
            {
                item.Date = DateTime.Now; //Ensure, that Date is actual
                item.Views = 0;           //Ensure, that survey has no views
            }
            return await base.AddAsync(item);
        }

        public override async Task<SurveyDTO> GetAsync(int id) //Overrided for increasing views field
        {
            if (uow != null)
            {
                var item = await uow.Repository<Survey>().GetAsync(id);
                item.Views ++;
                var result = await uow.Repository<Survey>().Update(item);
                await uow.SaveAsync();
                return mapper.Map<SurveyDTO>(result);
            }
            return null;
        }

        public async Task<IEnumerable<PlateSurveyDTO>> GetAllPlateAsync() //GetAll for plate DTO
        {
            if (uow != null)
            {
                var item = await uow.Repository<Survey>().GetAllAsync();
                if (item != null)
                {
                    return mapper.Map<IEnumerable<PlateSurveyDTO>>(item);
                }
            }
            return null;
        }

        public async Task<SurveyDTO> AddQuestionToSurveyAsync(int id, QuestionDTO question)
        {
            var survey = await uow.Repository<Survey>().GetAsync(id);
            if(survey != null && question != null)
            {
                survey.Questions.Add(mapper.Map<Question>(question));
                await uow.Repository<Survey>().Update(survey);
                await uow.SaveAsync();
                return mapper.Map<SurveyDTO>(await uow.Repository<Survey>().GetAsync(id));
            }
            return null;
        }

        public async Task<IEnumerable<QuestionDTO>> GetAllQuestionsAsync(int id)
        {
            var survey = await uow.Repository<Survey>().GetAsync(id);
            if (survey != null)
            {
                return mapper.Map<IEnumerable<QuestionDTO>>(survey.Questions);
            }
            return null;
        }

        public async Task<bool> RemoveAllQuestionsAsync(int id)
        {
            var survey = await uow.Repository<Survey>().GetAsync(id);
            if (survey != null)
            {
                survey.Questions.Clear();
                await uow.Repository<Survey>().Update(survey);
                await uow.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
