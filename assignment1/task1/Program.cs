using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // 输入操作数和运算符
                Console.WriteLine("请输入第一个操作数:");
                int ope1;
                if (!int.TryParse(Console.ReadLine(), out ope1))
                {
                    Console.WriteLine("您输入的操作数非法。");
                    continue;
                }

                Console.WriteLine("请输入运算符:");
                char @ope;
                if (!char.TryParse(Console.ReadLine(), out @ope))
                {
                    Console.WriteLine("您输入的运算符非法。");
                    continue;
                }

                Console.WriteLine("请输入第二个操作数:");
                int ope2;
                if (!int.TryParse(Console.ReadLine(), out ope2))
                {
                    Console.WriteLine("您输入的操作数非法。");
                    continue;
                }

                // 执行运算并输出结果
                double result;
                switch (@ope)
                {
                    case '+':
                        result = ope1 + ope2;
                        break;
                    case '-':
                        result = ope1 - ope2;
                        break;
                    case '*':
                        result = ope1 * ope2;
                        break;
                    case '/':
                        if (ope2 == 0)
                        {
                            Console.WriteLine("除数不能为0，请重新输入。");
                            continue;
                        }
                        result = (double)ope1 / ope2;
                        break;
                    default:
                        Console.WriteLine("您输入的运算符非法。");
                        continue;
                }

                Console.WriteLine($"运算结果: {ope1} {@ope} {ope2} = {result}");

                // 询问用户是否继续
                Console.WriteLine("是否继续计算？(Y/N)");
                string input = Console.ReadLine();
                if (input != null && input.Trim().ToUpper() != "Y")
                {
                    break;
                }
            }
        }
    }
}
