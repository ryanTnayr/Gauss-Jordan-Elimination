using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入陣列階層");
            int n = Convert.ToInt32(Console.ReadLine());
            double[,] a = new double[n,n]; //目標矩陣
            double[,] b = new double[n,n]; //單位矩陣

            //單位矩陣附值
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        b[i, j] = 0;
                    }
                    else
                    {
                        b[i, j] = 1;
                    }
                }
            }

            Console.WriteLine("請輸入陣列內容");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("目前輸入陣列"+i.ToString()+j.ToString());
                    a[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }



            //三層 for 用意
            //第一 遍歷對角線元素(p)
            //第二 遍歷column元素以計算要乘得倍數 (i = p+1 開始)
            //第三 row 相加的遍歷(j)
            //1. 建立上三角矩陣
            for (int p = 0; p < n-1; p++)
            {
                for (int i = p+1; i < n; i++)
                {
                    if (a[i, p] == 0) //避免元素等於 0 ， 0 不能當分母
                    {
                        break; 
                    }

                    double x = -a[p, p] / a[i, p];

                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = a[i, j] * x + a[p, j];   // row 2 = row 2 * ( x ) + row 1
                        b[i, j] = b[i, j] * x + b[p, j];
                    }
                }
            }


            //2. 讓對角線位置的值都變成 1
            for (int i = 0; i < n; i++)
            {
                double x = 1 / a[i, i];

                for (int j = 0; j < n; j++)
                {
                    a[i, j] = a[i, j] * x;    //  row 1 * ( x )
                    b[i, j] = b[i, j] * x;
                }
            }

            //3. 反向碟代，使原矩陣成為單元矩陣
            for (int p = n-1; p > 0; p--)
            {
                for (int i = 0; i < p; i++)
                {
                    double x = -a[i, p] / a[p, p];

                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = a[p, j] * x + a[i, j];  // row 1 = row 3 * ( x ) + row 1 
                        b[i, j] = b[p, j] * x + b[i, j];
                    }
                }
            }




            Console.WriteLine("目前的陣列");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i, j]+"  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("目前的單元陣列");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(b[i, j] + "  ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
