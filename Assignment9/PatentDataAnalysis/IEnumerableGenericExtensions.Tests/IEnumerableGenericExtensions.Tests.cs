using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BrianBosAssignmentNine.IEnumerableGenericExtensions.Tests
{
    [TestClass]
    public class IEnumerableGenericExtensionsTests
    {
        [TestMethod]
        public void Randomize_FilledList_ListIsRandomized()
        {
            List<string> numberList = new List<string>
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten"
            };

            /*
             * It is possible that the randomized list just happens to be the same as the original list.
             * 
             * However, under the assumption that each possible list order is equally likely,
             * the chance of this occurring after 3 iterations using a list of 10 unique elements is approximately 1 in 1209600.
             */
            for (int i = 0; i < 3; i++)
            {
                Assert.IsFalse(Enumerable.SequenceEqual(numberList, numberList.Randomize()), $"numberList was equal to numberList.Randomize() on iteration {i + 1}");
            }
        }

        [TestMethod]
        public void Randomize_ListWithOneItem_ListIsUnchanged()
        {
            List<string> numberList = new List<string> { "One" };

            Assert.IsTrue(Enumerable.SequenceEqual(numberList, numberList.Randomize()));
        }

        [TestMethod]
        public void Randomize_EmptyList_ListIsEmpty()
        {
            List<string> numberList = new List<string>();

            Assert.IsFalse(numberList.Randomize().Any());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Randomize_NullList_ArgumentNullExceptionIsThrown()
        {
            List<string> numberList = null;

            /*
             * The ToList() call is required to force Randomize() to actually execute.
             * If this is not done, its execution will be deferred, meaning that no ArgumentNullException will be thrown.
             */
            numberList.Randomize().ToList();
        }
    }
}