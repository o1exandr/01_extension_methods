/*
 Завдання 1.
Визначити методи розширення 
	для рваного цілочислового масиву(int [][])) : 	середнє арифметичне усіх елементів масиву
	для рядка(string) :  кількість входжень заданого слова (фрагмента) без врахування регістру букв
 */

using System;


namespace _01_extension_methods
{
    class Program
    {
        // заповнення масиву випадковими числами
        static void FillRand(int[][] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                    arr[i][j] = rand.Next(1, 10);
            }
        }

        // вивід  на екран
        static void Print(int[][] arr, string message = "")
        {
            Console.WriteLine(message);
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                    Console.Write($"{arr[i][j]}\t");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[][] arr = new int[4][]
            {
                new int[2],
                new int[1],
                new int[4],
                new int[3]
            };

            FillRand(arr);
            Print(arr);
            Console.WriteLine("\nAverage of array:\t{0}", arr.ArrayAverage());

            string str = "The old Latin maxim repetitio est mater studiorum seems to be applicable to the present case.";
            string word = "To";
            Console.WriteLine("\nString: {0}\nFind fragment: \"{1}\"", str, word);
            Console.WriteLine("\nQ-ty of word's repeat in string:\t{0}", str.CountWords(word));
        }


    }

    // для рваного цілочислового масиву(int [][])) : 	середнє арифметичне усіх елементів масиву
    static class ArrayExtensions
    {
        public static double ArrayAverage(this int[][] arr)
        {
            double avg = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    avg += arr[i][j];
                    ++count;
                }
            }
            return avg / count;
        }
    
    }

    // для рядка(string) :  кількість входжень заданого слова(фрагмента) без врахування регістру букв
    static class StringExtensions
    {
        public static int CountWords(this string str, string word)
        {
            str = str.ToLower();
            word = word.ToLower();
            int counterWord = (str.Length - str.Replace(word, "").Length) / word.Length;
            return counterWord;
        }

    }
}
