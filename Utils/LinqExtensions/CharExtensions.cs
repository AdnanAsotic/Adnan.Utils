using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.LinqExtensions
{
    public static class CharExtensions
    {
        public static string Replicate(this char c, int times)
        {
            return new string(Enumerable.Range(0, times).Select(i => c).ToArray());
        }
    }
}
