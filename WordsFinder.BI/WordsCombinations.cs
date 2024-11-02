using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsFinder.BI
{
    public static class WordsCombinations
    {
        /// <summary>
        /// Create collection of combinations imput string characters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HashSet<string> GetCombinations(string input)
        {
            HashSet<string> result = new HashSet<string>();
            GenerateCombinations("", input, result);
            return result;
        }
        internal static void GenerateCombinations(string prefix, string remaining, HashSet<string> result)
        {
            if (prefix.Length >= 3)
            {
                result.Add(prefix);
            }

            for (int i = 0; i < remaining.Length; i++)
            {
                string newPrefix = prefix + remaining[i];
                string newRemaining = remaining.Substring(0, i) + remaining.Substring(i + 1);
                GenerateCombinations(newPrefix, newRemaining, result);
            }
        }

        /// <summary>
        /// Checks if records from input collection are in myDictionary. If not are removed from input collection.
        /// At the result in input collection will stay only those records, that are also in myDictionary
        /// </summary>
        /// <param name="input"></param>
        /// <param name="myDictionary"></param>
        /// <returns></returns>
        public static HashSet<String> CheckCollection(HashSet<string> input, HashSet<string> myDictionary)
        {
            input.RemoveWhere(item => !myDictionary.Contains(item));

            return input;
        }

        /// <summary>
        /// Remove all records from collection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HashSet<string> ClearCollection(HashSet<string> input)
        { 
            input.Clear();
            return input;
        }
    }
}
