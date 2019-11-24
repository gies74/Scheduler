using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class frmMeeting : Form
    {
        private MeetingSpec _pMeeting;
        private MainUI _parent;
        private string _action;
        public frmMeeting(MeetingSpec pMeeting, MainUI parent, string action)
        {
            InitializeComponent();
            _pMeeting = pMeeting;
            _parent = parent;
            _action = action;
        }

        public MeetingSpec CurrentMeeting
        {
            get { return _pMeeting; }
            set { _pMeeting = value; }
        }
        new public MainUI Parent
        {
            set { _parent = value; }
        }

        private void frmMeeting_Load(object sender, EventArgs e)
        {
            clbxResources.Items.Clear();
            lbxResources.Items.Clear();
            tbxTopic.Text = _pMeeting.Topic;
            tbxDescription.Text = _pMeeting.Description;
            foreach (ListViewItem lvi in _parent.LVResources.Items)
            {
                Resource pResource = lvi.Tag as Resource;
                if (_pMeeting.RequiredResources.Contains(pResource))
                    clbxResources.Items.Add(pResource.Name, true);
                else if (_pMeeting.DesiredResources.Contains(pResource))
                    clbxResources.Items.Add(pResource.Name, false);
                else
                    lbxResources.Items.Add(pResource.Name);
            }
        }

        private void cmdInclude_Click(object sender, EventArgs e)
        {
            List<object> soc = new List<object>();
            foreach (object item in lbxResources.SelectedItems)
                soc.Add(item);
            foreach (object item in soc)
            {
                clbxResources.Items.Add(item.ToString());
                lbxResources.Items.Remove(item);
            }
        }

        private void cmdExclude_Click(object sender, EventArgs e)
        {
            if (clbxResources.SelectedItem == null)
                return;
            lbxResources.Items.Add(clbxResources.SelectedItem.ToString());
            clbxResources.Items.Remove(clbxResources.SelectedItem);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            _pMeeting.Topic = tbxTopic.Text;
            _pMeeting.Description = tbxDescription.Text;
            _pMeeting.RequiredResources.Clear();
            _pMeeting.DesiredResources.Clear();
            for (int i=0; i < clbxResources.Items.Count; i++)
            {
                ListViewItem lvi = _parent.LVResources.Items[clbxResources.Items[i].ToString()];
                if (lvi != null)
                {
                    Resource pResource = lvi.Tag as Resource;
                    if (clbxResources.GetItemChecked(i))
                        _pMeeting.RequiredResources.Add(pResource);
                    else
                        _pMeeting.DesiredResources.Add(pResource);
                }
            }
            _parent.doProcessMeeting(_pMeeting, _action);
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}