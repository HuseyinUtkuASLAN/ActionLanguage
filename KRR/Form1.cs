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
    public partial class frmInput : Form
    {
        int timeLimit;

        Dictionary<string, Fluent> fluents;
        Dictionary<string, Action> actions;
        Dictionary<string, Agent> agents;

        List<Fluent> lstOBS;
        List<ACS> lstAcs;
        List<Initially> lstInitially;
        List<Causes> lstCauses;
        List<Releases> lstReleases;


        public frmInput()
        {
            fluents = new Dictionary<string, Fluent>();
            actions = new Dictionary<string, Action>();
            agents = new Dictionary<string, Agent>();
            lstOBS = new List<Fluent>();
            lstAcs = new List<ACS>();
            lstInitially = new List<Initially>();
            lstCauses = new List<Causes>();
            lstReleases = new List<Releases>();

            InitializeComponent();
#if DEBUG
            cmbActions.Items.Add("Test Action");
            cmbFluents.Items.Add("TestFluent");
            cmbAgents.Items.Add("Test Agent");
#endif
            cmbTimeLimit.SelectedIndex = 4;
        }

        private void btnAddAgent_Click(object sender, EventArgs e)
        {
            string input = tbxNewAgent.Text;
            if (input == "")
            {
                MessageBox.Show("Agent cannot be empty string");
                return;
            }
            else if (cmbAgents.Items.Contains(input))
            {
                MessageBox.Show("Agent is already in the list. Agent : " + input);
                return;
            }
            cmbAgents.Items.Add(input);
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            string input = txtNewAction.Text;
            if (input == "")
            {
                MessageBox.Show("Action cannot be empty string");
                return;
            }
            else if (cmbActions.Items.Contains(input))
            {
                MessageBox.Show("Action is already in the list. Agent : " + input);
                return;
            }
            cmbActions.Items.Add(input);
        }

        private void btnAddFluent_Click(object sender, EventArgs e)
        {
            string input = txtNewFluent.Text;
            if (input == "")
            {
                MessageBox.Show("Fluent cannot be empty string");
                return;
            }
            else if (cmbFluents.Items.Contains(input))
            {
                MessageBox.Show("Fluent is already in the list. Agent : " + input);
                return;
            }
            cmbFluents.Items.Add(input);
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            if(cmbFluents.Items.Count == 0)
            {
                MessageBox.Show("Fluent can not be empty!");
                return;
            }
            if (cmbAgents.Items.Count == 0)
            {
                MessageBox.Show("Agents can not be empty!");
                return;
            }
            if (cmbActions.Items.Count == 0)
            {
                MessageBox.Show("Actions can not be empty!");
                return;
            }

            pnlInput.Enabled = false;
            pnlScenario.Enabled = true;

            timeLimit = int.Parse(cmbTimeLimit.Text);

            foreach(string str in cmbFluents.Items)
            {
                cmbLoadedFluents.Items.Add(str);
                cmbReleasesConditions.Items.Add(str);
                cmbCausesConditions.Items.Add(str);
                cmbReleasesFluents.Items.Add(str);
                cmbCausesFluents.Items.Add(str);
                cmbInitialFluents.Items.Add(str);
                fluents.Add(str, new Fluent(str));
            }

            foreach (string str in cmbActions.Items)
            {
                cmbLoadedActions.Items.Add(str);
                cmbReleasesActions.Items.Add(str);
                cmbCausesActions.Items.Add(str);
                actions.Add(str, new Action(str));
            }

            foreach (string str in cmbAgents.Items)
            {
                cmbLoadedAgents.Items.Add(str);
                cmbReleaesAgents.Items.Add(str);
                cmbCausesAgents.Items.Add(str);
                agents.Add(str, new Agent(str));
            }

            for (int i = 0; i < timeLimit; i++)
            {
                cmbLoadedTime.Items.Add(i.ToString());
            }
        }

        private void btnAddOBS_Click(object sender, EventArgs e)
        {
            string str = cmbLoadedFluents.Text;
            if (str == "")
            {
                MessageBox.Show("Fluent is empty!");
                return;
            }
            if (chkFluent.Checked)
            {
                fluents[str].value = 1;
            }else
            {
                fluents[str].value = 0;
            }

            lstOBS.Add(fluents[str]);
            lblOBS.Text = getOBSText();

            lstOBS.Add(fluents[str]);
        }

        private void btnAddACS_Click(object sender, EventArgs e)
        {
            if (cmbLoadedActions.Text == "")
            {
                MessageBox.Show("Action is empty");
                return;
            }

            if (cmbLoadedAgents.Text == "")
            {
                MessageBox.Show("Agent is empty");
                return;
            }

            if (cmbLoadedTime.Text == "")
            {
                MessageBox.Show("Fluent is empty");
                return;
            }

            foreach (ACS acs in lstAcs)
            {
                if (acs.time == int.Parse(cmbLoadedTime.Text))
                {
                    MessageBox.Show("There is an action in that time.");
                    return;
                }
            }

            Agent agent = new Agent(cmbLoadedAgents.Text);
            Action action = new Action(cmbLoadedActions.Text);
            //Fluent fluent = new Fluent(cmbLoadedFluents.Text);
            int time = int.Parse(cmbLoadedTime.Text);

            ACS a = new ACS(agent, action, time);

            lstAcs.Add(a);

            lblACS.Text = getACSText();
            
        }

        private void btnSaveScenerio_Click(object sender, EventArgs e)
        {
            pnlScenario.Enabled = false;
            pnlSemantics.Enabled = true;

            rtbSemantics.AppendText("Sc = (OBS,ACS)" + Environment.NewLine);

            rtbSemantics.AppendText(Environment.NewLine + "\t" + getOBSText() + Environment.NewLine);
            rtbSemantics.AppendText(Environment.NewLine + "\t" +getACSText() + Environment.NewLine);


        }

        private void btnAddInitial_Click(object sender, EventArgs e)
        {
            if (cmbInitialFluents.Text == "")
            {
                MessageBox.Show("Initially fluent is empty");
                return;
            }

            Fluent f = new Fluent(cmbInitialFluents.Text);
            string check = "";

            if (!chkInitial.Checked)
            {
                check = "¬ ";
                f.value = 0;
            }
            else
            {
                f.value = 1;
            }
            rtbSemantics.AppendText(Environment.NewLine + "Initially    " + check + cmbInitialFluents.Text + Environment.NewLine);

            Initially initially = new Initially();
            initially.name = cmbInitialFluents.Text;

            initially.fluent = f;
        }

        private void btnAddCauses_Click(object sender, EventArgs e)
        {
            if (cmbCausesActions.Text == "")
            {
                MessageBox.Show("Action is empty");
                return;
            }
            if (cmbCausesAgents.Text == "")
            {
                MessageBox.Show("Agent is empty");
                return;
            }
            if (cmbCausesFluents.Text == "")
            {
                MessageBox.Show("Fluent is empty");
                return;
            }
            if (cmbCausesConditions.Text == "")
            {
                MessageBox.Show("Condition fluent is empty");
                return;
            }
            string action = cmbCausesActions.Text;
            string agent = cmbCausesAgents.Text;
            string fluent = cmbCausesFluents.Text;
            string condition = cmbCausesConditions.Text;
            string checkFluent = "";
            string checkCondition = "";


            Fluent f = new Fluent(fluent);
            Fluent c = new Fluent(condition);
            if (!chkCausesFluent.Checked)
            {
                checkFluent = "¬ ";
                f.value = 0;
            }
            else
            {
                f.value = 1;
            }

            if (!chkCausesCondition.Checked)
            {
                checkCondition = "¬ ";
                c.value = 0;
            }
            else
            {
                c.value = 1;
            }

            rtbSemantics.AppendText(Environment.NewLine + action + "    by    " + agent + "    causes    " + checkFluent + fluent + "    if    " + checkCondition + condition + Environment.NewLine);

            Causes causes = new Causes();
            causes.action = actions[action];
            causes.agent = agents[agent];
            causes.fluent = f;
            causes.condition = c;

            lstCauses.Add(causes);

        }

        private void btnAddReleases_Click(object sender, EventArgs e)
        {
            if (cmbReleasesActions.Text == "")
            {
                MessageBox.Show("Action is empty");
                return;
            }
            if (cmbReleaesAgents.Text == "")
            {
                MessageBox.Show("Agent is empty");
                return;
            }
            if (cmbReleasesFluents.Text == "")
            {
                MessageBox.Show("Fluent is empty");
                return;
            }
            if (cmbReleasesConditions.Text == "")
            {
                MessageBox.Show("Condition fluent is empty");
                return;
            }
            string action = cmbReleasesActions.Text;
            string agent = cmbReleaesAgents.Text;
            string fluent = cmbReleasesFluents.Text;
            string condition = cmbReleasesConditions.Text;
            string checkFluent = "";
            string checkCondition = "";

            Fluent f = new Fluent(fluent);
            Fluent c = new Fluent(condition);
            if (!chkReleasesFluent.Checked)
            {
                checkFluent = "¬ ";
                f.value = 0;
            }
            else
            {
                f.value = 1;
            }

            if (!chkReleasesCondition.Checked)
            {
                checkCondition = "¬ ";
            }
            else
            {
                c.value = 1;
            }

            rtbSemantics.AppendText(Environment.NewLine + action + "    by    " + agent + "    releases    " + checkFluent + fluent + "    if    " + checkCondition + condition + Environment.NewLine);

            Releases releases = new Releases();
            releases.action = actions[action];
            releases.agent = agents[agent];
            releases.fluent = f;
            releases.condition = c;

            lstReleases.Add(releases);
        }

        string getACSText ()
        {
            string returnText;

            returnText = "ACS = { ";

            foreach (ACS acs in lstAcs)
            {
                string text = "( " + acs.agent.name + ", " + acs.action.name + ", " + acs.time.ToString() + " ), ";
                returnText += text;
            }
            if(lstAcs.Count > 0)
                returnText = returnText.Remove(returnText.Length - 2);
            returnText += " }";

            return returnText;
        }

        string getOBSText()
        {
            string returnText;
            int i = 0;
            returnText = "OBS = { (";
            foreach (KeyValuePair<string, Fluent> fluent in fluents)
            {

                if (fluent.Value.value != -1)
                {
                    if (fluent.Value.value == 0)
                    {
                        string change = "¬ " + fluent.Value.name + " Λ ";
                        returnText += change;
                    }
                    else
                    {
                        string change = "" + fluent.Value.name + " Λ ";
                        returnText += change;
                    }
                }
                i++;
            }
            if (i > 0)
                returnText = returnText.Remove(returnText.Length - 2);
            returnText += ", 0 ) }";

            return returnText;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            occlusionPoints();
        }

        private void occlusionPoints()
        {
            List<Occlusion> lstOcclusion = new List<Occlusion>();

            foreach(Causes c in lstCauses)
            {
                foreach(ACS a in lstAcs)
                {
                    if(a.agent.MemberwiseCompare(c.agent) && a.action.MemberwiseCompare(c.action))
                    {
                        Occlusion ocs = new Occlusion();
                        ocs.action = c.action.ShallowCopy();
                        ocs.agent = c.agent.ShallowCopy();
                        ocs.condition = c.condition;
                        ocs.fluent = c.fluent;

                        ocs.time = a.time;

                        lstOcclusion.Add(ocs);

                    }
                }
                
            }

            createReleasePoints(lstOcclusion, lstReleases);

        }

        private void createReleasePoints(List<Occlusion> lstOcclusion,List<Releases> lstReleases,string title = null)
        {

            //MessageBox.Show("hi");
            foreach (Releases r in lstReleases)
            {
                foreach(ACS a in lstAcs)
                {
                    if(a.agent.MemberwiseCompare(r.agent) && a.action.MemberwiseCompare(r.action))
                    {

                        List<Occlusion> newLstOcclusion = new List<Occlusion>(lstOcclusion);
                        List<Releases> newLstReleases = new List<Releases>(lstReleases);

                        Occlusion ocl = new Occlusion();

                        ocl.fluent = r.fluent.ShallowCopy();
                        ocl.fluent.value = 1;
                        ocl.condition = r.condition.ShallowCopy();

                        ocl.agent = a.agent.ShallowCopy();

                        ocl.action = a.action.ShallowCopy();

                        ocl.time = a.time;

                        lstOcclusion.Add(ocl);

                        Occlusion oclNew = new Occlusion();

                        oclNew.fluent = r.fluent.ShallowCopy();
                        oclNew.fluent.value = 0;
                        oclNew.condition = r.condition.ShallowCopy();

                        oclNew.agent = a.agent.ShallowCopy();

                        oclNew.action = a.action.ShallowCopy();

                        oclNew.time = a.time;

                        newLstReleases.Remove(r);
                        newLstOcclusion.Add(oclNew);
                        
                        string titleNew = "¬ " + r.fluent.name;
                        string titleOld = r.fluent.name;
                        createReleasePoints(newLstOcclusion, newLstReleases,titleNew);
                        createReleasePoints(lstOcclusion, newLstReleases,titleOld);
                        
                        break;
                    }
                }
            }

            
            if(lstReleases.Count == 0)
            {
                frmOutput output = new frmOutput(timeLimit, fluents, agents, lstAcs, lstOBS,lstOcclusion);
                if (title != null)
                    output.Text = title;
                else
                    output.Text = "Result";
                output.Show();
            }
            

        }

    }
}
