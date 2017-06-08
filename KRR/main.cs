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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            frmInput input = new frmInput();
            input.ShowDialog();
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            InformationForms.frmDescription desc = new InformationForms.frmDescription();
            desc.Show();
        }

        private void btnSigniture_Click(object sender, EventArgs e)
        {
            InformationForms.Signiture sig = new InformationForms.Signiture();
            sig.Show();
        }

        private void btnScenarios_Click(object sender, EventArgs e)
        {
            InformationForms.Scenarios scn = new InformationForms.Scenarios();
            scn.Show();
        }

        private void btnSyntax_Click(object sender, EventArgs e)
        {
            InformationForms.Syntax syt = new InformationForms.Syntax();
            syt.Show();
        }

        private void btnSemantics_Click(object sender, EventArgs e)
        {
            InformationForms.Semantics sem = new InformationForms.Semantics();
            sem.Show();
        }

        private void btnQueries_Click(object sender, EventArgs e)
        {
            InformationForms.Queries que = new InformationForms.Queries();
            que.Show();
        }
    }
}
