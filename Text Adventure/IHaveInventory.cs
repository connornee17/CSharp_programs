using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_1
{
    public interface IHaveInventory
    {
        GameObj Locate(string id);


        string Name
        {
            get;
        }
    }
}
