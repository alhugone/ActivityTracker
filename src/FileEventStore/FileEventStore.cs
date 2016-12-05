using ActivityTracker.Events;
using ActivityTracker.EventStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            if (!File.Exists(rootPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(rootPath));
                File.Create(rootPath,
                    512,
                    FileOptions.SequentialScan | FileOptions.WriteThrough).Close();
            }
        }

        public void Store(IActivityEvent activityEvent)
        {
            try
            {
                File.AppendAllLines(_fileFullPath, new List<string> { JsonConvert.SerializeObject(activityEvent) });
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
