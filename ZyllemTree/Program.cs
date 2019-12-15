using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ZyllemTree
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string fruitName = "";
                int quesNumber = 0;
                var tree = new Node(null, new List<Node>() {
                                new Node(null, new List<Node>()),
                                new Node(new List<object>(){ "Apple" }, null),
                                new Node(null, new List<Node>()),
                                new Node(new List<object>(){ "Orange", "Orange", "Orange" }, null),
                                new Node(null, new List<Node>(){
                                    new Node(new List<object>() { "Apple", "Orange" }, null),
                                    new Node(null, new List<Node>() {
                                        new Node(new List<object>() { "Apple" }, null),
                                        new Node(new List<object>() { "Orange", "Orange", "Apple" }, null)
                                    }),
                                    new Node(new List<object>() { "Orange" }, null),
                                    new Node(new List<object>() { "Apple", "Apple" }, null)
                                })
                                        });
                ShowQuestions();
                quesNumber = Convert.ToInt32(Console.ReadLine());

                switch (quesNumber)
                {
                    case 1:
                        Console.WriteLine("Enter fruit name: ");
                        fruitName = Console.ReadLine();
                        var fruitCount = tree.CountItemsByName(tree, fruitName);
                        Console.WriteLine(fruitName + " Count is: " + fruitCount);
                        break;
                    case 2:
                        var counter = new List<Counter>();
                        tree.CountMostItems(tree, counter);
                        var maxCount = counter.Max(x => x.Count);
                        var maxBranch = string.Join(", ", counter.Where(x => x.Count == maxCount).Select(z=>z.Branch).ToList());
                        Console.WriteLine(maxBranch + " branches has max fruits");
                        break;
                    case 3:
                        Console.WriteLine("Enter fruit name: ");
                        fruitName = Console.ReadLine();
                        var counterCon = new List<Counter>();
                        tree.ContainOnlyOneItem(tree, counterCon, fruitName);
                        var branches = string.Join(", ", counterCon.Select(x => x.Branch).ToList());
                        Console.WriteLine(branches + " branches has " + fruitName);
                    break;
                default:
                    break;
                }

                Console.ReadKey();
            }
        }

        private static void ShowQuestions()
        {
            Console.WriteLine("1. Find fruits count");
            Console.WriteLine("2. Which branch has most number of fruits");
            Console.WriteLine("3. Branches by fruit name");
            Console.WriteLine("Enter Question number: ");
        }
    }
}
