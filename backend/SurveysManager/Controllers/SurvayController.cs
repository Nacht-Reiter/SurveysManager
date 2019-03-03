using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveysManager.BusinessLogic.Interfaces;
using SurveysManager.Common.DTOs;

namespace SurveysManager.Controllers
{
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService service;

        public SurveyController(ISurveyService service)
        {
            this.service = service;
        }

        // GET: Surveys
        [HttpGet("survays")]
        public async Task<IActionResult> GetAllSurveys()
        {
            var survey = await service.GetAllPlateAsync();
            return survey == null ? NotFound() as IActionResult : Ok(survey);
        }

        // GET: Survey/5
        [HttpGet("[controller]/{id}", Name = "GetSurvey")]
        public async Task<IActionResult> GetSurvey(int id)
        {
            var survey = await service.GetAsync(id);
            return survey == null ? NotFound() as IActionResult : Ok(survey);
        }

        // POST: Survey
        [HttpPost("[controller]")]
        public async Task<IActionResult> AddSurvey([FromBody] SurveyDTO survey)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var result = await service.AddAsync(survey);
            return result != null ? Ok(result) as IActionResult : StatusCode(400);
        }

        // PUT: Survey/5
        [HttpPut("[controller]/{id}")]
        public async Task<IActionResult> ChangeSurvey(int id, [FromBody] SurveyDTO survey)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, survey);
            return result == null ? Ok(result) as IActionResult : StatusCode(400);
        }

        // DELETE: Survey/5
        [HttpDelete("[controller]/{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
