using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL.Data
{
    public class HLUnitOfWork : UnitOfWork
    {
        public HLUnitOfWork()
            :base()
        {
           
        }
        public override DbContext GetDbContext()
        {
            return new NorthwindContext();
        }
    }
}
