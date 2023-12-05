
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ZipStr()
        {
            string str = "zzzcccvhjy";
            string expected = "z3c3vhjy";
            

        }

        [TestMethod]
        public void DeZipStr()
        {
            string str = "z3c3vhjy";
            string expected = "zzzcccvhjy";
        }
    

        [TestMethod]
        public void ZipStrLinq()
        {
            string str = "zzzcccvhjy";
            string expected = "z3c3vhjy";

        }

        [TestMethod]
        public void DeZipStrLinq()
        {
            string str = "z3c3vhjy";
            string expected = "zzzcccvhjy";
        }

        [TestMethod]
        public void FullLinqZip()
        {
            string str = "zzzcccvhjy";
            string expected = "z3c3vhjy";

        }


    }
}
