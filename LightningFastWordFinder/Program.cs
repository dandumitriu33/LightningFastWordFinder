using System;
using System.IO;
using System.Threading;

namespace LightningFastWordFinder
{
    class Program
    {
        static string name = "Mike";
        static int numOfRuns = 100;

        static double RunParserPerformanceTests(string text)
        {
            string longestWord;
            DateTime start = DateTime.Now;
            for (int i = 0; i < numOfRuns; ++i)
            {
                Console.WriteLine("Run: " + i);
                LightningWordFinder parser = new LightningWordFinder();
                longestWord = parser.GetLongestWord(text);

                if (longestWord != "Constantinopolitan")
                {
                    Console.WriteLine("The longest word is not what I wanted to see..");
                    Thread.Sleep(20);
                }
            }
            DateTime end = DateTime.Now;
            return end.Subtract(start).TotalMilliseconds / numOfRuns;
        }

        static void StoreHighScore(double highscore)
        {
            StreamWriter writer = File.AppendText("highscore.txt");
            writer.WriteLine(name + " Runs: " + numOfRuns + " Score: " + highscore);
            writer.Close();
        }

        static void Main(string[] args)
        {
            string text = File.ReadAllText("history-of-egypt-chaldea-syria-babylonia-assyria.txt");
            Console.WriteLine("Text length: " + text.Length);
            double avgRuntime = RunParserPerformanceTests(text);
            Console.WriteLine("Average Running Time: " + avgRuntime);
            StoreHighScore(avgRuntime);

            Console.ReadKey();
        }
    }
}
