using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utils.Security;

namespace Utils.Specs.Security
{
    [Subject(typeof(CryptService))]
    public class when_encrypting_an_empty_value_with_aesmanaged_algorithm
    {
        Establish context = () =>
        {
            _cryptService = new CryptService();
        };

        Because of = () => { _result = _cryptService.Encrypt<AesManaged>("", "pass", "salt"); };

        It should_return_an_empty_string = () =>
        {
            _result.ShouldEqual("");
        };

        static string _result;
        static CryptService _cryptService;
    }

    [Subject(typeof(CryptService))]
    public class when_encrypting_a_valid_value_with_aesmanaged_algorithm
    {
        Establish context = () =>
        {
            _cryptService = new CryptService();
        };

        Because of = () => { _result = _cryptService.Encrypt<AesManaged>("policija", "pass", "salt"); };

        It should_return_valid_encrypted_text = () =>
        {
            _result.ShouldEqual("rNqyzOGSMjBovVU9MAbhu9giW9V+bspo3PKA8Djm9gA=");
        };

        static string _result;
        static CryptService _cryptService;
    }

    [Subject(typeof(CryptService))]
    public class when_decrypting_a_value_with_aesmanaged_algorithm
    {
        Establish context = () =>
        {
            _cryptService = new CryptService();
        };

        Because of = () => { _result = _cryptService.Decrypt<AesManaged>("rNqyzOGSMjBovVU9MAbhu9giW9V+bspo3PKA8Djm9gA=", "pass", "salt"); };

        It should_return_valid_decrypted_text = () =>
        {
            _result.ShouldEqual("policija");
        };

        static string _result;
        static CryptService _cryptService;
    }
}
