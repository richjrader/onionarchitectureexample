using System;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using Onion;
using Onion.Controllers;
using Onion.Models;
using Ploeh.AutoFixture;

namespace UnitTests.API
{
    [TestFixture]
    public class WidgetControllerTests
    {
        private Mock<IWidgetApplicationService> _widgetApplicationService;
        private Mock<IWidgetRepository> _widgetRepository;
        private Fixture fixture;
        private WidgetController _widgetController;

        [SetUp]
        public void Setup()
        {
            _widgetApplicationService = new Mock<IWidgetApplicationService>();
            _widgetRepository = new Mock<IWidgetRepository>();
            fixture = new Fixture();
            _widgetController = new WidgetController(_widgetRepository.Object, _widgetApplicationService.Object);
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenPassedNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new WidgetController(null, _widgetApplicationService.Object)) ;
        }

        [Test]
        public void Create_ShouldReturnBadRequest_WhenAppLayerReturnsAggregateException()
        {
            _widgetApplicationService.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<WidgetType>()))
                .Throws<AggregateException>();
            var req = fixture.Create<WidgetCreateModel>();
            var result = _widgetController.CreateWidget(req).Result;
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
        }
    }
}
