using System;
using System.IO;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {

       
            //Dependency injection

            Read r1 = new Read();
            string[] lines = r1.ReadNames(args[0]);

            Sort s1 = new Sort();
            s1.SortNames(lines);

            Write w1 = new Write();

            w1.writeInFile(args[1],lines);
           

        }

        //separation of concern: each class does just one thing

        class Read
        {
            public string[] ReadNames(string path)
            {
                //string path = "C:/Users/Nikita/source/repos/readfile/readfile/unsorted-name-list.txt";
                string[] lines = File.ReadAllLines(path);

                return lines;
            }


        }


        //bubble sort
        class Sort
        {
            public string[] SortNames(string[] namesInFile)
            {
                Console.WriteLine("Unsorted name list: \n");
                for (int i = 0; i < namesInFile.Length; i++)
                {
                    Console.WriteLine(namesInFile[i]);
                }
                Console.WriteLine("");

                int l = namesInFile.Length;
                string temp;
                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < l - 1; j++)
                    {
                        if (namesInFile[j].CompareTo(namesInFile[j + 1]) > 0)
                        {
                            temp = namesInFile[j];
                            namesInFile[j] = namesInFile[j + 1];
                            namesInFile[j + 1] = temp;
                        }
                    }
                }
                Console.Write("Sorted name list: \n\n");
                for (int i = 0; i < l; i++)
                {
                    Console.WriteLine(namesInFile[i] + " ");
                }
                return namesInFile;


            }
        }

        class Write
        {
            public void writeInFile(string path, string[] namesInFile)
            {

                File.WriteAllLines(path, namesInFile);

            }
        }

    }
}
