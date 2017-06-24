using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public class OBS : Fluent
    {
        public int time;

        public OBS (Fluent fluent, int time) : base(fluent.name)
        {
            this.value = fluent.value;
            this.time = time;
        }

    }   
}
