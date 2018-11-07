using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class ScheduleTests
    {
        private Schedule TestSchedule;

        [TestMethod]
        public void Constructor_ValidParameters_FieldsAreSet()
        {
            TimeSpan testTimeSpan = new TimeSpan(10000000);
            TestSchedule = new Schedule(Schedule.DayName.Tuesday, Schedule.CollegeQuarter.Fall, new ClockTime(19, 36, 25), testTimeSpan);

            Assert.IsTrue(TestSchedule.DayOfWeek == Schedule.DayName.Tuesday);
            Assert.IsTrue(TestSchedule.Quarter == Schedule.CollegeQuarter.Fall);
            Assert.IsTrue(TestSchedule.StartTime.Hours == 19);
            Assert.IsTrue(TestSchedule.StartTime.Minutes == 36);
            Assert.IsTrue(TestSchedule.StartTime.Seconds == 25);
            Assert.IsTrue(TestSchedule.Duration.Equals(testTimeSpan));
        }

        [TestMethod]
        public void Constructor_NoParameters_FieldsAreDefault()
        {
            TestSchedule = new Schedule();

            Assert.IsTrue(TestSchedule.DayOfWeek == Schedule.DayName.None);
            Assert.IsTrue(TestSchedule.Quarter == Schedule.CollegeQuarter.None);
            Assert.IsTrue(TestSchedule.StartTime.Hours == 0);
            Assert.IsTrue(TestSchedule.StartTime.Minutes == 0);
            Assert.IsTrue(TestSchedule.StartTime.Seconds == 0);
            Assert.IsTrue(TestSchedule.Duration.Equals(new TimeSpan()));
        }

        [TestMethod]
        public void Constructor_DayOfWeekMondayString_DayOfWeekIsMonday()
        {
            TestSchedule = new Schedule("Monday", Schedule.CollegeQuarter.Fall, new ClockTime(19, 36, 25), new TimeSpan(10000000));

            Assert.IsTrue(TestSchedule.DayOfWeek == Schedule.DayName.Monday);
        }

        [TestMethod]
        public void Constructor_DayOfWeekSaturdaySundayWednesdayString_DayOfWeekIsMonday()
        {
            TestSchedule = new Schedule("Saturday, Sunday, Wednesday", Schedule.CollegeQuarter.Fall, new ClockTime(19, 36, 25), new TimeSpan(10000000));

            Assert.IsTrue(TestSchedule.DayOfWeek == (Schedule.DayName.Saturday | Schedule.DayName.Sunday | Schedule.DayName.Wednesday));
        }

        [TestMethod]
        public void Constructor_DayOfWeekInvalidString_DayOfWeekIsNone()
        {
            TestSchedule = new Schedule("Noneday", Schedule.CollegeQuarter.Fall, new ClockTime(19, 36, 25), new TimeSpan(10000000));

            Assert.IsTrue(TestSchedule.DayOfWeek == Schedule.DayName.None);
        }

        [TestMethod]
        public void Constructor_QuarterSpringString_QuarterIsSpring()
        {
            TestSchedule = new Schedule(Schedule.DayName.Tuesday, "Spring", new ClockTime(19, 36, 25), new TimeSpan(10000000));

            Assert.IsTrue(TestSchedule.Quarter == Schedule.CollegeQuarter.Spring);
        }

        [TestMethod]
        public void Constructor_QuarterInvalidString_QuarterIsNone()
        {
            TestSchedule = new Schedule(Schedule.DayName.Tuesday, "Duck Season", new ClockTime(19, 36, 25), new TimeSpan(10000000));

            Assert.IsTrue(TestSchedule.Quarter == Schedule.CollegeQuarter.None);
        }

        [TestMethod]
        public void Schedule_UnmanagedSizeIsLessThan16Bytes()
        {
            TestSchedule = new Schedule(Schedule.DayName.Tuesday, Schedule.CollegeQuarter.Fall, new ClockTime(19, 36, 25), new TimeSpan(10000000));

            Assert.IsTrue(System.Runtime.InteropServices.Marshal.SizeOf<Schedule>(TestSchedule) <= 16);
        }
    }
}