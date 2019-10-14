using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTreeInCSharp;

namespace BinaryTreeInCSharpTests
{
  [TestClass]
  public class BinarySearchTreeSpec
  {
    [TestMethod]
    public void BinarySearchTree_HasValueSet()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree(100);
      Assert.AreEqual(100, binarySearchTree.FirstNode.Value);
      Assert.AreEqual(true, binarySearchTree.FirstNode.ValueIsSet);
    }

    [TestMethod]
    public void BinarySearchTree_ValueNotSet()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree();
      Assert.AreEqual(null, binarySearchTree.FirstNode.Value);
      Assert.AreEqual(false, binarySearchTree.FirstNode.ValueIsSet);
    }

    [TestMethod]
    public void Add_Lower_HasValueSetCorrectly()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree(100);
      binarySearchTree.Add(99);

      Assert.AreEqual(99, binarySearchTree.FirstNode.lower.Value);
      Assert.AreEqual(true, binarySearchTree.FirstNode.lower.ValueIsSet);
    }

    [TestMethod]
    public void Add_Higher_HasValueSetCorrectly()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree(100);
      binarySearchTree.Add(101);

      Assert.AreEqual(101, binarySearchTree.FirstNode.higher.Value);
      Assert.AreEqual(true, binarySearchTree.FirstNode.higher.ValueIsSet);
    }

    [TestMethod]
    public void Add_MultipleHigherAndLowerValues_HasValuesSetCorrectly()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree(100);
      binarySearchTree.Add(100004);
      binarySearchTree.Add(3);

      Assert.AreEqual(100004, binarySearchTree.FirstNode.higher.Value);
      Assert.AreEqual(true, binarySearchTree.FirstNode.higher.ValueIsSet);
      Assert.AreEqual(3, binarySearchTree.FirstNode.lower.Value);
      Assert.AreEqual(true, binarySearchTree.FirstNode.lower.ValueIsSet);
    }

    [TestMethod]
    public void Add_MultipleHigherAndLowerStringValues_HasValuesSetCorrectly()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree("monad");
      binarySearchTree.Add("Zettabyte");
      binarySearchTree.Add("abstraction");

      Assert.AreEqual("Zettabyte", binarySearchTree.FirstNode.higher.Value);
      Assert.AreEqual(true, binarySearchTree.FirstNode.higher.ValueIsSet);
      Assert.AreEqual("abstraction", binarySearchTree.FirstNode.lower.Value);
      Assert.AreEqual(true, binarySearchTree.FirstNode.lower.ValueIsSet);
    }

    [TestMethod]
    public void Search_MultipleHigherAndLowerStringValues_FindsSearchedTerm()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree("monad");
      binarySearchTree.Add("Zettabyte");
      binarySearchTree.Add("service");
      binarySearchTree.Add("abstraction");
      binarySearchTree.Add("ip");

      Assert.AreEqual("ip", binarySearchTree.Search("ip"));
    }

    [TestMethod]
    public void Search_MultipleHigherAndLowerStringValues_DoesNotFindSearchedTerm()
    {
      BinarySearchTree binarySearchTree = new BinarySearchTree("monad");
      binarySearchTree.Add("Zettabyte");
      binarySearchTree.Add("service");
      binarySearchTree.Add("abstraction");
      binarySearchTree.Add("ip");

      Assert.AreEqual(false, binarySearchTree.Search("w3c"));
    }



  }
}
