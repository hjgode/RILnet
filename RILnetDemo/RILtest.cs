﻿using System;
using System.Collections.Generic;
using System.Text;

using RilNET;
using System.Diagnostics;

using System.Runtime.InteropServices;

namespace RILnetDemo
{
    class RILtest:IDisposable
    {
        int hrCo, hrCti, hrEi, hrGetAllOperatorsList, hrGetOperatorList, hrGetPreferredOperatorList, hrRemovePreferredOperator, hrRegisterOnNetwork;

        int hr=-1;
        static IntPtr hRil=IntPtr.Zero;

        public RILOPERATORNAMES[] _operatorNames
        {
            get { return _operatorList.ToArray(); }
        }

        public RILOPERATORINFO[] _operatorInfos
        {
            get { return _operatorNamesList.ToArray(); }
        }

        public RILOPERATORINFO[] _preferredOPlist
        {
            get { return _operatorPreferredList.ToArray(); }
        }

        private List<RILOPERATORNAMES> _operatorList = new List<RILOPERATORNAMES>();
        private List<RILOPERATORINFO> _operatorNamesList = new List<RILOPERATORINFO>();
        private List<RILOPERATORINFO> _operatorPreferredList = new List<RILOPERATORINFO>();

        public RILtest()
        {

            // you can bind only to RilResultCallback 
            // int hr = Ril.Initialize(1, new RILRESULTCALLBACK(RilResultCallback), null, 0, 0, out hRil);
            // or only to or RilNotifyCallback
            // int hr = Ril.Initialize(1, null, new RILNOTIFYCALLBACK(RilNotifyCallback), RIL_NCLASS.ALL, 0, out hRil);
        }

        private bool init()
        {
            bool bRet = false;
            if (hRil == IntPtr.Zero)
            {
                hr = Ril.Initialize(1, new RILRESULTCALLBACK(RilResultCallback), new RILNOTIFYCALLBACK(RilNotifyCallback), RIL_NCLASS.ALL, 0, out hRil);

                if (hr == 0)
                {
                    OnRILmessage(new RILnetEventArgs("RIL Initialize OK\r\n"));
                    bRet = true;
                }
                else
                    OnRILmessage(new RILnetEventArgs("RIL Initialize FAILED: 0x" + hr.ToString("x") + "\r\n"));
            }
            else
                bRet = true;

            return bRet;
        }

        public void start()
        {
            init();

            hrCti = Ril.GetCellTowerInfo(hRil);
            hrCo = Ril.GetCurrentOperator(hRil, RIL_OPFORMAT.LONG);
            hrEi = Ril.GetEquipmentInfo(hRil);

            hrGetAllOperatorsList = Ril.GetAllOperatorsList(hRil);

            //hrGetOperatorList = Ril.GetOperatorList(hRil);

            //hr = Ril.Deinitialize(hRil);
        }

        public void getOperatorInfoList()
        {
            init();
            if (hRil == IntPtr.Zero)
                return;
            hrGetOperatorList = Ril.GetOperatorList(hRil);
            if (hrGetOperatorList < 0)
                OnRILmessage("GetOperatorList FAILED!\r\n");
        }

        public void getPreferredOperatorList()
        {
            init();
            if (hRil == IntPtr.Zero)
                return;
            hrGetPreferredOperatorList = Ril.GetPreferredOperatorList(hRil, RIL_OPFORMAT.NUM);
            if (hrGetPreferredOperatorList < 0)
            {
                string sError = RilErrorClass.getRIL_Error(hrGetPreferredOperatorList);
                OnRILmessage("GetPreferredOperatorList FAILED! hResult=" + hrGetPreferredOperatorList + "\r\n");
            }
        }

        public void removePreferredOperator(int iIndex)
        {
            init();
            if (hRil == IntPtr.Zero)
                return;
            hrRemovePreferredOperator = Ril.RemovePreferredOperator(hRil, (uint)iIndex);
            if (hrRemovePreferredOperator < 0)
            {
                string sError = RilErrorClass.getRIL_Error(hrRemovePreferredOperator);
                OnRILmessage("RemovePreferredOperator FAILED! hResult=" + hrRemovePreferredOperator + "\r\n");
            }

        }

