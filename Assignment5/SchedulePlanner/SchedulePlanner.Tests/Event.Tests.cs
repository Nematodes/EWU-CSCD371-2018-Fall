using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class EventTests
    {
        private Event TestEvent { get; set; }

        [TestMethod]
        public void DefaultConstructor_DefaultNameIsUnnamedEvent()
        {
            TestEvent = new Event();

            Assert.IsTrue(TestEvent.Name.Equals("Unnamed Event"));
        }

        [TestMethod]
        public void DefaultConstructor_DefaultNumberOfAttendeesIsZero()
        {
            TestEvent = new Event();

            Assert.IsTrue(TestEvent.NumberOfAttendees == 0);
        }

        [TestMethod]
        public void DefaultConstructor_DefaultDateIsThursday1January1970()
        {
            TestEvent = new Event();

            Assert.IsTrue(TestEvent.Date.Equals("Thursday, 1 January 1970"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NameIsSet()
        {
            TestEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(TestEvent.Name.Equals("Flibber Flabber Eating Competition"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NumberOfAttendeesIsSet()
        {
            TestEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(TestEvent.NumberOfAttendees == 2);
        }

        [TestMethod]
        public void Constructor_ValuesSet_DateIsSet()
        {
            TestEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(TestEvent.Date.Equals("Sunday, 13 June 2010"));
        }

        [TestMethod]
        public void Constructor_ValuesNullOrZero_AllValuesSet()
        {
            TestEvent = new Event(null, 0, null);

            Assert.IsTrue(TestEvent.Date == null);
            Assert.IsTrue(TestEvent.Name == null);
            Assert.IsTrue(TestEvent.NumberOfAttendees == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Constructor_NegativeNumberOfAttendees_ArgumentOutOfRangeExceptionIsThrown()
        {
            TestEvent = new Event("Flibber Flabber Eating Competition", -2, "Sunday, 13 June 2010");
        }

        [TestMethod]
        public void GetSummaryInformation_SummaryIsValid()
        {
            TestEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(TestEvent.GetSummaryInformation().Equals($@"Event name: Flibber Flabber Eating Competition{Environment.NewLine
                                                                   }Number of attendees: 2{Environment.NewLine
                                                                   }Date: Sunday, 13 June 2010"));
        }

        [TestMethod]
        public void NumberOfInstantiatedScheduleItemsIsValid()
        {
            int initialInstantiatedCourses = Event.NumberOfInstantiatedScheduleItems;

            Assert.IsTrue(Event.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses);

            TestEvent = new Event("Flibber Flabber Eating Competition", 2, "Sunday, 13 June 2010");

            Assert.IsTrue(Event.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses + 1);

            Event TestEvent2 = new Event();

            Assert.IsTrue(Event.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses + 2);

            Event TestEvent3 = new Event();
            Event TestEvent4 = new Event();

            Assert.IsTrue(UniversityCourse.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses + 4);
        }
    }
}