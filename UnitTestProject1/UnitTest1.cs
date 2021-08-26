using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
            DirectoryInfo dinfo = new DirectoryInfo(@"e:\2");
            Assert.IsTrue(dinfo.Exists);
        }
        public void TestMethod2()
        {
            Assert.IsNotNull(string.IsNullOrEmpty("1.txt"));
        }
        public void TestMethod3()
        {
            Assert.IsTrue(!File.Exists("1.txt"));
        }
        public void TestMethod4()
        {
            Assert.IsNotNull(File.OpenText("1.txt"));
        }
        public void TestMethod5()
        {            
            using (TextReader reader = File.OpenText("1.txt"))
            {
                string line = reader.ReadLine();
                Assert.IsNotNull(line);
            }
        }


    }
}
