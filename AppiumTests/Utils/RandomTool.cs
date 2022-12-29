using System;
using System.Collections.Generic;

namespace AppiumTests.Utils
{
    public static class RandomTool
    {
        /// <summary>
        /// Method for getting random numbers.
        /// </summary>
        /// <param name="count">Count of numbers</param>
        /// <param name="min">Minimal value of probably numbers</param>
        /// <param name="max">Maximal value of probably numbers</param>
        /// <returns>Vector of random numbers</returns>
        public static int[] GetRandomNumbers(int count, int min, int max)
        {
            Random random = new Random();
            int[] randomnumbers = new int[count];
            var alreadyused = new HashSet<int>();
            for (int n = 0; n < count; n++)
            {
                randomnumbers[n] = random.Next(min, max);
                if (!alreadyused.Contains(randomnumbers[n]))
                    alreadyused.Add(randomnumbers[n]);
                else n--;
            }
            return randomnumbers;
        }

        public static string GetRandomText(int countOfWords = 1)
        {
            string randomString = string.Empty;
            int countOfLetters;
            Random random = new Random();

            for (int i = 0; i < countOfWords; i++)
            {
                countOfLetters = random.Next(5, 10);
                for (int j = 0; j < countOfLetters; j++)
                {
                    char letter = (char)random.Next(65, 91);
                    if (letter % 2 == 0) 
                        letter = char.ToLower(letter);
                    randomString += letter;
                }
                if (i != countOfWords - 1)
                {
                    randomString += ' ';
                }
            }
            return randomString;
        }
    }
}