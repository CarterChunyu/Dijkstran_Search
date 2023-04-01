using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstran_Search
{
    class Dijkstran
    {
        private class Node : IComparable<Node>
        {
            public string Name;
            public int Distnace;
            public Node(string name, int distance)
            {
                this.Name = name;
                this.Distnace = distance;
            }

            public int CompareTo(Node other)
            {
                if (this.Distnace < other.Distnace)
                    return -1;
                else if (this.Distnace > other.Distnace)
                    return 1;
                return 0;
            }
        }
        private readonly Dictionary<string, List<Node>> NodeDic;
        public Dijkstran()
        {
            this.NodeDic = new Dictionary<string, List<Node>>()
            {
                {"A",new List<Node>(){new Node("B",5),new Node("C",1)} },
                {"B",new List<Node>(){new Node("A",5),new Node("C",2),new Node("D",1) }},
                {"C",new List<Node>(){new Node("A",1),new Node("B",2),new Node("D",4),new Node("E",8)}},
                {"D",new List<Node>(){new Node("B",1),new Node("C",4),new Node("E",3),new Node("F",6)}},
                {"E",new List<Node>(){new Node("C",8),new Node("D",3)} },
                {"F",new List<Node>(){new Node("D",6)}}
            };
        }
        private void Calculator(string Start_Node,out Dictionary<string,int> Deep,out Dictionary<string,string> Parent)
        {
            MinSortedQueue<Node> minQueue = new MinSortedQueue<Node>();
            minQueue.Enqueue(new Node(Start_Node, 0));
            List<string> Confirms = new List<string>();
            Deep = new Dictionary<string, int>() { { Start_Node, 0 } };
            Parent = new Dictionary<string, string>() { {Start_Node, null }};
            while (!minQueue.IsEmpty)
            {
                Node node = minQueue.Dequeue();
                foreach (var item in NodeDic[node.Name])
                {
                    if (!Confirms.Any(p => p == item.Name))
                    {
                        // 存的是離起始點的距離
                        item.Distnace = node.Distnace + item.Distnace;
                        minQueue.Enqueue(item);                       
                        if (Deep.ContainsKey(item.Name))
                        {
                            // 如果距離較短更新
                            if (Deep[item.Name] > item.Distnace)
                            {
                                Deep[item.Name] = item.Distnace;
                                Parent[item.Name] = node.Name;
                            }
                        }
                        else
                        {
                            Deep.Add(item.Name, item.Distnace);
                            Parent.Add(item.Name, node.Name);
                        }
                    }
                }
                Confirms.Add(node.Name);
            }            
        }
        public void Print(string Start_Node,string Distanation_Node)
        {
            Dictionary<string, int> deep;
            Dictionary<string, string> parent;
            Calculator(Start_Node, out deep, out parent);
            // 印出深度
            foreach (var item in deep)
            {
                Console.WriteLine($"位置:{item.Key},距離{item.Value}");
            }
            // 印出路徑
            Stack<string> stack = new Stack<string>();
            while (Distanation_Node != null)
            {
                stack.Push(Distanation_Node);
                Distanation_Node = parent[Distanation_Node];
            }
            StringBuilder builder = new StringBuilder();
            while (stack.Count() > 0)
            {
                builder.Append($"{stack.Pop()}=>");
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
