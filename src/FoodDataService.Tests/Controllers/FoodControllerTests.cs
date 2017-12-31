using FoodDataService.Controllers.v1;
using FoodDataService.Data;
using FoodDataService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using FluentAssertions;

namespace FoodDataService.Tests.Controllers
{
    public class FoodControllerTests : IClassFixture<ConfigurationFixture>
    {
        private readonly MockRepository _mocks;
        private readonly FoodController _controller;
        private readonly Mock<FoodDataRepository> _data;
        private const string _ndbNo = "00000";

        public FoodControllerTests()
        {
            _mocks = new MockRepository(MockBehavior.Default);
            _data = _mocks.Create<FoodDataRepository>();

            _controller = new FoodController(_data.Object);
        }

        [Fact]
        public void Description_BadNdbNo_ReturnsNotFound()
        {
            _data.Setup(x => x.GetFoodDescriptionByNdbNo(It.IsAny<string>())).Returns((FoodDescriptionData) null);

            var result = _controller.GetFoodDescriptionByNdbNo(_ndbNo) as NotFoundResult;

            Assert.NotNull(result);
            _mocks.VerifyAll();
        }

        [Fact]
        public void Description_Success()
        {
            var validFoodDescriptionData = ValidFoodDescriptionData();
            _data.Setup(x => x.GetFoodDescriptionByNdbNo(It.IsAny<string>())).Returns(validFoodDescriptionData);

			var expected = new FoodDescriptionResponse
			{
			    ndb_no = validFoodDescriptionData.ndb_no,
			    cho_factor = validFoodDescriptionData.cho_factor,
			    comname = validFoodDescriptionData.comname,
			    fat_factor = validFoodDescriptionData.fat_factor,
			    fdgrp_cd = validFoodDescriptionData.fdgrp_cd,
			    long_desc = validFoodDescriptionData.long_desc,
			    manufacname = validFoodDescriptionData.manufacname,
			    n_factor = validFoodDescriptionData.n_factor,
			    pro_factor = validFoodDescriptionData.pro_factor,
			    ref_desc = validFoodDescriptionData.ref_desc,
			    sciname = validFoodDescriptionData.sciname,
			    shrt_desc = validFoodDescriptionData.shrt_desc,
			    survey = validFoodDescriptionData.survey
            };

	        var result = _controller.GetFoodDescriptionByNdbNo(_ndbNo) as OkObjectResult;
	        var actual = result?.Value as FoodDescriptionResponse;

			Assert.NotNull(result);
			actual.ShouldBeEquivalentTo(expected);
			_mocks.VerifyAll();
        }

	    private FoodDescriptionData ValidFoodDescriptionData()
	    {
			return new FoodDescriptionData
			{
				ndb_no = "00000",
				cho_factor = 2,
				comname = "Common Name",
				fat_factor = 4,
				fdgrp_cd = "1234",
				long_desc = "A super long description",
				manufacname = "Manufacturer's Name",
				n_factor = 5,
				pro_factor = 6,
				ref_desc = "A reference description",
				sciname = "A scientific name",
				shrt_desc = "A short description",
				survey = "y"
			};
	    }
    }
}
