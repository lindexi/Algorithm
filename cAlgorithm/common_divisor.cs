using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace cAlgorithm
{
    [TestClass]
    public class common_divisor
    {
        [TestMethod]
        public void euler()
        {
            int m = 24;
            int n = 60;
            Algorithm.Model.common_divisor _common_divisor=new Algorithm.Model.common_divisor();
            Assert.AreEqual(12,_common_divisor.euler(n,m));
        }
    }
}
