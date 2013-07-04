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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGetOperator = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPhoneInfo = new System.Windows.Forms.TextBox();
            this.btnPhoneRefresh = new System.Windows.Forms.Button();
            this.btnCellTowerInfo = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.AcceptsTab = true;
            this.txtLog.Location = new System.Drawing.Point(7, 32);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(223, 210);
            this.txtLog.TabIndex = 0;
            this.txtLog.WordWrap = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(7, 7);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(101, 24);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGetOpInfos
            // 
            this.btnGetOpInfos.Location = new System.Drawing.Point(125, 7);
            this.btnGetOpInfos.Name = "btnGetOpInfos";
            this.btnGetOpInfos.Size = new System.Drawing.Size(101, 24);
            this.btnGetOpInfos.TabIndex = 1;
            this.btnGetOpInfos.Text = "OP infos";
            this.btnGetOpInfos.Click += new System.EventHandler(this.btnGetOpInfos_Click);
            // 
            // btnPreferredOperator
            // 
            this.btnPreferredOperator.Location = new System.Drawing.Point(7, 55);
            this.btnPreferredOperator.Name = "btnPreferredOperator";
            this.btnPreferredOperator.Size = new System.Drawing.Size(101, 24);
            this.btnPreferredOperator.TabIndex = 1;
            this.btnPreferredOperator.Text = "pref. OP list";
            this.btnPreferredOperator.Click += new System.EventHandler(this.btnPreferredOperator_Click);
            // 
            // lstOPNames
            // 
            this.lstOPNames.Location = new System.Drawing.Point(7, 85);
            this.lstOPNames.Name = "lstOPNames";
            this.lstOPNames.Size = new System.Drawing.Size(217, 128);
            this.lstOPNames.TabIndex = 2;
            // 
            // btnSetOP
            // 
            this.btnSetOP.Location = new System.Drawing.Point(125, 219);
            this.btnSetOP.Name = "btnSetOP";
            this.btnSetOP.Size = new System.Drawing.Size(99, 23);
            this.btnSetOP.TabIndex = 3;
            this.btnSetOP.Text = "set operator";
            this.btnSetOP.Click += new System.EventHandler(this.btnSetOP_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.btnGetOperator);
            this.tabPage1.Controls.Add(this.btnSetOP);
            this.tabPage1.Controls.Add(this.btnGetOpInfos);
            this.tabPage1.Controls.Add(this.lstOPNames);
            this.tabPage1.Controls.Add(this.btnPreferredOperator);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 242);
            this.tabPage1.Text = "operator";
            // 
            // btnGetOperator
            // 
            this.btnGetOperator.Location = new System.Drawing.Point(9, 219);
            this.btnGetOperator.Name = "btnGetOperator";
            this.btnGetOperator.Size = new System.Drawing.Size(99, 23);
            this.btnGetOperator.TabIndex = 3;
            this.btnGetOperator.Text = "get operator";
            this.btnGetOperator.Click += new System.EventHandler(this.btnGetOperator_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPage2.Controls.Add(this.txtLog);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(232, 242);
            this.tabPage2.Text = "log";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tabPage3.Controls.Add(this.btnCellTowerInfo);
            this.tabPage3.Controls.Add(this.btnPhoneRefresh);
            this.tabPage3.Controls.Add(this.txtPhoneInfo);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(240, 245);
            this.tabPage3.Text = "Phone";
            // 
            // txtPhoneInfo
            // 
            this.txtPhoneInfo.AcceptsReturn = true;
            this.txtPhoneInfo.AcceptsTab = true;
            this.txtPhoneInfo.Location = new System.Drawing.Point(7, 7);
            this.txtPhoneInfo.Multiline = true;
            this.txtPhoneInfo.Name = "txtPhoneInfo";
            this.txtPhoneInfo.ReadOnly = true;
            this.txtPhoneInfo.Size = new System.Drawing.Size(226, 134);
            this.txtPhoneInfo.TabIndex = 0;
            // 
            // btnPhoneRefresh
            // 
            this.btnPhoneRefresh.Location = new System.Drawing.Point(97, 147);
            this.btnPhoneRefresh.Name = "btnPhoneRefresh";
            this.btnPhoneRefresh.Size = new System.Drawing.Size(136, 25);
            this.btnPhoneRefresh.TabIndex = 1;
            this.btnPhoneRefresh.Text = "get equipment";
            this.btnPhoneRefresh.Click += new System.EventHandler(this.btnPhoneRefresh_Click);
            // 
            // btnCellTowerInfo
            // 
            this.btnCellTowerInfo.Location = new System.Drawing.Point(97, 178);
            this.btnCellTowerInfo.Name = "btnCellTowerInfo";
            this.btnCellTowerInfo.Size = new System.Drawing.Size(136, 25);
            this.btnCellTowerInfo.TabIndex = 1;
            this.btnCellTowerInfo.Text = "get Cell Tower Info";
            this.btnCellTowerInfo.Click += new System.EventHandler(this.btnCellTowerInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "RILnet Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGetOpInfos;
        private System.Windows.Forms.Button btnPreferredOperator;
        private System.Windows.Forms.ListBox lstOPNames;
        private System.Windows.Forms.Button btnSetOP;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnGetOperator;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtPhoneInfo;
        private System.Windows.Forms.Button btnPhoneRefresh;
        private System.Windows.Forms.Button btnCellTowerInfo;
    }
}

