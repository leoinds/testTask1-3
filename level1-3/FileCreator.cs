using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace level1_3
{
    class FileCreator
    {
        static List<string> lines = new List<string>();
        public static void SelectCases(string pathToTheFile, int numberOfLines = 10)
        {
            using (StreamReader sr = new StreamReader(pathToTheFile, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)  
                {
                    lines.Add(line);
                }
            }
            string header = lines[0];
            lines.RemoveAt(0);

            if (numberOfLines > lines.Count())
            {
                Console.WriteLine("Указано больше строк, чем есть в файле!");
                Console.ReadKey();
                return;
            }
            Random rand = new Random();
            string pathResFile = pathToTheFile.Insert(pathToTheFile.IndexOf(".txt"), "_res");
            using (StreamWriter sw = new StreamWriter(pathResFile, false, Encoding.Default))
            {
                sw.WriteLine(header);
                for (int i = 0; i < numberOfLines; i++)
                {
                    int index = rand.Next(0, lines.Count() - 1);
                    sw.WriteLine(lines[index]);
                    lines.RemoveAt(index);
                }
            }
            using (StreamWriter sw = new StreamWriter(pathToTheFile, false, Encoding.Default)) 
            {
                sw.WriteLine(header);
                foreach (string element in lines)
                    sw.WriteLine(element);
            }
            Console.WriteLine($"Путь к результирующему файлу: {pathResFile}");
        }
    }
}