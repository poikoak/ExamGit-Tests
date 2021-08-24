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
      readonly int count = 1;
        readonly string[] NFiles = null;
        readonly List<string> lst = new List<string>();
        public void ShowAllFiles(string path, string mask)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
   
                if (dinfo.Exists)
                {
                    // Получить массив файлов в текущей папке
                    try
                    {
                    string[] files = Directory.GetFiles(path, mask);
                     
                   // Console.WriteLine("Всего файлов {0}.", files.Length);
                   
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


       
        public static void Main()
        {
           
            string mask = (@"*.txt");
            Program p = new Program();
            p.ShowAllFiles(@"e:\2", mask);            
         
            
        }
    }

}