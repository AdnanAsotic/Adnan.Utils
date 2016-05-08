using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Collections;

namespace Utils.Specs.Collections
{
    [Subject(typeof(EnumerableProviders))]
    public class when_collection_is_empty_and_iscontained_in_is_called
    {
        Establish context = () =>
        {
            _col = new List<string> { };
        };

        Because of = () =>
        {
            _isContained = _col.IsContainedIn("test");
        };

        It should_return_false = () =>
        {
            _isContained.ShouldEqual(false);
        };

        static bool _isContained;
        static IEnumerable<string> _col;
    }

    [Subject(typeof(EnumerableProviders))]
    public class when_collection_contains_entry_and_iscontainedin_is_called
    {
        Establish context = () =>
        {
            _col = new List<string> { "test" };
        };

        Because of = () =>
        {
            _isContained = _col.IsContainedIn("test");
        };

        It should_return_true = () =>
        {
            _isContained.ShouldEqual(true);
        };

        static bool _isContained;
        static IEnumerable<string> _col;
    }
}
