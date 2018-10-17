using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignment4Namespace
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void DefaultConstructor_DefaultNameIsUnnamedEvent()
        {
            Event myEvent = new Event();

            Assert.IsTrue(myEvent.Name.Equals("Unnamed Event"));
        }

        [TestMethod]
        public void DefaultConstructor_DefaultNumberOfAttendeesIsZero()
        {
            Event myEvent = new Event();

            Assert.IsTrue(myEvent.NumberOfAttendees == 0);
        }

        [TestMethod]
        public void DefaultConstructor_DefaultDateIsThursday1January1970()
        {
            Event myEvent = new Event();

            Assert.IsTrue(myEvent.Date.Equals("Thursday, 1 January 1970"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NameIsSet()
        {
            Event myEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(myEvent.Name.Equals("Flibber Flabber Eating Competition"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NumberOfAttendeesIsSet()
        {
            Event myEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(myEvent.NumberOfAttendees == 2);
        }

        [TestMethod]
        public void Constructor_ValuesSet_DateIsSet()
        {
            Event myEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(myEvent.Date.Equals("Sunday, 13 June 2010"));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Constructor_NegativeNumberOfAttendees_ArgumentOutOfRangeExceptionIsThrown()
        {
            Event myEvent = new Event("Flibber Flabber Eating Competition", -2, "Sunday, 13 June 2010");
        }
    }
}