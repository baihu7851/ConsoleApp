using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Dictionary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            const int COUNT = 1000000;
            int[] targets = new int[COUNT / 100];
            List<Student> lst = null;
            Dictionary<int, Student> dic = null;
            SetData(ref lst,ref dic, COUNT,ref targets);
            Console.WriteLine("設定完成，開始搜尋");
            DateTime start, end;
            TimeSpan ts;

            start = DateTime.Now;
            Search(lst, targets);
            end = DateTime.Now;
            ts = end - start;
            Console.WriteLine($"List搜尋時間：\t{ts.TotalMilliseconds}");

            start = DateTime.Now;
            Search(dic, targets);
            end = DateTime.Now;
            ts = end - start;
            Console.WriteLine($"Dictionary搜尋時間：\t{ts.TotalMilliseconds}");
            Console.ReadKey();
        }
        static void SetData(ref List<Student> lst, ref Dictionary<int, Student> dic, int COUNT,ref int[] targets)
        {
            lst = new List<Student>();
            dic = new Dictionary<int, Student>();
            Random rdm = new Random();
            int key;
            Student student;
            for (int i = 0; i < COUNT; i++)
            {
                key = rdm.Next(COUNT * 3);
                while (dic.Keys.Contains(key)) key = rdm.Next(COUNT * 3);
                student = new Student(key);
                lst.Add(student);
                dic.Add(key, student);
            }
            int[] keys = dic.Keys.ToArray();
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i] = keys[rdm.Next(targets.Length)];
            }
        }
        static void Search(List<Student> lst, int[] targets)
        {
            int count = targets.Length;
            Student student;
            for (int i = 0; i < count; i++)
            {
                student = lst.Find(x => x.Id == targets[i]);
            }
        }
        static void Search(Dictionary<int, Student> dic, int[] targets)
        {
            int count = targets.Length;
            Student student;
            for (int i = 0; i < count; i++)
            {
                student = dic[targets[i]];
            }
        }
    }
    class Student
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
