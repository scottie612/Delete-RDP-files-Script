using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Downloads_Cleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            string myExeDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
            var configPath = myExeDir + "\\config.json";
            Console.WriteLine(configPath);
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configPath, optional: false);

            IConfiguration config = builder.Build();

            string path = config.GetSection("PathToDeleteFrom").Value;
            string filesToRemove= config.GetSection("TypesOfFilesToRemove").Value;

            Console.WriteLine("Starting....");
            Console.WriteLine("Deleting Files in " + path);
            
            string[] directoryFiles = System.IO.Directory.GetFiles(path, filesToRemove);
            foreach (string directoryFile in directoryFiles)
            {
                Console.WriteLine("...Deleting file : " + directoryFile);
                System.IO.File.Delete(directoryFile);
            }

            Console.WriteLine("Finished....");

            //Console.ReadLine();
        }
    }
}
