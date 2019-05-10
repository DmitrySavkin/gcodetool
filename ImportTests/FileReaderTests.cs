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
        public void ReadTest() {
           string data =    Import.FileReader.Read();
           Assert.AreEqual("bla", data);

        }
    }
}