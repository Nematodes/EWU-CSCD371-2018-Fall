using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class SchedulePlannerTests
    {
        private SchedulePlanner TestSchedulePlanner;

        // This class is nested and private because it has limited functionality and is for use solely by SchedulePlannerTests
        private class TestConsole : IConsole
        {
            public string ConsoleInput()
            {
                return System.Console.ReadLine();
            }

            public void ConsoleOutput(string output)
            {
                System.Console.WriteLine(output + " (Unit Test Output)"); // The additional "(Unit Test Output)" output exists to differentiate TestConsole from CmdConsole
            }
        }

        private readonly string NL = System.Environment.NewLine;

        [TestInitialize]
        public void InitializeSchedulePlanner()
        {
            TestSchedulePlanner = new SchedulePlanner(new TestConsole());
        }

        /*
         * This is here to test the implementation of IConsole that SchedulePlanner uses (i.e. CmdConsole)
         * 
         * It is somewhat strange to test CmdConsole in SchedulePlanner.Tests.
         * This was done because I am unsure how to test for console output within a unit test
         * (Intellitect.TestTools.Console.ConsoleAssert.Expect takes a delegate parameter, but the unit test wouldn't be able to pass one in.)
         */
        [TestMethod]
        public void Main_InputExit_ProgramExits()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void BeginPlanner_InputExit_ProgramExits()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_InvalidChoice_OutputsNotAnInvalidChoice()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<Waffles{NL

                                      }>>{NL}""Waffles"" is not a valid choice!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_ListEvents_NoEventsListedMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<2{NL

                                      }>> (Unit Test Output){NL}There are no events in the event list!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateEvent_ListEvents_CreatedEventListed()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event: (Unit Test Output){NL
                                      }<<Marshmallow Dripping{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<31{NL

                                      }>>{NL}Enter the date: (Unit Test Output){NL
                                      }<<Saptembre 23rd{NL

                                      }>>{NL}Event successfully added!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<2{NL

                                      }>> (Unit Test Output){NL}Event name: Marshmallow Dripping{NL
                                      }Number of attendees: 31{NL
                                      }Date: Saptembre 23rd{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateEvent_InvalidAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event: (Unit Test Output){NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<Quesadilla{NL

                                      }>>{NL}""Quesadilla"" is not an integer value!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateEvent_NegativeAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event: (Unit Test Output){NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<-128{NL

                                      }>>{NL}""-128"" is less than zero!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateEvent_OverflowAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event: (Unit Test Output){NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<18446744073709551616{NL

                                      }>>{NL}""18446744073709551616"" is not an integer value!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateEvent_NegativeOverflowAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event: (Unit Test Output){NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<-18446744073709551616{NL

                                      }>>{NL}""-18446744073709551616"" is not an integer value!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateUniversityCourse_ListEvents_CreatedUniversityCourseListed()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date: (Unit Test Output){NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date: (Unit Test Output){NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours: (Unit Test Output){NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees: (Unit Test Output){NL
                                      }<<5{NL

                                      }>>{NL}Enter the weekly schedule: (Unit Test Output){NL
                                      }<<Monday-Friday 9:00 A.M.{NL

                                      }>>{NL}University course successfully added!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<2{NL

                                      }>> (Unit Test Output){NL}Course name: Architecture and Reorganization{NL
                                      }Enrolled students: 40{NL
                                      }Waitlisted students: 5{NL
                                      }Start date: June 2016{NL
                                      }End date: September 2016{NL
                                      }Credit hours: 6{NL
                                      }Weekly schedule: Monday-Friday 9:00 A.M.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateUniversityCourse_InvalidAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<Enchilada{NL

                                      }>>{NL}""Enchilada"" is not an integer value!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateUniversityCourse_NegativeAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<-40{NL

                                      }>>{NL}""-40"" is less than zero!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateUniversityCourse_OverflowCreditHours_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date: (Unit Test Output){NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date: (Unit Test Output){NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours: (Unit Test Output){NL
                                      }<<18446744073709551616{NL

                                      }>>{NL}""18446744073709551616"" is not an integer value!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateUniversityCourse_NegativeCreditHours_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date: (Unit Test Output){NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date: (Unit Test Output){NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours: (Unit Test Output){NL
                                      }<<-184{NL

                                      }>>{NL}""-184"" is less than zero!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateUniversityCourse_NonIntegerWaitlistedAttendees_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date: (Unit Test Output){NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date: (Unit Test Output){NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours: (Unit Test Output){NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees: (Unit Test Output){NL
                                      }<<Tamale{NL

                                      }>>{NL}""Tamale"" is not an integer value!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateUniversityCourse_NegativeWaitlistedAttendees_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date: (Unit Test Output){NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date: (Unit Test Output){NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours: (Unit Test Output){NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees: (Unit Test Output){NL
                                      }<<-84{NL

                                      }>>{NL}""-84"" is less than zero!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }

        [TestMethod]
        public void BeginPlanner_CreateEventsAndUniversityCourses_ListEvents_CreatedEventsAndUniversityCoursesListed()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event: (Unit Test Output){NL
                                      }<<Marshmallow Dripping{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<31{NL

                                      }>>{NL}Enter the date: (Unit Test Output){NL
                                      }<<Saptembre 23rd{NL

                                      }>>{NL}Event successfully added!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event: (Unit Test Output){NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<314{NL

                                      }>>{NL}Enter the date: (Unit Test Output){NL
                                      }<<March 14th{NL

                                      }>>{NL}Event successfully added!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date: (Unit Test Output){NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date: (Unit Test Output){NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours: (Unit Test Output){NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees: (Unit Test Output){NL
                                      }<<5{NL

                                      }>>{NL}Enter the weekly schedule: (Unit Test Output){NL
                                      }<<Monday-Friday 9:00 A.M.{NL

                                      }>>{NL}University course successfully added!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL
                                      } (Unit Test Output){NL
                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL
                                      } (Unit Test Output){NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course: (Unit Test Output){NL
                                      }<<Advanced Microsoft Office{NL

                                      }>>{NL}Enter the number of attendees: (Unit Test Output){NL
                                      }<<60{NL

                                      }>>{NL}Enter the start date: (Unit Test Output){NL
                                      }<<September 2017{NL

                                      }>>{NL}Enter the end date: (Unit Test Output){NL
                                      }<<December 2017{NL

                                      }>>{NL}Enter the number of credit hours: (Unit Test Output){NL
                                      }<<5{NL

                                      }>>{NL}Enter the number of waitlisted attendees: (Unit Test Output){NL
                                      }<<15{NL

                                      }>>{NL}Enter the weekly schedule: (Unit Test Output){NL
                                      }<<Monday-Friday 10:00 A.M.{NL

                                      }>>{NL}University course successfully added!{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<2{NL

                                      }>> (Unit Test Output){NL}Event name: Marshmallow Dripping{NL
                                      }Number of attendees: 31{NL
                                      }Date: Saptembre 23rd{NL
                                      } (Unit Test Output){NL
                                      }Event name: Pumpkin Consumer{NL
                                      }Number of attendees: 314{NL
                                      }Date: March 14th{NL
                                      } (Unit Test Output){NL
                                      }Course name: Architecture and Reorganization{NL
                                      }Enrolled students: 40{NL
                                      }Waitlisted students: 5{NL
                                      }Start date: June 2016{NL
                                      }End date: September 2016{NL
                                      }Credit hours: 6{NL
                                      }Weekly schedule: Monday-Friday 9:00 A.M.{NL
                                      } (Unit Test Output){NL
                                      }Course name: Advanced Microsoft Office{NL
                                      }Enrolled students: 60{NL
                                      }Waitlisted students: 15{NL
                                      }Start date: September 2017{NL
                                      }End date: December 2017{NL
                                      }Credit hours: 5{NL
                                      }Weekly schedule: Monday-Friday 10:00 A.M.{NL
                                      } (Unit Test Output){NL
                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do? (Unit Test Output){NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, TestSchedulePlanner.BeginPlanner);
        }
    }
}