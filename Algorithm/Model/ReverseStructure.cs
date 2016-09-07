using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    public static class ReverseStructure
    {
        public static void RecursionReverse(Stack<Puke> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }
            Puke t = stack.Pop();

            RecursionReverse(stack);

            if (stack.Count == 0)
            {
                stack.Push(t);
            }
            else
            {
                Puke g = stack.Pop();

                RecursionReverse(stack);

                stack.Push(t);

                RecursionReverse(stack);

                stack.Push(g);
            }
        }
    }

    public class Puke
    {
        public Puke(string paimian)
        {
            Paimian = paimian;
        }

        public Puke(int n)
        {
            this.n = n;
        }

        public string Paimian
        {
            set;
            get;
        }

        public int n
        {
            set;
            get;
        }
    }
}
