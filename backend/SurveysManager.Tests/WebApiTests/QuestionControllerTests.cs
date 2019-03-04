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
    public class QuestionControllerTests
    {
        [Fact]
        public async void GetAllQuestions_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.GetAllAsync()).Returns(FakeServicesMethods.GetAllQuestions());
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.GetAllQuestions();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetAllQuestions_ReturnsAllItems()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.GetAllAsync()).Returns(FakeServicesMethods.GetAllQuestions());
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.GetAllQuestions();
            var okResult = result as OkObjectResult;

            // Assert
            var items = Assert.IsAssignableFrom<IEnumerable<QuestionDTO>>(okResult.Value);
            Assert.Equal(3, items.Count());
        }

        [Fact]
        public async void GetQuestion_UnknownId_ReturnsNotFoundResult()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.GetAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetQuestion(id));
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.GetQuestion(0);
            var notFoundResult = result as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
        }

        [Fact]
        public async void GetQuestion_CorrectId_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.GetAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetQuestion(id));
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.GetQuestion(1);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void GetQuestion_CorrectId_ReturnsRightItem()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.GetAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.GetQuestion(id));
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.GetQuestion(1);
            var okResult = result as OkObjectResult;

            // Assert
            var item = Assert.IsAssignableFrom<QuestionDTO>(okResult.Value);
            Assert.Equal(1, (okResult.Value as QuestionDTO)?.Id);
        }

        [Fact]
        public async void DeleteQuestion_UnknownId_ReturnsBadRequestResult()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.DeleteAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.DeleteQuestion(id));
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.DeleteQuestion(0);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
        }

        [Fact]
        public async void DeleteQuestion_CorrectId_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.DeleteAsync(It.IsAny<int>())).Returns((int id) => FakeServicesMethods.DeleteQuestion(id));
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.DeleteQuestion(1);
            var okResult = result as OkResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void AddQuestion_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.AddAsync(It.IsAny<QuestionDTO>())).Returns((QuestionDTO s) => FakeServicesMethods.AddQuestion(s));
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.AddQuestion(null);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async void AddQuestion_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.AddAsync(It.IsAny<QuestionDTO>())).Returns((QuestionDTO s) => FakeServicesMethods.AddQuestion(s));
            var controller = new QuestionController(mock.Object);

            // Act
            var question = new QuestionDTO
            {
                Id = 1,
                Title = "Question 1",
                QuestionText = "text",
                Comment = "",
                Answers = new List<AnswerDTO>()
            };
            var result = await controller.AddQuestion(question);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void AddQuestion_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.AddAsync(It.IsAny<QuestionDTO>())).Returns((QuestionDTO s) => FakeServicesMethods.AddQuestion(s));
            var controller = new QuestionController(mock.Object);

            // Act
            var question = new QuestionDTO
            {
                Id = 1,
                Title = "Question 1",
                QuestionText = "text",
                Comment = "",
                Answers = new List<AnswerDTO>()
            };
            var result = await controller.AddQuestion(question);
            var okResult = result as OkObjectResult;

            // Assert
            var item = Assert.IsAssignableFrom<QuestionDTO>(okResult.Value);
            Assert.Equal(1, (okResult.Value as QuestionDTO)?.Id);
        }

        [Fact]
        public async void ChangeQuestion_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<QuestionDTO>())).Returns((int id, QuestionDTO s) => FakeServicesMethods.ChangeQuestion(id, s));
            var controller = new QuestionController(mock.Object);

            // Act
            var result = await controller.ChangeQuestion(1, null);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async void ChangeQuestion_ValidObjectPassed_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<QuestionDTO>())).Returns((int id, QuestionDTO s) => FakeServicesMethods.ChangeQuestion(id, s));
            var controller = new QuestionController(mock.Object);

            // Act
            var question = new QuestionDTO
            {
                Id = 1,
                Title = "Question 1",
                QuestionText = "text",
                Comment = "",
                Answers = new List<AnswerDTO>()
            };
            var result = await controller.ChangeQuestion(1, question);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void ChangeQuestion_ValidObjectPassed_ReturnedResponseHaUpdatedItem()
        {
            // Arrange
            var mock = new Mock<IQuestionService>();
            mock.Setup(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<QuestionDTO>())).Returns((int id, QuestionDTO s) => FakeServicesMethods.ChangeQuestion(id, s));
            var controller = new QuestionController(mock.Object);

            // Act
            var question = new QuestionDTO
            {
                Id = 1,
                Title = "Question 1",
                QuestionText = "text",
                Comment = "",
                Answers = new List<AnswerDTO>()
            };
            var result = await controller.ChangeQuestion(1, question);
            var okResult = result as OkObjectResult;

            // Assert
            var item = Assert.IsAssignableFrom<QuestionDTO>(okResult.Value);
            Assert.Equal(1, (okResult.Value as QuestionDTO)?.Id);
        }

    }
}
