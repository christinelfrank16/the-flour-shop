using System;
using System.Linq;

namespace Interactions
{
    class Interaction
    {
        public static string AskOptionsQuestion(string[] options, string badAnswerMessage)
        {
            string answer = "";
            while (answer == "")
            {
                string responseString = Console.ReadLine().ToLower();
                if (options.Contains(responseString))
                {
                    answer = responseString;
                }
                else
                {
                    Console.WriteLine(badAnswerMessage + " (Type the option you would like)");
                }
            }
            return answer;
        }
        public static bool AskYesNoQuestion(string badAnswerMessage)
        {
            bool isAnswered = false;
            bool answer = false;
            while (!isAnswered)
            {
                string responseString = Console.ReadLine().ToLower();
                if (responseString.StartsWith('y'))
                {
                    answer = true;
                    isAnswered = true;
                }
                else if (responseString.StartsWith('n'))
                {
                    isAnswered = true;
                }
                else
                {
                    Console.WriteLine(badAnswerMessage);
                }
            }

            return answer;
        }

        public static int AskPositiveIntQuestion(string badAnswerMessage)
        {
            int count = -1;
            while(count < 0)
            {
                string countString = Console.ReadLine();
                try
                {
                    count = Convert.ToInt32(countString);
                }
                catch (FormatException)
                {
                    Console.WriteLine(badAnswerMessage + " (in numeric form)");
                }
                if(count < 0)
                {
                    Console.WriteLine(badAnswerMessage + " (positive values only)");
                }
            }
            return count;
        }

        public static double AskPositiveDoubleQuestion(string badAnswerMessage)
        {
            double count = -1.00;
            while (count < 0)
            {
                string countString = Console.ReadLine();
                try
                {
                    count = Convert.ToInt64(countString);
                }
                catch (FormatException)
                {
                    Console.WriteLine(badAnswerMessage + " (in numeric form)");
                }
                if (count < 0)
                {
                    Console.WriteLine(badAnswerMessage + " (positive values only)");
                }
            }
            return count;
        }

        public static string UserInput()
        {
            string returnString = "";
            Console.WriteLine("What would you like to do? [Show Products, Order, Checkout, Leave]");
            while (returnString == "")
            {
                string response = Console.ReadLine().ToLower();
                if (response.StartsWith('o'))
                {
                    returnString = "order";
                }
                else if (response.StartsWith('c'))
                {
                    returnString = "checkout";
                }
                else if (response.StartsWith('l'))
                {
                    returnString = "leave";
                }
                else if (response.StartsWith('s'))
                {
                    returnString = "show";
                }

                if (returnString == "")
                {
                    Console.WriteLine("I didn't quite get that. What would you like to do? [Order, Checkout, Leave]");
                }
            }

            return returnString;
        }

        public static void AddSpace()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
        }


    }
}