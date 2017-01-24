using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Onion;

namespace UnitTests.Application
{
    [TestFixture]
    public class WidgetApplicationServiceTests
    {
        private Mock<IWidgetRepository> _widgetRepository;
        private Mock<INotifier> _notifier;
        private WidgetApplicationService _widgetApplicationService;

        [SetUp]
        public void SetUp()
        {
            _widgetRepository = new Mock<IWidgetRepository>();
            _notifier = new Mock<INotifier>();
            _widgetApplicationService = new WidgetApplicationService(_widgetRepository.Object, _notifier.Object);
        }

        [Test]
        public void PickUp_ThrowsArgumentExcepetion_WhenWidgetNotFound()
        {
            _widgetRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(null);
            
            Assert.That(async () => await _widgetApplicationService.PickUp(1,1), Throws.Exception.TypeOf<ArgumentException>());

        }
    }
}
