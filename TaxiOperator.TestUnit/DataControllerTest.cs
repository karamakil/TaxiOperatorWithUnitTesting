using Microsoft.AspNetCore.Mvc;
using TaxiOperator.BLL.DAL;
using TaxiOperator.Controllers;
using Xunit;

namespace TaxiOperator.TestUnit
{
    public class DataControllerTest
    {
        DataController _controller;

        #region ctor

        public DataControllerTest()
        {
            _controller = new DataController();
        }

        #endregion

        [Fact]
        public void GetCustomerList_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetCustomerList() as ObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int testId = 1;
            // Act
            var okResult = _controller.GetById(testId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            int testId = 1;
            // Act
            var okResult = _controller.GetById(testId).Result as OkObjectResult;
            // Assert
            Assert.IsType<Customer>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Customer).Id);
        }

        [Fact]
        public void SaveCustomer_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Customer()
            {
                Name = "UnitTestingNewUser",
            };
            _controller.ModelState.AddModelError("Id", "Required");
            // Act
            var badResponse = _controller.SaveCustomer(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void SaveCustomer_ValidObjectPassed_ReturnsOkResult()
        {
            // Arrange
            Customer customer = new Customer()
            {
                Id = 0,
                Name = "HelloUnitTesting"
            };
            // Act
            var createdResponse = _controller.SaveCustomer(customer);
            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(createdResponse);
        }

        [Fact]
        public void DeleteCustomer_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            int existingId = 5;
            // Act
            var okResponse = _controller.DeleteCustomer(existingId);
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

    }
}
