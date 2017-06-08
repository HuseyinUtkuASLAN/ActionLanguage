using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public class ACS
    {
        public Agent agent { set; get; }
        public Action action { set; get; }
        public int time { set; get; }

        public ACS(Agent agent,Action action, int time)
        {
            this.agent = agent;
            this.action = action;
            this.time = time;
        }

        public bool Compare (ACS acs)
        {
            
            if (this.agent != acs.agent)
                return false;
            if (this.action != acs.action)
                return false;
            if (this.time != acs.time)
                return false;

            return true;
        }

    }
}
