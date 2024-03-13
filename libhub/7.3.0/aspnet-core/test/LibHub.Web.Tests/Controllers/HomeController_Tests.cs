using System.Threading.Tasks;
using LibHub.Models.TokenAuth;
using LibHub.Web.Controllers;
using Shouldly;
using Xunit;

namespace LibHub.Web.Tests.Controllers
{
    public class HomeController_Tests: LibHubWebTestBase
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