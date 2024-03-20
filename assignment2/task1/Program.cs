using System;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int data = int.Parse(Console.ReadLine());
            int temp = 2;
            int[] rec = new int[data]; // 调整数组大小
            int j = 0; // 修改数组索引起始值
            while (data >= temp)
            {
                if (data % temp == 0)
                {
                    data /= temp;
                    if (rec[j - 1] != temp) // 避免记录重复的质因数
                    {
                        rec[j] = temp;
                        j++;
                    }
                }
                else
                {
                    temp++;
                }
            }
            for (int i = 0; i < j; i++) // 修改循环条件
            {
                Console.Write(rec[i] + " ");
            }
        }
    }
}
