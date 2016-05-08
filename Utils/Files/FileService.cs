using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Files
{
    public class FileService
    {
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

        public bool DeleteFile(string path)
        {
            if (!File.Exists(path))
                return false;

            File.Delete(path);

            return true;
        }
    }
}
