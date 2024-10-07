using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2
{
    public interface IProduct
    {
        string Name { get; }
        double GetPrice();
        int GetStock();
    }
}
