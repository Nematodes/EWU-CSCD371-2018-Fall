using System;
using System.Collections.Generic;
using System.Linq;

// This project is separate from PatentDataAnalyzer because it has no relevance to patent data queries
namespace BrianBosAssignmentNine.IEnumerableGenericExtensions
{
    public static class IEnumerableGenericExtensions
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> inputEnumerable)
        {
            if (inputEnumerable is null)
            {
                throw new ArgumentNullException("Parameter \"inputEnumerable\" in method Randomize<T>(this IEnumerable<T> inputEnumerable) was null!");
            }

            List<T> inputEnumerableList = inputEnumerable.ToList();
            int randomIndex;
            Random randomNumberGenerator = new Random();

            for (int i = inputEnumerable.Count(); i > 0; i--)
            {
                randomIndex = randomNumberGenerator.Next(i);

                yield return inputEnumerableList[randomIndex];

                inputEnumerableList.RemoveAt(randomIndex);
            }
        }
    }
}