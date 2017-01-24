using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Onion;

namespace UnitTests.Domain
{
    [TestFixture]
    public class WidgetTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void Create_DoesntAllowWizbangType_ForSomeReason()
        {
            Assert.Throws<AggregateException>(() => Widget.Create("Something", new WidgetType("Wizbang")));
        }

        [Test]
        public void Create_DoesNotSetId_Always()
        {
            var widget = Widget.Create("Something", new WidgetType("Type"));
            Assert.IsNull(widget.Id);
        }

        [Test]
        public void Create_SetsHeightToZero_Always()
        {
            var widget = Widget.Create("Something", new WidgetType("Type"));
            Assert.AreEqual(0,widget.Height);
        }
    }
}
