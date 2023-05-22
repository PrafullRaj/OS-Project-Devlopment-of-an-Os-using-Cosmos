using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel2
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine(@"
  /$$$$$$         /$$$$$$          /$$        /$$$$$$ 
 /$$__  $$       /$$__  $$       /$$$$       /$$$_  $$
| $$  \ $$      | $$  \__/      |_  $$      | $$$$\ $$
| $$  | $$      |  $$$$$$         | $$      | $$ $$ $$
| $$  | $$       \____  $$        | $$      | $$\ $$$$
| $$  | $$       /$$  \ $$        | $$      | $$ \ $$$
|  $$$$$$/      |  $$$$$$/       /$$$$$$ /$$|  $$$$$$/
 \______/        \______/       |______/|__/ \______/ 
                                                      
                                                      
                                                      
\t");
            Console.WriteLine("Cosmos booted successfully.");

            Console.WriteLine("Type 'notepad' to open a basic text editor, 'calculator' to open a simple calculator, 'calendar' to view the calendar, or 'taskmanager' to open the task manager.");
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();

            if (input == "notepad")
            {
                RunNotepad();
            }
            else if (input == "calculator")
            {
                RunCalculator();
            }
            else if (input == "calendar")
            {
                RunCalendar();
            }
            else if (input == "shutdown")
            {
                Cosmos.System.Power.Shutdown();
            }
            else if (input == "restart")
            {
                Cosmos.System.Power.Reboot();
            }
            else
            {
                Console.WriteLine("Unknown command.");
            }
        }

        private void RunNotepad()
        {
            Console.WriteLine("Notepad - type 'exit' to return to the console.");

            StringBuilder text = new StringBuilder();
            string input;
            do
            {
                input = Console.ReadLine();

                if (input == "exit")
                    break;

                if (input == "clear")
                {
                    text.Clear();
                    Console.Clear();
                    continue;
                }

                text.AppendLine(input);
                Console.WriteLine(input);

            } while (true);

            // Save or process the text as needed
        }

        private void RunCalculator()
        {
            Console.WriteLine("Calculator - type 'exit' to return to the console.");

            string input;
            do
            {
                Console.WriteLine("Type the first number:");
                input = Console.ReadLine();
                double num1;
                if (!double.TryParse(input, out num1))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                Console.WriteLine("Type the second number:");
                input = Console.ReadLine();
                double num2;
                if (!double.TryParse(input, out num2))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                Console.WriteLine("Choose an operation (+, -, *, /):");
                input = Console.ReadLine();

                double result = 0;
                switch (input)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            Console.WriteLine("Cannot divide by zero.");
                            continue;
                        }
                        result = num1 / num2;
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid operation.");
                        continue;
                }

                Console.WriteLine($"Result: {result}");

            } while (input != "exit");
        }

        private void RunCalendar()
        {
            Console.WriteLine("Calendar - type 'exit' to return to the console.");
            Console.WriteLine($"Today's date: {DateTime.Now.ToShortDateString()}");

            string input;
            do
            {
                Console.Write("Input: ");
                input = Console.ReadLine();
                if (input != "exit")
                {
                    break;
                }
            } while (true);
        }
       
    }
}
