using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //существует ли папка
        [TestMethod]
        public void TestMethod1()
        {
            DirectoryInfo dinfo = new DirectoryInfo(@"e:\2");
            Assert.IsTrue(dinfo.Exists);
        }
        //не пустой ли фаил
        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsNotNull(string.IsNullOrEmpty("1.txt"));
        }


        //существует ли фаил
        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsTrue(File.Exists("1.txt"));
        }


        //не происходи ли подмена слова в алгоритме
        [TestMethod]
        public void TestMethod4()
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            string line = "world";
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
                    Assert.AreEqual("world", word);
                }
            }
        }
        //считает ли слова
        [TestMethod]
        public void TestMethod5()
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            int frequency = 1;
            string line = "string";
            while (frequency != 2)
            {
                string cleanedLine = line;
                string[] words = cleanedLine.Split(' ');
                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {

                        if (wordCounts.ContainsKey(word))
                        {
                            frequency = wordCounts[word] + 1;
                        }
                        wordCounts[word] = frequency;
                    }
                }
                line = "string";
            }
            Assert.AreEqual(2, frequency);

        }
        //не происходи ли подмена слова в алгоритме
        [TestMethod]
        public void TestMethod6()
        {
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            var content = "str";
            var wordPattern = new Regex(@"\w+");
            foreach (Match match in wordPattern.Matches(content))
            {
                words.TryGetValue(match.Value, out int currentCount);
                currentCount++;
                words[match.Value] = currentCount;
                Assert.AreSame(content, match.Value);
            }


        }
        //записывает ли результат
        [TestMethod]
        public void TestMethod7()
        {
            //string[] files = Directory.GetFiles("");
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            var content = "str";
            var wordPattern = new Regex(@"\w+");
            StreamWriter writer = new StreamWriter("TEST.txt", true);
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
            Assert.IsNotNull(writer);
        }

        //находи ли фаилы
        [TestMethod]
        public void TestMethod8()
        {
            string mask = (@"*.txt");
            ShowAllFiles(@"e:\2", mask);
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
                    Assert.IsNotNull(files.Length);
                    foreach (string f in files)
                    {


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
        //находит ли все нужные файлы в папке
        [TestMethod]
        public void TestMethod9()
        {
            string mask = (@"*.txt");
            ShowAllFiles1(@"e:\2", mask);
        }
        public void ShowAllFiles1(string path, string mask)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            if (dinfo.Exists)
            {
                // Получить массив файлов в текущей папке
                try
                {
                    string[] files = Directory.GetFiles(path, mask);
                    Console.WriteLine("Всего файлов {0}.", files.Length);
                    Assert.AreEqual(3, files.Length);
                    foreach (string f in files)
                    {
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
        //одинаковы фаилы при сохр. в конце
        [TestMethod]
        public void TestMethod10()
        {
            CountWordFrequencySimpleDimple();
        }

        public static void CountWordFrequencySimpleDimple()
        {    
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            string line = "String 123 KKE";
            
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
            StreamWriter writer = new StreamWriter("56.txt", true);
            List<KeyValuePair<string, int>> pairList = new List<KeyValuePair<string, int>>(wordCounts);
            pairList.Sort((first, second) => { return second.Value.CompareTo(first.Value); });
            foreach (KeyValuePair<string, int> pair in pairList)
            {               
                writer.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
          
            StreamWriter writer2 = new StreamWriter("55.txt", true);
            List<KeyValuePair<string, int>> pairList2 = new List<KeyValuePair<string, int>>(wordCounts);
            pairList2.Sort((first, second) => { return second.Value.CompareTo(first.Value); });
            foreach (KeyValuePair<string, int> pair in pairList2)
            {

                writer2.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
            
            Assert.AreNotEqual(writer, writer2);
            writer2.Close();
            writer.Close();
        }
    }
}

