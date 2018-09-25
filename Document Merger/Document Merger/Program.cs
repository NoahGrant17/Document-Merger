using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            var again = "yes";
            while (again == "yes")
            {
                string fileName1 = null, fileName2 = null;
                string content1 = "", content2 = "";

                Console.WriteLine("Document Merger");
                Console.WriteLine("What is the name of the first document?");
                fileName1 = Console.ReadLine();

                try
                {
                    while (File.Exists(fileName1 + ".txt") == false)
                    {
                        Console.WriteLine("Wrong name! Enter the right file name of the first document?");
                        fileName1 = Console.ReadLine();
                    }

                    StreamReader sr = new StreamReader($"{fileName1}.txt");

                    string line = sr.ReadLine();
                    content1 = line;
                    while (line != null)
                    {
                        content1 = content1 + Environment.NewLine;
                        line = sr.ReadLine();
                        content1 = content1 + line;
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("File error!");
                }

                Console.WriteLine("What is the name of the second document?");
                fileName2 = Console.ReadLine();
                try
                {
                    while (File.Exists(fileName2 + ".txt") == false)
                    {
                        Console.WriteLine("Wrong name! Enter the right file name of the second document?");
                        fileName2 = Console.ReadLine();
                    }

                    StreamReader sr2 = new StreamReader($"{fileName2}.txt");

                    string line = sr2.ReadLine();
                    content2 = line;
                    while (line != null)
                    {
                        content2 = content2 + Environment.NewLine;
                        line = sr2.ReadLine();
                        content2 = content2 + line;
                    }
                    sr2.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("File error!");
                }

                int count = 0;
                try
                {
                    string content3 = content1 + content2;
                    count = content3.ToCharArray().Count();
                    string fileName3 = fileName1 + fileName2 + ".txt";

                    using (StreamWriter sw = new StreamWriter(fileName3))
                    {
                        sw.WriteLine(content1);
                        sw.WriteLine(content2);
                    }
                    count = content1.Length + content2.Length;
                    Console.WriteLine($"{fileName3} was successfully saved. The document contains {count} characters.");
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error unable to create new file with file1 and file2!");
                }

                    Console.WriteLine("Do you want to run program again type 'yes' or to end program type anything else");
                    again = Console.ReadLine();
                
                
            }           
        }
    }
}
