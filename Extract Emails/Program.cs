using System;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s|^)(?<user>[A-Za-z0-9]([-._]?[A-Za-z0-9])*)@(?<host>[A-Za-z](\-?[A-Za-z])*(\.[A-Za-z](\-?[A-Za-z])*)+)";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text,pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
                //Console.WriteLine($"--User: {match.Groups["user"].Value}");
                //Console.WriteLine($"--Host: {match.Groups["host"].Value}");
            }
        }
    }
}
