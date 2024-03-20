using System;

namespace task3
{
    internal class Program
    {
        // 使用筛法求解素数
        public int[] SieveOfEratosthenes(int n)
        {
            bool[] prime = new bool[n + 1];
            for (int i = 0; i <= n; i++)
            {
                prime[i] = true; // 初始化所有数为素数
            }

            for (int p = 2; p * p <= n; p++)
            {
                // 如果 prime[p] 为 true，则 p 是素数
                if (prime[p] == true)
                {
                    // 将 p 的倍数标记为非素数
                    for (int i = p * 2; i <= n; i += p)
                    {
                        prime[i] = false;
                    }
                }
            }

            // 构建素数数组
            int count = 0;
            for (int p = 2; p <= n; p++)
            {
                if (prime[p])
                {
                    count++;
                }
            }

            int[] primes = new int[count];
            int idx = 0;
            for (int p = 2; p <= n; p++)
            {
                if (prime[p])
                {
                    primes[idx++] = p;
                }
            }

            return primes;
        }

        // 打印素数数组
        public void PrintPrimes(int[] primes)
        {
            foreach (int prime in primes)
            {
                Console.Write(prime + " ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("筛法求解素数：");
            int n = 100; // 求解范围为 1 到 100 之间的素数
            var program = new Program();
            int[] primes = program.SieveOfEratosthenes(n);
            program.PrintPrimes(primes);
        }
    }
}
