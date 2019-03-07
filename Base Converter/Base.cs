using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Converter
{
    public class Base
    {
        public int BaseType { get; set; }
        public string Name { get; set; }

        public Base(int bType, string name)
        {
            BaseType = bType;
            Name = name;
        }
    }
}
