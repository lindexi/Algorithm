#最佳时间买入卖出股票 Best Time to Buy and Sell Stock 

LeetCode

我们有一个股票的数组，数组是每时间的钱，我们只能买入一次和卖出一次，求我们的最大收益。

我们知道了一个数组，那么我们可以在低价买入，然后高价卖出，但是需要知道我们的低价需要在高价之前。

我们可以两个变量，一个记录最低价，一个记录我们卖出得到最大钱。

```
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
```

我们不断计算当前最小和当前价格的卖出得到的钱，如果大于我们的最大卖出钱就记下，这样就得到我们的最大卖出钱。

我们来个测试，UWP的测试其实和我发的单元测试是一样。

新建测试，然后写一个类

```
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
```

代码：https://github.com/lindexi/Algorithm/blob/master/Algorithm/Model/BestTimetoBuyandSellStock.cs