        public void registerOnNetwork(RIL_OPSELMODE sMode, RILOPERATORNAMES operatorName){
            init();
            if (hRil == IntPtr.Zero)
                return;
            hrRegisterOnNetwork = Ril.RegisterOnNetwork(hRil, sMode, operatorName);
            if (hrRegisterOnNetwork < 0)
            {
                string sError = RilErrorClass.getRIL_Error(hrRegisterOnNetwork);
                OnRILmessage("hrRegisterOnNetwork FAILED! hResult=" + hrRegisterOnNetwork + "\r\n");
            }
        }

        public void Dispose()
        {
            if (hRil != IntPtr.Zero){
                Ril.Deinitialize(hRil);
                hRil=IntPtr.Zero;
            }
        }

        private static RILOPERATORNAMES[] getRILOPERATORNAMES(IntPtr iptr, uint size)
        {

            var counter = iptr;

            uint iCount = size / (uint)Marshal.SizeOf(typeof(RILOPERATORNAMES));

            RILOPERATORNAMES[] ret = new RILOPERATORNAMES[iCount];

            for (int i = 0; i < iCount /*size*/; i++)
            {
                RILOPERATORNAMES cur = (RILOPERATORNAMES)Marshal.PtrToStructure(counter, typeof(RILOPERATORNAMES));

                ret[i] = cur;

                //IntPtr.Add(counter, Marshal.SizeOf(typeof(RILOPERATORNAMES)));
                IntPtr pNext = new IntPtr(counter.ToInt64() + Marshal.SizeOf(typeof(RILOPERATORNAMES)));
                counter = pNext;
            }
            return ret;

        }

        private static RILOPERATORINFO[] getRILOPERATORINFO(IntPtr iptr, uint size)
        {
            var counter = iptr;

            uint iCount = size / (uint)Marshal.SizeOf(typeof(RILOPERATORINFO));

            RILOPERATORINFO[] ret = new RILOPERATORINFO[iCount];

            for (int i = 0; i < iCount /*size*/; i++)
            {
                RILOPERATORINFO cur = (RILOPERATORINFO)Marshal.PtrToStructure(counter, typeof(RILOPERATORINFO));

                ret[i] = cur;

                //IntPtr.Add(counter, Marshal.SizeOf(typeof(RILOPERATORNAMES)));
                IntPtr pNext = new IntPtr(counter.ToInt64() + Marshal.SizeOf(typeof(RILOPERATORINFO)));
                counter = pNext;
            }
            return ret;
        }

        string dumpOperatorNames(RILOPERATORNAMES on)
        {
            string sRet = "'" + on.GetLongName() + "'/" +
                "'" + on.dwParams.ToString() + "'/" +
                "'" + on.GetShortName() + "'/" +
                on.GetCountryCode() + "/" +
                on.GetNumName();
            return sRet;
        }

