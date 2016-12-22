using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    public class CorrespondAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">数据</param>
        /// <param name="str">匹配</param>
        public static bool Bdt(string text, string str)
        {
            int i = 0;
            bool reu = false;
            foreach (var temp in str)
            {
                reu = false;
                for (; i < text.Length; i++)
                {
                    if (temp == text[i])
                    {
                        reu = true;
                        break;
                    }
                }
            }
            return reu;
        }
    }
}
