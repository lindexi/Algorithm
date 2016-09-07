using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace cAlgorithm
{
    [TestClass]
    public class BinaryReflectedGrayCode
    {
        [TestMethod]
        public void BinaryReflectedGrayCodeRecursion()
        {
            //林德熙
            var binaryReflectedGrayCode = new Algorithm.Model.BinaryReflectedGrayCode();
            var n = binaryReflectedGrayCode.BinaryReflectedGrayCodeRecursion(10);
            StringBuilder str=new StringBuilder();
            foreach (var temp in n)
            {
                str.Append(temp + "\r\n");
            }
            Debug.Write(str.ToString());
        }
    }
}
