using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    public class BinaryReflectedGrayCode
    {
        /// <summary>
        /// 递归生成n位二进制反射格雷码
        /// </summary>
        /// <param name="n">长度为n的整数</param>
        /// <returns>所有长度为n的格雷码位串列表</returns>
        public List<string> BinaryReflectedGrayCodeRecursion(int n)
        {
            if (n == 1)
            {
                return new List<string>()
                {
                    "0",
                    "1"
                };
            }
            else
            {
                List<string> L1 = BinaryReflectedGrayCodeRecursion(n - 1);
                //使用BinaryReflectedGrayCodeRecursion(n - 1)生成长度为n-1的位串
                List<string> L2 = ReverseBinaryReflectedGrayCode(L1);
                //把L1倒序后复制
                L1 = BinaryGrayCode("0",L1);
                L2 = BinaryGrayCode("1", L2);
                L1.AddRange(L2);
                return L1;
            }
        }
        /// <summary>
        /// 倒序格雷码
        /// </summary>
        /// <param name="binaryReflectedGrayCode"></param>
        /// <returns></returns>
        private List<string> ReverseBinaryReflectedGrayCode(List<string> binaryReflectedGrayCode)
        {
            List<string> temp= binaryReflectedGrayCode.ToList();
            temp.Reverse();
            return temp;
        }

        /// <summary>
        /// 在位串每个前添加i
        /// </summary>
        /// <param name="n"></param>
        /// <param name="binaryReflectedGrayCode"></param>
        /// <returns></returns>
        private List<string> BinaryGrayCode(string n, List<string> binaryReflectedGrayCode)
        {
            for (int i = 0; i < binaryReflectedGrayCode.Count; i++)
            {
                binaryReflectedGrayCode[i] = binaryReflectedGrayCode[i].Insert(0, n);
            }
            return binaryReflectedGrayCode;
        }
    }
}
