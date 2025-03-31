using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotPOE
{
    class Store
    {
        public void StoreArrayResponse(ArrayList Bot_Response)
        {
            // Adding predefined responses with triggering words
            Bot_Response.Add("cyber security-Cybersecurity is the practice of protecting computers, networks, systems, and data from unauthorized access, cyberattacks, and damage. It encompasses a wide range of technologies, processes, and practices designed to safeguard sensitive information and ensure the confidentiality, integrity, and availability of digital resources.");
            Bot_Response.Add("password-A password is a secret combination of characters (letters, numbers, and symbols) used to authenticate a user's identity when accessing systems, applications, or online services. It acts as a digital key, safeguarding personal accounts and sensitive information from unauthorized access.");
            Bot_Response.Add("network security-Network security refers to the measures and strategies used to protect computer networks and their data from unauthorized access, misuse, attacks, or disruptions. It involves a combination of technologies, policies, and practices designed to safeguard the integrity, confidentiality, and availability of network resources.");
            Bot_Response.Add("data protection-refers to the practices and measures taken to safeguard sensitive or personal information from unauthorized access, misuse, alteration, or loss. It ensures that data remains secure, private, and available only to authorized individuals or systems. Data protection is essential for maintaining trust, compliance with legal regulations, and the integrity of information.");
            Bot_Response.Add("social engineering-is a manipulation technique that exploits human psychology to trick individuals into revealing sensitive information, performing actions, or granting access to systems. Instead of relying on technical hacking methods, social engineering targets people's trust, emotions, and behaviors to bypass security.");
            Bot_Response.Add("sql injection-SQL Injection is a type of cyberattack that exploits vulnerabilities in applications that interact with databases. This attack allows malicious actors to insert or 'inject' harmful SQL statements into input fields (like login forms or search bars). These statements can manipulate the database to execute unintended actions.");
            Bot_Response.Add("information security-Information security, often abbreviated as InfoSec, refers to the practices and techniques used to protect sensitive information from unauthorized access, use, disclosure, alteration, or destruction. It ensures the confidentiality, integrity, and availability of data, whether it's stored digitally, on paper, or in transit.");
            Bot_Response.Add("malware-Malware, short for 'malicious software,' refers to any software intentionally created to damage, disrupt, or gain unauthorized access to systems.");
            Bot_Response.Add("ransomware-Ransomware is a specific type of malware designed to encrypt or lock files on a victim's computer, making them inaccessible. The attacker demands payment (usually in cryptocurrency) in exchange for decrypting the files or restoring access.");
            Bot_Response.Add("phishing-Phishing is a cyber attack where attackers trick users into providing sensitive information.");
        }

        public void StoreArrayWordToIgnore(ArrayList words_ignore)
        {
            // Adding common words to ignore from user input
            words_ignore.Add("how");
            words_ignore.Add("why");
            words_ignore.Add("tell");
            words_ignore.Add("can");
            words_ignore.Add("me");
            words_ignore.Add("to");
            words_ignore.Add("about");
        }

        public Boolean ValidateName(String Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AI: Please ensure that the name is not empty, enter a proper name:");
                return false;
            }
            return true;
        }

        public Boolean ValidateQuestion(String question)
        {
            if (string.IsNullOrEmpty(question))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AI: Please ensure that the question is not empty, enter a question related to cyber security:");
                return false;
            }
            return true;
        }

        public Boolean ValidateFirstInput(String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AI: Your input is empty, please enter something that is valid:");
                return false;
            }
            return true;
        }

        public void SearchForUserResponses(ArrayList response, ArrayList words_ignore, string userQuestion)
        {
            string[] split_words = userQuestion.Split(' ');
            ArrayList words_to_filter = new ArrayList();

            // Filtering out ignored words from the user question
            foreach (string words_touse in split_words)
            {
                if (!words_ignore.Contains(words_touse.ToLower()))
                {
                    words_to_filter.Add(words_touse.ToLower());
                }
            }

            bool found = false;

            // Looping through stored bot responses
            foreach (string bot_response in response)
            {
                // Splitting response into triggering words and definition using '-'
                string[] split_parts = bot_response.Split('-');
                string triggering_word = split_parts[0]; // Triggering word at index 0
                string response_keywords = split_parts[1]; // Response at index 1

                // Checking if any of the words in user input match triggering words
                if (words_to_filter.Contains(triggering_word.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AI: " + response_keywords);
                    found = true;
                    break; // Exit loop once a match is found
                }
            }

            // If no match is found, show an error message once
            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("AI: Please search for something that relates to cyber security");
            }
        }
    }
}
