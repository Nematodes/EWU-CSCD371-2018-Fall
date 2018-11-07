using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class UniversityCourseTests
    {
        private UniversityCourse TestUniversityCourse { get; set; }

        [TestMethod]
        public void DefaultConstructor_DefaultNameIsUnnamedCourse()
        {
            TestUniversityCourse = new UniversityCourse();

            Assert.IsTrue(TestUniversityCourse.Name.Equals("Unnamed Course"));
        }

        [TestMethod]
        public void DefaultConstructor_DefaultNumberOfAttendeesIsZero()
        {
            TestUniversityCourse = new UniversityCourse();

            Assert.IsTrue(TestUniversityCourse.NumberOfAttendees == 0);
        }

        [TestMethod]
        public void DefaultConstructor_DefaultStartDateIsThursday1January1970()
        {
            TestUniversityCourse = new UniversityCourse();

            Assert.IsTrue(TestUniversityCourse.StartDate.Equals("Thursday, 1 January 1970"));
        }

        [TestMethod]
        public void DefaultConstructor_DefaultEndDateIsMonday5January1970()
        {
            TestUniversityCourse = new UniversityCourse();

            Assert.IsTrue(TestUniversityCourse.EndDate.Equals("Monday, 5 January 1970"));
        }

        [TestMethod]
        public void DefaultConstructor_DefaultWeeklyScheduleIsNotApplicable()
        {
            TestUniversityCourse = new UniversityCourse();

            Assert.IsTrue(TestUniversityCourse.WeeklySchedule.Equals("N/A"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NameIsSet()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.Name.Equals("Steganography"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NumberOfAttendeesIsSet()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.NumberOfAttendees == 20);
        }

        [TestMethod]
        public void Constructor_ValuesSet_StartDateIsSet()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.StartDate.Equals("Wednesday, September 19 2018"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_EndDateIsSet()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.EndDate.Equals("Friday, December 7 2018"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_CreditHoursIsSet()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.CreditHours == 4);
        }

        [TestMethod]
        public void Constructor_ValuesSet_NumberOfWaitlistedAttendeesIsSet()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.NumberOfWaitlistedAttendees == 5);
        }

        [TestMethod]
        public void Constructor_ValuesSet_TotalAttendingStudentsIsValid()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.TotalAttendingStudents == 25);
        }

        [TestMethod]
        public void Constructor_ValuesSet_WeeklyScheduleIsSet()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(TestUniversityCourse.WeeklySchedule.Equals("Tuesdays and Thursdays, 3:00-5:50 PM"));
        }

        [TestMethod]
        public void Constructor_ValuesNullOrZero_AllValuesSet()
        {
            TestUniversityCourse = new UniversityCourse(null, 0, null, null, 0, 0, null);

            Assert.IsTrue(TestUniversityCourse.CreditHours == 0);
            Assert.IsTrue(TestUniversityCourse.EndDate == null);
            Assert.IsTrue(TestUniversityCourse.Name == null);
            Assert.IsTrue(TestUniversityCourse.NumberOfAttendees == 0);
            Assert.IsTrue(TestUniversityCourse.NumberOfWaitlistedAttendees == 0);
            Assert.IsTrue(TestUniversityCourse.StartDate == null);
            Assert.IsTrue(TestUniversityCourse.TotalAttendingStudents == 0);
            Assert.IsTrue(TestUniversityCourse.WeeklySchedule == null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Constructor_NegativeNumberOfAttendees_ArgumentOutOfRangeExceptionIsThrown()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", -20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Constructor_NegativeNumberOfWaitlistedAttendees_ArgumentOutOfRangeExceptionIsThrown()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, -100, "Tuesdays and Thursdays, 3:00-5:50 PM");
        }

        [TestMethod]
        public void GetSummaryInformation_SummaryIsValid()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");


            Assert.IsTrue(TestUniversityCourse.GetSummaryInformation().Equals($@"Course name: Steganography{Environment.NewLine
                                                                              }Enrolled students: 20{Environment.NewLine
                                                                              }Waitlisted students: 5{Environment.NewLine
                                                                              }Start date: Wednesday, September 19 2018{Environment.NewLine
                                                                              }End date: Friday, December 7 2018{Environment.NewLine
                                                                              }Credit hours: 4{Environment.NewLine
                                                                              }Weekly schedule: Tuesdays and Thursdays, 3:00-5:50 PM"));
        }

        [TestMethod]
        public void NumberOfInstantiatedScheduleItemsIsValid()
        {
            // Other tests may run before this one, so NumberOfInstantiatedScheduleItems cannot be assumed to start at zero
            int initialInstantiatedCourses = UniversityCourse.NumberOfInstantiatedScheduleItems;

            Assert.IsTrue(UniversityCourse.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses);

            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            Assert.IsTrue(UniversityCourse.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses + 1);

            UniversityCourse testUniversityCourse2 = new UniversityCourse();

            Assert.IsTrue(UniversityCourse.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses + 2);

            UniversityCourse testUniversityCourse3 = new UniversityCourse();
            UniversityCourse testUniversityCourse4 = new UniversityCourse();

            Assert.IsTrue(UniversityCourse.NumberOfInstantiatedScheduleItems == initialInstantiatedCourses + 4);
        }

        [TestMethod]
        public void Deconstructor_MembersInitialized_ReturnedValuesAreIdentical()
        {
            TestUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5, "Tuesdays and Thursdays, 3:00-5:50 PM");

            (string Name, int NumberOfAttendees, string StartDate, string EndDate, int CreditHours, int NumberOfWaitlistedAttendees, string WeeklySchedule) = TestUniversityCourse;

            Assert.IsTrue(Name.Equals("Steganography"));
            Assert.IsTrue(NumberOfAttendees == 20);
            Assert.IsTrue(StartDate.Equals("Wednesday, September 19 2018"));
            Assert.IsTrue(EndDate.Equals("Friday, December 7 2018"));
            Assert.IsTrue(CreditHours == 4);
            Assert.IsTrue(NumberOfWaitlistedAttendees == 5);
            Assert.IsTrue(WeeklySchedule.Equals("Tuesdays and Thursdays, 3:00-5:50 PM"));
        }
    }
}