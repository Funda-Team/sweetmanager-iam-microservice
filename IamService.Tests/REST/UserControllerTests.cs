using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IamService.Domain.Model.Queries;
using IamService.Domain.Services.Users;
using IamService.Domain.Services.Users.Admin;
using IamService.Domain.Services.Users.Owner;
using IamService.Domain.Services.Users.Worker;
using IamService.Interfaces.REST;
using IamService.Interfaces.REST.Resource.Authentication.User;
using IamService.Interfaces.REST.Transform.Authentication.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace IamService.Tests.REST
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IWorkerCommandService> _workerCommandServiceMock;
        private Mock<IAdminCommandService> _adminCommandServiceMock;
        private Mock<IOwnerCommandService> _ownerCommandServiceMock;
        private Mock<IAdminQueryService> _adminQueryServiceMock;
        private Mock<IWorkerQueryService> _workerQueryServiceMock;
        private Mock<IOwnerQueryService> _ownerQueryServiceMock;
        private UserController _controller;

        [SetUp]
        public void SetUp()
        {
            _workerCommandServiceMock = new Mock<IWorkerCommandService>();
            _adminCommandServiceMock = new Mock<IAdminCommandService>();
            _ownerCommandServiceMock = new Mock<IOwnerCommandService>();
            _adminQueryServiceMock = new Mock<IAdminQueryService>();
            _workerQueryServiceMock = new Mock<IWorkerQueryService>();
            _ownerQueryServiceMock = new Mock<IOwnerQueryService>();

            _controller = new UserController(
                _workerCommandServiceMock.Object,
                _adminCommandServiceMock.Object,
                _ownerCommandServiceMock.Object,
                _adminQueryServiceMock.Object,
                _workerQueryServiceMock.Object,
                _ownerQueryServiceMock.Object
            );
        }

        [Test]
        public async Task GetAdmins_ReturnsOk_WhenAdminsExist()
        {
            // Arrange
            var hotelId = 1;
            var admin = new IamService.Domain.Model.Aggregates.Admin
            {
                Id = 1,
                RolesId = 2,
                Username = "admin",
                Name = "Admin",
                Surname = "User",
                Email = "admin@example.com",
                Phone = 987654321, // Use an int value that fits in int32
                State = "Active"
            };
            var admins = new List<IamService.Domain.Model.Aggregates.Admin> { admin };
            _adminQueryServiceMock.Setup(x => x.Handle(It.IsAny<GetAllUsersQuery>()))
                .ReturnsAsync(admins);

            // Act
            var result = await _controller.GetAdmins(hotelId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
