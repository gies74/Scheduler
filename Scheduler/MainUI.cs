using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Xml;
using System.Diagnostics;
// using Microsoft.Win32;

namespace Scheduler
{
    public partial class MainUI : Form
    {
        private string _currXDocFileName;
        private frmResource _frmResource;
        private Dictionary<MeetingSpec,frmMeeting> _frmMeetingDict;
        private bool _dirty = false;
        private Thread _engineThread;
        private frmAbout _frmAbout = new frmAbout();
        public MainUI()
        {
            InitializeComponent();
            _frmResource = null;
            _frmMeetingDict = new Dictionary<MeetingSpec,frmMeeting>();
        }

        internal ListView LVResources
        {
            get { return lvResources; }
        }
        internal ListView LVMeetings
        {
            get { return lvMeetings; }
        }
        internal string NoParSess
        {
            get { return tbxParSess.Text; }
        }
        internal string NoSessBlocks
        {
            get { return tbxSessBlocks.Text; }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckSaveChanges())
                return;
            //openFileDialog1.InitialDirectory = RestorableDirectory(null);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _currXDocFileName = openFileDialog1.FileName;
                LoadSpecs();
            }
        }

        //private string RestorableDirectory(string sDir)
        //{
        //    if (sDir == null)
        //    {
        //        string s = Registry.CurrentUser.GetValue(@"Software\Gies\Scheduler") as string;
        //        if (s == null)
        //            s = "";
        //        return s;
        //    }
        //    else
        //    {
        //        Registry.CurrentUser.SetValue(@"Software\Gies\Scheduler", sDir);
        //        return null;
        //    }
        //}

        private void SaveSpecs()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement xSpecs = xDoc.CreateElement("SCHEDULE_SPECS");

            XmlElement xResources = xDoc.CreateElement("RESOURCES");
            foreach (ListViewItem lvi in lvResources.Items)
            {
                XmlElement xResource = xDoc.CreateElement("RESOURCE");
                Resource pResource = lvi.Tag as Resource;
                XmlAttribute xaName = xDoc.CreateAttribute("name");
                xaName.Value = pResource.Name;
                xResource.Attributes.Append(xaName);
                XmlAttribute xaType = xDoc.CreateAttribute("type");
                xaType.Value = pResource.Type.ToString().ToLower();
                xResource.Attributes.Append(xaType);
                xResources.AppendChild(xResource);
            }
            xSpecs.AppendChild(xResources);

            XmlElement xMeetings = xDoc.CreateElement("MEETINGS");
            foreach (ListViewItem lvi in lvMeetings.Items)
            {
                XmlElement xMeeting = xDoc.CreateElement("MEETING");
                MeetingSpec pMeeting = lvi.Tag as MeetingSpec;
                XmlAttribute xaTopic = xDoc.CreateAttribute("topic");
                xaTopic.Value = pMeeting.Topic;
                xMeeting.Attributes.Append(xaTopic);
                XmlElement xDescription = xDoc.CreateElement("DESCRIPTION");
                XmlText xDescVal = xDoc.CreateTextNode(pMeeting.Description);
                xDescription.AppendChild(xDescVal);
                xMeeting.AppendChild(xDescription);
                
                xResources = xDoc.CreateElement("RESOURCES");
                foreach (Resource pReqRsrc in pMeeting.RequiredResources)
                {
                    XmlElement xResource = xDoc.CreateElement("RESOURCE");
                    XmlAttribute xaName = xDoc.CreateAttribute("name");
                    xaName.Value = pReqRsrc.Name;
                    xResource.Attributes.Append(xaName);
                    XmlAttribute xaLevel = xDoc.CreateAttribute("level");
                    xaLevel.Value = "required";
                    xResource.Attributes.Append(xaLevel);
                    xResources.AppendChild(xResource);
                }
                foreach (Resource pDesRsrc in pMeeting.DesiredResources)
                {
                    XmlElement xResource = xDoc.CreateElement("RESOURCE");
                    XmlAttribute xaName = xDoc.CreateAttribute("name");
                    xaName.Value = pDesRsrc.Name;
                    xResource.Attributes.Append(xaName);
                    XmlAttribute xaLevel = xDoc.CreateAttribute("level");
                    xaLevel.Value = "desired";
                    xResource.Attributes.Append(xaLevel);
                    xResources.AppendChild(xResource);
                }
                xMeeting.AppendChild(xResources);
                xMeetings.AppendChild(xMeeting);
            }
            xSpecs.AppendChild(xMeetings);

            XmlElement xSettings = xDoc.CreateElement("SETTINGS");
            XmlElement xSetting;
            XmlAttribute xaSettname, xaValue;
            xSetting = xDoc.CreateElement("SETTING");
            xaSettname = xDoc.CreateAttribute("name");
            xaSettname.Value = "noParSess";
            xSetting.Attributes.Append(xaSettname);
            xaValue = xDoc.CreateAttribute("value");
            xaValue.Value = tbxParSess.Text;
            xSetting.Attributes.Append(xaValue);
            xSettings.AppendChild(xSetting);
            xSetting = xDoc.CreateElement("SETTING");
            xaSettname = xDoc.CreateAttribute("name");
            xaSettname.Value = "noSessBlocks";
            xSetting.Attributes.Append(xaSettname);
            xaValue = xDoc.CreateAttribute("value");
            xaValue.Value = tbxSessBlocks.Text;
            xSetting.Attributes.Append(xaValue);
            xSettings.AppendChild(xSetting);
            xSpecs.AppendChild(xSettings);

            xDoc.AppendChild(xSpecs);
            xDoc.Save(_currXDocFileName);
            _dirty = false;
        }

        private void InitUI(bool solutionsTabOnly)
        {
            if (!solutionsTabOnly)
            {
                lvResources.Items.Clear();
                lvMeetings.Items.Clear();
                tbxParSess.Text = "1";
                tbxSessBlocks.Text = "1";
                foreach (ColumnHeader ch in lvResources.Columns)
                    ch.Tag = null;
                foreach (ColumnHeader ch in lvMeetings.Columns)
                    ch.Tag = null;
            }
            tbxSolution.Clear();
            lvSolutions.Items.Clear();
            lblScore.Text = "Score:";
            lblProgress.Text = "";
            pgbProgress.Value = pgbProgress.Minimum;
        }

        private void LoadSpecs()
        {
            InitUI(false);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(_currXDocFileName);
            XmlNodeList xResources = xDoc.DocumentElement.SelectNodes("RESOURCES/RESOURCE");
            foreach (XmlNode xResource in xResources)
            {
                Resource pResource = new Resource(xResource.Attributes["name"].Value, xResource.Attributes["type"].Value);
                AddResource(pResource);
            }
            XmlNodeList xMeetings = xDoc.DocumentElement.SelectNodes("MEETINGS/MEETING");
            foreach (XmlNode xMeeting in xMeetings)
            {
                string topic = xMeeting.Attributes["topic"].Value;
                MeetingSpec pMeeting = new MeetingSpec(topic);
                pMeeting.Description = xMeeting.SelectSingleNode("DESCRIPTION").InnerText;
                XmlNodeList xRelatedRsrcs = xMeeting.SelectNodes("RESOURCES/RESOURCE");
                foreach (XmlNode xRelatedRsrc in xRelatedRsrcs)
                {
                    Resource pResource = FindResourceByName(xRelatedRsrc.Attributes["name"].Value);
                    if (pResource != null)
                    {
                        string level = xRelatedRsrc.Attributes["level"].Value;
                        if (level == "required")
                            pMeeting.AddRequired(pResource);
                        else if (level == "desired")
                            pMeeting.AddDesired(pResource);
                    }
                }
                AddMeeting(pMeeting);
            }
            UpdateResourceCounts();
            XmlNode xSetting;
            xSetting = xDoc.DocumentElement.SelectSingleNode("SETTINGS/SETTING[@name='noParSess']");
            tbxParSess.Text = xSetting.Attributes["value"].Value;
            xSetting = xDoc.DocumentElement.SelectSingleNode("SETTINGS/SETTING[@name='noSessBlocks']");
            tbxSessBlocks.Text = xSetting.Attributes["value"].Value;
            _dirty = false;
        }

        private void AddResource(Resource pResource)
        {
            ListViewItem lvi = lvResources.Items.Add(pResource.Name, pResource.Name, 0);
            lvi.SubItems.Add(pResource.Type.ToString().ToLower());
            lvi.SubItems.Add(pResource.NumReqMeetings.ToString());
            lvi.SubItems.Add(pResource.NumDesMeetings.ToString());
            lvi.Tag = pResource;
        }

        private void AddMeeting(MeetingSpec pMeeting)
        {
            ListViewItem lvi = lvMeetings.Items.Add(pMeeting.Topic, pMeeting.Topic, 0);
            string desc = pMeeting.Description;
            lvi.SubItems.Add(desc.Substring(0, Math.Min(desc.Length, 40)));
            lvi.SubItems.Add(pMeeting.RequiredResources.Count.ToString());
            lvi.SubItems.Add(pMeeting.DesiredResources.Count.ToString());
            lvi.Tag = pMeeting;
            cmdRun.Enabled = (lvMeetings.Items.Count > 0);
        }

        private Resource FindResourceByName(string name)
        {
            ListViewItem lvi = lvResources.Items[name];
            if (lvi != null)
            {
                return lvi.Tag as Resource;
            }
            return null;
        }

        private void UpdateCounts(string topic)
        {
            ListViewItem lvi = lvMeetings.Items[topic];
            if (lvi != null)
            {
                MeetingSpec pMeeting = lvi.Tag as MeetingSpec;
                lvi.SubItems[2].Text = pMeeting.RequiredResources.Count.ToString();
                lvi.SubItems[3].Text = pMeeting.DesiredResources.Count.ToString();
            }
            UpdateResourceCounts();
        }

        private void UpdateResourceCounts()
        {
            foreach (ListViewItem lvi in lvResources.Items)
            {
                Resource r = lvi.Tag as Resource;
                int req = 0, des = 0;
                foreach (ListViewItem lvi2 in lvMeetings.Items)
                {
                    MeetingSpec ms = lvi2.Tag as MeetingSpec;
                    if (ms.RequiredResources.Contains(r))
                        req++;
                    if (ms.DesiredResources.Contains(r))
                        des++;
                }
                r.NumReqMeetings = req;
                r.NumDesMeetings = des;
                lvi.SubItems[2].Text = r.NumReqMeetings.ToString();
                lvi.SubItems[3].Text = r.NumDesMeetings.ToString();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_currXDocFileName))
                saveAsToolStripMenuItem_Click(sender, e);
            else
                SaveSpecs();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.InitialDirectory = RestorableDirectory(null);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _currXDocFileName = saveFileDialog1.FileName;
                saveToolStripMenuItem_Click(sender, e);
                System.IO.FileInfo fi = new System.IO.FileInfo(_currXDocFileName);
                //RestorableDirectory(fi.DirectoryName);
            }

        }

        private void cmdRsNew_Click(object sender, EventArgs e)
        {
            Resource pResource = new Resource("", "person");
            if (_frmResource == null)
                _frmResource = new frmResource(pResource, this);
            else
                _frmResource.CurrentResource = pResource;
            if (_frmResource.ShowDialog() == DialogResult.OK)
            {
                AddResource(pResource);
                _dirty = true;
            }
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            lvResources.ContextMenuStrip = cmsResource;
            lvMeetings.ContextMenuStrip = cmsMeeting;
        }

        private void editRsrcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvResources.SelectedItems.Count == 1)
            {
                Resource pResource = lvResources.SelectedItems[0].Tag as Resource;
                if (_frmResource == null)
                    _frmResource = new frmResource(pResource, this);
                else
                    _frmResource.CurrentResource = pResource;
                if (_frmResource.ShowDialog() == DialogResult.OK)
                {
                    lvResources.SelectedItems[0].Text = pResource.Name;
                    lvResources.SelectedItems[0].SubItems[1].Text = pResource.Type.ToString().ToLower();
                    _dirty = true;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvResources.SelectedItems.Count == 1 && (MessageBox.Show("Remove this resource?", "Confirm removal", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                lvResources.Items.Remove(lvResources.SelectedItems[0]);
                _dirty = true;
            }
        }

        private void editMtngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMeetings.SelectedItems.Count == 1)
            {
                MeetingSpec pMeeting = lvMeetings.SelectedItems[0].Tag as MeetingSpec;
                if (!_frmMeetingDict.ContainsKey(pMeeting))
                {
                    _frmMeetingDict.Add(pMeeting, new frmMeeting(pMeeting, this, "update"));
                }
                else if (_frmMeetingDict[pMeeting].IsDisposed)
                {
                    _frmMeetingDict[pMeeting] = new frmMeeting(pMeeting, this, "update");
                }
                _frmMeetingDict[pMeeting].Show();
            }
        }

        internal void doProcessMeeting(MeetingSpec pMeeting, string action)
        {
            if (action == "update")
            {
                foreach (ListViewItem lvi in lvMeetings.Items)
                {
                    if (pMeeting == (lvi.Tag as MeetingSpec))
                    {
                        lvi.Text = pMeeting.Topic;
                        lvi.SubItems[1].Text = pMeeting.Description.Substring(0, Math.Min(40, pMeeting.Description.Length));
                        UpdateCounts(pMeeting.Topic);
                        _dirty = true;
                        break;
                    }
                }
            }
            else if (action == "insert")
            {
                AddMeeting(pMeeting);
                _dirty = true;
            }
        }


        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvMeetings.SelectedItems.Count == 1 && (MessageBox.Show("Remove this meeting?", "Confirm removal", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                lvMeetings.Items.Remove(lvMeetings.SelectedItems[0]);
                _dirty = true;
            }
            cmdRun.Enabled = (lvMeetings.Items.Count > 0);
        }


        private void cmdMtNew_Click(object sender, EventArgs e)
        {
            MeetingSpec pMeeting = new MeetingSpec("");
            if (!_frmMeetingDict.ContainsKey(pMeeting))
                _frmMeetingDict.Add(pMeeting, new frmMeeting(pMeeting, this, "insert"));
            _frmMeetingDict[pMeeting].Show();

        }

        public delegate void ProgressDelegate(string test, decimal progress);

        public  void UpdateProgress(string test, decimal progress)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ProgressDelegate(UpdateProgress), test, progress);
                return;
            }
            int c;
            lblProgress.Text = String.Format("{0} ({1:0.0}%)", test, progress);
            c = Convert.ToInt32(progress);
            c = Math.Max(pgbProgress.Minimum, c);
            c = Math.Min(pgbProgress.Maximum, c);
            pgbProgress.Value = c;
        }


        delegate void ThreadDelegate();

        private void cmdRun_Click(object sender, EventArgs e)
        {
            InitUI(true);
            if (cmdRun.Text == "Compute")
            {

                ScheduleEngine.Parent = this;
                ScheduleEngine.InitMeetings.Clear();
                ScheduleEngine.stop = false;

                ScheduleEngine.PenRR = Convert.ToInt32(tbxPenRR.Text);
                ScheduleEngine.PenRD = Convert.ToInt32(tbxPenRD.Text);
                ScheduleEngine.PenDD = Convert.ToInt32(tbxPenDD.Text);

                List<int> idxs = PopulateMutualConflict();
                //for (int i = 0; i < idxs.Count; i++)
                for (int i = idxs.Count - 1; i>=0 ; i--)
                {
                    int idx = idxs[i];
                    ListViewItem lvi = this.lvMeetings.Items[idx];
                    ScheduleEngine.InitMeetings.Add(lvi.Tag as MeetingSpec);
                }

                _engineThread = new Thread(new ThreadStart(ScheduleEngine.Run));
                _engineThread.IsBackground = true;
                _engineThread.Start();

                //ThreadDelegate d = new ThreadDelegate(ScheduleEngine.Run);

                //cmdRun.Enabled = false;
                //this.Cursor = Cursors.AppStarting;

                //d.BeginInvoke(new AsyncCallback(Callback), d);
                cmdRun.Text = "Preliminary accept";
            }
            else
            {
                lock (ScheduleEngine.uiLock)
                {
                    ScheduleEngine.stop = true;
                }
                cmdRun.Text = "Compute";
                this.Cursor = Cursors.Default;
            }

            // ScheduleEngine.Run();
        }

        public void Callback(IAsyncResult ar)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AsyncCallback(Callback), ar);
                return;
            }
            lblScore.Text = String.Format("Score: {0:0.00000000}", Math.Exp(Convert.ToDouble(-1 * ScheduleEngine.MinScore)/16));
            int rank = 1;
            foreach (Schedule aSchedule in ScheduleEngine.Solutions)
            {
                ListViewItem lvi = lvSolutions.Items.Add(String.Format("Schedule {0:000000}", rank++));
                lvi.Tag = aSchedule;
            }
            if (lvSolutions.Items.Count > 0)
                lvSolutions.Items[0].Selected = true;
            cmdRun.Enabled = true;
            this.Cursor = Cursors.Default;
            cmdRun.Text = "Compute";
        }

        private void editRsrc(object sender, MouseEventArgs e)
        {
            editRsrcToolStripMenuItem_Click(sender, null);
        }

        private void editMtng(object sender, MouseEventArgs e)
        {
            editMtngToolStripMenuItem_Click(sender, null);
        }

        private void lvSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSolutions.SelectedItems.Count > 0)
            {
                Schedule aSchedule;
                aSchedule = (Schedule)lvSolutions.SelectedItems[0].Tag;
                tbxSolution.Text = aSchedule.Print();
                string comment;
                aSchedule.Evaluate(true, out comment, new int[] { Convert.ToInt32(tbxPenRR.Text), Convert.ToInt32(tbxPenRD.Text), Convert.ToInt32(tbxPenDD.Text) });
                tbxSolution.Text += comment;
            }
            else
            {
                tbxSolution.Clear();
            }
        }

        private void CheckSaveChanges(object sender, FormClosingEventArgs e)
        {
            if (!CheckSaveChanges())
                e.Cancel = true;
        }

        private bool CheckSaveChanges()
        {
            if (_dirty)
            {
                DialogResult dr = MessageBox.Show("Save changes? ", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                switch (dr)
                {
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(null, null);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                    default:
                        return false;
                }
            }
            _dirty = false;
            return true;
        }

        private void tbxParSess_TextChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void tbxSessBlocks_TextChanged(object sender, EventArgs e)
        {
            _dirty = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckSaveChanges())
                return;
            _currXDocFileName = null;
            InitUI(false);
        }

        private void tbxKeyPressed(object sender, KeyPressEventArgs e)
        {
            _dirty = true;
        }

        private void enableRunbutton(object sender, EventArgs e)
        {
            cmdRun.Enabled = ((sender as ListView).Items.Count > 0);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private List<int> PopulateMutualConflict()
        {
            object memory = lvMeetings.Columns[0].Tag;
            lvMeetings.Columns[0].Tag = null;
            this.SortBy(lvMeetings, new ColumnClickEventArgs(0));
            List<int> s1, s2;
            s1 = new List<int>();
            s2 = new List<int>();
            for (int i = 0; i < lvMeetings.Items.Count; i++)
                s1.Add(i);

            int[] penalties = new int[3] { Convert.ToInt32(tbxPenRR.Text), Convert.ToInt32(tbxPenRD.Text), Convert.ToInt32(tbxPenDD.Text) };

            //return s1;
            int greatestConflict = int.MinValue;
            int greatestRival1=0, greatestRival2=0;
            for (int n1 = 0; n1 < s1.Count - 1; n1++)
            {
                Meeting mtng1 = new Meeting(lvMeetings.Items[s1[n1]].Tag as MeetingSpec);
                for (int n2 = n1 + 1; n2 < s1.Count; n2++)
                {
                    Meeting mtng2 = new Meeting(lvMeetings.Items[s1[n2]].Tag as MeetingSpec);
                    string dummy;
                    int score = Schedule.EvaluateMeetingPair(mtng1, mtng2, false, out dummy, penalties);
                    if (score > greatestConflict)
                    {
                        greatestRival1 = s1[n1];
                        greatestRival2 = s1[n2];
                        greatestConflict = score;
                    }
                }
            }
            s2.Add(greatestRival1);
            s1.Remove(greatestRival1);
            if (greatestRival1 != 0 && greatestRival2 != 0)
            {
                s2.Add(greatestRival2);
                s1.Remove(greatestRival2);
            }
            // stage 2...
            while (s1.Count > 0)
            {
                greatestConflict = int.MinValue;
                greatestRival1 = s1[0];
                for (int n1 = 0; n1 < s1.Count; n1++)
                {
                    Meeting mtng1 = new Meeting(lvMeetings.Items[s1[n1]].Tag as MeetingSpec);
                    int sumscores=0;
                    for (int n2 = 0; n2 < s2.Count; n2++)
                    {
                        Meeting mtng2 = new Meeting(lvMeetings.Items[s2[n2]].Tag as MeetingSpec);
                        string dummy;
                        int score = Schedule.EvaluateMeetingPair(mtng1, mtng2, false, out dummy, penalties);
                        sumscores += score;
                    }
                    if (sumscores > greatestConflict)
                    {
                        greatestRival1 = s1[n1];
                        greatestConflict = sumscores;
                    }
                }
                s2.Add(greatestRival1);
                s1.Remove(greatestRival1);
            }
            lvMeetings.Columns[0].Tag = memory;
            return s2;
        }

        private void SortBy(object sender, ColumnClickEventArgs e)
        {
            ListView lview = sender as ListView;

            // up or down?
            bool up;
            if (lview.Columns[e.Column].Tag != null)
                lview.Columns[e.Column].Tag = up = !(bool)lview.Columns[e.Column].Tag;
            else
                lview.Columns[e.Column].Tag = up = true;
            foreach (ColumnHeader ch in lview.Columns)
                if (ch != lview.Columns[e.Column])
                    ch.Tag = null;

            // bubble sort...
            for (int i=0; i<lview.Items.Count-1; i++)
            {
                for (int j = lview.Items.Count-1; j > i; j--)
                {
                    if (up != (lview.Items[j].SubItems[e.Column].Text.CompareTo(lview.Items[j - 1].SubItems[e.Column].Text) == 1))
                    {
                        ListViewItem lvi = lview.Items[j];
                        lview.Items.Remove(lvi);
                        lview.Items.Insert(j-1, lvi);
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_frmAbout.IsDisposed)
                _frmAbout = new frmAbout();
            if (_frmAbout.Visible)
                _frmAbout.Focus();
            else
                _frmAbout.Show();
        }
    }
}