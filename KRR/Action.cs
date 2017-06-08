using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public class Action
    {
        public Action(string name)
        {
            this.name = name;
        }
        public string name { set; get; }

        public Action ShallowCopy()
        {
            return (Action)this.MemberwiseClone();
        }

        public bool MemberwiseCompare (Action a)
        {
            if (a.name == this.name)
                return true;
            else
                return false;
        }
    }
}
