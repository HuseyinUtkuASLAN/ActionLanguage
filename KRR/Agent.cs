using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public class Agent
    {
        public string name { set; get; }

        public Agent(string name)
        {
            this.name = name;
        }
        
        public Agent ShallowCopy()
        {
            return (Agent)this.MemberwiseClone();
        }

        public bool MemberwiseCompare(Agent a)
        {
            if (a.name == this.name)
                return true;
            else
                return false;
        }
    }
}
