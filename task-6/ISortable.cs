using System;
using System.Collections.Generic;

namespace task_6
{
    public interface ISortable<T>
    {

        public enum Order
        {
            UP, DOWN
        }

        public void Sort(ref T[] arr, Order flag, IComparer<T> cmp, List<Object> parameters);
    }
}