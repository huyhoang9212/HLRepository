using HL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindContext context = new NorthwindContext();
            var customer = context.Customers.Find("AS001");
        }
    }
}
