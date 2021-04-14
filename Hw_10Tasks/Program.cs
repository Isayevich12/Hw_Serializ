using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hw_10Tasks
{
    class Program
    {
        static (List<int[]>, List<int[]>) DoTask10(int[] arr)
        {
            List<int[]> t1 = new List<int[]>();
            List<int[]> t2 = new List<int[]>();

            for (int i = 0; i < arr.Length; i++)
            {
              
                int[] query1 = arr.Where(n => arr.Contains(arr[i]) && n % arr[i] == 0).ToArray();
                int[] query2 = arr.Where(n => arr.Contains(arr[i]) && arr[i] % n == 0).ToArray();
                t1.Add(query1);
                t2.Add(query2);
            }

          
            return (t1, t2);

        }

        static async Task Main(string[] args)
        {
            // ассинхронность здесь не нужна просто тренеруюсь
            int[] array = { 5, 2, 55, 44, 32, 85, 15, 1, 45, 48, 49, 110 };

            var result = await Task.Run(() => DoTask10(array));

            // показать решение первого пункта
            Console.WriteLine("Cписок элементов  массива которые делятся на каждый элемент без остатка");
            foreach (var arr in result.Item1)
            {
                foreach (var item in arr)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('_',60));

            // показать решение второго пункта
            Console.WriteLine("Cписок элементов  массива на которые делятся  каждый элемент без остатка");
            foreach (var arr in result.Item2)
            {
                foreach (var item in arr)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }


        }

       
    }
}
