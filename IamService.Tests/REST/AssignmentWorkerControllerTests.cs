using System.Collections.Generic;
using System.Threading.Tasks;
using IamService.Domain.Model.Commands.Assignments;
using IamService.Domain.Model.Entities;
using IamService.Domain.Model.Queries;
using IamService.Domain.Services.Assignments;
using IamService.Interfaces.REST.Resource.Assignments;
using IamService.Interfaces.REST.Transform.Assignments;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using IamService.Interfaces.REST;
using SweetManagerWebService.IAM.Interfaces.REST;
using SweetManagerWebService.IAM.Interfaces.REST.Transform.Assignments;

namespace IamService.Tests.REST
{
    [TestFixture]
    public class AssignmentWorkerControllerTests
    {
        private Mock<IAssignmentWorkerCommandService> _commandServiceMock;
        private Mock<IAssignmentWorkerQueryService> _queryServiceMock;
        private AssignmentWorkerController _controller;

        [SetUp]
        public void SetUp()
        {
            _commandServiceMock = new Mock<IAssignmentWorkerCommandService>();
            _queryServiceMock = new Mock<IAssignmentWorkerQueryService>();
            _controller = new AssignmentWorkerController(_commandServiceMock.Object, _queryServiceMock.Object);
        }

        [Test]
        public async Task CreateAssignmentWorker_ReturnsOk_WhenSuccess()
        {
            // Arrange
            var resource = new CreateAssignmentWorkerResource(1, 2, 3, "2025-07-08", "2025-07-09",
                "Active");
            var command = CreateAssignmentWorkerCommandFromResourceAssembler.ToCommandFromResource(resource);
            _commandServiceMock.Setup(x => x.Handle(It.IsAny<CreateAssignmentWorkerCommand>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.CreateAssignmentWorker(resource);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetAssignmentWorkersByWorkerId_ReturnsOk_WhenFound()
        {
            // Arrange
            int workerId = 1;
            var assignments = new List<AssignmentWorker> { new AssignmentWorker() };
            _queryServiceMock.Setup(x => x.Handle(It.IsAny<GetAssignmentWorkerByWorkerIdQuery>()))
                .ReturnsAsync(assignments);

            // Act
            var result = await _controller.GetAssignmentWorkersByWorkerId(workerId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
