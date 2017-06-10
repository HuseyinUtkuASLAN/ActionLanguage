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
    public partial class frmOutput : Form
    {
        // control lists
        List<Label> lstLabels = new List<Label>();

        Dictionary<string, Fluent> fluents;
        Dictionary<string, Agent> agents;
        Dictionary<string, Color> agentNameColor;
        List<Occlusion> lstOcclusion;
        Dictionary<int, Dictionary<string, Occlusion>> occlusionPoints;
        //List<KeyValuePair<string, KeyValuePair<int,bool> >> changePoints;

        List<ACS> lstAcs;
        List<Fluent> lstObs;
        public Dictionary<int, Dictionary<string, FluentQuery>> dctFluentQuery;

        int timeLimit;
        

        public frmOutput( int timeLimit, Dictionary<string,Fluent> fluents, Dictionary<string, Agent> agents, List<ACS> lstAcs, List<Fluent> lstObs, List<Occlusion> lstOcclusion, Dictionary<int, Dictionary<string, FluentQuery>> dctFluentQuery)
        {
            this.timeLimit = timeLimit;
            this.fluents = fluents;
            this.agents = agents;
            this.lstAcs = lstAcs;
            this.lstObs = lstObs;
            this.lstOcclusion = lstOcclusion;
            this.dctFluentQuery = dctFluentQuery;

            agentNameColor = new Dictionary<string, Color>();
            InitializeComponent();
        }

        private void frmOutput_Load(object sender, EventArgs e)
        {
            occlusionPoints = new Dictionary<int, Dictionary<string, Occlusion>>();

            rtbEntrence.AppendText(Environment.NewLine + "Fluents : " + Environment.NewLine);
            string strFluents = "\t";
            foreach (KeyValuePair<string,Fluent> f in fluents)
            {
                strFluents += f.Value.name + "\t";
            }
            rtbEntrence.AppendText(strFluents + Environment.NewLine);

            if(lstOcclusion.Count > 0)
            {
                Dictionary<string, int> fluentValues = new Dictionary<string, int>();

                rtbEntrence.AppendText(Environment.NewLine + "Occlusion regions : " + Environment.NewLine);
                string strOccurrencesActions = "Occurrences Actions : { ";
                foreach (Occlusion o in lstOcclusion)
                {
                    strFluents = "\t";
                    strFluents += o.fluent.name + " ⊆ Occulate ( " + o.action.name + ", " + o.time.ToString() + " )\n";
                    rtbEntrence.AppendText(strFluents + Environment.NewLine);
                    strOccurrencesActions += "(" + o.action.name + ", " + o.time.ToString() + "), ";

                    //occlusionPoints.Add(o.time, o);
                    try
                    {
                        addOcclusionPoints(ref occlusionPoints, o.time, o.fluent.name, o);
                    }catch (ArgumentException ae)
                    {
                        MessageBox.Show(ae.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                strOccurrencesActions = strOccurrencesActions.Remove(strOccurrencesActions.Length - 2);
                strOccurrencesActions += " }" + Environment.NewLine;
                //Occurrences Actions
                rtbEntrence.AppendText(strOccurrencesActions);


                int startPointX = 30;
                int startPointY = 340;
                int step = 380 / (timeLimit + 1);

                for (int i = 0; i < timeLimit + 1; i++)
                {
                    startPointY = 340;

                    foreach (KeyValuePair<string, Fluent> pair in fluents)
                    {
                        Label label = new Label();
                        Label label2 = new Label();
                        string text = "";
                        if (i != 0)
                        {

                            if(occlusionPoints.ContainsKey(i - 1) && occlusionPoints[i - 1].ContainsKey(pair.Value.name))
                            {
                                if(occlusionPoints[i - 1][pair.Value.name].fluent.value == 0)
                                {
                                    text = "￢";
                                }

                                label.ForeColor = Color.Crimson;

                                bool contains = false;
                                List<Occlusion> lstFoundOcclusion = new List<Occlusion>();
                                
                                foreach(KeyValuePair<string,Occlusion> occPair in occlusionPoints[i-1])
                                {
                                    if(fluentValues.ContainsKey(occPair.Key))
                                    {
                                        Occlusion foundOcc = new Occlusion();
                                        contains = true;
                                        foundOcc = occPair.Value;
                                        lstFoundOcclusion.Add(foundOcc);
                                        //break;
                                    }
                                }
                                foreach(Occlusion foundOcc in lstFoundOcclusion)
                                {
                                    if (!contains)
                                    {
                                        fluentValues.Add(foundOcc.fluent.name, foundOcc.fluent.value);
                                    }
                                    else
                                    {
                                        fluentValues[foundOcc.fluent.name] = foundOcc.fluent.value;
                                    }
                                    label2.ForeColor = Color.Magenta;
                                } 
                                
                            }else
                            {
                                text = "* ";
                            }



                           
                        }
                        else
                        {
                            bool found = false;

                            foreach (Fluent f in lstObs)
                            {
                                if (f.name == pair.Key)
                                {

                                    if (f.value == 0)
                                    {
                                        text = "￢";
                                    }
                                    else
                                    {
                                        text = "";
                                    }

                                    if (!fluentValues.ContainsKey(f.name))
                                    {
                                        fluentValues.Add(f.name, f.value);
                                    }
                                    else
                                    {
                                        fluentValues[f.name] = f.value;
                                    }
                                    found = true;
                                    break;
                                }

                            }
                            if(!found)
                            {
                                text = "* ";
                            }
                        }
                        text += pair.Value.name;

                        

                        
                        label.Parent = this;
                        label.Name = "lbl" + pair.Key + i.ToString();
                        label.Text = text;
                        label.Size = new Size(65, 15);
                        label.Location = new Point(startPointX - 20, startPointY);
                        
                        
                        label.Anchor = AnchorStyles.Top;
                        this.Controls.Add(label);

                        string text2 = "";

                        if (fluentValues.ContainsKey(pair.Key))
                        {
                            //FluentQuery tmpFQuery;
                            //foreach (FluentQuery fQuery in lstFluentQuery)
                            //{
                            //    if (fQuery.fluent.name == pair.Key && fQuery.time == i)
                            //    {
                            //        tmpFQuery = fQuery;
                            //        break;
                            //    }
                            //}
                            
                            if (fluentValues[pair.Key] == 0)
                            {
                                text2 = "￢";
                                if (dctFluentQuery.ContainsKey(i) && dctFluentQuery[i].ContainsKey(pair.Key))
                                {
                                    if(dctFluentQuery[i][pair.Key].value == false)
                                    {
                                        dctFluentQuery[i][pair.Key].valid = true;
                                    }
                                }
                                
                            }
                            else if (fluentValues[pair.Key] == 1)
                            {
                                text2 = "";
                                if (dctFluentQuery.ContainsKey(i) && dctFluentQuery[i].ContainsKey(pair.Key))
                                {
                                    if (dctFluentQuery[i][pair.Key].value == true)
                                    {
                                        dctFluentQuery[i][pair.Key].valid = true;
                                    }
                                }

                            }
                            else
                            {
                                text2 = "* ";
                            }
                        }
                        else
                        {
                            fluentValues.Add(pair.Key, -1 );
                            text2 = "* ";
                        }
                        

                        text2 += pair.Value.name;

                        label2.Parent = this;
                        label2.Name = "lbl" + pair.Key + i.ToString();
                        label2.Text = text2;
                        label2.Size = new Size(65, 15);
                        label2.Location = new Point(startPointX - 20, startPointY + 200);


                        label.Anchor = AnchorStyles.Top;
                        this.Controls.Add(label);

                        startPointY += 20;
                        
                        //xPoint += label.Size.Width;

                    }
                    startPointX += step;
                }

                startPointY += 20;


            }
            

            int xPoint = 12;
            foreach (KeyValuePair<string,Agent> a in agents)
            {
                Label label = new Label();
                label.Location = new Point(xPoint, 235);
                label.Parent = this;
                label.Name = "lbl" + a.Value.name;
                label.Text = a.Key;
                lstLabels.Add(label);
                label.Size = new Size( 80, 15);
                this.Controls.Add(label);

                xPoint += label.Size.Width ;
                
            }
            

            
            
        }

        private void frmOutput_Paint(object sender, PaintEventArgs e)
        {

            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush b = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;

            int i = 0;
            foreach (Label lbl in lstLabels)
            {



                if (i == 0)
                {
                    b.Color = Color.Blue;
                }
                else if (i == 1)
                {
                    b.Color = Color.Green;
                }
                else if (i == 2)
                {
                    b.Color = Color.Purple;
                }
                else if (i == 3)
                {
                    b.Color = Color.Yellow;
                }
                else
                {
                    b.Color = Color.Red;
                }

                i++;
                if (!agentNameColor.ContainsKey(lbl.Text))
                    agentNameColor.Add(lbl.Text, b.Color);
                Rectangle rect = new Rectangle(lbl.Location.X + 10, 260, 20, 10);

                g.DrawRectangle(blackPen, rect);
                g.FillRectangle(b, rect);

                // createLabels(rect.X, rect.Y + 20, ref labelsCreated);
            }

            printGraph(e,300,blackPen,b);

            blackPen.Color = Color.Black;

            printGraph(e, 500, blackPen, b);
        }

        private void printGraph(PaintEventArgs e,int y,Pen blackPen, SolidBrush b)
        {
            Graphics g = e.Graphics;

            

            b.Color = Color.Black;
            Rectangle rectTimeLine = new Rectangle(10, y+20, 380, 1);
            g.DrawRectangle(blackPen, rectTimeLine);
            g.FillRectangle(b, rectTimeLine);

            int startPoint = 40;
            int step = 380 / (timeLimit + 1);


            for (int i = 0; i < timeLimit + 1; i++)
            {
                Rectangle rectCircle = new Rectangle(startPoint, y+15, 5, 10);
                g.DrawRectangle(blackPen, rectCircle);
                g.FillRectangle(b, rectCircle);

                startPoint += step;
            }
            startPoint = 40;
            foreach (ACS a in lstAcs)
            {
                Color c = agentNameColor[a.agent.name];

                int point = startPoint + step * a.time;

                b.Color = c;
                blackPen.Color = c;
                Rectangle actionLine = new Rectangle(point + 5, y, step - 5, 5);
                g.DrawRectangle(blackPen, actionLine);
                g.FillRectangle(b, actionLine);
            }
        }

        private void createLabels (int x, int y, ref bool labelsCreated, Dictionary<string, Fluent> fluents, List<KeyValuePair<string, KeyValuePair<int, bool>>> changePoints, bool minimized = false)
        {
            int xPoint = x, yPoint = y;
            int step = 380 / (timeLimit + 1);

            if (!labelsCreated)
            { 
                foreach(KeyValuePair<string,Fluent> f in fluents)
                {
                    KeyValuePair<int, bool> pair = new KeyValuePair<int, bool>(-1,false); ;
                    bool valueAssigned = false;

                    //search for fluent in changePoints
                    foreach(KeyValuePair<string, KeyValuePair<int, bool>> point in changePoints)
                    {

                        if (point.Key == f.Key)
                        {
                            pair = point.Value;
                            valueAssigned = true;
                            break;
                        }

                    }

                    if(valueAssigned)
                    {
                        int timePoint = pair.Key;

                        for(int i = 0; i < timeLimit; i++)
                        {
                            Label label = new Label();
                            label.Location = new Point(xPoint, yPoint);
                            label.Parent = this;
                            label.Name = "lbl" + f.Key + timePoint.ToString();
                            if (i == timePoint)
                            {
                                if (pair.Value)
                                    label.Text = f.Key;
                                else
                                    label.Text = "¬" + f.Key;
                            }
                            else
                            {
                                label.Text = "*" + f.Key;
                            }
                                
                            
                            lstLabels.Add(label);
                            label.Size = new Size(80, 15);

                            xPoint += step;

                            //this.Controls.Add(label);
                        }

                        xPoint = x;
                        yPoint += 20;
                    }
                    


                }
                

                labelsCreated = true;
            }
        }

        private void addOcclusionPoints(ref Dictionary<int, Dictionary<string,Occlusion>> occlusionPoints,int time,string fluentName,Occlusion occlusion)
        {
            if(occlusionPoints == null)
            {
                occlusionPoints = new Dictionary<int, Dictionary<string, Occlusion>>();
            }

            if (!occlusionPoints.ContainsKey(time))
            {
                Dictionary<string, Occlusion> newItem = new Dictionary<string, Occlusion>();
                newItem.Add(fluentName, occlusion);
                occlusionPoints.Add(time, newItem);
            }else
            {
                if (!occlusionPoints[time].ContainsKey(fluentName))
                {
                    occlusionPoints[time].Add(fluentName, occlusion);
                }
                else
                {
                    throw new ArgumentException("Conflict!");
                }
            }



        }
    }
}
