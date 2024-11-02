using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WordsFinder.BI
{
    public class Filtering
    {
    
        /// <summary>
        /// Simple filtering method where ? - one any character and * - any characters
        /// </summary>
        /// <param name="words"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static HashSet<string> FilterWords(HashSet<string> words, string pattern)
        {
            HashSet<string> result = new HashSet<string>();
            pattern = "^" + Regex.Escape(pattern)
                .Replace("\\*", ".*")
                .Replace("\\?", ".") + "$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); // without Regex.Escape
            foreach (string word in words)
            {
                if (regex.IsMatch(word))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        /// <summary>
        /// Use full Regex expressions as input
        /// </summary>
        /// <param name="words"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static HashSet<string> FilterAdvanceWords(HashSet<string> words, string pattern)
        {
            HashSet<string> result = new HashSet<string>();
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase); 
            foreach (string word in words)
            {
                if (regex.IsMatch(word))
                {
                    result.Add(word);
                }
            }

            return result;
        }
    }
}
