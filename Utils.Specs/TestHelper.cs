using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Specs
{
    public static class TestHelper
    {
        public static void CleanupFiles(params string[] files)
        {
            foreach(string file in files)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