        // after call some method remember to save returned HRESULT and compare it to hrCmdID in RilResultCallback
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwCode">the result of the CallBack</param>
        /// <param name="hrCmdID">the ID to the query performed</param>
        /// <param name="lpData">pointer to the data</param>
        /// <param name="cbData">size of the returned data</param>
        /// <param name="dwParam">additional params</param>
        private void RilResultCallback(
            uint dwCode,
            int hrCmdID,
            IntPtr lpData,
            uint cbData,
            uint dwParam)
        {
            if (dwCode != (uint)RilNET.RIL_FUNCRESULT.RIL_RESULT_OK)
                System.Diagnostics.Debug.WriteLine("#### CALL failed! #### :" + hrCmdID.ToString()+"\r\n");

            if (hrRegisterOnNetwork == hrCmdID)
            {
                OnRILmessage("set preferred Operator with index " + dwParam.ToString());
            }

            if (hrRemovePreferredOperator == hrCmdID)
            {
                OnRILmessage("removed preferred Operator with index " + dwParam.ToString());
            }

            if (hrGetPreferredOperatorList == hrCmdID)
            {
                RILOPERATORINFO[] pOperInfo = getRILOPERATORINFO(lpData, cbData);

                _operatorPreferredList = arrayHelper<RILOPERATORINFO>.ToList(pOperInfo);// pOperInfo.ToList();

                OnRILmessage("Preferred Operator List:\r\n======================\r\n");
                foreach (RILOPERATORINFO oi in pOperInfo)
                {
                    OnRILmessage(
                        oi.dwIndex.ToString() + ": " +
                        oi.dwParams.ToString() + ", " +
                        oi.dwStatus.ToString() + "\r\n" +
                        dumpOperatorNames(oi.ronNames) +
                        "\r\n");
                }
                OnRILmessage(new RILnetEventArgs("list ready", (int)RILnotiType.preferredListReady));
            }

            if (hrGetAllOperatorsList == hrCmdID)   // this is the answer by the RIL to our GetAllOperatorsList request
            {
                //RILOPERATORNAMES pOperator = (RILOPERATORNAMES)Marshal.PtrToStructure(lpData, typeof(RILOPERATORNAMES));
                RILOPERATORNAMES[] pOperatores = getRILOPERATORNAMES(lpData, cbData);

                _operatorList = arrayHelper<RILOPERATORNAMES>.ToList(pOperatores);// pOperatores.ToList();  // NETCF 3.5

                OnRILmessage("OperatorList:\r\n======================\r\n");
                foreach (RILOPERATORNAMES on in pOperatores)
                {
                    OnRILmessage(dumpOperatorNames(on) +
                        "\r\n");
                }
            }

            if (hrGetOperatorList == hrCmdID)   // this is the answer by the RIL to our GetOperatorsList request
            {
                //RILOPERATORINFO pOperatorInfo = (RILOPERATORINFO)Marshal.PtrToStructure(lpData, typeof(RILOPERATORINFO));
                RILOPERATORINFO[] pOperInfo = getRILOPERATORINFO(lpData, cbData);

                _operatorNamesList = arrayHelper<RILOPERATORINFO>.ToList(pOperInfo);// pOperInfo.ToList(); //NETCF 3.5

                OnRILmessage("OperatorInfos:\r\n======================\r\n");
                foreach (RILOPERATORINFO oi in pOperInfo)
                {
                    OnRILmessage(
                        oi.dwIndex.ToString() + ": " +
                        oi.dwParams.ToString() + ", " +
                        oi.dwStatus.ToString() + "\r\n" +
                        dumpOperatorNames(oi.ronNames) +
                        "\r\n");
                }
            }

            if (hrCo == hrCmdID)
            {
                //Ril.GetCurrentOperator
                RILOPERATORNAMES pOperatorNames = (RILOPERATORNAMES)Marshal.PtrToStructure(lpData, typeof(RILOPERATORNAMES));
                string longName = "";
                if ((pOperatorNames.dwParams & RIL_PARAM_ON.LONGNAME) == RIL_PARAM_ON.LONGNAME) // check that LongName member is valid
                {
                    longName = Encoding.ASCII.GetString(pOperatorNames.szLongName, 0, pOperatorNames.szLongName.Length).Replace("\0", "");
                }
                OnRILmessage("Operator: '" + longName +"'\r\n");
            }

            if (hrCti == hrCmdID)
            {
                //Ril.GetCellTowerInfo
                RILCELLTOWERINFO pCellTowerInfo = (RILCELLTOWERINFO)Marshal.PtrToStructure(lpData, typeof(RILCELLTOWERINFO));
                string s =
                    "CellTowerInfo:\r\n==================\r\n" +
                    "CellID            =" + pCellTowerInfo.dwCellID.ToString() + "\r\n" +
                    "LocationAreaCode  =" + pCellTowerInfo.dwLocationAreaCode.ToString() + "\r\n" +
                    "MobileCountryCode =" + pCellTowerInfo.dwMobileCountryCode.ToString() + "\r\n" +
                    "MobileNetworkCode =" + pCellTowerInfo.dwMobileNetworkCode.ToString() + "\r\n"
                    ;
                OnRILmessage(s);
            }

            if (hrEi == hrCmdID)
            {
                //Ril.GetEquipmentInfo
                RILEQUIPMENTINFO pEquipmentInfo = (RILEQUIPMENTINFO)Marshal.PtrToStructure(lpData, typeof(RILEQUIPMENTINFO));
                string manufacturer="";
                string model="";
                string revision = "";
                string serialNumber = "";

                if ((pEquipmentInfo.dwParams & RIL_PARAM_EI.MANUFACTURER) == RIL_PARAM_EI.MANUFACTURER)
                {
                    manufacturer = Encoding.ASCII.GetString(pEquipmentInfo.szManufacturer, 0, pEquipmentInfo.szManufacturer.Length).Replace("\0", "");
                }

                if ((pEquipmentInfo.dwParams & RIL_PARAM_EI.MODEL) == RIL_PARAM_EI.MODEL)
                {
                    model = Encoding.ASCII.GetString(pEquipmentInfo.szModel, 0, pEquipmentInfo.szModel.Length).Replace("\0", "");
                }

                if ((pEquipmentInfo.dwParams & RIL_PARAM_EI.REVISION) == RIL_PARAM_EI.REVISION)
                {
                    revision = Encoding.ASCII.GetString(pEquipmentInfo.szRevision, 0, pEquipmentInfo.szRevision.Length).Replace("\0", "");
                }

                if ((pEquipmentInfo.dwParams & RIL_PARAM_EI.SERIALNUMBER) == RIL_PARAM_EI.SERIALNUMBER)
                {
                    serialNumber = Encoding.ASCII.GetString(pEquipmentInfo.szSerialNumber, 0, pEquipmentInfo.szSerialNumber.Length).Replace("\0", "");
                }
                OnRILmessage("Info\r\n==================\r\n" +
                    "manufacturer='" + manufacturer + "'\r\n" +
                    "model       ='" + model + "'\r\n" +
                    "revision    ='" + revision + "'\r\n" +
                    "serialnumber='" + serialNumber + "'\r\n");
            }
        }

