using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public class  Semantics
    {
        public string name { set; get; }
    }

    public class Initially : Semantics
    {
        public Fluent fluent;
    }

    public class Releases : Semantics
    {
        public Fluent fluent;
        public Fluent condition;
        public Action action;
        public Agent agent;
    }

    public class Causes : Semantics
    {
        public Fluent fluent;
        public Fluent condition;
        public Action action;
        public Agent agent;
    }
}
