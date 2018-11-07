using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class ClockTimeTests
    {
        private ClockTime TestClockTime;

        [TestMethod]
        public void Constructor_ValidParameters_FieldsAreSet()
        {
            TestClockTime = new ClockTime(5, 13, 21);

            Assert.IsTrue(TestClockTime.Hours == 5);
            Assert.IsTrue(TestClockTime.Minutes == 13);
            Assert.IsTrue(TestClockTime.Seconds == 21);
        }

        [TestMethod]
        public void Constructor_NoParameters_FieldsAreDefault()
        {
            TestClockTime = new ClockTime();

            Assert.IsTrue(TestClockTime.Hours == 0);
            Assert.IsTrue(TestClockTime.Minutes == 0);
            Assert.IsTrue(TestClockTime.Seconds == 0);
        }

        [TestMethod]
        public void Constructor_InvalidLargeHour_HoursIsMaximized()
        {
            TestClockTime = new ClockTime(100, 13, 21);

            Assert.IsTrue(TestClockTime.Hours == 23);
        }

        [TestMethod]
        public void Constructor_InvalidLargeMinute_MinutesIsMaximized()
        {
            TestClockTime = new ClockTime(5, 200, 21);

            Assert.IsTrue(TestClockTime.Minutes == 59);
        }

        [TestMethod]
        public void Constructor_InvalidLargeSecond_SecondsIsMaximized()
        {
            TestClockTime = new ClockTime(5, 13, 255);

            Assert.IsTrue(TestClockTime.Seconds == 59);
        }
    }
}