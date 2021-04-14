using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        public class BinaryHeap
        {
            public List<int> list = new List<int>();

            public int size()
            {
                return this.list.Count();
            }
            public int getMax()
            {
                int result = list[0];
                list[0] = list[size() - 1];
                balanse(0);
                list.RemoveAt(size() - 1);
                return result;
            }
            public void balanse(int i)
            {
                int leftChild, rightChild, largCh;

                while(true)
                {
                    leftChild = 2 * i + 1;
                    rightChild = 2 * i + 2;
                    largCh = i;

                    if (leftChild < size() && list[leftChild] > list[largCh])
                    {
                        largCh = leftChild;
                    }
                    if (rightChild < size() && list[rightChild] > list[largCh])
                    {
                        largCh = rightChild;
                    }
                    if (largCh == i)
                    {
                        break;
                    }
                    int temp = list[i];
                    list[i] = list[largCh];
                    list[largCh] = temp;
                    i = largCh;
                }
            }
            public void add(int value)
            {
                list.Add(value);
                int i = size() - 1;
                int parent = (i - 1) / 2;
                while (i > 0 && list[parent] < list[i])
                {
                    int temp = list[i];
                    list[i] = list[parent];
                    list[parent] = temp;
                    i = parent;
                    parent = (i - 1) / 2;
                }
            }
        }
        static void Main(string[] args)
        {
            FileStream infile = new FileStream("./" + args[0], FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(infile);
            FileStream outfile = new FileStream("./programm.out", FileMode.Open, FileAccess.Write);
            outfile.SetLength(0);
            StreamWriter writer = new StreamWriter(outfile);
            BinaryHeap heap = new BinaryHeap();
            int N = int.Parse(reader.ReadLine());
            for (int i = 0; i < N; i++)
            {
                
                string str = reader.ReadLine();
                if (str == "GET")
                {
                    int max = heap.getMax();
                    Console.WriteLine(max);
                    writer.WriteLine(max);
                }
                else
                {
                    int val = int.Parse(str);
                    heap.add(val);
                }
            }
            writer.Close();
            Console.ReadKey();
        }
    }
}
