using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Files;

namespace Utils.Specs.Files
{
    [Subject(typeof(FileService))]
    public class when_createfile_is_called_with_valid_arguments
    {
        Establish context = () =>
        {
            _fileService = new FileService();

            TestHelper.CleanupFiles(OUTPUT_FILE);
        };

        Because of = () =>
        {
            _fileService.CreateFile("D:/output.txt", "input");
        };

        It should_create_file_when_file_doesnt_exist = () =>
        {
            bool exists = File.Exists("D:/output.txt");
            exists.ShouldEqual<bool>(true);
        };

        It should_contain_text_which_was_passed_in = () =>
        {
            string text = File.ReadAllText("D:/output.txt");
            text.ShouldEqual<string>("input");
        };

        Cleanup cleanup = () =>
        {
            TestHelper.CleanupFiles(OUTPUT_FILE);
        };

        const string OUTPUT_FILE = "D:/output.txt";
        private static FileService _fileService;
    }

    [Subject(typeof(FileService))]
    public class when_createfile_is_called_with_invalid_path
    {
        Establish context = () =>
        {
            _fileService = new FileService();

            TestHelper.CleanupFiles(OUTPUT_FILE);
        };

        Because of = () => _exception = Catch.Exception(() => _fileService.CreateFile(null, "input"));

        It should_fail_with_argument_exception = () =>
        {
            _exception.ShouldBeOfExactType<ArgumentException>();
        };

        Cleanup cleanup = () =>
        {
            TestHelper.CleanupFiles(OUTPUT_FILE);
        };

        const string OUTPUT_FILE = "D:/output.txt";
        private static Exception _exception;
        private static FileService _fileService;
    }

    [Subject(typeof(FileService))]
    public class when_createfile_is_called_and_file_already_exists
    {
        Establish context = () =>
        {
            _fileService = new FileService();
            TestHelper.CleanupFiles(OUTPUT_FILE);
        };

        Because of = () =>
        {
            _fileService.CreateFile("D:/output.txt", "");
            _isCreated = _fileService.CreateFile("D:/output.txt", "");
        };

        It should_return_false = () =>
        {
            _isCreated.ShouldEqual<bool>(false);
        };

        const string OUTPUT_FILE = "D:/output.txt";
        private static bool _isCreated = false;
        private static FileService _fileService;
    }

    [Subject(typeof(FileService))]
    public class when_deletefile_is_called_and_file_doesnt_exist
    {
        Establish context = () =>
        {
            _fileService = new FileService();

        };

        Because of = () =>
        {
            _isDeleted = _fileService.DeleteFile("");
        };

        It should_return_false = () =>
        {
            _isDeleted.ShouldEqual<bool>(false);
        };

        const string OUTPUT_FILE = "D:/output.txt";
        private static FileService _fileService;
        private static bool _isDeleted;
    }
}
