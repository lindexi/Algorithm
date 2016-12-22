using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace cAlgorithm
{
    [TestClass]
    public class CorrespondAlgorithm
    {
        [TestMethod]
        public void Bdt()
        {
            string text = "abc";
            string str = "abc";
            Assert.AreEqual(true, Algorithm.Model.CorrespondAlgorithm.Bdt(text,str));
            text = "aaaaacbc";
            Assert.AreEqual(true, Algorithm.Model.CorrespondAlgorithm.Bdt(text,str));
            text = "bacabc";
            Assert.AreEqual(true, Algorithm.Model.CorrespondAlgorithm.Bdt(text,str));
        }
    }
}
