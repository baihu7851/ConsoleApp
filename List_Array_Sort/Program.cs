using System;
using System.Collections.Generic;

namespace List_Array_Sort
{
    internal class Program
    {
        private static void Main()
        {
            const int count = 50000;
            List<int> lst = null;
            int[] arr = null;
            SetData(ref lst, ref arr, count);
            Console.WriteLine("資料設定完成，開始排序");
            var start = DateTime.Now;
            Sort(lst);
            var end = DateTime.Now;
            var ts = end - start;
            Console.WriteLine($"ListSortTime:\t{ts.TotalMilliseconds}");
            start = DateTime.Now;
            Sort(arr);
            end = DateTime.Now;
            ts = end - start;
            Console.WriteLine($"ArraySortTime:\t{ts.TotalMilliseconds}");
            Console.ReadKey();
        }

        private static void SetData(ref List<int> lst, ref int[] arr, int count)
        {
            lst = new List<int>();
            arr = new int[count];
            for (var i = 0; i < count; i++)
            {
                Random rdm = new Random();
                lst.Add(rdm.Next(count));
                arr[i] = rdm.Next(count);
            }
        }

        private static void Sort(List<int> lst)
        {
            int count = lst.Count;
            int tmp;
            for (var i = 0; i < count; i++)
            {
                for (var j = i + 1; j < count; j++)
                {
                    if (lst[j] < lst[i])
                    {
                        tmp = lst[j];
                        lst[j] = lst[i];
                        lst[i] = tmp;
                    }
                }
            }
        }

        private static void Sort(int[] arr)
        {
            int count = arr.Length;
            int tmp;
            for (var i = 0; i < count; i++)
            {
                for (var j = i + 1; j < count; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }
        }
    }
}