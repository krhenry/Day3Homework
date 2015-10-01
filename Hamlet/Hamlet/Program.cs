using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamlet
{
    class Program
    {
        static void Main(string[] args)
        {
            var hamlet = File.ReadAllText(@"C:\Hamlet.txt").ToLower();

            var words = hamlet.Split(' ');
            var hamletDictionary = new Dictionary<string, int>();
            var value = 0;
            foreach (var word in words)
            {
                hamletDictionary[word] = hamletDictionary.TryGetValue(word, out value) ? ++value : 1;
            }
            hamletDictionary.Remove("");
            hamletDictionary.Remove(" ");

            foreach (KeyValuePair<string,int> item in hamletDictionary.OrderBy(key => key.Value))
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
              
            }
            Console.WriteLine(hamletDictionary.Values);
            Console.ReadLine();

        }
    }

}

