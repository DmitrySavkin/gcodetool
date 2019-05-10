using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortAndPackagesShape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAndPackagesShape.Tests
{
    [TestClass()]
    public class GeometrySortTests
    {
        [TestMethod()]
        public void LineSortTest()
        {
            List<string> l = GeometrySort.LineSort();
            Assert.AreEqual("1", l[0]);
            Assert.AreEqual("2", l[1]);
        }
    }
}