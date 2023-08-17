using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDPFileListener
{
    internal class Watcher : IDisposable, IWatcher
    {
        public FileSystemWatcher watcher;
        private readonly Settings _settings;
        public Watcher(IOptions<Settings> settings)
        {
            watcher = new FileSystemWatcher();
            _settings = settings.Value;
        }

        public void watch()
        {
            watcher.Path = _settings.PathToListenOn;
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
            watcher.Filter = _settings.FilesToLookFor;
            watcher.Created += OnChanged;
            watcher.EnableRaisingEvents = true;

        }
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Changed!");
            Console.WriteLine("Full Path: " + e.FullPath);
            Console.WriteLine("Name: " + e.Name);


            if (!System.Threading.SpinWait.SpinUntil(() => File.Exists(e.FullPath), 10000))
            {
                Console.WriteLine("File does not exist");
                return;
            }


            Console.WriteLine($"Updating {e.FullPath}");

            using (StreamWriter sr = File.AppendText(e.FullPath))
            {
                sr.WriteLine(Environment.NewLine + _settings.SettingsToAdd);
            }


        }

        public void Dispose()
        {
            watcher.Changed -= OnChanged;
            this.watcher.Dispose();

        }
    }
}
