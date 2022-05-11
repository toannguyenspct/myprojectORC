using inter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inter.Interface
{
    public interface ItesttblService
    {
        IEnumerable<testtbl> GetALL();

        testtbl GetById();

        void Addtesttbl(testtbl tbl);
    }
}
