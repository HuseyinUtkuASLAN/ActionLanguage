using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRR
{
    public class Formula
    {
        public List<Fluent> lstCauses0;
        public List<Fluent> lstCauses1;
        public Action action;
        public Agent agent;

        public string text;

        public bool or = false;

        public Fluent condition;

        public Formula()
        {
            lstCauses0 = new List<Fluent>();
            lstCauses1 = new List<Fluent>();
        }

        public void addToList0 (Fluent f)
        {
            lstCauses0.Add(f);
        }

        public void addToList1 (Fluent f)
        {
            lstCauses1.Add(f);
        }
    }
}
