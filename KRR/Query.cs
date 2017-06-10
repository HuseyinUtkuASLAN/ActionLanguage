using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public enum Necessity
    {
        Necessary = 0,
        Possibly = 1
    }

    public class Query
    {
        public Necessity necessity;
        public int time;
        public bool valid = false;
    }

    public class ActionQuery : Query
    {
        public Action action;
        
        public ActionQuery(Necessity necessity,Action action,int time)
        {
            this.necessity = necessity;
            this.action = action;
            this.time = time;
        }
    }

    public class FluentQuery : Query
    {
        public Fluent fluent;
        public bool value;

        public FluentQuery(Necessity necessity, bool value,Fluent fluent, int time)
        {
            this.necessity = necessity;
            this.value = value;
            this.fluent = fluent;
            this.time = time;
        }
    }

    public class FluentResultQuery : FluentQuery
    {
        public bool visited = false;

        public FluentResultQuery(Necessity necessity, bool value, Fluent fluent, int time) : base(necessity, value, fluent, time)
        {
            
        }
    }

    public class ActionResultQuery : ActionQuery
    {
        public bool visited = false;

        public ActionResultQuery(Necessity necessity, Action action, int time) : base(necessity, action, time)
        {

        }
    }

}
