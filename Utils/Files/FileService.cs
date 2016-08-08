using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.LinqExtensions;

namespace Utils.Files
{
    /// <summary>
    /// Service for file operations
    /// </summary>
    public class FileService
    {
        FileSearcher _searcher;

        public FileService(FileSearcher searcher)
        {
            _searcher = searcher;
        }

        /// <summary>
        /// Create file on path
        /// </summary>
        public bool CreateFile(string path, string content)
        {
            if (String.IsNullOrEmpty(path))
                throw new ArgumentException("path is not set");

            if (File.Exists(path))
            {
                return false;
            }

            using (FileStream fs = File.Create(path))
            using(StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(content);
            }
            
            return true;
        }

        /// <summary>
        /// Delete file on path
        /// </summary>
        public bool DeleteFile(string path)
        {
            if (!File.Exists(path))
                return false;

            File.Delete(path);

            return true;
        }

        public IEnumerable<FileSystemInfo> Search(string directoryPath, string pattern, bool searchSubdirectories = false)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException(string.Format("Directory {0} not found.", directoryPath));
            }

            string[] fileNames = new string[] { };

            try
            {
                fileNames = Directory.GetFiles(directoryPath, pattern);
            }
            catch (Exception exception)
            {
                
            }
            
            foreach(string fileName in fileNames)
            {
                yield return new FileInfo(fileName);
            }
            
            if (searchSubdirectories)
            {
                string[] directoryPaths = new string[] { };

                try
                {
                    directoryPaths = Directory.GetDirectories(directoryPath);
                }
                catch (Exception exception)
                {

                }
                
                foreach (string subDirectoryPath in directoryPaths)
                {
                    if (subDirectoryPath.Contains(pattern))
                    {
                        yield return new DirectoryInfo(subDirectoryPath);
                    }

                    foreach(var subDirectoryFile in Search(subDirectoryPath, pattern, searchSubdirectories))
                    {
                        yield return subDirectoryFile;
                    }
                }
            }
        }

        public void PrintStructure(string directoryPath, StreamWriter sw, int startLevel)
        {
            string[] filePaths = Directory.GetFiles(directoryPath);

            foreach (string filePath in filePaths)
            {
                sw.WriteLine(string.Format("{0}{1}", '\t'.Replicate(startLevel), filePath));
            }

            string[] directoryPaths = Directory.GetDirectories(directoryPath);

            foreach (string subDirectoryPath in directoryPaths)
            {
                sw.WriteLine(string.Format("{0}{1}", '\t'.Replicate(startLevel), subDirectoryPath));

                PrintStructure(subDirectoryPath, sw, startLevel + 1);
            }
        }

        public void PrintStructure(string directoryPath, string outputFilePath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException("Directory was not found.");
            }

            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }

            using (var fs = new FileStream(outputFilePath, FileMode.OpenOrCreate))
            using (var sw = new StreamWriter(fs))
            {
                PrintStructure(directoryPath, sw, 0);
            }
        }
    }
}
