using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.Models.ValueObjects
{
    public class Name
    {
        public Name(string name)
        {
            this.name = name;
        }

        public string name { get; private set; }

        public override string ToString()
        {
            return name;
        }
    }
}
