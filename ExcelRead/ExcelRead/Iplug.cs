using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelRead
{
    public interface IPlug
    {
        string ProcessText(string txt);
    }
}
