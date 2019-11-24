namespace Scheduler
{
    partial class frmMeeting
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
            this.tbxTopic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.clbxResources = new System.Windows.Forms.CheckedListBox();
            this.lbxResources = new System.Windows.Forms.ListBox();
            this.cmdInclude = new System.Windows.Forms.Button();
            this.cmdExclude = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxTopic
            // 
            this.tbxTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTopic.Location = new System.Drawing.Point(78, 26);
            this.tbxTopic.Name = "tbxTopic";
            this.tbxTopic.Size = new System.Drawing.Size(198, 20);
            this.tbxTopic.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Topic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDescription.Location = new System.Drawing.Point(78, 59);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(198, 102);
            this.tbxDescription.TabIndex = 2;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(435, 176);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(77, 28);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(518, 176);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(77, 28);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // clbxResources
            // 
            this.clbxResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbxResources.FormattingEnabled = true;
            this.clbxResources.Location = new System.Drawing.Point(294, 40);
            this.clbxResources.Name = "clbxResources";
            this.clbxResources.Size = new System.Drawing.Size(130, 124);
            this.clbxResources.Sorted = true;
            this.clbxResources.TabIndex = 3;
            // 
            // lbxResources
            // 
            this.lbxResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxResources.FormattingEnabled = true;
            this.lbxResources.Location = new System.Drawing.Point(466, 40);
            this.lbxResources.Name = "lbxResources";
            this.lbxResources.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxResources.Size = new System.Drawing.Size(129, 121);
            this.lbxResources.Sorted = true;
            this.lbxResources.TabIndex = 6;
            // 
            // cmdInclude
            // 
            this.cmdInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdInclude.Location = new System.Drawing.Point(430, 40);
            this.cmdInclude.Name = "cmdInclude";
            this.cmdInclude.Size = new System.Drawing.Size(30, 28);
            this.cmdInclude.TabIndex = 4;
            this.cmdInclude.Text = "<<";
            this.cmdInclude.UseVisualStyleBackColor = true;
            this.cmdInclude.Click += new System.EventHandler(this.cmdInclude_Click);
            // 
            // cmdExclude
            // 
            this.cmdExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExclude.Location = new System.Drawing.Point(430, 74);
            this.cmdExclude.Name = "cmdExclude";
            this.cmdExclude.Size = new System.Drawing.Size(30, 28);
            this.cmdExclude.TabIndex = 5;
            this.cmdExclude.Text = ">>";
            this.cmdExclude.UseVisualStyleBackColor = true;
            this.cmdExclude.Click += new System.EventHandler(this.cmdExclude_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Required / Desired";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Uninvolved";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Resources";
            // 
            // frmMeeting
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(606, 214);
            this.Controls.Add(this.lbxResources);
            this.Controls.Add(this.clbxResources);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdExclude);
            this.Controls.Add(this.cmdInclude);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxTopic);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmMeeting";
            this.Text = "Meeting Properties";
            this.Load += new System.EventHandler(this.frmMeeting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxTopic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckedListBox clbxResources;
        private System.Windows.Forms.ListBox lbxResources;
        private System.Windows.Forms.Button cmdInclude;
        private System.Windows.Forms.Button cmdExclude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}