using Moq;
using SurveysManager.BusinessLogic.Interfaces;
using SurveysManager.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SurveysManager.Common.DTOs;
using System.Linq;
using System;

namespace SurveysManager.Tests.WebApiTests
{
    public class SurveyControllerTests
    {
        [Fact]
        public async void GetAllSurveys_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAllPlateAsync()).Returns(FakeServicesMethods.GetAllSurveys());
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetAllSurveys();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetAllSurveys_ReturnsAllItems()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAllPlateAsync()).Returns(FakeServicesMethods.GetAllSurveys());
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetAllSurveys();
            var okResult = result as OkObjectResult;

            // Assert
            var items = Assert.IsAssignableFrom<IEnumerable<PlateSurveyDTO>>(okResult.Value);
            Assert.Equal(3, items.Count());
        }

        [Fact]
        public async void GetSurvey_UnknownId_ReturnsNotFoundResult()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetSurvey(0);
            var notFoundResult = result as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
        }

        [Fact]
        public async void GetSurvey_CorrectId_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetSurvey(1);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetSurvey_CorrectId_ReturnsRightItem()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetSurvey(1);
            var okResult = result as OkObjectResult;

            // Assert
            var item = Assert.IsAssignableFrom<SurveyDTO>(okResult.Value);
            Assert.Equal(1, (okResult.Value as SurveyDTO)?.Id);
        }

        [Fact]
        public async void DeleteSurvey_UnknownId_ReturnsBadRequestResult()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.DeleteAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.DeleteSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.DeleteSurvey(0);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
        }

        [Fact]
        public async void DeleteSurvey_CorrectId_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.DeleteAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.DeleteSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.DeleteSurvey(1);
            var okResult = result as OkResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void AddSurvey_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.AddAsync(It.IsAny<SurveyDTO>())).Returns((SurveyDTO s) => FakeServicesMethods.AddSurvey(s));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.AddSurvey(null);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async void AddSurvey_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.AddAsync(It.IsAny<SurveyDTO>())).Returns((SurveyDTO s) => FakeServicesMethods.AddSurvey(s));
            var controller = new SurveyController(mock.Object);

            // Act
            var survey = new SurveyDTO
            {
                Id = 1,
                Creator = "John",
                Date = DateTime.Now,
                Views = 3,
                Title = "Survey 1",
                Questions = new List<QuestionDTO>()
            };
            var result = await controller.AddSurvey(survey);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void AddSurvey_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.AddAsync(It.IsAny<SurveyDTO>())).Returns((SurveyDTO s) => FakeServicesMethods.AddSurvey(s));
            var controller = new SurveyController(mock.Object);

            // Act
            var survey = new SurveyDTO
            {
                Id = 1,
                Creator = "John",
                Date = DateTime.Now,
                Views = 3,
                Title = "Survey 1",
                Questions = new List<QuestionDTO>()
            };
            var result = await controller.AddSurvey(survey);
            var okResult = result as OkObjectResult;

            // Assert
            var item = Assert.IsAssignableFrom<SurveyDTO>(okResult.Value);
            Assert.Equal(1, (okResult.Value as SurveyDTO)?.Id);
        }

        [Fact]
        public async void ChangeSurvey_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<SurveyDTO>())).Returns((int id, SurveyDTO s) => FakeServicesMethods.ChangeSurvey(id, s));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.ChangeSurvey(1, null);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async void ChangeSurvey_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<SurveyDTO>())).Returns((int id, SurveyDTO s) => FakeServicesMethods.ChangeSurvey(id, s));
            var controller = new SurveyController(mock.Object);

            // Act
            var survey = new SurveyDTO
            {
                Id = 1,
                Creator = "John",
                Date = DateTime.Now,
                Views = 3,
                Title = "Survey 1",
                Questions = new List<QuestionDTO>()
            };
            var result = await controller.ChangeSurvey(1, survey);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void ChangeSurvey_ValidObjectPassed_ReturnedResponseHaUpdatedItem()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<SurveyDTO>())).Returns((int id, SurveyDTO s) => FakeServicesMethods.ChangeSurvey(id, s));
            var controller = new SurveyController(mock.Object);

            // Act
            var survey = new SurveyDTO
            {
                Id = 1,
                Creator = "John",
                Date = DateTime.Now,
                Views = 3,
                Title = "Survey 1",
                Questions = new List<QuestionDTO>()
            };
            var result = await controller.ChangeSurvey(1, survey);
            var okResult = result as OkObjectResult;

            // Assert
            var item = Assert.IsAssignableFrom<SurveyDTO>(okResult.Value);
            Assert.Equal(1, (okResult.Value as SurveyDTO)?.Id);
        }

        [Fact]
        public async void GetAllQuestions_UnknownId_ReturnsNotFoundResult()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAllQuestionsAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetAllQuestionsOfSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetAllQuestions(0);
            var notFoundResult = result as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
        }

        [Fact]
        public async void GetAllQuestions_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAllQuestionsAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetAllQuestionsOfSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetAllQuestions(1);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetAllQuestions_ReturnsAllItems()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.GetAllQuestionsAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetAllQuestionsOfSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.GetAllQuestions(1);
            var okResult = result as OkObjectResult;

            // Assert
            var items = Assert.IsAssignableFrom<IEnumerable<QuestionDTO>>(okResult.Value);
            Assert.Equal(3, items.Count());
        }

        [Fact]
        public async void AddOuestionToSurvey_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.AddQuestionToSurveyAsync(It.IsAny<int>(), It.IsAny<QuestionDTO>())).Returns((int id, QuestionDTO s) => FakeServicesMethods.AddQuestionToSurvey(id, s));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.AddOuestionToSurvey(1, null);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async void AddOuestionToSurvey_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.AddQuestionToSurveyAsync(It.IsAny<int>(), It.IsAny<QuestionDTO>())).Returns((int id, QuestionDTO s) => FakeServicesMethods.AddQuestionToSurvey(id, s));
            var controller = new SurveyController(mock.Object);

            // Act
            var question = new QuestionDTO
            {
                Id = 1,
                Title = "Question 1",
                QuestionText = "text",
                Comment = "",
                Answers = new List<AnswerDTO>()
            };
            var result = await controller.AddOuestionToSurvey(1, question);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void AddOuestionToSurvey_ValidObjectPassed_ReturnsAllItems()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.AddQuestionToSurveyAsync(It.IsAny<int>(), It.IsAny<QuestionDTO>())).Returns((int id, QuestionDTO s) => FakeServicesMethods.AddQuestionToSurvey(id, s));
            var controller = new SurveyController(mock.Object);

            // Act
            var question = new QuestionDTO
            {
                Id = 1,
                Title = "Question 1",
                QuestionText = "text",
                Comment = "",
                Answers = new List<AnswerDTO>()
            };
            var result = await controller.AddOuestionToSurvey(1, question);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(1, (okResult.Value as SurveyDTO)?.Questions.Count);
        }

        [Fact]
        public async void RemoveAllQuestionsAsync_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.RemoveAllQuestionsAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.DeleteQuestionFromSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.RemoveAllQuestions(0);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async void RemoveAllQuestions_ValidId_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ISurveyService>();
            mock.Setup(s => s.RemoveAllQuestionsAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.DeleteQuestionFromSurvey(id));
            var controller = new SurveyController(mock.Object);

            // Act
            var result = await controller.RemoveAllQuestions(1);
            var okResult = result as OkResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

    }
}
