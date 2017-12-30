using FoodDataService.Controllers;
using FoodDataService.Data;
using FoodDataService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FoodDataService.Tests.Controllers
{
    public class FoodControllerTests : IClassFixture<ConfigurationFixture>
    {
        private readonly MockRepository _mocks;
        private readonly FoodController _controller;
        private readonly Mock<FoodDataRepository> _data;

        public FoodControllerTests()
        {
            _mocks = new MockRepository(MockBehavior.Default);
            _data = _mocks.Create<FoodDataRepository>();

            _controller = new FoodController();
        }

        [Fact]
        public void Description_BadNdbNo_ReturnsNotFound()
        {
            var ndbNo = "00000";
            _data.Setup(x => x.GetFoodDescriptionByNdbNo(It.IsAny<string>())).Returns((FoodDescription) null);

            var result = _controller.Description(ndbNo) as NotFoundResult;

            Assert.NotNull(result);
            _mocks.VerifyAll();
        }
    }
}
