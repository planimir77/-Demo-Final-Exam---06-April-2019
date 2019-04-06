using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();

            string inputString = Console.ReadLine();

            string[] arr = inputString.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var item in arr)
            {
                string[] temp = item.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string key = temp[0];
                string value = temp[1];
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string>());
                }
                dict[key].Add(value);
            }

            string[] words = Console.ReadLine().Split(" | ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = Console.ReadLine();

            if (command=="List")
            {
                foreach (var kvp in dict.OrderBy(x=>x.Key))
                {
                    Console.Write(kvp.Key+" ");
                }
                Console.ReadLine();
            }
            else if (command == "End")
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (dict.ContainsKey(words[i]))
                    {
                        Console.WriteLine(words[i]);
                        foreach (var kvp in dict)
                        {
                            if (kvp.Key== words[i])
                            {
                                foreach (var item in kvp.Value.OrderByDescending(x=>x.Count()))
                                {
                                    Console.WriteLine(" -"+item);
                                }
                            }
                        }

                    }
                }
                
                
            }
            
        }
    }
}
