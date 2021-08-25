using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public BinaryTree()
        {
            Root = null;
        }
        /// <summary>
        /// 根結點
        /// </summary>
#if DEBUG
        public Node Root;
#else
        private Node Root;
#endif
        /// <summary>
        /// 確認樹是否為空
        /// </summary>
        public bool IsEmpty { get { return Root == null; } }

        #region 尋找值
        /// <summary>
        /// 尋找某個值
        /// </summary>
        /// <param name="value">數值</param>
        /// <returns></returns>
        public bool Find(T value)
        {
            if (Root == null)
            {
                return false;
            }
            return Find(value, Root);
        }
        private bool Find(T value, Node currentRoot)
        {
            if (currentRoot == null)
            {
                return false;
            }
            // 判斷currentRoot是否大於value，是傳1，否傳-1，等於傳0
            if (currentRoot.Value.CompareTo(value) == 0)
            {
                return true;
            }
            if (currentRoot.Value.CompareTo(value) > 0)
            {
                return Find(value, currentRoot.Left);
            }
            return Find(value, currentRoot.Right);
        }
        #endregion

        #region 遍歷
        /// <summary>
        /// 遍歷
        /// </summary>
        /// <returns>結果</returns>
        public List<T> Traversal()
        {
            List<T> result = new List<T>();
            Traversal(Root, result);
            return result;
        }

        private void Traversal(Node currentRoot, List<T> result)
        {
            if (currentRoot == null) return;
            Traversal(currentRoot.Left, result);
            result.Add(currentRoot.Value);
            Traversal(currentRoot.Right, result);
        }
        /// <summary>
        /// 新增節點
        /// </summary>
        /// <param name="value">傳入值</param>
        public void Insert(T value)
        {
            Insert(value, ref Root);
        }
        #endregion

        #region 加入值
        private void Insert(T value, ref Node currentRoot)
        {

            if (currentRoot == null)
            {
                currentRoot = new Node(value);
                return;
            }
            // 判斷currentRoot是否大於value，是傳1，否傳-1
            if (currentRoot.Value.CompareTo(value) > 0)
                Insert(value, ref currentRoot.Left);
            else
                Insert(value, ref currentRoot.Right);
        }
        #endregion

        #region 移除指定值
        /// <summary>
        /// 移除指定值
        /// </summary>
        /// <param name="value">移除值</param>
        public void Remove(T value)
        {
            Remove(value, ref Root);
        }
        void Remove(T value, ref Node currentRoot)
        {
            if (currentRoot == null) return;
            if (currentRoot.Value.CompareTo(value) < 0)
            {
                Remove(value, ref currentRoot.Left);
                return;
            }
            if (currentRoot.Value.CompareTo(value) > 0)
            {
                Remove(value, ref currentRoot.Right);
                return;
            }
            //***********  找到了 *************
            if (currentRoot.Left == null && currentRoot.Right == null)
                currentRoot = null;
            else if (currentRoot.Left == null)
                currentRoot = currentRoot.Right;
            else if (currentRoot.Right == null)
                currentRoot = currentRoot.Left;
            else
            {
                //*******  CurrentRoot 左右皆存在 child Node **********
                Node orgLeft = currentRoot.Left, orgRight = currentRoot.Right;
                ref Node leftMost = ref currentRoot.Right;
                while (leftMost.Left != null)
                {
                    leftMost = ref leftMost.Left;
                }
                currentRoot = leftMost;
                leftMost = leftMost.Right;
                currentRoot.Left = orgLeft;
                currentRoot.Right = orgRight;
            }
        }
        /// <summary>
        /// BinaryTree使用的節點
        /// </summary>
        public class Node
        {
            public Node(T value)
            {
                Value = value;
                Left = Right = null;
            }
            public T Value { get; set; }
            public Node Left, Right;

        }
        #endregion

    }
}
