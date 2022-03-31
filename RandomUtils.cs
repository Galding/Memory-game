using System;
using System.Collections.Generic;

namespace Memory_Game
{
    internal static class RandomUtils
    {
        public static List<int> GenerateRandomNumberList(int maxBound, int listSize)
        {
            Random random = new Random();
            List<int> result = new List<int>();
            for (int i = 0; i < listSize / 2; i++)
            {
                int ranValue;
                do
                {
                    ranValue = random.Next(maxBound) + 1;
                } while (result.Contains(ranValue));
                result.Add(ranValue);
                result.Add(ranValue);
            }
            result.Shuffle();
            return result;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            for (int i = list.Count - 1; i > 1; i--)
            {
                int ran = random.Next(i + 1);
                T value = list[ran];
                list[ran] = list[i];
                list[i] = value;
            }
        }
    }
}
