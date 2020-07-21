using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"\+([359]+)([-| ])2(\2)(\d{3})(\2)(\d{4})\b");
            MatchCollection patternMatch = regex.Matches(input);

            var matchedPhones = patternMatch.Cast<Match>().Select(x => x.Value.Trim()).ToArray();
            Console.WriteLine(String.Join(", ",matchedPhones));
        }
    }
}
