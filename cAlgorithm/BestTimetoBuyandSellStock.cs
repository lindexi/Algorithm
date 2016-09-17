using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace cAlgorithm
{
    [TestClass]
    public class BestTimetoBuyandSellStock
    {
        [TestMethod]
        public void MaxProfit()
        {
            int[] price = new[]
            {
                2,3,2,5
            };

            var temp = Algorithm.Model.BestTimetoBuyandSellStock.MaxProfit(price);
            Assert.AreEqual(temp, 3);

            price = new[]
            {
                5, 15, 1, 3, 6, 5, 3, 2, 5, 6, 7, 2, 2, 3
            };
            temp = Algorithm.Model.BestTimetoBuyandSellStock.MaxProfit(price);
            Assert.AreEqual(temp, 10);

        }
    }
}
