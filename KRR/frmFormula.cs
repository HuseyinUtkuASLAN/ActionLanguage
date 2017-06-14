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
    public partial class frmFormula : Form
    {
        Dictionary<string, Fluent> fluents;
        Dictionary<string, Action> actions;
        Dictionary<string, Agent> agents;

        Formula formula;
        frmInput formInput;

        public frmFormula(Dictionary<string, Fluent> fluents, Dictionary<string, Action> actions, Dictionary<string, Agent> agents,frmInput formInput)
        {
            formula = new Formula();
            this.fluents = fluents;
            this.actions = actions;
            this.agents = agents;
            this.formInput = formInput;
            InitializeComponent();
        }

        private void frmFormula_Load(object sender, EventArgs e)
        {
            foreach(KeyValuePair<string,Fluent> pair in fluents)
            {
                cmbCauses0.Items.Add(pair.Key);
                cmbCauses1.Items.Add(pair.Key);
                cmbCondition.Items.Add(pair.Key);
            }
            foreach(KeyValuePair<string,Agent> pair in agents)
            {
                cmbCausesAgents.Items.Add(pair.Key);
            }
            foreach(KeyValuePair<string,Action> pair in actions)
            {
                cmbCausesActions.Items.Add(pair.Key);
            }
        }

        private void btnAdd0_Click(object sender, EventArgs e)
        {
            string sign = "";
            Fluent f = new Fluent(cmbCauses0.Text);
            if (chkCauses0.Checked)
            {
                f.value = 1;
                sign = "";
            }
            else
            {
                f.value = 0;
                sign = "¬";
            }

            foreach (Fluent cf in formula.lstCauses0)
            {
                if (cf.name == f.name)
                {
                    MessageBox.Show("Fluent is already entered");
                    return;
                }
            }

            formula.addToList0(f);

            if (rtbFormula.Text == "")
            {
                rtbFormula.Text = "( " + sign + f.name + " )";
            }
            else
            {
                string text = rtbFormula.Text;

                text = text.Insert(text.Length - 2, " Λ " + sign + f.name);

                rtbFormula.Text = text;
            }
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            if (rtbFormula.Text == "")
            {
                MessageBox.Show("You need to add a fluent before adding 'OR'");
                return;
            }
            pnlCauses0.Enabled = false;
            pnlCauses1.Enabled = true;
            
            rtbFormula.Text += "  V  ";
            btnOr.Enabled = false;
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            string sign = "";
            Fluent f = new Fluent(cmbCauses1.Text);
            if (chkCauses1.Checked)
            {
                f.value = 1;
                sign = "";
            }
            else
            {
                f.value = 0;
                sign = "¬";
            }
            
            foreach(Fluent cf in formula.lstCauses1)
            {
                if(cf.name == f.name)
                {
                    MessageBox.Show("Fluent is already entered");
                    return;
                }
            }

            formula.addToList1(f);

            if (rtbFormula.Text[rtbFormula.Text.Length - 1] != ')')
            {
                rtbFormula.Text += "( " + sign + f.name + " )";
            }
            else
            {
                string text = rtbFormula.Text;

                text = text.Insert(text.Length - 2, " Λ " + sign + f.name);

                rtbFormula.Text = text;
            }

        }

        private void btnAddFormula_Click(object sender, EventArgs e)
        {
            if(rtbFormula.Text == "")
            {
                MessageBox.Show("Formula is empty.");
                return;
            }
            if(cmbCausesActions.Text == "")
            {
                MessageBox.Show("Actions is empty.");
                return;
            }
            if (cmbCausesAgents.Text == "")
            {
                MessageBox.Show("Agents is empty.");
                return;
            }
            if (cmbCondition.Text == "")
            {
                MessageBox.Show("Condition is empty.");
                return;
            }

            formula.text = rtbFormula.Text;
            formula.action = actions[cmbCausesActions.Text];
            formula.agent = agents[cmbCausesAgents.Text];
            formula.condition = fluents[cmbCondition.Text];

            formInput.lstFormula.Add(formula);

            DialogResult = DialogResult.OK;
        }
    }
}
