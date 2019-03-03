using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SurveysManager.BusinessLogic.Interfaces;
using SurveysManager.Common.DTOs;

namespace QuestionsManager.Controllers
{
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService service;

        public QuestionController(IQuestionService service)
        {
            this.service = service;
        }

        // GET: Questions
        [HttpGet("survays")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var question = await service.GetAllAsync();
            return question == null ? NotFound() as IActionResult : Ok(question);
        }

        // GET: Question/5
        [HttpGet("[controller]/{id}", Name = "GetQuestion")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var question = await service.GetAsync(id);
            return question == null ? NotFound() as IActionResult : Ok(question);
        }

        // POST: Question
        [HttpPost("[controller]")]
        public async Task<IActionResult> AddQuestion([FromBody] QuestionDTO question)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var result = await service.AddAsync(question);
            return result != null ? Ok(result) as IActionResult : StatusCode(400);
        }

        // PUT: Question/5
        [HttpPut("[controller]/{id}")]
        public async Task<IActionResult> ChangeQuestion(int id, [FromBody] QuestionDTO question)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, question);
            return result == null ? Ok(result) as IActionResult : StatusCode(400);
        }

        // DELETE: Question/5
        [HttpDelete("[controller]/{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}