using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NET.DZ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 1 Объявить одномерный(5 элементов) массив с именем A и двумерный массив(3 строки, 4 столбца) дробных чисел с именем B.Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, двумерный массив В случайными числами с помощью циклов.Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы.Найти в данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, общее произведение всех элементов, сумму четных элементов массива А, сумму нечетных столбцов массива В.


           
            Random rnd = new Random();
            double[,] Array = new double[3, 4];


            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Array[i, j] =Convert.ToDouble( rnd.Next(-10, 20))/10;
                    Console.Write("{0,6}", Array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            double[] arr = new double[5];
            for (int i11 = 0; i11 < arr.Length; i11++)
            {
                arr[i11] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("------------------------------------------------------------");
            for (int i11 = 0; i11 < arr.Length; i11++)
            {
                Console.Write("{0,6}", arr[i11]); Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            double max = 0;
            double min = 0;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    for(int k = 0; k < arr.Length; k++)
                    {
                        if (Array[i, j] == arr[k]) {
                             max = Array[i,j];
                             min = Array[i,j];
                            break;
                        }
                    }
                }
            }
            for (int k = 0; k < arr.Length; k++) {
                for (int i = 0; i < Array.GetLength(0); i++)
                {
                    for (int j = 0; j < Array.GetLength(1); j++)
                    {
                        if(Array[i, j] == arr[k])
                        {
                            if (Array[i, j] > max) { max = Array[i, j]; }
                            if (Array[i, j] < min) { min = Array[i, j]; }
                        }
                        
                    }
                }
            }
            Console.Write("max ->  "); Console.WriteLine(max);
            Console.Write("min ->  "); Console.WriteLine(min);
            Console.WriteLine("------------------------------------------------------------");

            double sum = 0;
            double mult=1;
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    sum += Array[i, j];
                    mult *= Array[i, j];
                }
            }
            for (int k = 0; k < arr.Length; k++)
            {
                sum  += arr[k];
                mult *= arr[k];
            }
            Console.Write("sum ->  "); Console.WriteLine(sum);
            Console.Write("mult ->  "); Console.WriteLine(mult);
            Console.WriteLine("------------------------------------------------------------");
            double sum1= 0;
            double sum2= 1;
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] % 2 == 0) { sum1 += arr[k]; }
            }
            Console.Write("sum1 ->  "); Console.WriteLine(sum1);
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    if (j % 2 > 0)
                    {
                        sum2 += Array[i, j];
                    }
                }
            }
            Console.Write("sum2 ->  "); Console.WriteLine(sum2);
            Console.WriteLine("------------------------------------------------------------");


            #endregion


            #region Задание 2  Дан двумерный массив размерностью 5×5, заполненный случайными числами из диапазона от –100 до 100.Определить сумму элементов массива, расположенных между минимальным и максимальным элементами.
            Random rnd1 = new Random();
            double[,] Array2 = new double[5, 5];


            for (int i = 0; i < Array2.GetLength(0); i++)
            {
                for (int j = 0; j < Array2.GetLength(1); j++)
                {
                    Array2[i, j] = Convert.ToDouble(rnd1.Next(-100, 100)) ;
                    Console.Write("{0,6}", Array2[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            double max3 = Array2[0, 0];
            double min3 = Array2[0, 0];
            int st = 0;
            int fn = 0;

            int st1 = 0;
            int fn1 = 0;

            for (int i = 0; i < Array2.GetLength(0); i++)
            {
                for (int j = 0; j < Array2.GetLength(1); j++)
                {
                    if (Array2[i, j] > max3) { max3 = Array2[i, j];st = i;fn = j; }
                    if (Array2[i, j] < min3) { min3 = Array2[i, j]; st1 = i;fn = j; }
                }
            }

          double sum5 = 0;
            if (st > st1 && fn > fn1) {
                for ( int d=st1; d <= st; d++)
                {
                    for (int l = fn1; l < fn; l++)
                    {
                        sum5 += Array2[ d, l];
                    }
                }
            }
            if (st > st1 && fn < fn1)
            {
                for (int d = st1; d <= st; d++)
                {
                    for (int l = fn; l < fn1; l++)
                    {
                        sum5 += Array2[d, l];
                    }
                }
            }
            if (st < st1 && fn > fn1)
            {
                for (int d = st; d <= st1; d++)
                {
                    for (int l = fn1; l < fn; l++)
                    {
                        sum5 += Array2[d, l];
                    }
                }
            }
            if (st < st1 && fn < fn1)
            {
                for (int d = st; d <= st1; d++)
                {
                    for (int l = fn; l < fn1; l++)
                    {
                        sum5 += Array2[d, l];
                    }
                }
            }
            Console.Write("max3->  "); Console.WriteLine(max3);
            Console.Write("min3 ->  "); Console.WriteLine(min3);
            Console.WriteLine();
            Console.Write("sum5 ->  "); Console.WriteLine(sum5);
            Console.WriteLine("------------------------------------------------------------");
            #endregion


            #region Задание 3 Пользователь вводит строку с клавиатуры.Необходимо зашифровать данную строку используя шифр Цезаря.

            string str= Console.ReadLine();
            int l1 = str.Length;
            char[] arr21 = str.ToCharArray();
            char[] arr23 = new char[arr21.Length];

            string alf = ("abcdefghijklmnopqrstuvwxyz");
            int l2 = alf.Length;
            char[] arr22 = alf.ToCharArray();
            Console.WriteLine("Enter encryption step -> ");
            int a3=Convert.ToInt32(Console.ReadLine());

            for(int i3 = 0; i3 < l1; i3++)
            {
                for (int j3 = 0; j3 < l2; j3++)
                {
                    if (arr21[i3] == arr22[j3] && (j3+a3)<l2)
                    {
                       arr23[i3] = arr22[j3 + a3];
                    }
                    else { arr23[i3] = arr21[i3]; }
                }
            }
            for(int c=0; c < l1; c++)
            {
                Console.Write(arr23[c]);

            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            #endregion


            #region Задание 4 Создайте приложение, которое производит операции над матрицами ■ Умножение матрицы на число;■ Сложение матриц;■ Произведение матриц.

            Random rnd12 = new Random();
            double[,] Array8 = new double[10, 10];
            for (int i = 0; i < Array8.GetLength(0); i++)
            {
                for (int j = 0; j < Array8.GetLength(1); j++)
                {
                    Array8[i, j] = Convert.ToDouble(rnd12.Next(10, 40));
                    Console.Write("{0,6}", Array8[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            double b =Convert.ToDouble(Console.ReadLine());
            for (int i = 0; i < Array8.GetLength(0); i++)
            {
                for (int j = 0; j < Array8.GetLength(1); j++)
                {
                    Array8[i, j] = Array8[i, j] * b;
                    Console.Write("{0,6}", Array8[i, j]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            double sum12 = 0;
            for (int i = 0; i < Array8.GetLength(0); i++)
            {
                for (int j = 0; j < Array8.GetLength(1); j++)
                {
                    sum12 = sum12+Array8[i, j];
                }
            }
            Console.WriteLine(sum12);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            double mult12 = 1;
            for (int i = 0; i < Array8.GetLength(0); i++)
            {
                for (int j = 0; j < Array8.GetLength(1); j++)
                {
                    mult12 = mult12 * Array8[i, j];
                }
            }
            Console.WriteLine(mult12);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            #endregion


            #region Задание 5 Пользователь с клавиатуры вводит в строку арифметическое выражение. Приложение должно посчитать его результат.Необходимо поддерживать только две операции: +и –.
            string str23 = Console.ReadLine();
            char[] arr32 = str.ToCharArray();
            int r8 = 0;
            int r9 = 0;
            int beg = 0;
            int a6= 0;
            int total = 0;
            for (int i = beg;i < arr32.Length; i++)
            {

                if(arr32[i] =='-' && arr32[i] == '+' && i<(arr32.Length - 1))
                {
                    r9 = i+1;
                    r8=i-1;
                    int lh = r8 - beg;
                    char[] arr33 = new char[lh];
                    for (int j = beg; j < lh; j++)
                    {
                        arr33[j] = arr32[beg];
                        beg++;
                    }
                    a6=Convert.ToInt32(arr33);
                    Console.WriteLine(a6);
                    if (beg==0) { total = a6; }
                    else if(beg>0) {
                        if (arr32[beg - 1] == '-' )
                        {
                            total = -a6;
                        }
                        else if(arr32[beg - 1] == '+')
                        {
                            total = +a6;
                        }

                     }
                }
            } 
            Console.WriteLine(total);   

            #endregion


            #region Задание 6 Пользователь с клавиатуры вводит некоторый текст.Приложение должно изменять регистр первой буквы каждого предложения на букву в верхнем регистре.
            string str5 = Console.ReadLine();
            int l5 = str5.Length;
            char[] arr25 = str5.ToCharArray();
            for (int i = 0; i < l5; i++)
            {
                arr25[0] = Char.ToUpper(Convert.ToChar(arr25[0]));
                if (str5[i] == '.' && i < (l5 - 2))
                {
                    arr25[i + 1] = Char.ToUpper(Convert.ToChar(arr25[i + 2]));
                }
                Console.Write(arr25[i]);
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            #endregion


            #region Задание 7 Создайте приложение, проверяющее текст на недопустимые слова. Если недопустимое слово найдено, оно должно быть заменено на набор символов *.По итогам работы приложения необходимо показать статистику действий.
            string str6 =( "To be, or not to be, that is the question,Whether 'tis nobler in the mind to suffer The slings and arrows of outrageous fortune,Or to take arms against a sea of troubles,And by opposing end them? To die: to sleep;No more; and by a sleep to say we end The heart-ache and the thousand natural shocks That flesh is heir to, 'tis a consummationDevoutly to be wish'd. To die, to sleep;");
            int l16 = str6.Length;
            char[] arr26 = str6.ToCharArray();
            char[] arr27 = new char[arr26.Length];


            Console.WriteLine("Enter an invalid word -> ");
            string str61= Console.ReadLine();
            int l26 = str61.Length;
            char[] arr28 = str61.ToCharArray();
            char[] arr29 = new char[l26];
            int k1 = 0;
            int k2= 0;  
            int stk= 0;
            for (int i = 0; i < l16; i++)
            {
                k1 = i;
                if(k1 < (l16 - l26))
                {
                    for (int j = 0; j < l26; j++)
                    {
                        arr29[j]=arr26[k1];
                        if (arr29[j] == arr28[j])
                        {
                            k2++;
                        }
                        k1++;
                    }
                }
                k1 = i;
                if (k2 == l26)
                {
                    stk++;
                    for(int j7 = 0;j7 < l26; j7++)
                    {
                        arr26[k1] = '*';
                        k1++;
                    }
                }
                k2 = 0;
            }
            for (int i = 0;i < l16; i++)
            {
                Console.Write(arr26[i]);
            }
            Console.WriteLine();
            Console.Write("Number of substitutions -> "); Console.WriteLine(stk);
            Console.WriteLine("------------------------------------------------------------");

            #endregion
        }
    }
}
