using System;
using System.Collections.Generic;
using System.IO;

namespace WordsFinder.BI
{
    public static class ReferenceDictionary
    {
        public static HashSet<String> UploadDictionary(string filePatch)
        {
            HashSet<String> results = new HashSet<String>();
            try
            {
                using StreamReader sr = new StreamReader(filePatch);
                {
                    String line = sr.ReadLine();
                    while (line != null)
                    {
                        results.Add(line);
                        line = sr.ReadLine();
                    }
                };
            }
            catch (Exception ex)
            {
                // Add exception code
            }
            return results;
        }
    }
}
