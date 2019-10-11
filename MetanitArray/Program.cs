using System;

namespace MetanitArray
{
    class Program
    {
        /// <summary>
        /// Генерация чисел до количество точек.
        /// </summary>
        /// <param name="count">Количество точек.</param>
        /// <param name="numbers">Числа.</param>
        static void Range(int count, out int[] numbers)
        {
            if (count < 0)
            {
                throw new ArgumentException();
            }

            numbers = new int[count];

            count--;

            if (count != 0)
            {
                numbers[count] = count;

                Range(count, out int[] tempNumbers);

                for (int index = 0; index < tempNumbers.Length; index++)
                {
                    numbers[index] = tempNumbers[index];
                }
            }
        }
        /// <summary>
        /// Генерация чисел от/до начальной точки.
        /// </summary>
        /// <param name="start">Начальная точка.</param>
        /// <param name="count">Количесто от/до начальной точки.</param>
        /// <param name="isBack"></param>
        /// <returns>Массив чисел.</returns>
        static int[] Range(int start, int count, bool isBack = false)
        {
            bool isLess = (count < 0);
            
            if (!isBack && isLess)
            {
                throw new ArgumentException();
            }

            if (isLess)
            {
                count = Math.Abs(count);
            }

            Range(count + 1, out int[] numbers);

            for (int index = 0; index < numbers.Length; index++)
            {
                if (isLess)
                {
                    // Magic

                    int difference = ((-count + start) + start);

                    int op = difference <= 0 ? Math.Abs(difference) : -difference;

                    numbers[index] -= start + op;
                }
                else
                {
                    numbers[index] += start;
                }
            }

            return numbers;
        }
        /// <summary>
        /// Генерация чисел от начальной точки до конечной точки.
        /// </summary>
        /// <param name="start">Начальная точка.</param>
        /// <param name="end">Конечная точка.</param>
        /// <returns>Массив чисел.</returns>
        static int[] Range(int start, int end)
        {
            return Range(start, end - start, true);
        }

        static void Main(string[] args)
        {
            #region Range 2

            Console.WriteLine("Range (2)");

            Range(5, out int[] numbers);

            foreach (var number in numbers)
            {
                Console.Write("{0}, ", number);
            }

            Console.WriteLine();

            #endregion

            #region Range 3

            Console.WriteLine("Range (3)");

            foreach (var number in Range(3, -5, true))
            {
                Console.Write("{0}, ", number);
            }

            Console.WriteLine();

            #endregion

            #region Range 1

            Console.WriteLine("Range (1)");

            foreach (var number in Range(3, -5))
            {
                Console.Write("{0}, ", number);
            }

            Console.WriteLine();

            #endregion
        }
    }
}