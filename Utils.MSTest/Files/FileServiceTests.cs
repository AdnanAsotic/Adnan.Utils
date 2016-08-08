using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Files;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Utils.LinqExtensions;

namespace Utils.MSTest.Files
{
    [TestClass]
    public class FileServiceTests
    {

        [TestMethod]
        public void Search_Should_Find_File()
        {
            //IEnumerable<FileSystemInfo> files = _fileService.Search(@"C:\\", "Microsoft .NET Core 1.0.0 RC2 - SDK Preview 1 (x64).swidtag", true);
            //foreach(var file in files)
            //{
            //    Console.WriteLine(file);
            //}
        }

        [TestMethod]
        public void PrintStructure_Should_Write_Structure_To_File()
        {
            //_fileService.PrintStructure(@"D:\dev\Projects", @"D:\Structure.txt");
        }

        [TestMethod]
        public void Search_Should_Find_File2()
        {
            FileSearcher searcher = new FileSearcher();
            FileStream fs = new FileStream(@"D:\files.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            int i = 0;

            foreach(string file in searcher.FindFiles(@"C:\\"))
            {
                sw.WriteLine(file);
                if (i++ % 100 == 0)
                    sw.Flush();
            }

            sw.Close();
        }
    }
}
