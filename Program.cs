using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConAppAssignment12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter a piece of text:");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            List<string> emailAddresses = FindEmailAddresses(inputText);
            List<string> mobileNumbers = ExtractMobileNumbers(inputText);

            Console.WriteLine("\nWord Count: " + wordCount);
            Console.WriteLine("Email Addresses:");
            foreach (string email in emailAddresses)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine("Mobile Numbers:");
            foreach (string number in mobileNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Enter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            List<string> customMatches = CustomRegexSearch(inputText, customRegexPattern);

            Console.WriteLine("Custom Regex Matches:");
            foreach (string match in customMatches)
            {
                Console.WriteLine(match);
            }
        }

        static int CountWords(string inputText)
        {
            string[] words = inputText.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static List<string> FindEmailAddresses(string inputText)
        {
            List<string> emails = new List<string>();
            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            MatchCollection matches = Regex.Matches(inputText, pattern);
            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }
            return emails;
        }

        static List<string> ExtractMobileNumbers(string inputText)
        {
            List<string> mobileNumbers = new List<string>();
            string pattern = @"\b\d{10}\b";
            MatchCollection matches = Regex.Matches(inputText, pattern);
            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }
            return mobileNumbers;
        }

        static List<string> CustomRegexSearch(string inputText, string customRegexPattern)
        {
            List<string> customMatches = new List<string>();
            MatchCollection matches = Regex.Matches(inputText, customRegexPattern);
            foreach (Match match in matches)
            {
                customMatches.Add(match.Value);
            }
            return customMatches;
        }
    }
}
