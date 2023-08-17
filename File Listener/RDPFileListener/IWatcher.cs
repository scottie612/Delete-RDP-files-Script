namespace RDPFileListener
{
    internal interface IWatcher
    {
        void Dispose();
        void OnChanged(object source, FileSystemEventArgs e);
        void watch();
    }
}