        public void RilNotifyCallback(
            uint dwCode,
            IntPtr lpData,
            uint cbData,
            uint dwParam)
        {
            RIL_NCLASS dwClass = ((RIL_NCLASS)dwCode & RIL_NCLASS.ALL);

            OnRILmessage("NotifyCallback: " + dwClass.ToString());

            switch ((RIL_NOTIFY_RADIOSTATE)dwCode)
            {
                case RIL_NOTIFY_RADIOSTATE.RADIOEQUIPMENTSTATECHANGED:
                    {
                        RILEQUIPMENTSTATE pState = (RILEQUIPMENTSTATE)Marshal.PtrToStructure(lpData, typeof(RILEQUIPMENTSTATE));

                        OnRILmessage(String.Format("Radio Support: {0}; equipment State: {1}; ready State: {2}\r\n",
                                       pState.dwRadioSupport, pState.dwEqState, pState.dwReadyState));

                        break;
                    }
                case RIL_NOTIFY_RADIOSTATE.RADIOPRESENCECHANGED:
                    {
                        RIL_RADIOPRESENCE dwPresence = (RIL_RADIOPRESENCE)Marshal.ReadInt32(lpData);

                        switch (dwPresence)
                        {
                            case RIL_RADIOPRESENCE.NOTPRESENT:
                                OnRILmessage("Radio module is not present\r\n");
                                break;
                            case RIL_RADIOPRESENCE.PRESENT:
                                Debug.WriteLine("Radio module is present\r\n");
                                OnRILmessage("Radio module is present\r\n");
                                break;
                        }

                        break;
                    }
            }
        }

        //helpers
        /// <summary>
        /// NETCF2 does not have array.ToList()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        static class arrayHelper<T>
        {
            public static List<T> ToList(T[] arr)
            {
                List<T> list = new List<T>();
                foreach (T on in arr)
                    list.Add(on);
                return list;
            }
        }

        #region event_stuff
        //event stuff
        public enum RILnotiType
        {
            normal = 0,
            preferredListReady = 1,
        }

        public class RILnetEventArgs : EventArgs
        {
            public RILnetEventArgs(string s, int iStatus)
            {
                _msg = s;
                _status = iStatus;
            }
            public RILnetEventArgs(string s)
            {
                _msg = s;
                _status = 0;
            }
            private string _msg;
            private int _status;
            public string Message
            {
                get { return _msg; }
                set { _msg = value; }
            }
            public int Status
            {
                get { return _status; }
                set { _status = value; }
            }
        }
        public delegate void RILnetDelegate(object sender, RILnetEventArgs e);
        public event EventHandler<RILnetEventArgs> onRILnetMessage;
        protected virtual void OnRILmessageHandler(RILnetEventArgs e)
        {
            EventHandler<RILnetEventArgs> handler = onRILnetMessage;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        void OnRILmessage(string s)
        {
            Debug.Write(s);
            if (onRILnetMessage != null)
                onRILnetMessage(this, new RILnetEventArgs(s));
        }
        void OnRILmessage(RILnetEventArgs e)
        {
            Debug.Write(e.Message);
            if (onRILnetMessage != null)
                onRILnetMessage(this, e);
        }
        #endregion
    }
}

