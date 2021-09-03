using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tree.Tests
{
    [TestClass()]
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void InsertTest_Int()
        {
            BinaryTree<int> bTree = new BinaryTree<int>();
            bTree.Insert(5);
            bTree.Insert(8);
            bTree.Insert(12);
            bTree.Insert(1);
            bTree.Insert(85);
            bTree.Insert(43);
            bTree.Insert(6);
            Assert.AreEqual(5, bTree.Root.Value, "Root錯誤");
            Assert.AreEqual(1, bTree.Root.Left.Value, "Left錯誤");
            Assert.AreEqual(8, bTree.Root.Right.Value, "Right錯誤");
        }

        [TestMethod()]
        public void InsertTest_string()
        {
            BinaryTree<string> bTree = new BinaryTree<string>();
            bTree.Insert("B");
            bTree.Insert("D");
            bTree.Insert("E");
            bTree.Insert("A");
            bTree.Insert("C");
            bTree.Insert("F");
            Assert.AreEqual("B", bTree.Root.Value, "Root錯誤");
            Assert.AreEqual("A", bTree.Root.Left.Value, "Left錯誤");
            Assert.AreEqual("D", bTree.Root.Right.Value, "Right錯誤");
        }
    }
}