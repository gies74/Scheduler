namespace Scheduler
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcEntities = new System.Windows.Forms.TabControl();
            this.tpResources = new System.Windows.Forms.TabPage();
            this.cmdRsNew = new System.Windows.Forms.Button();
            this.lvResources = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.chReqInMtngs = new System.Windows.Forms.ColumnHeader();
            this.chDesInMtngs = new System.Windows.Forms.ColumnHeader();
            this.tpMeetings = new System.Windows.Forms.TabPage();
            this.cmdMtNew = new System.Windows.Forms.Button();
            this.lvMeetings = new System.Windows.Forms.ListView();
            this.chTopic = new System.Windows.Forms.ColumnHeader();
            this.chDescription = new System.Windows.Forms.ColumnHeader();
            this.chReqSize = new System.Windows.Forms.ColumnHeader();
            this.chDesired = new System.Windows.Forms.ColumnHeader();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPenDD = new System.Windows.Forms.TextBox();
            this.tbxPenRD = new System.Windows.Forms.TextBox();
            this.tbxPenRR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxSessBlocks = new System.Windows.Forms.TextBox();
            this.tbxParSess = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpSolution = new System.Windows.Forms.TabPage();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblScore = new System.Windows.Forms.Label();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chAlternatives = new System.Windows.Forms.ColumnHeader();
            this.cmdRun = new System.Windows.Forms.Button();
            this.tbxSolution = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsResource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMeeting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcEntities.SuspendLayout();
            this.tpResources.SuspendLayout();
            this.tpMeetings.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpSolution.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cmsResource.SuspendLayout();
            this.cmsMeeting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcEntities
            // 
            this.tcEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcEntities.Controls.Add(this.tpResources);
            this.tcEntities.Controls.Add(this.tpMeetings);
            this.tcEntities.Controls.Add(this.tpSettings);
            this.tcEntities.Controls.Add(this.tpSolution);
            this.tcEntities.Location = new System.Drawing.Point(5, 28);
            this.tcEntities.Name = "tcEntities";
            this.tcEntities.SelectedIndex = 0;
            this.tcEntities.Size = new System.Drawing.Size(589, 251);
            this.tcEntities.TabIndex = 0;
            // 
            // tpResources
            // 
            this.tpResources.Controls.Add(this.cmdRsNew);
            this.tpResources.Controls.Add(this.lvResources);
            this.tpResources.Location = new System.Drawing.Point(4, 22);
            this.tpResources.Name = "tpResources";
            this.tpResources.Padding = new System.Windows.Forms.Padding(3);
            this.tpResources.Size = new System.Drawing.Size(581, 225);
            this.tpResources.TabIndex = 1;
            this.tpResources.Text = "Resources";
            this.tpResources.UseVisualStyleBackColor = true;
            // 
            // cmdRsNew
            // 
            this.cmdRsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRsNew.Location = new System.Drawing.Point(6, 177);
            this.cmdRsNew.Name = "cmdRsNew";
            this.cmdRsNew.Size = new System.Drawing.Size(123, 28);
            this.cmdRsNew.TabIndex = 2;
            this.cmdRsNew.Text = "New...";
            this.cmdRsNew.UseVisualStyleBackColor = true;
            this.cmdRsNew.Click += new System.EventHandler(this.cmdRsNew_Click);
            // 
            // lvResources
            // 
            this.lvResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chType,
            this.chReqInMtngs,
            this.chDesInMtngs});
            this.lvResources.FullRowSelect = true;
            this.lvResources.Location = new System.Drawing.Point(-4, 0);
            this.lvResources.Name = "lvResources";
            this.lvResources.Size = new System.Drawing.Size(582, 171);
            this.lvResources.TabIndex = 0;
            this.lvResources.UseCompatibleStateImageBehavior = false;
            this.lvResources.View = System.Windows.Forms.View.Details;
            this.lvResources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.editRsrc);
            this.lvResources.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortBy);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 181;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 124;
            // 
            // chReqInMtngs
            // 
            this.chReqInMtngs.Text = "Required in #meetings";
            this.chReqInMtngs.Width = 128;
            // 
            // chDesInMtngs
            // 
            this.chDesInMtngs.Text = "Desired in #meetings";
            this.chDesInMtngs.Width = 125;
            // 
            // tpMeetings
            // 
            this.tpMeetings.Controls.Add(this.cmdMtNew);
            this.tpMeetings.Controls.Add(this.lvMeetings);
            this.tpMeetings.Location = new System.Drawing.Point(4, 22);
            this.tpMeetings.Name = "tpMeetings";
            this.tpMeetings.Padding = new System.Windows.Forms.Padding(3);
            this.tpMeetings.Size = new System.Drawing.Size(581, 225);
            this.tpMeetings.TabIndex = 0;
            this.tpMeetings.Text = "Meetings";
            this.tpMeetings.UseVisualStyleBackColor = true;
            // 
            // cmdMtNew
            // 
            this.cmdMtNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdMtNew.Location = new System.Drawing.Point(6, 177);
            this.cmdMtNew.Name = "cmdMtNew";
            this.cmdMtNew.Size = new System.Drawing.Size(123, 28);
            this.cmdMtNew.TabIndex = 1;
            this.cmdMtNew.Text = "New...";
            this.cmdMtNew.UseVisualStyleBackColor = true;
            this.cmdMtNew.Click += new System.EventHandler(this.cmdMtNew_Click);
            // 
            // lvMeetings
            // 
            this.lvMeetings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMeetings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTopic,
            this.chDescription,
            this.chReqSize,
            this.chDesired});
            this.lvMeetings.FullRowSelect = true;
            this.lvMeetings.Location = new System.Drawing.Point(-1, 0);
            this.lvMeetings.Name = "lvMeetings";
            this.lvMeetings.Size = new System.Drawing.Size(581, 171);
            this.lvMeetings.TabIndex = 0;
            this.lvMeetings.UseCompatibleStateImageBehavior = false;
            this.lvMeetings.View = System.Windows.Forms.View.Details;
            this.lvMeetings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.editMtng);
            this.lvMeetings.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SortBy);
            // 
            // chTopic
            // 
            this.chTopic.Text = "Topic";
            this.chTopic.Width = 148;
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            this.chDescription.Width = 303;
            // 
            // chReqSize
            // 
            this.chReqSize.Text = "# Required";
            // 
            // chDesired
            // 
            this.chDesired.Text = "# Desired";
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.groupBox1);
            this.tpSettings.Controls.Add(this.tbxSessBlocks);
            this.tpSettings.Controls.Add(this.tbxParSess);
            this.tpSettings.Controls.Add(this.label2);
            this.tpSettings.Controls.Add(this.label1);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(581, 225);
            this.tpSettings.TabIndex = 3;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxPenDD);
            this.groupBox1.Controls.Add(this.tbxPenRD);
            this.groupBox1.Controls.Add(this.tbxPenRR);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(17, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conflict Penalties";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Required-Required";
            // 
            // tbxPenDD
            // 
            this.tbxPenDD.Location = new System.Drawing.Point(157, 72);
            this.tbxPenDD.Name = "tbxPenDD";
            this.tbxPenDD.Size = new System.Drawing.Size(48, 20);
            this.tbxPenDD.TabIndex = 1;
            this.tbxPenDD.Text = "1";
            this.tbxPenDD.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.tbxPenDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxKeyPressed);
            // 
            // tbxPenRD
            // 
            this.tbxPenRD.Location = new System.Drawing.Point(157, 48);
            this.tbxPenRD.Name = "tbxPenRD";
            this.tbxPenRD.Size = new System.Drawing.Size(48, 20);
            this.tbxPenRD.TabIndex = 1;
            this.tbxPenRD.Text = "2";
            this.tbxPenRD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxKeyPressed);
            // 
            // tbxPenRR
            // 
            this.tbxPenRR.Location = new System.Drawing.Point(157, 26);
            this.tbxPenRR.Name = "tbxPenRR";
            this.tbxPenRR.Size = new System.Drawing.Size(48, 20);
            this.tbxPenRR.TabIndex = 1;
            this.tbxPenRR.Text = "10";
            this.tbxPenRR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxKeyPressed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Desired-Desired";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Required-Desired";
            // 
            // tbxSessBlocks
            // 
            this.tbxSessBlocks.Location = new System.Drawing.Point(169, 31);
            this.tbxSessBlocks.Name = "tbxSessBlocks";
            this.tbxSessBlocks.Size = new System.Drawing.Size(48, 20);
            this.tbxSessBlocks.TabIndex = 1;
            this.tbxSessBlocks.Text = "1";
            this.tbxSessBlocks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxKeyPressed);
            // 
            // tbxParSess
            // 
            this.tbxParSess.Location = new System.Drawing.Point(169, 7);
            this.tbxParSess.Name = "tbxParSess";
            this.tbxParSess.Size = new System.Drawing.Size(48, 20);
            this.tbxParSess.TabIndex = 1;
            this.tbxParSess.Text = "1";
            this.tbxParSess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxKeyPressed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "No. of Session Blocks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. of Parallel Sessions";
            // 
            // tpSolution
            // 
            this.tpSolution.Controls.Add(this.lblProgress);
            this.tpSolution.Controls.Add(this.pgbProgress);
            this.tpSolution.Controls.Add(this.lblScore);
            this.tpSolution.Controls.Add(this.lvSolutions);
            this.tpSolution.Controls.Add(this.cmdRun);
            this.tpSolution.Controls.Add(this.tbxSolution);
            this.tpSolution.Location = new System.Drawing.Point(4, 22);
            this.tpSolution.Name = "tpSolution";
            this.tpSolution.Size = new System.Drawing.Size(581, 225);
            this.tpSolution.TabIndex = 2;
            this.tpSolution.Text = "Solution";
            this.tpSolution.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(131, 205);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(10, 13);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "-";
            // 
            // pgbProgress
            // 
            this.pgbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbProgress.Location = new System.Drawing.Point(134, 188);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(432, 14);
            this.pgbProgress.TabIndex = 4;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(17, 59);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(38, 13);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score:";
            // 
            // lvSolutions
            // 
            this.lvSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAlternatives});
            this.lvSolutions.GridLines = true;
            this.lvSolutions.Location = new System.Drawing.Point(20, 75);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(104, 146);
            this.lvSolutions.TabIndex = 2;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.SelectedIndexChanged += new System.EventHandler(this.lvSolutions_SelectedIndexChanged);
            // 
            // chAlternatives
            // 
            this.chAlternatives.Text = "Alternatives";
            this.chAlternatives.Width = 98;
            // 
            // cmdRun
            // 
            this.cmdRun.Enabled = false;
            this.cmdRun.Location = new System.Drawing.Point(17, 10);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(108, 30);
            this.cmdRun.TabIndex = 1;
            this.cmdRun.Text = "Compute";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // tbxSolution
            // 
            this.tbxSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSolution.Location = new System.Drawing.Point(130, 10);
            this.tbxSolution.Multiline = true;
            this.tbxSolution.Name = "tbxSolution";
            this.tbxSolution.ReadOnly = true;
            this.tbxSolution.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxSolution.Size = new System.Drawing.Size(447, 163);
            this.tbxSolution.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cmsResource
            // 
            this.cmsResource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsResource.Name = "cmsResource";
            this.cmsResource.Size = new System.Drawing.Size(108, 48);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.propertiesToolStripMenuItem.Text = "Edit...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.editRsrcToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cmsMeeting
            // 
            this.cmsMeeting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.cmsMeeting.Name = "cmsMeeting";
            this.cmsMeeting.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit...";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editMtngToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "XML-files|*.xml";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "XML-files|*.xml";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 291);
            this.Controls.Add(this.tcEntities);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainUI";
            this.Text = "Meeting Scheduler 1.1";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckSaveChanges);
            this.tcEntities.ResumeLayout(false);
            this.tpResources.ResumeLayout(false);
            this.tpMeetings.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpSolution.ResumeLayout(false);
            this.tpSolution.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmsResource.ResumeLayout(false);
            this.cmsMeeting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcEntities;
        private System.Windows.Forms.TabPage tpMeetings;
        private System.Windows.Forms.ListView lvMeetings;
        private System.Windows.Forms.TabPage tpResources;
        private System.Windows.Forms.ColumnHeader chTopic;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.ColumnHeader chReqSize;
        private System.Windows.Forms.ColumnHeader chDesired;
        private System.Windows.Forms.Button cmdMtNew;
        private System.Windows.Forms.ListView lvResources;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.TabPage tpSolution;
        private System.Windows.Forms.Button cmdRsNew;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.TextBox tbxSessBlocks;
        private System.Windows.Forms.TextBox tbxParSess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip cmsResource;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsMeeting;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.TextBox tbxSolution;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chAlternatives;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.ColumnHeader chReqInMtngs;
        private System.Windows.Forms.ColumnHeader chDesInMtngs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPenRR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPenDD;
        private System.Windows.Forms.TextBox tbxPenRD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}