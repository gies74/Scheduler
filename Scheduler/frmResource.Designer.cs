namespace Scheduler
{
    partial class frmResource
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdShowMeetings = new System.Windows.Forms.Button();
            this.tbxMeetings = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tbxName
            // 
            this.tbxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxName.Location = new System.Drawing.Point(66, 26);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(198, 20);
            this.tbxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // cbxType
            // 
            this.cbxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(67, 66);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(196, 21);
            this.cbxType.TabIndex = 2;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(186, 279);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(77, 28);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(103, 279);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(77, 28);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdShowMeetings
            // 
            this.cmdShowMeetings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdShowMeetings.Location = new System.Drawing.Point(12, 279);
            this.cmdShowMeetings.Name = "cmdShowMeetings";
            this.cmdShowMeetings.Size = new System.Drawing.Size(77, 28);
            this.cmdShowMeetings.TabIndex = 5;
            this.cmdShowMeetings.Text = "Meetings>>";
            this.cmdShowMeetings.UseVisualStyleBackColor = true;
            this.cmdShowMeetings.Click += new System.EventHandler(this.cmdShowMeetings_Click);
            // 
            // tbxMeetings
            // 
            this.tbxMeetings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMeetings.Location = new System.Drawing.Point(15, 112);
            this.tbxMeetings.Multiline = true;
            this.tbxMeetings.Name = "tbxMeetings";
            this.tbxMeetings.ReadOnly = true;
            this.tbxMeetings.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMeetings.Size = new System.Drawing.Size(248, 161);
            this.tbxMeetings.TabIndex = 6;
            this.tbxMeetings.Visible = false;
            // 
            // frmResource
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(292, 324);
            this.Controls.Add(this.tbxMeetings);
            this.Controls.Add(this.cmdShowMeetings);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmResource";
            this.Text = "Resource Properties";
            this.Load += new System.EventHandler(this.frmResource_Load);
            this.Activated += new System.EventHandler(this.SetResourceControls);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdShowMeetings;
        private System.Windows.Forms.TextBox tbxMeetings;
    }
}