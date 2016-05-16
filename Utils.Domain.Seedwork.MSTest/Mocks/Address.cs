using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Domain.Seedwork.MSTest.Mocks
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; set; }
    }
}
