using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Dictionary_Search
{
    internal class Program
    {
        private static void Main()
        {
            const int count = 1000000;
            int[] targets = new int[count / 100];
            List<Student> lst = null;
            Dictionary<int, Student> dic = null;
            SetData(ref lst, ref dic, count, ref targets);
            Console.WriteLine("設定完成，開始搜尋");

            var start = DateTime.Now;
            Search(lst, targets);
            var end = DateTime.Now;
            var ts = end - start;
            Console.WriteLine($"List搜尋時間：\t{ts.TotalMilliseconds}");

            start = DateTime.Now;
            Search(dic, targets);
            end = DateTime.Now;
            ts = end - start;
            Console.WriteLine($"Dictionary搜尋時間：\t{ts.TotalMilliseconds}");
            Console.ReadKey();
        }

        private static void SetData(ref List<Student> lst, ref Dictionary<int, Student> dic, int count, ref int[] targets)
        {
            lst = new List<Student>();
            dic = new Dictionary<int, Student>();
            Random rdm = new Random();
            int key;
            Student student;
            for (var i = 0; i < count; i++)
            {
                key = rdm.Next(count * 3);
                while (dic.Keys.Contains(key)) key = rdm.Next(count * 3);
                student = new Student(key);
                lst.Add(student);
                dic.Add(key, student);
            }
            int[] keys = dic.Keys.ToArray();
            for (var i = 0; i < targets.Length; i++)
            {
                targets[i] = keys[rdm.Next(targets.Length)];
            }
        }

        private static void Search(List<Student> lst, int[] targets)
        {
            int count = targets.Length;
            Student student;
            for (var i = 0; i < count; i++)
            {
                student = lst.Find(x => x.Id == targets[i]);
            }
        }

        private static void Search(Dictionary<int, Student> dic, int[] targets)
        {
            int count = targets.Length;
            Student student;
            for (var i = 0; i < count; i++)
            {
                student = dic[targets[i]];
            }
        }
    }

    internal class Student
    {
        public Student(int id)
        {
            Id = id;
            Msg = $"My Id is{id}";
        }

        public int Id { get; set; }
        public string Msg { get; set; }
    }
}