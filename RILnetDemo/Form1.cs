using System;
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
            rilTest.OnRILnetMessage += new EventHandler<RILtest.RILnetEventArgs>(rilTest_onRILnetMessage);
            rilTest.EnableNotifications(RilNET.RIL_NCLASS.ALL);
            rilTest.getEquipmentInfo();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            rilTest.start();
        }

        void rilTest_onRILnetMessage(object sender, RILtest.RILnetEventArgs e)
        {
            if (e.Status == (int)RILtest.RILnotiType.preferredOperatorInfoListReady)
            {
                clearList();
                try
                {
                    if (e._object == null)
                        return;
                    List<RilNET.RILOPERATORINFO> oiList = (List<RilNET.RILOPERATORINFO>)e._object;
                    foreach (RilNET.RILOPERATORINFO oi in oiList)
                    {
                        addItem(new RilNET.OperatorInfo(oi));
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                }
            }
            if (e.Status == (int)RILtest.RILnotiType.operatorInfoListReady)
            {
                clearList();
                try
                {
                    if (e._object == null)
                        return;
                    List<RilNET.RILOPERATORINFO> onList = (List<RilNET.RILOPERATORINFO>)e._object;
                    foreach (RilNET.RILOPERATORINFO oi in onList)
                    {
                        addItem(new RilNET.OperatorInfo(oi));
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                }
            }
            else if (e.Status == (int)RILtest.RILnotiType.currentOperator)
                addPhoneInfo(e.Message);
            else if (e.Status == (int)RILtest.RILnotiType.EquipmentInfo)
                addPhoneInfo(e.Message);
            else if (e.Status == (int)RILtest.RILnotiType.CellTowerInfo)
                addPhoneInfo(e.Message);
            else
                addLog(e.Message);

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

        delegate void ClearListCallback();
        public void clearList()
        {
            if (lstOPNames.InvokeRequired)
            {
                ClearListCallback d = new ClearListCallback(clearList);
                this.Invoke(d, new object[] {});
            }
            else
                lstOPNames.Items.Clear();
        }

        delegate void SetTextPhoneInfoCallback(string text);
        public void addPhoneInfo(string text)
        {
            if (txtPhoneInfo.InvokeRequired)
            {
                SetTextPhoneInfoCallback d = new SetTextPhoneInfoCallback(addPhoneInfo);
                this.Invoke(d, new object[] { text });
            }
            else
                txtPhoneInfo.Text = text;
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

        private void btnSetOP_Click(object sender, EventArgs e)
        {
            if (lstOPNames.SelectedIndex < 0)
                return;
            RilNET.OperatorInfo oi = (RilNET.OperatorInfo)lstOPNames.SelectedItem;
            rilTest.registerOnNetwork(RilNET.RIL_OPSELMODE.MANUAL, oi.ronNames);
        }

        private void btnGetOperator_Click(object sender, EventArgs e)
        {
            if (rilTest.getCurrentOperator())
                addLog("getCurrentOperator() request OK\n");
            else
                addLog("getCurrentOperator() request FAILED\n");
        }

        private void btnPhoneRefresh_Click(object sender, EventArgs e)
        {
            rilTest.getEquipmentInfo();
        }

        private void btnCellTowerInfo_Click(object sender, EventArgs e)
        {
            rilTest.getCellTowerInfo();
        }
    }
}