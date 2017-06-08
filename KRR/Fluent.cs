using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public class Fluent
    {
        public Fluent(string name)
        {
            this.name = name;
            this.value = -1;
        }
        public string name { set; get; }
        public int value { set; get; }

        public Fluent ShallowCopy()
        {
            return (Fluent)this.MemberwiseClone();
        }
        
    }
}
