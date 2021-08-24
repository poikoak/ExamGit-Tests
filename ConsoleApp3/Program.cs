using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class Program
    {

        public static void CountWordsInFile(string file, Dictionary<string, int> words)
        {
            var content = File.ReadAllText(file);           
            var wordPattern = new Regex(@"\w+");
            StreamWriter writer = new StreamWriter("1.txt", true);
            foreach (Match match in wordPattern.Matches(content))
            {
                words.TryGetValue(match.Value, out int currentCount);
                currentCount++;
                words[match.Value] = currentCount;
            }
            foreach (Match match in wordPattern.Matches(content))
            {
                writer.WriteLine("{0}", match.Value);
            }
            writer.Close();
        }
      
        public void ShowAllFiles(string path, string mask)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            if (dinfo.Exists)
            {
                // Получить массив файлов в текущей папке
                try
                {
                    string[] files = Directory.GetFiles(path, mask);
                    Console.WriteLine("Всего файлов {0}.", files.Length);
                    foreach (string f in files)
                    {                        
                        var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
                        //сортируем слова в 1 фаил
                        CountWordsInFile(f, words);
                    }
                    // Получить массив подпапок в текущей папке
                    DirectoryInfo[] dirs = dinfo.GetDirectories();
                    foreach (DirectoryInfo current in dirs)
                    {
                        // Console.WriteLine("<DIR>    " + path + "\\" + current.Name);
                        ShowAllFiles(path + @"\" + current.Name, mask);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Path is not exists");
            }
        }


        public static void CountWordFrequencySimpleDimple(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName", "You must specify a file");
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Could not find the specified file.", fileName);
            }

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            using (TextReader reader = File.OpenText(fileName))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string cleanedLine = line;
                    string[] words = cleanedLine.Split(' ');
                    foreach (string word in words)
                    {

                        if (!string.IsNullOrEmpty(word))
                        {
                            int frequency = 1;
                            if (wordCounts.ContainsKey(word))
                            {
                                frequency = wordCounts[word] + 1;
                            }
                            wordCounts[word] = frequency;
                        }
                    }

                    line = reader.ReadLine();
                }
                StreamWriter writer = new StreamWriter("2.txt", true);
                List<KeyValuePair<string, int>> pairList = new List<KeyValuePair<string, int>>(wordCounts);
                pairList.Sort((first, second) => { return second.Value.CompareTo(first.Value); });
                foreach (KeyValuePair<string, int> pair in pairList)
                {
                    Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
                    writer.WriteLine("{0}, {1}", pair.Key, pair.Value);
                }
                writer.Close();
            }
        }
        public static void Main()
        {
            string mask = (@"*.txt");
            Program p = new Program();
            p.ShowAllFiles(@"e:\2", mask);
            CountWordFrequencySimpleDimple("1.txt");
        }
    }

}