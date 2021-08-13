using System;
using System.IO;
using System.Collections.Generic;

namespace SampleForFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            for (int i = 1; i <= 10; i++)
            {
                people.Add(new Person { Name = $"Name{i}", Age = 10 + i });
            }

            //D:\WEBDEV\SampleForFileStream
            //G:\C#Projects\SampleForFileStream
            //string path = Path.Combine("D:", "WEBDEV", "SampleForFileStream", "TestFiles");
            string path = Path.Combine("G:", "C#Projects", "SampleForFileStream", "TestFiles");
            //string path2 = @"G:\C#Projects\SampleForFileStream\TestFiles\test2.txt";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            //Console.WriteLine("Введите текст");
            //var text = Console.ReadLine();





            using (FileStream fileStream = new FileStream($"{path}\\Test.txt", FileMode.Truncate))
            {
                foreach (var item in people)
                {

                    string text = $"{item.Name},{Convert.ToString(item.Age)}{Environment.NewLine}";
                    byte[] array = System.Text.Encoding.Default.GetBytes(text);
                    fileStream.Write(array, 0, array.Length);
                }

            }
            List<Person> listFromFile = new List<Person>();
            using (FileStream filestream = new FileStream($"{path}\\Test.txt", FileMode.Open))
            {
                byte[] array2 = new byte[filestream.Length];
                filestream.Read(array2, 0, array2.Length);
                string readText = System.Text.Encoding.Default.GetString(array2);
                var arr = readText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                foreach (var pers in arr)
                {
                    var prop = pers.Split(",");

                    listFromFile.Add(new Person { Name = prop[0], Age = Convert.ToInt32(prop[1]) });
                    //Console.WriteLine(pers.Length);
                    Console.WriteLine(prop.Length);

                }
                Console.WriteLine( $"Это данные из файла: ");
                foreach (var item in listFromFile)
                {
                    Console.WriteLine($" {item.Name} {item.Age}");
                }
                //Console.WriteLine(readText);
            }

        }
    }
}
