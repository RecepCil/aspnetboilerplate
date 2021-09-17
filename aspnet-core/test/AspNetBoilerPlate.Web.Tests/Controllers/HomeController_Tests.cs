using System.Threading.Tasks;
using AspNetBoilerPlate.Models.TokenAuth;
using AspNetBoilerPlate.Web.Controllers;
using Shouldly;
using Xunit;

namespace AspNetBoilerPlate.Web.Tests.Controllers
{
    public class HomeController_Tests: AspNetBoilerPlateWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}