using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class Assignment9
    {

        public static string ReverseByWords(string sentence)
        {
            string[] words = sentence.Split(',');
            Array.Reverse(words);
            string revString = string.Join(" ", words);
            return revString;
        }

        static void Main(string[] args)
        {
            string sentence = ConsoleUtil.GetInputString("Enter the string to be reversed");
            string reversedString = ReverseByWords(sentence);
            Console.WriteLine(reversedString);
        }
    }
}
