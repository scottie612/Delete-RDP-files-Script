using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDPFileListener
{
    internal class Worker : BackgroundService
    {
        private readonly IWatcher _watcher;
        public Worker(IWatcher watcher)
        {
            _watcher= watcher;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _watcher.watch();
            while(!stoppingToken.IsCancellationRequested) { }
            Environment.Exit(0);
            return Task.CompletedTask;
        }
    }
}
