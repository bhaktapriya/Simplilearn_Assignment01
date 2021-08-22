using System;
using System.IO;

namespace Project1Module1
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean flag = true;
            while (flag)
            {
                Console.WriteLine("1.Create");
                Console.WriteLine("2.Append");
                Console.WriteLine("3.Read");
                Console.WriteLine("4.Update");
                Console.WriteLine("5.Delete");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter the number to choose the operation");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Write();
                        Console.ReadLine();
                        break;
                    case 2:
                        Append();
                        Console.ReadLine();
                        break;
                    case 3:
                        Read();
                        Console.ReadLine();
                        break;
                    case 4:
                            Console.WriteLine("Enter the new record.");
                            string str = Console.ReadLine();
                            Console.WriteLine("Enter the id of the record you want to update.");
                            int num = Convert.ToInt32(Console.ReadLine());
                        Update(str, num);
                        break;
                    case 5:
                        Delete();
                        break;
                    case 6:
                        flag = false;
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No Match Found");
                        break;
                }
            }
        }
        const string filename = "Rainbow.txt";
        static void Write()
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine("1 " + "Bhakti " + "7B");
            sw.WriteLine("2 " + "Sonali " + "5C");
            sw.WriteLine("3 " + "Shreya " + "8D");
            sw.Close();
        }
        static void Append()
        {
            StreamWriter sw = new StreamWriter(filename, true);
            Console.WriteLine("Enter the ID, name, class and section of the teacher.");
            int id = Convert.ToInt32(Console.ReadLine());
            string tname = Console.ReadLine();
            string cs = Console.ReadLine();
            sw.WriteLine(id + " " + tname + " " + cs);
            Console.WriteLine();
            sw.Close();
        }
        static void Read()
        {
            StreamReader sr = new StreamReader(filename);
            string s = sr.ReadToEnd();
            Console.WriteLine(s);
            sr.Close();
        }
        static void Update(string modified, int id)
        {
            string[] lines = File.ReadAllLines("Rainbow.txt");
            for(int i=0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                if (Convert.ToInt32(parts[0]) == id)
                {
                    lines[i] = modified;
                }
            }
            File.WriteAllLines("Rainbow.txt", lines);
        }
        static void Delete()
        {
            Console.WriteLine("Enter the record to be deleted");
            string str = Console.ReadLine();
            string tempFile = Path.GetTempFileName();
            using(var sr = new StreamReader(filename))
                using(var sw = new StreamWriter(tempFile))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    if (line != str)
                        sw.WriteLine(line);
                }
            }
            File.Delete(filename);
            File.Move(tempFile, filename);
        }
    }
}


