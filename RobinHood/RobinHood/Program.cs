using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobinHood
{
    class Program
    {
        static void Main(string[] args)
        {
            string robinHood = File.ReadAllText(@"C:\Robinhood.txt");
            var words = Regex.Split(robinHood, "[\\b\\s,.\"]");

            var wordDictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (word.Length > 3)
                {
                    if (!wordDictionary.ContainsKey(word))
                    {
                        wordDictionary[word] = 0;
                    }
                    wordDictionary[word] = wordDictionary[word] + 1;
                }
            }

            KeyValuePair<string, int>? maxWord = null;
            foreach (KeyValuePair<string, int> entry in wordDictionary)
            {
                if (maxWord == null || entry.Value > maxWord.Value.Value)
                {
                    maxWord = entry;
                }
            }

            //var sorted = wordDictionary.OrderBy(e => e.Value).Take(100);

            ////Console.WriteLine("{0} appears {1} times", entry.Key, entry.Value);
            //Console.ReadLine();


            Console.WriteLine("{0} appears {1} times", maxWord.Value.Key,maxWord.Value.Value);
            Console.ReadLine();
        }
    }
}
