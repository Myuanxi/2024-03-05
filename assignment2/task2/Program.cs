using System;

namespace task2
{
    internal class Program
    {
        public int Max(int[] a)
        {
            int max = a[0]; // 将最大值初始化为数组的第一个元素
            for (int i = 1; i < a.Length; i++) // 从第二个元素开始比较
            {
                if (a[i] > max)
                    max = a[i];
            }
            return max;
        }

        public int Min(int[] a)
        {
            int min = a[0]; // 将最小值初始化为数组的第一个元素
            for (int i = 1; i < a.Length; i++) // 从第二个元素开始比较
            {
                if (a[i] < min)
                    min = a[i];
            }
            return min;
        }

        public int Sum(int[] a)
        {
            int sum = 0;
            foreach (int num in a) // 使用 foreach 循环计算总和
            {
                sum += num;
            }
            return sum;
        }

        public double Ave(int[] a)
        {
            int sum = 0;
            foreach (int num in a) // 使用 foreach 循环计算总和
            {
                sum += num;
            }
            return (double)sum / a.Length; // 使用 double 类型进行除法运算
        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入数字的个数以及各个数字");
            int len = int.Parse(Console.ReadLine());
            if (len <= 0)
            {
                Console.WriteLine("请输入有效的数字个数！");
                return;
            }

            int[] numbers = new int[len]; // 重命名数组变量
            for (int i = 0; i < len; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            var sol = new Program();
            Console.WriteLine("最大值是" + sol.Max(numbers));
            Console.WriteLine("最小值是" + sol.Min(numbers));
            Console.WriteLine("总和是" + sol.Sum(numbers));
            Console.WriteLine("平均值是" + sol.Ave(numbers));
        }
    }
}
