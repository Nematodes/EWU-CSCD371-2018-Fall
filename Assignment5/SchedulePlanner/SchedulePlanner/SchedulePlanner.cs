using System;
using System.Collections.Generic;
using static System.Environment;

namespace BrianBosAssignmentSix
{
    public class SchedulePlanner
    {
        public IConsole ConsoleInterface { get; set; }

        private List<IEvent> EventList;

        public SchedulePlanner()
        {
            ConsoleInterface = new CmdConsole();
            EventList = new List<IEvent>();
        }

        public SchedulePlanner(IConsole consoleInterface)
        {
            ConsoleInterface = consoleInterface;
            EventList = new List<IEvent>();
        }

        public static void Main(string[] args)
        {
            SchedulePlanner testSchedulePlanner = new SchedulePlanner();

            testSchedulePlanner.BeginPlanner();
        }

        public void BeginPlanner()
        {
            ConsoleInterface.ConsoleOutput($"Enter the option number of the action you would like to take.{NewLine}");

            string userInput;

            do
            {
                ConsoleInterface.ConsoleOutput($@"1.) Create an event{NewLine
                                                 }2.) List all current events{NewLine
                                                 }3.) Exit{NewLine}{NewLine
                                                 }What would you like to do?");

                userInput = ConsoleInterface.ConsoleInput();

                if (userInput.Equals("1"))
                {
                    HandleEventCreationChoiceDialogue();
                }
                else if (userInput.Equals("2"))
                {
                    ListEvents();
                }
                else if (!userInput.Equals("3"))
                {
                    ConsoleInterface.ConsoleOutput($"{NewLine}\"{userInput}\" is not a valid choice!{NewLine}");
                }
            } while (!userInput.ToLower().Equals("3"));
        }

        private void HandleEventCreationChoiceDialogue()
        {
            string userInput;

            ConsoleInterface.ConsoleOutput($"{NewLine}What kind of event would you like to create?{NewLine}");

            while (true)
            {
                ConsoleInterface.ConsoleOutput($@"1.) Event{NewLine
                                                 }2.) UniversityCourse{NewLine
                                                 }3.) Return{NewLine}");

                userInput = ConsoleInterface.ConsoleInput();

                if (userInput.Equals("1"))
                {
                    HandleEventCreationDialogue();
                    break;
                }
                else if (userInput.Equals("2"))
                {
                    HandleUniversityCourseCreationDialogue();
                    break;
                }
                else if (userInput.Equals("3"))
                {
                    break;
                }
                else
                {
                    ConsoleInterface.ConsoleOutput($"{NewLine}\"{userInput}\" is not a valid choice!{NewLine}");
                }
            }
        }

        private void HandleEventCreationDialogue()
        {
            Event newEvent = new Event();
            string userInput;

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the name of the event:");
            newEvent.Name = ConsoleInterface.ConsoleInput();

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the number of attendees:");
            userInput = ConsoleInterface.ConsoleInput();

            if (!int.TryParse(userInput, out int newEventAttendeeCount))
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                return;
            }
            else if (newEventAttendeeCount < 0)
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{newEventAttendeeCount}\" is less than zero!{NewLine}");
                return;
            }

            newEvent.NumberOfAttendees = newEventAttendeeCount;

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the date:");
            newEvent.Date = ConsoleInterface.ConsoleInput();

            EventList.Add(newEvent);
            ConsoleInterface.ConsoleOutput($"{NewLine}Event successfully added!{NewLine}");
        }

        private void HandleUniversityCourseCreationDialogue()
        {
            UniversityCourse newUniversityCourse = new UniversityCourse();
            string userInput;

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the name of the course:");
            newUniversityCourse.Name = ConsoleInterface.ConsoleInput();

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the number of attendees:");
            userInput = ConsoleInterface.ConsoleInput();

            if (!int.TryParse(userInput, out int newUniversityCourseIntegerArgument))
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                return;
            }
            else if (newUniversityCourseIntegerArgument < 0)
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{newUniversityCourseIntegerArgument}\" is less than zero!{NewLine}");
                return;
            }

            newUniversityCourse.NumberOfAttendees = newUniversityCourseIntegerArgument;

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the start date:");
            newUniversityCourse.StartDate = ConsoleInterface.ConsoleInput();

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the end date:");
            newUniversityCourse.EndDate = ConsoleInterface.ConsoleInput();

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the number of credit hours:");
            userInput = ConsoleInterface.ConsoleInput();

            if (!int.TryParse(userInput, out newUniversityCourseIntegerArgument))
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                return;
            }
            else if (newUniversityCourseIntegerArgument < 0)
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{newUniversityCourseIntegerArgument}\" is less than zero!{NewLine}");
                return;
            }

            newUniversityCourse.CreditHours = newUniversityCourseIntegerArgument;

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the number of waitlisted attendees:");
            userInput = ConsoleInterface.ConsoleInput();

            if (!int.TryParse(userInput, out newUniversityCourseIntegerArgument))
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                return;
            }
            else if (newUniversityCourseIntegerArgument < 0)
            {
                ConsoleInterface.ConsoleOutput($"{NewLine}\"{newUniversityCourseIntegerArgument}\" is less than zero!{NewLine}");
                return;
            }

            newUniversityCourse.NumberOfWaitlistedAttendees = newUniversityCourseIntegerArgument;

            ConsoleInterface.ConsoleOutput($"{NewLine}Enter the weekly schedule:");
            newUniversityCourse.WeeklySchedule = ConsoleInterface.ConsoleInput();

            EventList.Add(newUniversityCourse);
            ConsoleInterface.ConsoleOutput($"{NewLine}University course successfully added!{NewLine}");
        }

        private void ListEvents()
        {
            ConsoleInterface.ConsoleOutput("");

            if (EventList.Count == 0)
            {
                ConsoleInterface.ConsoleOutput($"There are no events in the event list!{NewLine}");
            }
            else
            {
                foreach (IEvent listEvent in EventList)
                {
                    ConsoleInterface.ConsoleOutput(listEvent.GetSummaryInformation() + NewLine);
                }
            }
        }
    }
}