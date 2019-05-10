using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackClosedShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackClosedShapes.Tests
{
    [TestClass()]
    public class PackShapeTests
    {
        [TestMethod()]
        public void GetShapesTest()
        {
            List<string> l = PackShape.GetShapes(null);
            Assert.AreEqual("1", l[0]);
        }
    }
}