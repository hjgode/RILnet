using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RILnetDemo
{
    public partial class Form1 : Form
    {
        RILtest rilTest;

        public Form1()
        {
            InitializeComponent();
            rilTest = new RILtest();
            rilTest.onRILnetMessage += new EventHandler<RILtest.RILnetEventArgs>(rilTest_onRILnetMessage);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            rilTest.start();
        }

        void rilTest_onRILnetMessage(object sender, RILtest.RILnetEventArgs e)
        {
            addLog(e.Message);
            if (e.Status == (int)RILtest.RILnotiType.preferredListReady)
            {
                //if (lstOPNames.Items.Count > 0)
                //    lstOPNames.Items.Clear();
                try
                {
                    for (int idx=0; idx<rilTest._preferredOPlist.Length; idx++)// RilNET.RILOPERATORINFO oi in rilTest._preferredOPlist)
                    {
                        addItem(rilTest._preferredOPlist[idx].ronNames.GetLongName());
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                }
            }
        }
        delegate void SetListAddCallback(object o);
        public void addItem(object o)
        {
            if (this.lstOPNames.InvokeRequired)
            {
                SetListAddCallback d = new SetListAddCallback(addItem);
                this.Invoke(d, new object[] { o });
            }
            else
            {
                lstOPNames.Items.Add(o);
            }
        }

        delegate void SetTextCallback(string text);
        public void addLog(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(addLog);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (txtLog.Text.Length > 2000)
                    txtLog.Text = "";
                txtLog.Text += text + "\r\n";
                txtLog.SelectionLength = 0;
                txtLog.SelectionStart = txtLog.Text.Length - 1;
                txtLog.ScrollToCaret();
            }
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            rilTest.Dispose();
        }

        private void btnGetOpInfos_Click(object sender, EventArgs e)
        {
            rilTest.getOperatorInfoList();
        }

        private void btnPreferredOperator_Click(object sender, EventArgs e)
        {
            rilTest.getPreferredOperatorList();
        }
    }
}