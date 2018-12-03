using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BrianBosAssignmentNine.PatentDataAnalyzer.Tests
{
    [TestClass]
    public class PatentDataAnalyzerTests
    {
        [TestMethod]
        public void InventorLastNames_ReturnedListIsCorrect()
        {
            List<string> correctInventorLastNameList = new List<string>
            {
                "Jacob",
                "Michaelis",
                "Stephenson",
                "Morse",
                "Wright",
                "Wright",
                "Franklin"
            };

            List<string> inventorLastNameList = PatentDataAnalyzer.InventorLastNames();

            Assert.IsTrue(Enumerable.SequenceEqual(inventorLastNameList, correctInventorLastNameList));
        }

        [TestMethod]
        public void InventorNames_CountryWithInventors_ReturnedListIsCorrect()
        {
            List<string> correctInventorNameList = new List<string>
            {
                "Benjamin Franklin",
                "Orville Wright",
                "Wilbur Wright",
                "Samuel Morse",
                "John Michaelis",
                "Mary Phelps Jacob"
            };

            List<string> inventorNameList = PatentDataAnalyzer.InventorNames("USA");

            Assert.IsTrue(Enumerable.SequenceEqual(inventorNameList, correctInventorNameList));
        }

        [TestMethod]
        public void InventorNames_CountryWithoutInventors_ReturnedListIsEmpty()
        {
            List<string> inventorNameList = PatentDataAnalyzer.InventorNames("CA");

            Assert.IsFalse(Enumerable.Any(inventorNameList));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void InventorNames_NullCountry_ArgumentNullExceptionIsThrown()
        {
            PatentDataAnalyzer.InventorNames(null);
        }

        [TestMethod]
        public void LocationsWithInventors_ReturnedStringIsCorrect()
        {
            string correctInventorStateCountryCombinations = "PA-USA, NC-USA, NY-USA, Northumberland-UK, IL-USA";
            string uniqueInventorStateCountryCombinations = PatentDataAnalyzer.LocationsWithInventors();

            Assert.IsTrue(uniqueInventorStateCountryCombinations == correctInventorStateCountryCombinations);
        }
    }
}