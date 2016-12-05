using ActivityTracker.Events;
using ActivityTracker.EventStore;
using Newtonsoft.Json;
using System.IO;

namespace FileEventStore
{
    public class FileEventStore : IEventStore
    {
        private readonly string _fileFullPath;

        public FileEventStore(string fileFullPath)
        {
            Validate(fileFullPath);
            _fileFullPath = fileFullPath;
        }

        private void Validate(string rootPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(rootPath));
            File.Create(rootPath, 512, FileOptions.SequentialScan | FileOptions.WriteThrough);
        }

        public void Store(IActivityEvent activityEvent)
        {
            File.AppendAllText(_fileFullPath, JsonConvert.SerializeObject(activityEvent));
        }
    }
}
