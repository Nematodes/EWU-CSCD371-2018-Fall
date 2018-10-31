using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentFive
{
    [TestClass]
    public class SchedulePlannerTests
    {
        private readonly string NL = System.Environment.NewLine;

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
        public void Main_InvalidChoice_OutputsNotAnInvalidChoice()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<Waffles{NL

                                      }>>{NL}""Waffles"" is not a valid choice!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_ListEvents_NoEventsListedMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<2{NL

                                      }>>{NL}There are no events in the event list!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateEvent_ListEvents_CreatedEventListed()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event:{NL
                                      }<<Marshmallow Dripping{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<31{NL

                                      }>>{NL}Enter the date:{NL
                                      }<<Saptembre 23rd{NL

                                      }>>{NL}Event successfully added!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<2{NL

                                      }>>{NL}Event name: Marshmallow Dripping{NL
                                      }Number of attendees: 31{NL
                                      }Date: Saptembre 23rd{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateEvent_InvalidAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event:{NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<Quesadilla{NL

                                      }>>{NL}""Quesadilla"" is not an integer value!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateEvent_NegativeAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event:{NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<-128{NL

                                      }>>{NL}""-128"" is less than zero!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateEvent_OverflowAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event:{NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<18446744073709551616{NL

                                      }>>{NL}""18446744073709551616"" is not an integer value!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateEvent_NegativeOverflowAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event:{NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<-18446744073709551616{NL

                                      }>>{NL}""-18446744073709551616"" is not an integer value!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateUniversityCourse_ListEvents_CreatedUniversityCourseListed()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date:{NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date:{NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours:{NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees:{NL
                                      }<<5{NL

                                      }>>{NL}Enter the weekly schedule:{NL
                                      }<<Monday-Friday 9:00 A.M.{NL

                                      }>>{NL}University course successfully added!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<2{NL

                                      }>>{NL}Course name: Architecture and Reorganization{NL
                                      }Enrolled students: 40{NL
                                      }Waitlisted students: 5{NL
                                      }Start date: June 2016{NL
                                      }End date: September 2016{NL
                                      }Credit hours: 6{NL
                                      }Weekly schedule: Monday-Friday 9:00 A.M.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateUniversityCourse_InvalidAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<Enchilada{NL

                                      }>>{NL}""Enchilada"" is not an integer value!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateUniversityCourse_NegativeAttendeeCount_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<-40{NL

                                      }>>{NL}""-40"" is less than zero!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateUniversityCourse_OverflowCreditHours_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date:{NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date:{NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours:{NL
                                      }<<18446744073709551616{NL

                                      }>>{NL}""18446744073709551616"" is not an integer value!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateUniversityCourse_NegativeCreditHours_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date:{NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date:{NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours:{NL
                                      }<<-184{NL

                                      }>>{NL}""-184"" is less than zero!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateUniversityCourse_NonIntegerWaitlistedAttendees_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date:{NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date:{NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours:{NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees:{NL
                                      }<<Tamale{NL

                                      }>>{NL}""Tamale"" is not an integer value!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateUniversityCourse_NegativeWaitlistedAttendees_ErrorMessage()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date:{NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date:{NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours:{NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees:{NL
                                      }<<-84{NL

                                      }>>{NL}""-84"" is less than zero!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }

        [TestMethod]
        public void Main_CreateEventsAndUniversityCourses_ListEvents_CreatedEventsAndUniversityCoursesListed()
        {
            string expectedOutput = $@">>Enter the option number of the action you would like to take.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event:{NL
                                      }<<Marshmallow Dripping{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<31{NL

                                      }>>{NL}Enter the date:{NL
                                      }<<Saptembre 23rd{NL

                                      }>>{NL}Event successfully added!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<1{NL

                                      }>>{NL}Enter the name of the event:{NL
                                      }<<Pumpkin Consumer{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<314{NL

                                      }>>{NL}Enter the date:{NL
                                      }<<March 14th{NL

                                      }>>{NL}Event successfully added!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Architecture and Reorganization{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<40{NL

                                      }>>{NL}Enter the start date:{NL
                                      }<<June 2016{NL

                                      }>>{NL}Enter the end date:{NL
                                      }<<September 2016{NL

                                      }>>{NL}Enter the number of credit hours:{NL
                                      }<<6{NL

                                      }>>{NL}Enter the number of waitlisted attendees:{NL
                                      }<<5{NL

                                      }>>{NL}Enter the weekly schedule:{NL
                                      }<<Monday-Friday 9:00 A.M.{NL

                                      }>>{NL}University course successfully added!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<1{NL

                                      }>>{NL}What kind of event would you like to create?{NL}{NL

                                      }1.) Event{NL
                                      }2.) UniversityCourse{NL
                                      }3.) Return{NL}{NL

                                      }<<2{NL

                                      }>>{NL}Enter the name of the course:{NL
                                      }<<Advanced Microsoft Office{NL

                                      }>>{NL}Enter the number of attendees:{NL
                                      }<<60{NL

                                      }>>{NL}Enter the start date:{NL
                                      }<<September 2017{NL

                                      }>>{NL}Enter the end date:{NL
                                      }<<December 2017{NL

                                      }>>{NL}Enter the number of credit hours:{NL
                                      }<<5{NL

                                      }>>{NL}Enter the number of waitlisted attendees:{NL
                                      }<<15{NL

                                      }>>{NL}Enter the weekly schedule:{NL
                                      }<<Monday-Friday 10:00 A.M.{NL

                                      }>>{NL}University course successfully added!{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<2{NL

                                      }>>{NL}Event name: Marshmallow Dripping{NL
                                      }Number of attendees: 31{NL
                                      }Date: Saptembre 23rd{NL}{NL

                                      }Event name: Pumpkin Consumer{NL
                                      }Number of attendees: 314{NL
                                      }Date: March 14th{NL}{NL

                                      }Course name: Architecture and Reorganization{NL
                                      }Enrolled students: 40{NL
                                      }Waitlisted students: 5{NL
                                      }Start date: June 2016{NL
                                      }End date: September 2016{NL
                                      }Credit hours: 6{NL
                                      }Weekly schedule: Monday-Friday 9:00 A.M.{NL}{NL

                                      }Course name: Advanced Microsoft Office{NL
                                      }Enrolled students: 60{NL
                                      }Waitlisted students: 15{NL
                                      }Start date: September 2017{NL
                                      }End date: December 2017{NL
                                      }Credit hours: 5{NL
                                      }Weekly schedule: Monday-Friday 10:00 A.M.{NL}{NL

                                      }1.) Create an event{NL
                                      }2.) List all current events{NL
                                      }3.) Exit{NL}{NL

                                      }What would you like to do?{NL
                                      }<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SchedulePlanner.Main);
        }
    }
}