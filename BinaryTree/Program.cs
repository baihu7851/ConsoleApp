using System.Collections.Generic;

namespace BinaryTree
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var d = new BinaryTree();
        }

        private Node Root;

        /// <summary>
        /// 確認樹是否為空
        /// </summary>
        public bool IsEmpty
        {
            get { return Root == null; }
        }

        public Program()
        {
            Root = new Node(5);
        }

        /// <summary>
        /// 尋找某個值
        /// </summary>
        /// <param name="value">數值</param>
        /// <returns></returns>
        public bool Find(int value)
        {
            if (Root == null)
            {
                return false;
            }
            return Find(value, Root);
        }

        private bool Find(int value, Node currentRoot)
        {
            if (currentRoot == null)
            {
                return false;
            }
            if (currentRoot.Value == value)
            {
                return true;
            }
            if (value < currentRoot.Value)
            {
                return Find(value, currentRoot.Left);
            }
            return Find(value, currentRoot.Right);
        }

        /// <summary>
        /// 遍歷
        /// </summary>
        /// <returns>結果</returns>
        public List<int> Traversal()
        {
            List<int> result = new List<int>();
            Traversal(Root, result);
            return result;
        }

        private void Traversal(Node currentRoot, List<int> result)
        {
            Traversal(currentRoot.Left, result);
            result.Add(currentRoot.Value);
            Traversal(currentRoot.Right, result);
        }
    }
}