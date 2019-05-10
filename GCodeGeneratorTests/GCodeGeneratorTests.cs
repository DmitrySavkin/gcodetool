using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeGenerator.Tests
{
    [TestClass()]
    public class GCodeGeneratorTests
    {
        [TestMethod()]
        public void GetGCodeTest()
        {
            StringBuilder s = new StringBuilder();
            s.Append("G0 X0 Y0 Z0");
            s.Append(Environment.NewLine);
            s.Append("G01 X0 Y0 Z0");
            s.Append(Environment.NewLine);
            Assert.AreEqual(s.ToString(), GCodeGenerator.GetGCode().ToString());
        }
    }
}