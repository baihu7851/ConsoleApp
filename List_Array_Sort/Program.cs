using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Array_Sort
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int COUNT = 50000;
            List<int> lst = null;
            int[] arr = null;
            SetData(ref lst, ref arr, COUNT);
            Console.WriteLine("資料設定完成，開始排序");
            DateTime start, end;
            TimeSpan ts;
            start = DateTime.Now;
            Sort(lst);
            end = DateTime.Now;
            ts = end - start;
            Console.WriteLine($"ListSortTime:\t{ts.TotalMilliseconds}");
            start = DateTime.Now;
            Sort(arr);
            end = DateTime.Now;
            ts = end - start;
            Console.WriteLine($"ArraySortTime:\t{ts.TotalMilliseconds}");
            Console.ReadKey();

        }
        private static void SetData(ref List<int> lst, ref int[] arr, int COUNT)
        {
            lst = new List<int>();
            arr = new int[COUNT];
            for (int i = 0; i < COUNT; i++)
            {
                Random rdm = new Random();
                lst.Add(rdm.Next(COUNT));
                arr[i] = rdm.Next(COUNT);
            }
        }
        private static void Sort(List<int> lst)
        {
            int count = lst.Count;
            int tmp;
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
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
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
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
