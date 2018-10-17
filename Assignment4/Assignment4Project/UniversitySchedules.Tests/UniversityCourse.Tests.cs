using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignment4Namespace
{
    [TestClass]
    public class UniversityCourseTests
    {
        [TestMethod]
        public void DefaultConstructor_DefaultNameIsUnnamedCourse()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse();

            Assert.IsTrue(myUniversityCourse.Name.Equals("Unnamed Course"));
        }

        [TestMethod]
        public void DefaultConstructor_DefaultNumberOfAttendeesIsZero()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse();

            Assert.IsTrue(myUniversityCourse.NumberOfAttendees == 0);
        }

        [TestMethod]
        public void DefaultConstructor_DefaultStartDateIsThursday1January1970()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse();

            Assert.IsTrue(myUniversityCourse.StartDate.Equals("Thursday, 1 January 1970"));
        }

        [TestMethod]
        public void DefaultConstructor_DefaultEndDateIsMonday5January1970()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse();

            Assert.IsTrue(myUniversityCourse.EndDate.Equals("Monday, 5 January 1970"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NameIsSet()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5);

            Assert.IsTrue(myUniversityCourse.Name.Equals("Steganography"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_NumberOfAttendeesIsSet()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5);

            Assert.IsTrue(myUniversityCourse.NumberOfAttendees == 20);
        }

        [TestMethod]
        public void Constructor_ValuesSet_StartDateIsSet()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5);

            Assert.IsTrue(myUniversityCourse.StartDate.Equals("Wednesday, September 19 2018"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_EndDateIsSet()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5);

            Assert.IsTrue(myUniversityCourse.EndDate.Equals("Friday, December 7 2018"));
        }

        [TestMethod]
        public void Constructor_ValuesSet_CreditHoursIsSet()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5);

            Assert.IsTrue(myUniversityCourse.CreditHours == 4);
        }

        [TestMethod]
        public void Constructor_ValuesSet_NumberOfWaitlistedAttendeesIsSet()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5);

            Assert.IsTrue(myUniversityCourse.NumberOfWaitlistedAttendees == 5);
        }

        [TestMethod]
        public void Constructor_ValuesSet_TotalAttendingStudentsIsValid()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, 5);

            Assert.IsTrue(myUniversityCourse.TotalAttendingStudents == 25);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Constructor_NegativeNumberOfWaitlistedAttendees_ArgumentOutOfRangeExceptionIsThrown()
        {
            UniversityCourse myUniversityCourse = new UniversityCourse("Steganography", 20, "Wednesday, September 19 2018", "Friday, December 7 2018", 4, -100);
        }
    }
}
