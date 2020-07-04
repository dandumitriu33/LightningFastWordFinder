using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LightningFastWordFinder
{
    class LightningWordFinder
    {
        public string GetLongestWord(string text)
        {
            string processedText = processTextRemoveDigitsPunctuation(text);
            string longestWord = findLongestWord(processedText);
            return longestWord;
        }

        private string findLongestWord(string processedText)
        {
            int maxLength = 0;
            string longestWord = "";
            string[] words = processedText.Split(' ');
            Parallel.ForEach(words, (word) =>
            {
                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                    longestWord = word;
                }
            });
            Console.WriteLine($"Longest word is {longestWord}");
            return longestWord;
        }

        private string processTextRemoveDigitsPunctuation(string text)
        {
            string result = Regex.Replace(text, @"\d|\W", " ");
            return result;
        }
    }
}
