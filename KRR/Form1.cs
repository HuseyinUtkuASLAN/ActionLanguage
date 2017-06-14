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
        List<Causes> lstCauses;
        List<Releases> lstReleases;
        public List<Formula> lstFormula;

        // dctFluentQuery[time][fluentName]
        Dictionary<int, Dictionary<string, FluentQuery>> dctFluentQuery;
        Dictionary<int, Dictionary<string, ActionQuery>> dctActionQuery;

        Dictionary<int, Dictionary<string, FluentResultQuery>> dctFluentResultQuery;
        Dictionary<int, Dictionary<string, ActionResultQuery>> dctActionResultQuery;

        public frmInput()
        {
            fluents = new Dictionary<string, Fluent>();
            actions = new Dictionary<string, Action>();
            agents = new Dictionary<string, Agent>();
            lstOBS = new List<Fluent>();
            lstAcs = new List<ACS>();
            lstCauses = new List<Causes>();
            lstReleases = new List<Releases>();
            lstFormula = new List<Formula>();

            dctFluentQuery = new Dictionary<int, Dictionary<string, FluentQuery>>();
            dctActionQuery = new Dictionary<int, Dictionary<string, ActionQuery>>();
            dctFluentResultQuery = new Dictionary<int, Dictionary<string, FluentResultQuery>>();
            dctActionResultQuery = new Dictionary<int, Dictionary<string, ActionResultQuery>>();

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
                cmbFluentQuery.Items.Add(str);
                fluents.Add(str, new Fluent(str));
            }

            foreach (string str in cmbActions.Items)
            {
                cmbLoadedActions.Items.Add(str);
                cmbReleasesActions.Items.Add(str);
                cmbCausesActions.Items.Add(str);
                cmbActionQuery.Items.Add(str);
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
                cmbFluentQueryTime.Items.Add(i.ToString());
                cmbActionQueryTime.Items.Add(i.ToString());
            }
            cmbFluentQueryTime.Items.Add(timeLimit.ToString());
            //cmbActionQueryTime.Items.Add(timeLimit.ToString());
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
            //if (cmbCausesConditions.Text == "")
            //{
            //    MessageBox.Show("Condition fluent is empty");
            //    return;
            //}
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
            if (cmbCausesConditions.Text == "")
            {
                c.value = -1;

                rtbSemantics.AppendText(Environment.NewLine + action + "    by    " + agent + "    causes    " + checkFluent + fluent + Environment.NewLine);

            }
            else {
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

            }



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

            //if (!chkReleasesFluent.Checked)
            //{
            //    checkFluent = "¬ ";
            //    f.value = 0;
            //}
            //else
            //{
            //    f.value = 1;
            //}
            f.value = 1;

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
            if(lstCauses.Count < 1 && lstReleases.Count < 1)
            {
                MessageBox.Show("There are no Causes or Releases statements. Please enter at least 1.");
                return;
            }

            if(dctActionQuery.Count < 1 && dctFluentQuery.Count < 1)
            {
                MessageBox.Show("There are no Action queries or Fluent queries. Please enter at least 1.");
                return;
            }

            occlusionPoints();

            frmQueryResult queryResult = new frmQueryResult(dctFluentResultQuery, dctActionResultQuery);
            queryResult.Show();
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
                frmOutput output = new frmOutput(timeLimit, fluents, agents, lstAcs, lstOBS,lstOcclusion,new Dictionary<int, Dictionary<string, FluentQuery>>(dctFluentQuery));
                if (title != null)
                    output.Text = title;
                else
                    output.Text = "Result";
                output.Show();
                calculateQueries(output.dctFluentQuery);
            }
            

        }

        private void btnAddFluentQuery_Click(object sender, EventArgs e)
        {
            string text = "";
            
            if(cmbQueryFluentNecessity.Text == "")
            {
                MessageBox.Show("Fluent Necessity is empty");
                return ;
            }

            if (cmbFluentQueryTime.Text == "")
            {
                MessageBox.Show("Time is empty");
                return;
            }

            if (cmbFluentQuery.Text == "")
            {
                MessageBox.Show("Fluent is empty");
                return;
            }



            text += cmbQueryFluentNecessity.Text + "  ";

            if (!chkFluentQuery.Checked)
            {
                text += "¬ ";
            }

            text += cmbFluentQuery.Text + "  at  ";
            text += cmbFluentQueryTime.Text + "  when  Sc";

            rtbSemantics.AppendText(Environment.NewLine + text + Environment.NewLine);

            Necessity n;
            if(cmbQueryFluentNecessity.Text == "Necessary")
            {
                n = Necessity.Necessary;
            }
            else
            {
                n = Necessity.Possibly;
            }

            FluentQuery fQuery = new FluentQuery(n, chkFluentQuery.Checked, new Fluent(cmbFluentQuery.Text), int.Parse(cmbFluentQueryTime.Text));
            FluentResultQuery frQuery = new FluentResultQuery(n, chkFluentQuery.Checked, new Fluent(cmbFluentQuery.Text), int.Parse(cmbFluentQueryTime.Text));
            try
            {
                addToFluentQueries(fQuery.time, fQuery.fluent.name, fQuery, ref dctFluentQuery);
                addToFluentResultQueries(frQuery.time, frQuery.fluent.name, frQuery, ref dctFluentResultQuery);
            }
            catch(ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //lstFluentQueries.Add(fQuery);
        }

        private void btnAddActionQuery_Click(object sender, EventArgs e)
        {
            string text = "";

            if (cmbQueryActionNecessity.Text == "")
            {
                MessageBox.Show("Action Necessity is empty");
                return;
            }

            if (cmbActionQueryTime.Text == "")
            {
                MessageBox.Show("Time is empty");
                return;
            }

            if (cmbActionQuery.Text == "")
            {
                MessageBox.Show("Action is empty");
                return;
            }

            text += cmbQueryActionNecessity.Text + "  ";
            text += cmbActionQuery.Text + "  at  ";
            text += cmbActionQueryTime.Text + "  when  Sc";

            rtbSemantics.AppendText(Environment.NewLine + text + Environment.NewLine);

            Necessity n;
            if (cmbQueryActionNecessity.Text == "Necessary")
            {
                n = Necessity.Necessary;
            }
            else
            {
                n = Necessity.Possibly;
            }

            ActionQuery aQuery = new ActionQuery(n, new Action(cmbActionQuery.Text), int.Parse(cmbActionQueryTime.Text));
            ActionResultQuery arQuery = new ActionResultQuery(n, new Action(cmbActionQuery.Text), int.Parse(cmbActionQueryTime.Text));
            try
            {
                addToActionQueries(aQuery.time, aQuery.action.name, aQuery, ref dctActionQuery);
                addToActionResultQueries(arQuery.time, arQuery.action.name, arQuery, ref dctActionResultQuery);
            }catch(ArgumentException ae)
            {
                 MessageBox.Show(ae.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            //lstActionQueries.Add(aQuery);
        }

        private void addToFluentQueries( int time, string fluentName, FluentQuery fQuery, ref Dictionary<int, Dictionary<string, FluentQuery>> dctFluentQuery)
        {
            if(dctFluentQuery == null)
            {
                dctFluentQuery = new Dictionary<int, Dictionary<string, FluentQuery>>();
            }

            if (!dctFluentQuery.ContainsKey(time))
            {
                dctFluentQuery.Add(time, new Dictionary<string, FluentQuery>());
            }

            if (!dctFluentQuery[time].ContainsKey(fluentName))
            {
                dctFluentQuery[time].Add(fluentName, fQuery);
            }
            else
            {
                throw new ArgumentException("Fluent Query is already entered.");
            }
        }

        private void addToActionQueries(int time, string actionName, ActionQuery aQuery, ref Dictionary<int, Dictionary<string, ActionQuery>> dctActionQuery)
        {
            if (dctActionQuery == null)
            {
                dctActionQuery = new Dictionary<int, Dictionary<string, ActionQuery>>();
            }

            if (!dctActionQuery.ContainsKey(time))
            {
                dctActionQuery.Add(time, new Dictionary<string, ActionQuery>());
            }

            if (!dctActionQuery[time].ContainsKey(actionName))
            {
                dctActionQuery[time].Add(actionName, aQuery);
            }
            else
            {
                throw new ArgumentException("Action Query is already entered.");
            }
        }

        private void addToFluentResultQueries(int time, string fluentName, FluentResultQuery frQuery, ref Dictionary<int, Dictionary<string, FluentResultQuery>> dctFluentResultQuery)
        {
            if (dctFluentResultQuery == null)
            {
                dctFluentResultQuery = new Dictionary<int, Dictionary<string, FluentResultQuery>>();
            }

            if (!dctFluentResultQuery.ContainsKey(time))
            {
                dctFluentResultQuery.Add(time, new Dictionary<string, FluentResultQuery>());
            }

            if (!dctFluentResultQuery[time].ContainsKey(fluentName))
            {
                dctFluentResultQuery[time].Add(fluentName, frQuery);
            }
            else
            {
                throw new ArgumentException("Fluent Query is already entered.");
            }
        }

        private void addToActionResultQueries(int time, string actionName, ActionResultQuery arQuery, ref Dictionary<int, Dictionary<string, ActionResultQuery>> dctActionResultQuery)
        {
            if (dctActionResultQuery == null)
            {
                dctActionResultQuery = new Dictionary<int, Dictionary<string, ActionResultQuery>>();
            }

            if (!dctActionResultQuery.ContainsKey(time))
            {
                dctActionResultQuery.Add(time, new Dictionary<string, ActionResultQuery>());
            }

            if (!dctActionResultQuery[time].ContainsKey(actionName))
            {
                dctActionResultQuery[time].Add(actionName, arQuery);
            }
            else
            {
                throw new ArgumentException("Action Query is already entered.");
            }
        }

        private void calculateQueries(Dictionary<int, Dictionary<string, FluentQuery>> dctFluentQuery)
        {
            foreach(KeyValuePair<int, Dictionary<string, FluentQuery>> timePair in dctFluentQuery)
            {
                foreach(KeyValuePair<string,FluentQuery> fluentPair in timePair.Value)
                {
                    bool visited = dctFluentResultQuery[timePair.Key][fluentPair.Key].visited;

                    if (!visited)
                    {
                        dctFluentResultQuery[timePair.Key][fluentPair.Key].visited = true;

                        if(dctFluentResultQuery[timePair.Key][fluentPair.Key].value == fluentPair.Value.value)
                        {
                            dctFluentResultQuery[timePair.Key][fluentPair.Key].valid = fluentPair.Value.valid;
                            //dctFluentResultQuery[timePair.Key][fluentPair.Key].valid = true;
                        }
                        else
                        {
                            dctFluentResultQuery[timePair.Key][fluentPair.Key].valid = false;
                        }
                    } else if(dctFluentResultQuery[timePair.Key][fluentPair.Key].necessity == Necessity.Necessary)
                    {
                        if (dctFluentResultQuery[timePair.Key][fluentPair.Key].valid)
                        {
                            if (dctFluentResultQuery[timePair.Key][fluentPair.Key].value != fluentPair.Value.value)
                            {
                                dctFluentResultQuery[timePair.Key][fluentPair.Key].valid = false;
                            }
                        }
                        
                    }else if(dctFluentResultQuery[timePair.Key][fluentPair.Key].necessity == Necessity.Possibly)
                    {
                        if (!dctFluentResultQuery[timePair.Key][fluentPair.Key].valid)
                        {
                            if (dctFluentResultQuery[timePair.Key][fluentPair.Key].value == fluentPair.Value.value)
                            {
                                dctFluentResultQuery[timePair.Key][fluentPair.Key].valid = true;
                            }
                        }
                    }

                }
            }
            
            foreach(KeyValuePair<int,Dictionary<string, ActionResultQuery>> basePair in dctActionResultQuery)
            {
                foreach(KeyValuePair<string,ActionResultQuery> arQuery in basePair.Value)
                {
                    foreach (ACS acs in lstAcs)
                    {
                        if (acs.time == basePair.Key && acs.action.name == arQuery.Key)
                        {

                            if (!arQuery.Value.visited)
                            {
                                arQuery.Value.visited = true;
                                arQuery.Value.valid = true;
                            }
                            //else if(arQuery.Value.necessity == Necessity.Necessary)
                            //{

                            //}
                            //else if (arQuery.Value.necessity == Necessity.Possibly)
                            //{

                            //}

                            break;
                        }
                    }
                }

                
            }


        }

        private void btnCausesFormula_Click(object sender, EventArgs e)
        {
            frmFormula formula = new frmFormula(fluents,actions,agents,this);
            DialogResult dialogResult = formula.ShowDialog();

            if(dialogResult == DialogResult.Cancel)
            {
                return;
            }else
            {
                string formulaText = lstFormula[lstFormula.Count - 1].text;

                string text = "";

                text += lstFormula[lstFormula.Count - 1].action.name + " by ";
                text += lstFormula[lstFormula.Count - 1].agent.name + "  ";
                text += formulaText + "  ";

                string sign = "";

                if(lstFormula[lstFormula.Count - 1].condition.value == 0)
                {
                    sign = "¬ ";
                }

                text += "  if  " + sign + lstFormula[lstFormula.Count - 1].condition.name;

                rtbSemantics.AppendText(Environment.NewLine + text + Environment.NewLine);

            }
            
        }



    }
}
