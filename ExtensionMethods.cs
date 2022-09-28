using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static Font FontFromString(this string str)
        {
            FontConverter fc = new FontConverter();
            return (Font)fc.ConvertFromString(str);
        }
    }
}
