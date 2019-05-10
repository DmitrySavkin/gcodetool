using Microsoft.VisualStudio.TestTools.UnitTesting;
using Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Tests
{
    [TestClass()]
    public class FileReaderTests
    {
        [TestMethod()]
        public void ReadTest()
        {
           List<string> list = FileReader.Read();
            /*
               l.Add("0.0.0");
            l.Add("0.0.1");
            l.Add("0.1.0");
             */
            Assert.AreEqual("0.0.0", list[0]);
            Assert.AreEqual("0.0.1", list[1]);
            Assert.AreEqual("0.1.0", list[2]);
       }
    }
}