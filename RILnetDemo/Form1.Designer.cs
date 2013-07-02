namespace RILnetDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnGetOpInfos = new System.Windows.Forms.Button();
            this.btnPreferredOperator = new System.Windows.Forms.Button();
            this.lstOPNames = new System.Windows.Forms.ListBox();
            this.btnSetOP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.AcceptsTab = true;
            this.txtLog.Location = new System.Drawing.Point(1, 152);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(238, 113);
            this.txtLog.TabIndex = 0;
            this.txtLog.WordWrap = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(10, 10);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(101, 24);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGetOpInfos
            // 
            this.btnGetOpInfos.Location = new System.Drawing.Point(128, 10);
            this.btnGetOpInfos.Name = "btnGetOpInfos";
            this.btnGetOpInfos.Size = new System.Drawing.Size(101, 24);
            this.btnGetOpInfos.TabIndex = 1;
            this.btnGetOpInfos.Text = "OP infos";
            this.btnGetOpInfos.Click += new System.EventHandler(this.btnGetOpInfos_Click);
            // 
            // btnPreferredOperator
            // 
            this.btnPreferredOperator.Location = new System.Drawing.Point(128, 40);
            this.btnPreferredOperator.Name = "btnPreferredOperator";
            this.btnPreferredOperator.Size = new System.Drawing.Size(101, 24);
            this.btnPreferredOperator.TabIndex = 1;
            this.btnPreferredOperator.Text = "pref. OP list";
            this.btnPreferredOperator.Click += new System.EventHandler(this.btnPreferredOperator_Click);
            // 
            // lstOPNames
            // 
            this.lstOPNames.Location = new System.Drawing.Point(10, 88);
            this.lstOPNames.Name = "lstOPNames";
            this.lstOPNames.Size = new System.Drawing.Size(98, 58);
            this.lstOPNames.TabIndex = 2;
            // 
            // btnSetOP
            // 
            this.btnSetOP.Location = new System.Drawing.Point(128, 88);
            this.btnSetOP.Name = "btnSetOP";
            this.btnSetOP.Size = new System.Drawing.Size(99, 23);
            this.btnSetOP.TabIndex = 3;
            this.btnSetOP.Text = "set operator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnSetOP);
            this.Controls.Add(this.lstOPNames);
            this.Controls.Add(this.btnPreferredOperator);
            this.Controls.Add(this.btnGetOpInfos);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtLog);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "RILnet Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGetOpInfos;
        private System.Windows.Forms.Button btnPreferredOperator;
        private System.Windows.Forms.ListBox lstOPNames;
        private System.Windows.Forms.Button btnSetOP;
    }
}

