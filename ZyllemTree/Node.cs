using System;
using System.Collections.Generic;
using System.Linq;

namespace ZyllemTree
{
    public class Node
    {
        public List<object> ObjList { get; set; }
        public List<Node> BranchList { get; set; }

        public Node() { }

        public Node(List<object> objList, List<Node> branchList)
        {
            this.ObjList = objList;
            this.BranchList = branchList;
        }

        public int CountItemsByName(Node treeNode, string itemName)
        {
            int count = 0;
            if (treeNode.ObjList != null)
            {
                foreach (var node in treeNode.ObjList)
                {
                    if (node.ToString().ToLower() == itemName.ToLower()) count++;
                }
            }

            if (treeNode.BranchList != null)
            {
                foreach (var pred in treeNode.BranchList)
                {
                    count += CountItemsByName(pred, itemName);
                }
            }

            return count;
        }

        public void CountMostItems(Node tree, List<Counter> countList, string startingBranchName = "0")
        {
            var count = tree.ObjList != null ? tree.ObjList.Count : 0;
            var counter = 0;
            countList.Add(new Counter() { Branch = $"{startingBranchName}", Count = count });

            if (tree.BranchList != null)
            {
                foreach (var branch in tree.BranchList)
                {
                    counter++;
                    CountMostItems(branch, countList, $"{startingBranchName}.{counter}");
                }
            }
        }

        public void ContainOnlyOneItem(Node tree, List<Counter> countList, string itemName, string startingBranchName = "0")
        {
            var count = tree.ObjList != null ? tree.ObjList.Count : 0;
            var counter = 0;

            if (tree.ObjList != null)
            {
                var itemCount = tree.ObjList.GroupBy(x => x).Select(y => y.Key);
                if (itemCount.ToList().Count == 1 && itemCount.Contains(itemName))
                    countList.Add(new Counter() { Branch = $"{startingBranchName}", Count = count });
            }

            if (tree.BranchList != null)
            {
                foreach (var branch in tree.BranchList)
                {
                    counter++;
                    ContainOnlyOneItem(branch, countList, itemName, $"{startingBranchName}.{counter}");
                }
            }
        }
    }

}


public class Counter
{
    public string Branch { get; set; }
    public int Count { get; set; }
}