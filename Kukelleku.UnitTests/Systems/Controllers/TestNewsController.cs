using kukelleku.api.Controllers;
using Kukelleku.Dto.VrtNews;
using Kukelleku.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Kukelleku.UnitTests.Systems.Controllers
{
    public class TestNewsController
    {
        [Fact]
        public async Task OnSuccess_GetNewsArticles() { 
            // Arrange
            var newsService = new Mock<IVrtNewsService>();
            var newsController = new NewsController(newsService.Object);

            // Act
            var result = await newsController.GetVrt();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsType<FeedDto>(okResult.Value);
        }
    }
}
