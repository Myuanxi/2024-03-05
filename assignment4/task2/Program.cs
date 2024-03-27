using System;

namespace GenericList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public Node(T t)
        {
            // 初始化节点
            Next = null;
            Value = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            head = null;
            tail = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        // 添加元素到链表尾部
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        // 对每个元素执行操作
        public void ForEach(Action<T> action)
        {
            Node<T> n = head;
            while (n != null)
            {
                action(n.Value);
                n = n.Next;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for (int i = 0; i < 30; i++)
            {
                list.Add(i + 1);
            }

            Console.Write("链表元素为：");
            list.ForEach(m => Console.Write(m + " "));
            Console.WriteLine();

            // 防止链表为空时操作导致异常
            if (list.Head != null)
            {
                Console.Write("最大值为：");
                int max = list.Head.Value;
                list.ForEach(m => { if (m > max) max = m; });
                Console.WriteLine(max);

                Console.Write("最小值为：");
                int min = list.Head.Value;
                list.ForEach(m => { if (m < min) min = m; });
                Console.WriteLine(min);

                Console.Write("和为：");
                int sum = 0;
                list.ForEach(m => sum += m);
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("链表为空。");
            }
        }
    }
}
