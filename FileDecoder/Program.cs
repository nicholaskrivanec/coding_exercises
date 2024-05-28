using System;
using System.IO;
using System.Collections.Generic;

namespace FileDecoder
{
    class Program
    {
        private  
        
        static void Main()
        {
            Console.WriteLine("Please enter a file path for the encoded text file");
            string path = Console.ReadLine();
            SortedDictionary<int, string> sd = GetKeyValues(path);
            Console.WriteLine(GetDecodedMessage(sd));
            Console.ReadLine();
        }
        

        private static string GetDecodedMessage(SortedDictionary<int, string> sd)
        {
            string result = sd[1];
            int step = 2;
            int i = 3;

            while (i <= sd.Count) { 
                result += string.Format(@" {0}", sd[i]);
                step++;
                i += step;
            }
            return result;
                
        }

        private static SortedDictionary<int,string> GetKeyValues(string filePath)
        {
            SortedDictionary<int, string> keyVals = new SortedDictionary<int, string>();
           
            try
            {
                if (!File.Exists(filePath))
                    Console.WriteLine("File Path Does Not Exist");
                else
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string ln;
                        string[] kv;

                        while (sr.Peek() >= 0)
                        {
                            ln = sr.ReadLine();
                            kv = ln.Split(' ');
                            if (Int32.TryParse(kv[0], out int i))
                                keyVals.TryAdd(i, kv[1]);
                        }
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format(@"Unable to Read File: {0}",ex.Message));
            }
            return keyVals;
        }
    }
}
