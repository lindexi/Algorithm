// lindexi
// 16:49

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    /// <summary>
    ///     堆排序
    /// </summary>
    public class HeapSort<T> where T : IComparable
    {
        /// <summary>
        /// </summary>
        /// <param name="array">要排序数组</param>
        public HeapSort(IEnumerable<T> array)
        {
            _sortArray = array.ToList();
            BuildMaxHeap();
        }

        public List<T> SortArray
        {
            set
            {
                if (value == null)
                {
                    value = new List<T>();
                }
                _sortArray = value;
            }
            get
            {
                return _sortArray;
            }
        }

        private List<T> _sortArray;

        /// <summary>
        ///     初始大根堆，自底向上地建堆
        ///     完全二叉树的基本性质，最底层节点是 n/2，所以从 SortArray.Count / 2 开始
        /// </summary>
        private void BuildMaxHeap()
        {
            for (int i = SortArray.Count/2 - 1; i >= 0; i--)
            {
                MaxHeapifyRecursion(i);
            }
        }

        /// <summary>
        ///     将指定的节点调整为堆
        /// </summary>
        /// <param name="i">需要调整的节点</param>
        private void MaxHeapifyRecursion(int i)
        {
            int left = 2*i + 1; // 左子节点 
            int right = 2*i + 2; // 右子节点  
            int max = i;
            if (left < SortArray.Count
                && SortArray[left].CompareTo(SortArray[max]) > 0)
            {
                max = left;
            }

            if (right < SortArray.Count
                && SortArray[right].CompareTo(SortArray[max]) > 0)
            {
                max = right;
            }

            if (i == max)
            {
                return;
            }
            //Swap( SortArray[i], SortArray[max]);
            T temp = SortArray[i];
            SortArray[i] = SortArray[max];
            SortArray[max] = temp;

            MaxHeapifyRecursion(max);
        }

        /// <summary>
        ///     将指定的节点调整为堆
        /// </summary>
        /// <param name="i">需要调整的节点</param>
        private void MaxHeapify(int i)
        {
            while (true)
            {
                int left = 2*i + 1; // 左子节点 
                int right = 2*i + 2; // 右子节点  
                int max = i;
                if (left < SortArray.Count && SortArray[left].CompareTo(SortArray[max]) > 0)
                {
                    max = left;
                }

                if (right < SortArray.Count && SortArray[right].CompareTo(SortArray[max]) > 0)
                {
                    max = right;
                }

                if (i == max)
                {
                    return;
                }
                //Swap( SortArray[i], SortArray[max]);
                T temp = SortArray[i];
                SortArray[i] = SortArray[max];
                SortArray[max] = temp;

                i = max;
            }
        }
    }
}