﻿using System;
using System.Collections.Generic;

namespace CountingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";
            var countDict = new Dictionary<char, int>();

            // Loop through each character in the input string.
            foreach (char c in inputString)
            {
                // Already in there, increment the count.
                if (countDict.ContainsKey(c))
                    countDict[c] += 1;
                // First time, add to the dictionary.
                else
                    countDict.Add(c, 1);
            }

            // Loop through the dictionary and output the counts.
            foreach (var item in countDict)
                Console.WriteLine($"{item.Key}: {item.Value}");

        }
    }
}
