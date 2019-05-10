using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExportTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportTool.Tests
{
    [TestClass()]
    public class NCWriterTests
    {
        [TestMethod()]
        public void GetCodeTest()
        {
            string s = NCWriter.GetCode();
            Assert.AreEqual(s, "G00 X0 Y0 Z0");
        }
    }
}