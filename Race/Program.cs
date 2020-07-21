using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {

            var patternName = new Regex(@"(?<name>[A-Za-z]+)"); //Pattern for finding a name
            string patternDigits = @"(?<digits>\d+)"; //Pattern for finding digits

            int sumOfDigits = 0;

            //Dictionary for the participants
            Dictionary<string, int> participants = new Dictionary<string, int>();

            //List of participants
            List<string> names = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var matchedNames = patternName.Matches(input); //Finding names(words)
                var matchedDigits = Regex.Matches(input, patternDigits); //Finding digits

                string currentName = string.Join("", matchedNames); //Joining the words
                string currentDigit = string.Join("", matchedDigits); //Joining the digits

                sumOfDigits = 0;

                for (int i = 0; i < currentDigit.Length; i++)
                {
                    //Converting the digits
                    //Sum them
                    sumOfDigits += int.Parse(currentDigit[i].ToString());
                }

                //If our list of participants contains the current name
                if (names.Contains(currentName))
                {
                    //If our participants dictionary does not contain the current name
                    if (!participants.ContainsKey(currentName))
                    {
                        //We add the current name and the sum of the digits to the dictionary                   
                        participants.Add(currentName, sumOfDigits);
                    }

                    //else if our dictionary with participants contains the current name
                    else
                    {
                        //We add the sum to the old distance(sum) of the same participant
                        participants[currentName] += sumOfDigits;
                    }
                }

                input = Console.ReadLine();
            }

            var currentWinners = participants
               .OrderByDescending(x => x.Value)
               .Take(3);

            var firstPlace = currentWinners // We take the 1st player
                .Take(1);

            var secondPlace = currentWinners // We take the 2nd player
                .OrderByDescending(x => x.Value)
                .Take(2)
                .OrderBy(x => x.Value)
                .Take(1);

            var thirdPlace = currentWinners  // We take the 3rd player
                .OrderBy(x => x.Value)
                .Take(1);

            //Output
            foreach (var firstName in firstPlace)
            {
                Console.WriteLine($"1st place: {firstName.Key}");

            }

            foreach (var secondName in secondPlace)
            {
                Console.WriteLine($"2nd place: {secondName.Key}");
            }

            foreach (var thirdName in thirdPlace)
            {
                Console.WriteLine($"3rd place: {thirdName.Key}");
            }
        }
    }
}