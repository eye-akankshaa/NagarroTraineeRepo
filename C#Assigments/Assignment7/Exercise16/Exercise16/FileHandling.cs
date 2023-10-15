using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise16
{
    class FileHandling
    {

        public static void Run()
        {
            try
            {
                //Get all the files from a given directory and perform the following actions
                string directoryPath = @"C:\Users\akanshakhandelwal\Desktop\FileSystemTestFolder";

                //Console.Write("Enter the directory (example:C:Users\akanshakhandelwal\Desktop\FileSystemTestFolder ) ");

                //directoryPath = Console.ReadLine();

                if (Directory.Exists(directoryPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

                    //1.Return the number of text files in the directory.
                    int numberTextFiles = directoryInfo.GetFiles().ToList().Where(file => file.FullName.Contains(".txt")).Count();
                    Console.WriteLine("\nThe number of text files in the directory (*.txt): {0}", numberTextFiles);
                    
                    //2.Return the number of files as per extension type.
                    Console.WriteLine("\nThe number of files per extension type:");
                    var extensionTypeCounters = directoryInfo.EnumerateFiles(".", SearchOption.TopDirectoryOnly)
                            .GroupBy(file => file.Extension)
                            .Select(g => new { Extension = g.Key, Count = g.Count() })
                            .ToList();
                    foreach (var extensionTypeCounter in extensionTypeCounters)
                    {
                        Console.WriteLine("The number of files with extension \"{0}\" is: {1}", extensionTypeCounter.Extension, extensionTypeCounter.Count);
                    }
                   
                    
                    //3.Return the top 5 largest files, along with their file size.
                    Console.WriteLine("\nThe top 5 largest files, along with their file size:");
                    var topLargestFiles = directoryInfo.GetFiles().OrderByDescending(file => file.Length).Take(5).ToList();
                    foreach (FileInfo fileInfo in topLargestFiles)
                    {
                        Console.WriteLine("The file \"{0}\" has size {1} MB", fileInfo.Name, fileInfo.Length / 1024f / 1024f);
                    }
                    
                    //4. Return the file with maximum length.
                    if (topLargestFiles.Count != 0)
                    {
                        Console.WriteLine("\nThe file \"{0}\" has maximum length in the directory {1} MB", ((FileInfo)topLargestFiles[0]).Name, ((FileInfo)topLargestFiles[0]).Length / 1024f / 1024f);
                    }
                }
                else
                {
                    Console.WriteLine("The directory does not exist.");
                }
            }
            catch (Exception ex)
            {

            }
            Console.ReadLine();


        }

    }
}
    

