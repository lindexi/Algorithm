using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace cAlgorithm
{
    [TestClass]
    public class ReverseStructure
    {
        public ReverseStructure()
        {
        }

        [TestMethod]
        public void Reverse()
        {
            Stack<Puke> stack=new Stack<Puke>();
            Puke puke=new Puke("1");
            stack.Push(puke);

            stack.Pop();

            for (int i = 0; i < 100; i++)
            {
                puke=new Puke(i);
                stack.Push(puke);
            }

            //puke=new Puke("2");

            //stack.Push(puke);

            //puke=new Puke("3");

            //stack.Push(puke);

            //puke=new Puke("4");

            //stack.Push(puke);

            //puke=new Puke("5");

            //stack.Push(puke);

            Algorithm.Model.ReverseStructure.RecursionReverse(stack);

           // string str="";

            //while (stack.Count!=0)
            //{
               // str+=stack.Pop().Paimian + " ";

            //}
            int n = stack.Count;
            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(i,stack.Pop().n);
            }

        }
    }
}
