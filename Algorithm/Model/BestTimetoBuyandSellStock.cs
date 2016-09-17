using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    /// <summary>
    /// 最佳时间买入卖出股票：你有一个数组保存了股票天的价钱，现在你只能进行一次买入卖出，如何赚的最多
    /// </summary>
    public static class BestTimetoBuyandSellStock
    {
        /// <summary>
        /// 用一个数记录最小的值，一个记录卖出收益
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] price)
        {
            if (price.Length <= 1)
            {
                return 0;
            }

            int minPrice = price[0];//最小的钱

            int maxProfit = 0;//收益

            for (int i = 1; i < price.Length; i++)
            {
                minPrice = Math.Min(minPrice, price[i]);

                int currentProfit = price[i] - minPrice;

                maxProfit = Math.Max(maxProfit, currentProfit);
            }

            return maxProfit;
        }
    }
}
