using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeInCSharp
{
  public class BinarySearchTree
    {
    public Node FirstNode;

    public BinarySearchTree()
    {
      FirstNode = new Node();
    }

    public BinarySearchTree(IComparable startingValue)
    {
      this.FirstNode = new Node(startingValue);
    }

    public void Add(IComparable comparable)
    {
      ProcessAdd(FirstNode, comparable);
    }

    private void ProcessAdd(Node node, IComparable comparable)
    {
      if (node.ValueIsSet == false)
      {
        node.Value = comparable;
      }
      else
      {
        GoToNextTreeLevel(node, comparable);
      }
    }

    private void GoToNextTreeLevel(Node node, IComparable comparable)
    {
      if (IsLower(node, comparable))
      {
        this.ProcessAdd(node.lower, comparable);
      }
      else
      {
        this.ProcessAdd(node.higher, comparable);
      }
    }

    private Boolean IsLower(Node node, IComparable comparable)
    {
      return node.Value.CompareTo(comparable) == 1;
    }


    public IComparable Search(IComparable comparable)
    {
      return ProcessReturn(FirstNode, comparable);
    }

    public IComparable ProcessReturn(Node node, IComparable comparable)
    {
      if (node.ValueIsSet == false)
      {
        return false;
      }
      else if (node.Value.CompareTo(comparable) == 0)
      {
        return node.Value;
      }
      else
      {
        return SearchNextTreeLevel(node, comparable);
      }
    }

    private IComparable SearchNextTreeLevel(Node node, IComparable comparable)
    {
      if (IsLower(node, comparable))
      {
        return this.ProcessReturn(node.lower, comparable);
      }
      else
      {
        return this.ProcessReturn(node.higher, comparable);
      }
    }


  }
}
