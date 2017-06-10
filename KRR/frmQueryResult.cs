using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRR
{
    public partial class frmQueryResult : Form
    {
        Dictionary<int, Dictionary<string, FluentResultQuery>> dctFluentResultQuery;
        Dictionary<int, Dictionary<string, ActionResultQuery>> dctActionResultQuery;

        public frmQueryResult(Dictionary<int, Dictionary<string, FluentResultQuery>> dctFluentResultQuery, Dictionary<int, Dictionary<string, ActionResultQuery>> dctActionResultQuery)
        {

            this.dctActionResultQuery = dctActionResultQuery;
            this.dctFluentResultQuery = dctFluentResultQuery;
            
            InitializeComponent();
        }

        private void frmQueryResult_Load(object sender, EventArgs e)
        {
            string text = "";
            foreach (KeyValuePair<int, Dictionary<string, ActionResultQuery>> basePair in dctActionResultQuery)
            {
                foreach (KeyValuePair<string, ActionResultQuery> arQuery in basePair.Value)
                {
                    text = Environment.NewLine + "Sc,D";
                    if (arQuery.Value.valid)
                        text += " ≈ ";
                    else
                        text += " ≈/ ";
                    text += arQuery.Value.action.name + " at ";
                    text += basePair.Key.ToString() + " when Sc";
                    text += Environment.NewLine;
                    rtbQueryResults.AppendText(text);
                }
            }

            text = "";

            foreach (KeyValuePair<int, Dictionary<string, FluentResultQuery>> timePair in dctFluentResultQuery)
            {
                foreach (KeyValuePair<string, FluentResultQuery> frQuery in timePair.Value)
                {
                    text = Environment.NewLine + "Sc,D";
                    if (frQuery.Value.valid)
                        text += " ≈ ";
                    else
                        text += " ≈/ ";

                    if (!frQuery.Value.value)
                        //text += "!";
                        text += "  ￢";

                    text += frQuery.Value.fluent.name + " at ";
                    text += timePair.Key.ToString() + " when Sc";
                    text += Environment.NewLine;
                    rtbQueryResults.AppendText(text);
                }
            }
        }
    }
}
