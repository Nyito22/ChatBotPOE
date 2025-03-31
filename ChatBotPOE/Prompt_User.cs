using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;

namespace ChatBotPOE
{
    public class Prompt_User 
    {
        public Prompt_User()
        {
            
            Store storing = new Store();
            ArrayList Bot_Response = new ArrayList();
            ArrayList Words_To_Ignore = new ArrayList();
            storing.StoreArrayResponse(Bot_Response);
            storing.StoreArrayWordToIgnore(Words_To_Ignore);


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("******************************************************************");
            Console.WriteLine("Welcome to the Cyber Security Artificial Intelligence Bot");
            Console.WriteLine("******************************************************************");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AI: Hey user,how are you doing today");
            string Answer;
            do {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("User: ");
                 Answer = Console.ReadLine();
            } while (!storing.ValidateFirstInput(Answer));
            GreetAndCheckUserResponse(Answer);


            // Optional: Ask for the user's name after checking how they feel
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AI: By the way, may I know your name?");
            string name;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("User: ");
                 name = Console.ReadLine();
                
            } while (!storing.ValidateName(name));

            Console.WriteLine($"AI: Nice to meet you, {name}!");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("AI: How may I assist you? (Please ask something related to cybersecurity or type (bye/Goodbye/exit) to exit the application)");

            while (true)
            {
               
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(name + ": ");
                string userQuestion = Console.ReadLine();

                
                if (!storing.ValidateQuestion(userQuestion))
                {
                    
                }

                
                if (CheckForExitWords(userQuestion.ToLower(), name))
                {
                  
                }

               
                storing.SearchForUserResponses(Bot_Response, Words_To_Ignore, userQuestion.ToLower());

               
            }
        }



        public void GreetAndCheckUserResponse(string response)
        {
            
            if (response.Contains("I am good") ||
                response.Contains("I am fine") ||
                response.Contains("I am doing well"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("AI: It's great to hear that! I hope you enjoy your experience here.");
            }
            else if (response.Contains("not good") ||
                     response.Contains("sad") ||
                     response.Contains("tired"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("AI: I'm sorry to hear that. I'm here to help if you need anything.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("AI: Thank you for sharing. Let me know how I can assist you!");
            }

            
        }

        public Boolean CheckForExitWords(string question, string name)
        {
            if (question.Contains("bye") || question.Contains("goodbye")   || question.Contains("Exit"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("*******************************************************************************************************");
                Console.WriteLine("Goodbye " + name + " Hope your had a nice experince, I am looking forward to helping you again");
                Console.WriteLine("*******************************************************************************************************");
                System.Environment.Exit(0);
                Console.ResetColor();
                return true;
            }

            return true;
        }

    }
}