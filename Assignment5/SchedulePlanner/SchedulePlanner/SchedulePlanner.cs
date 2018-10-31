using System;
using System.Collections.Generic;
using static System.Environment;

namespace BrianBosAssignmentFive
{
    public class SchedulePlanner : IConsole
    {
        public static void Main(string[] args)
        {
            List<IEvent> eventList = new List<IEvent>();
            IConsole testSchedulePlanner = new SchedulePlanner();

            testSchedulePlanner.ConsoleOutput($"Enter the option number of the action you would like to take.{NewLine}");

            string userInput;

            do
            {
                testSchedulePlanner.ConsoleOutput($@"1.) Create an event{NewLine
                                                    }2.) List all current events{NewLine
                                                    }3.) Exit{NewLine}{NewLine
                                                    }What would you like to do?");

                userInput = Console.ReadLine();

                if (userInput.Equals("1"))
                {
                    testSchedulePlanner.ConsoleOutput($"{NewLine}What kind of event would you like to create?{NewLine}");

                    while (true)
                    {
                        testSchedulePlanner.ConsoleOutput($@"1.) Event{NewLine
                                                            }2.) UniversityCourse{NewLine
                                                            }3.) Return{NewLine}");

                        userInput = Console.ReadLine();

                        if (userInput.Equals("1"))
                        {
                            Event newEvent = new Event();

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the name of the event:");
                            newEvent.Name = Console.ReadLine();

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the number of attendees:");
                            userInput = Console.ReadLine();

                            if (!int.TryParse(userInput, out int newEventAttendeeCount))
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                                break;
                            }
                            else if (newEventAttendeeCount < 0)
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{newEventAttendeeCount}\" is less than zero!{NewLine}");
                                break;
                            }

                            newEvent.NumberOfAttendees = newEventAttendeeCount;

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the date:");
                            newEvent.Date = Console.ReadLine();

                            eventList.Add(newEvent);
                            testSchedulePlanner.ConsoleOutput($"{NewLine}Event successfully added!{NewLine}");

                            userInput = "";

                            break;
                        }
                        else if (userInput.Equals("2"))
                        {
                            UniversityCourse newUniversityCourse = new UniversityCourse();

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the name of the course:");
                            newUniversityCourse.Name = Console.ReadLine();

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the number of attendees:");
                            userInput = Console.ReadLine();

                            if (!int.TryParse(userInput, out int newUniversityCourseIntegerArgument))
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                                break;
                            }
                            else if (newUniversityCourseIntegerArgument < 0)
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{newUniversityCourseIntegerArgument}\" is less than zero!{NewLine}");
                                break;
                            }

                            newUniversityCourse.NumberOfAttendees = newUniversityCourseIntegerArgument;

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the start date:");
                            newUniversityCourse.StartDate = Console.ReadLine();

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the end date:");
                            newUniversityCourse.EndDate = Console.ReadLine();

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the number of credit hours:");
                            userInput = Console.ReadLine();

                            if (!int.TryParse(userInput, out newUniversityCourseIntegerArgument))
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                                break;
                            }
                            else if (newUniversityCourseIntegerArgument < 0)
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{newUniversityCourseIntegerArgument}\" is less than zero!{NewLine}");
                                break;
                            }

                            newUniversityCourse.CreditHours = newUniversityCourseIntegerArgument;

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the number of waitlisted attendees:");
                            userInput = Console.ReadLine();

                            if (!int.TryParse(userInput, out newUniversityCourseIntegerArgument))
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{userInput}\" is not an integer value!{NewLine}");
                                break;
                            }
                            else if (newUniversityCourseIntegerArgument < 0)
                            {
                                testSchedulePlanner.ConsoleOutput($"{NewLine}\"{newUniversityCourseIntegerArgument}\" is less than zero!{NewLine}");
                                break;
                            }

                            newUniversityCourse.NumberOfWaitlistedAttendees = newUniversityCourseIntegerArgument;

                            testSchedulePlanner.ConsoleOutput($"{NewLine}Enter the weekly schedule:");
                            newUniversityCourse.WeeklySchedule = Console.ReadLine();

                            eventList.Add(newUniversityCourse);
                            testSchedulePlanner.ConsoleOutput($"{NewLine}University course successfully added!{NewLine}");

                            userInput = "";

                            break;
                        }
                        else if (userInput.Equals("3"))
                        {
                            userInput = "";
                            break;
                        }
                        else
                        {
                            testSchedulePlanner.ConsoleOutput($"{NewLine}\"{userInput}\" is not a valid choice!{NewLine}");
                        }
                    }
                }
                else if (userInput.Equals("2"))
                {
                    testSchedulePlanner.ConsoleOutput("");

                    if (eventList.Count == 0)
                    {
                        testSchedulePlanner.ConsoleOutput($"There are no events in the event list!{NewLine}");
                    }
                    else
                    {
                        foreach (IEvent listEvent in eventList)
                        {
                            testSchedulePlanner.ConsoleOutput(listEvent.GetSummaryInformation() + NewLine);
                        }
                    }
                }
                else if (!userInput.Equals("3"))
                {
                    testSchedulePlanner.ConsoleOutput($"{NewLine}\"{userInput}\" is not a valid choice!{NewLine}");
                }
            } while (!userInput.ToLower().Equals("3"));
        }

        public void ConsoleOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}