using Microsoft.AspNetCore.Mvc;
using MyWebService.Api.Controllers;

namespace MyWebService.Tests
{
    public class CalculatorControllerTests
    {
        private readonly CalculatorController _controller;

        public CalculatorControllerTests()
        {
            _controller = new CalculatorController();
        }

        [Fact]
        public void Add_ReturnsCorrectResult()
        {
            var result = _controller.Add(10, 5) as OkObjectResult;
            Assert.NotNull(result);

            var json = System.Text.Json.JsonSerializer.Serialize(result.Value);
            var data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, double>>(json);

            Assert.Equal(15, data["Result"]);

        }

        [Fact]
        public void Divide_ByZero_ReturnsBadRequest()
        {
            var result = _controller.Divide(10, 0) as BadRequestObjectResult;
            Assert.NotNull(result);
            Assert.Equal("Division by zero is not allowed.", result.Value);
        }
    }
}

