using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class frmResource : Form
    {
        private Resource _pResource;
        private MainUI _parent;

        public Resource CurrentResource
        {
            get { return _pResource; }
            set { _pResource = value; }
        }

        public frmResource(Resource res, MainUI parent)
        {
            InitializeComponent();
            _pResource = res;
            _parent = parent;
            cbxType.Items.Add(Resource.ResourceType.Person.ToString());
            cbxType.Items.Add(Resource.ResourceType.Device.ToString());
            cbxType.Items.Add(Resource.ResourceType.Room.ToString());
        }

        private void frmResource_Load(object sender, EventArgs e)
        {
            tbxName.Text = _pResource.Name;
            string selText = _pResource.Type.ToString();
            foreach (object cbxItem in cbxType.Items)
            {
                if (cbxItem.ToString() == selText)
                {
                    cbxType.SelectedItem = cbxItem;
                    break;
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            _pResource.Name = tbxName.Text;
            switch (cbxType.SelectedItem.ToString())
            {
                case "Person":
                    _pResource.Type = Resource.ResourceType.Person;
                    break;
                case "Device":
                    _pResource.Type = Resource.ResourceType.Device;
                    break;
                case "Room":
                    _pResource.Type = Resource.ResourceType.Room;
                    break;
                default:
                    _pResource.Type = Resource.ResourceType.Person;
                    break;
            }
        }

        private void cmdShowMeetings_Click(object sender, EventArgs e)
        {
            if (cmdShowMeetings.Text == "Meetings>>")
            {
                this.Size = new Size(308, 360);
                tbxMeetings.Visible = true;
                cmdShowMeetings.Text = "Meetings<<";
            }
            else
            {
                this.Size = new Size(308, 188);
                tbxMeetings.Visible = false;
                cmdShowMeetings.Text = "Meetings>>";
            }
        }

        private void SetResourceControls(object sender, EventArgs e)
        {
            tbxMeetings.Clear();
            foreach (ListViewItem lvi in _parent.LVMeetings.Items)
            {
                MeetingSpec pMeetingSpec = lvi.Tag as MeetingSpec;
                if (pMeetingSpec.RequiredResources.Contains(_pResource))
                    tbxMeetings.Text += pMeetingSpec.Topic + " (r)" + Environment.NewLine;
                else if (pMeetingSpec.DesiredResources.Contains(_pResource))
                    tbxMeetings.Text += pMeetingSpec.Topic + " (d)" + Environment.NewLine;
            } cmdShowMeetings.Text = "Meetings>>";
            this.Size = new Size(308, 188);
            tbxMeetings.Visible = false;
        }
    }
}