using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const string outputPath = @"C:\Users\fmi\Desktop\Lazar_Boradzhiev_STD_3a_1076\text.txt";
            string[] towns = FullArrayWithNames(outputPath);
            Console.Write("Total towns in the array: ");
            Console.WriteLine(towns.Length);

            Console.WriteLine("All cities containing an interval: ");

            for (int i = 0; i < towns.Length; i++)
            {
                if (towns[i].Contains(" "))
                {
                    Console.WriteLine(towns[i]);
                }
            }

            Console.WriteLine("All cities edining with -ово:");

            for (int i = 0; i < towns.Length; i++)
            {
                if (towns[i].EndsWith("ово"))
                {
                    Console.WriteLine(towns[i]);
                }
            }

            Console.WriteLine("All cities containing [o] or [O] more than 3 times:");

            for (int i = 0; i < towns.Length; i++)
            {
                int br = 0;
                foreach (char ch in towns[i])
                {
                    if (ch == 'о' || ch == 'О')
                    {
                        br++;
                    }
                }

                if (br >= 3)
                {
                    Console.WriteLine(towns[i]);
                }
            }

            Console.WriteLine("All cities having length shorten than the average:");

            int sum = 0;
            double average = 0;
            for (int i = 0; i < towns.Length; i++)
            {
                sum = sum + towns[i].Length;
            }
            average = sum / towns.Length;

            for (int i = 0; i < towns.Length; i++)
            {
                if (towns[i].Length < average)
                {
                    Console.WriteLine(towns[i]);
                }
            }

        }
        static string[] FullArrayWithNames(string pathToFile)
        {
            List<string> townNames = new List<string>();
            StreamReader reader = new StreamReader(pathToFile);
            using (reader)
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    townNames.Add(currentLine.Substring(0, currentLine.Length - 1));
                    currentLine = reader.ReadLine();
                }
            }
            return townNames.ToArray();

        }
    }
}
