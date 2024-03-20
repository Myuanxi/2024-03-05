using System;

namespace task4
{
    internal class Program
    {
        // 输入矩阵
        public int[,] InputMatrix()
        {
            Console.WriteLine("请输入矩阵的行数和列数");
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[m, n];
            Console.WriteLine("请输入矩阵内容");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }

        // 判断矩阵是否为斜线相等的矩阵
        public bool IsDiagonalEqual(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // 判断主对角线上的元素是否相等
            for (int i = 0; i < Math.Min(rows, cols) - 1; i++)
            {
                if (matrix[i, i] != matrix[i + 1, i + 1])
                {
                    return false;
                }
            }

            // 判断副对角线上的元素是否相等
            for (int i = 0; i < Math.Min(rows, cols) - 1; i++)
            {
                if (matrix[i, cols - i - 1] != matrix[i + 1, cols - i - 2])
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            var program = new Program();
            int[,] matrix = program.InputMatrix();
            bool isDiagonalEqual = program.IsDiagonalEqual(matrix);
            Console.WriteLine("该矩阵是否为斜线相等的矩阵：" + isDiagonalEqual);
        }
    }
}