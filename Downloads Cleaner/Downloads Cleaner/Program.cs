using System;

namespace Downloads_Cleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\scott\Downloads";

            Console.WriteLine("Starting....");
            Console.WriteLine("Deleting Files in " +path);
            
            string[] directoryFiles = System.IO.Directory.GetFiles(path, "*.rdp");
            foreach (string directoryFile in directoryFiles)
            {
                Console.WriteLine("...Deleting file : " + directoryFile);
                System.IO.File.Delete(directoryFile);
            }

            Console.WriteLine("Finished....");
            Console.ReadLine();
        }
    }
}
