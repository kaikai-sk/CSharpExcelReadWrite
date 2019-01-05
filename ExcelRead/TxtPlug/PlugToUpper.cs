using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelRead;

namespace TxtPlug
{
    public class PlugToUpper : ExcelRead.IPlug
    {
        public string ProcessText(string txt)
        {
            return txt.ToUpper();
        }
    }
}
