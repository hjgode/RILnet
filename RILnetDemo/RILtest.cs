using System;
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

        string manufacturer = "";
        string model = "";
        string revision = "";
        string serialNumber = "";

        public RILOPERATORNAMES[] _operatorNames
        {
            get { return _operatorNameList.ToArray(); }
        }

        public RILOPERATORINFO[] _operatorInfos
        {
            get { return _operatorInfoList.ToArray(); }
        }

        public OperatorInfo[] _preferredOPlist
        {
            get { return _operatorInfoPreferredList.ToArray(); }
        }

        private List<RILOPERATORNAMES> _operatorNameList = new List<RILOPERATORNAMES>();
        private List<RILOPERATORINFO> _operatorInfoList = new List<RILOPERATORINFO>();
        private List<OperatorInfo> _operatorInfoPreferredList = new List<OperatorInfo>();

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
            try
            {
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
            }
            catch (Exception ex)
            {
                throw;
            }
            return bRet;
        }

        public void start()
        {
            init();

            getCellTowerInfo();     //hrCti = Ril.GetCellTowerInfo(hRil);
            getCurrentOperator();   // hrCo = Ril.GetCurrentOperator(hRil, RIL_OPFORMAT.LONG);
            getEquipmentInfo();     // hrEi = Ril.GetEquipmentInfo(hRil);

            getAllOperatorsList();  // hrGetAllOperatorsList = Ril.GetAllOperatorsList(hRil);

            //hrGetOperatorList = Ril.GetOperatorList(hRil);

            //hr = Ril.Deinitialize(hRil);
        }


        public bool EnableNotifications(RIL_NCLASS ncclass)
        {
            init();
            if (hRil != IntPtr.Zero)
                if (Ril.RIL_EnableNotifications(hRil, ncclass) > 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public bool DisableNotifications(RIL_NCLASS ncclass)
        {
            init();
            if (hRil != IntPtr.Zero)
                if (Ril.RIL_EnableNotifications(hRil, ncclass) > 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public bool getCurrentOperator()
        {
            init();
            if(hRil!=null)
                hrCo = Ril.GetCurrentOperator(hRil, RIL_OPFORMAT.LONG);
            if (hrCo < 0)
            {
                return false;
            }
            else
            {
                requestEntry re = new requestEntry(hrCo, "getCurrentOperator");
                return true;
            }
        }

        public void getCellTowerInfo()
        {
            init();
            if (hRil != null)
            {
                hrCti = Ril.GetCellTowerInfo(hRil);
                if (hrCti > 0)
                {
                    requestEntry re = new requestEntry(hrCti, "get cell tower info");
                }
                else
                {
                    OnRILmessage("getCellTowerInfo FAILED!\r\n");
                }
            }
        }

        public void getEquipmentInfo()
        {
            init();
            if(hRil!=null)
                hrEi = Ril.GetEquipmentInfo(hRil);
            if (hrEi > 0)
            {
                requestEntry re = new requestEntry(hrEi, "get Equipment Info");
            }
            else
            {
                OnRILmessage("getEquipmentInfo FAILED!\r\n");
            }
        }

        public void getAllOperatorsList()
        {
            init();
            if(hRil!=null)
                hrGetAllOperatorsList = Ril.GetAllOperatorsList(hRil);
            if (hrGetAllOperatorsList > 0)
            {
                requestEntry re = new requestEntry(hrGetAllOperatorsList, "get all operators");
            }
            else
            {
                OnRILmessage("GetAllOperatorsList FAILED!\r\n");
            }

        }
        public void getOperatorInfoList()
        {
            init();
            if (hRil == IntPtr.Zero)
                return;
            hrGetOperatorList = Ril.GetOperatorList(hRil);
            if (hrGetOperatorList < 0)
                OnRILmessage("GetOperatorList FAILED!\r\n");
            else{
                requestEntry re = new requestEntry(hrGetOperatorList, "get operator info list");
            }
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
            else
            {
                requestEntry re = new requestEntry(hrGetPreferredOperatorList, "get preferred operator list");
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
            else
            {
                requestEntry re = new requestEntry(hrRemovePreferredOperator, "removePreferredOperator: "+iIndex.ToString());
            }
        }

        public void registerOnNetwork(RIL_OPSELMODE sMode, RILOPERATORNAMES operatorName){
            init();
            if (hRil == IntPtr.Zero)
                return;

            try
            {
                hrRegisterOnNetwork = Ril.RegisterOnNetwork(hRil, sMode, ref operatorName);
                requestEntry re = new requestEntry(hrRegisterOnNetwork, "registerOnNetwork("+operatorName.GetLongName()+")");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RegisterOnNetwork: " + ex.Message);
            }
            if (hrRegisterOnNetwork < 0)
            {
                string sError = RilErrorClass.getRIL_Error(hrRegisterOnNetwork);
                OnRILmessage("hrRegisterOnNetwork FAILED! hResult=" + hrRegisterOnNetwork + "\r\n");
            }
        }

        #region requestList
        public class requestEntry
        {
            public static Dictionary<int, requestEntry> pendingRequests = new Dictionary<int,requestEntry>();
            int requestID;
            string requestString;
            public requestEntry(int id, string str)
            {
                requestID = id;
                requestString = str;
                pendingRequests.Add(id, this);
                dump();
            }
            public override string ToString()
            {
                return requestString;
            }
            public static void remove(int reqID)
            {
                requestEntry v;
                if (pendingRequests.TryGetValue(reqID, out v))
                    pendingRequests.Remove(reqID);
                dump();
            }
            public static requestEntry getEntry(int reqID)
            {
                requestEntry v;
                if (pendingRequests.TryGetValue(reqID, out v))
                    return v;
                else
                    return new requestEntry(0, "unknown");
            }
            public static void dump(){
                System.Diagnostics.Debug.WriteLine("--- pending START---");
                foreach(KeyValuePair<int, requestEntry> kvp in pendingRequests)
                    System.Diagnostics.Debug.WriteLine(kvp.Key.ToString() +":"+ kvp.Value.ToString());
                System.Diagnostics.Debug.WriteLine("--- pending END  ---");
            }
        }

        #endregion
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
            {
                System.Diagnostics.Debug.WriteLine("#### CALL failed! #### :" + hrCmdID.ToString() + "\r\n");
                OnRILmessage("#### CALL failed! #### :" + hrCmdID.ToString() +"/"+ requestEntry.getEntry(hrCmdID).ToString());
            }
            requestEntry.remove(hrCmdID);

            if (hrRegisterOnNetwork == hrCmdID)
            {
                if (dwCode == (uint)RilNET.RIL_FUNCRESULT.RIL_RESULT_OK)
                    OnRILmessage("set preferred Operator OK");
                else
                    OnRILmessage("set preferred Operator returned " + dwCode.ToString());
            }

            if (hrRemovePreferredOperator == hrCmdID)
            {
                OnRILmessage("removed preferred Operator with index " + dwParam.ToString());
            }

            if (hrGetPreferredOperatorList == hrCmdID)
            {
                RILOPERATORINFO[] pOperInfo = getRILOPERATORINFO(lpData, cbData);

                _operatorInfoPreferredList=new List<OperatorInfo>(); //arrayHelper<OperatorInfo>.ToList(new OperatorInfo(pOperInfo));// pOperInfo.ToList();

                OnRILmessage("Preferred Operator List:\r\n======================\r\n");
                foreach (RILOPERATORINFO oi in pOperInfo)
                {
                    OnRILmessage(
                        oi.dwIndex.ToString() + ": " +
                        oi.dwParams.ToString() + ", " +
                        oi.dwStatus.ToString() + "\r\n" +
                        dumpOperatorNames(oi.ronNames) +
                        "\r\n");
                    _operatorInfoPreferredList.Add(new OperatorInfo(oi));
                }
                OnRILmessage(new RILnetEventArgs("list ready", (int)RILnotiType.preferredOperatorInfoListReady, _operatorInfoPreferredList));
            }

            if (hrGetAllOperatorsList == hrCmdID)   // this is the answer by the RIL to our GetAllOperatorsList request
            {
                _operatorNameList.Clear();
                //RILOPERATORNAMES pOperator = (RILOPERATORNAMES)Marshal.PtrToStructure(lpData, typeof(RILOPERATORNAMES));
                RILOPERATORNAMES[] pOperatores = getRILOPERATORNAMES(lpData, cbData);

                _operatorNameList = arrayHelper<RILOPERATORNAMES>.ToList(pOperatores);// pOperatores.ToList();  // NETCF 3.5

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

                _operatorInfoList = arrayHelper<RILOPERATORINFO>.ToList(pOperInfo);// pOperInfo.ToList(); //NETCF 3.5

                OnRILmessage("OperatorInfos:\r\n======================\r\n");
                foreach (RILOPERATORINFO oi in _operatorInfoList)
                {
                    OnRILmessage(
                    oi.dwIndex.ToString() + ": " +
                    oi.dwParams.ToString() + ", " +
                    oi.dwStatus.ToString() + "\r\n" +
                    dumpOperatorNames(oi.ronNames) +
                    "\r\n");
                }
                OnRILmessage(new RILnetEventArgs(
                    "OperatorInfoList ready", (int)RILnotiType.operatorInfoListReady, _operatorInfoList));
            }

            //current operator
            if (hrCo == hrCmdID)
            {
                //Ril.GetCurrentOperator
                RILOPERATORNAMES pOperatorNames = (RILOPERATORNAMES)Marshal.PtrToStructure(lpData, typeof(RILOPERATORNAMES));
                string longName = "";
                if ((pOperatorNames.dwParams & RIL_PARAM_ON.LONGNAME) == RIL_PARAM_ON.LONGNAME) // check that LongName member is valid
                {
                    longName = Encoding.ASCII.GetString(pOperatorNames.szLongName, 0, pOperatorNames.szLongName.Length).Replace("\0", "");
                }
                OnRILmessage(new RILnetEventArgs("Operator: '" + longName +"'\r\n", RILnotiType.currentOperator, longName));
            }

            //cell tower info
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
                OnRILmessage(new RILnetEventArgs(s, RILnotiType.CellTowerInfo, pCellTowerInfo));
            }

            if (hrEi == hrCmdID)
            {
                //Ril.GetEquipmentInfo
                RILEQUIPMENTINFO pEquipmentInfo = (RILEQUIPMENTINFO)Marshal.PtrToStructure(lpData, typeof(RILEQUIPMENTINFO));


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
                OnRILmessage(new RILnetEventArgs("Info\r\n==================\r\n" +
                    "manufacturer='" + manufacturer + "'\r\n" +
                    "model       ='" + model + "'\r\n" +
                    "revision    ='" + revision + "'\r\n" +
                    "serialnumber='" + serialNumber + "'\r\n", RILnotiType.EquipmentInfo, pEquipmentInfo));
            }
        }

        public void RilNotifyCallback(
            uint dwCode,
            IntPtr lpData,
            uint cbData,
            uint dwParam)
        {
            RIL_NCLASS dwClass = ((RIL_NCLASS)dwCode & RIL_NCLASS.ALL);
            Int32 i32=0;

            switch ((RIL_NCLASS)dwClass)
            {
                case RIL_NCLASS.RADIOSTATE:
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
                        case RIL_NOTIFY_RADIOSTATE.RIL_NOTIFY_RADIORESET:
                            OnRILmessage("Radio module has been reset!\r\n");
                            break;
                    }//switch RIL_NOTIFY_RADIOSTATE
                    break; // RADIOSTATE
                case RIL_NCLASS.NETWORK:
                    switch ((RIL_NOTIFY_NETWORK)dwCode)
                    {
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_CALLMETER:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_CALLMETER: "+i32.ToString());
                            break;
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_CALLMETERMAXREACHED:
                            OnRILmessage("RIL_NOTIFY_CALLMETERMAXREACHED");
                            break;
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_LOCATIONUPDATE:
                            RilLocationInfo loc = new RilLocationInfo(lpData);
                            OnRILmessage("RIL_NOTIFY_LOCATIONUPDATE: " + loc.LocationAreaCode.ToString() +", "+ loc.CellID.ToString());
                            break;
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_GPRSCONNECTIONSTATUS:
                            OnRILmessage("RIL_NOTIFY_GPRSCONNECTIONSTATUS");
                            RilGPRSContextActivated context = new RilGPRSContextActivated(lpData);
                            OnRILmessage("RIL_NOTIFY_GPRSCONNECTIONSTATUS: " + context.contextID.ToString() + ", "+ context.activated.ToString());
                            break;
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_GPRSREGSTATUSCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_GPRSREGSTATUSCHANGED: " + ((RIL_REGISTRATION_CONSTANTS)i32).ToString());
                            break;
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_REGSTATUSCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_REGSTATUSCHANGED: " + ((RIL_REGISTRATION_CONSTANTS)i32).ToString());
                            break;
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_SYSTEMCAPSCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_SYSTEMCAPSCHANGED: "+ ((RIL_NOTIFY_SYSTEMCAPS)i32).ToString());
                            break;
                        case RIL_NOTIFY_NETWORK.RIL_NOTIFY_SYSTEMCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_SYSTEMCHANGED: " + ((RIL_NOTIFY_SYSTEMCHANGED)i32).ToString());
                            break;
                        default:
                            OnRILmessage("NotifyCallback: " + "unknown code="+dwCode.ToString());
                            break;
                    }
                    break;
                case RIL_NCLASS.FUNCRESULT:
                    OnRILmessage("NotifyCallback: " + dwClass.ToString());
                    break;
                case RIL_NCLASS.MISC:
                    switch ((RIL_NOTIFY_MISC)dwCode)
                    {
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_SIMNOTACCESSIBLE:
                            //lpData=null
                            OnRILmessage("RIL_NOTIFY_SIMNOTACCESSIBLE: " + ((RIL_NOTIFY_MISC)dwCode).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_DTMFSIGNAL:
                            char c = Convert.ToChar(Marshal.ReadByte(lpData));
                            OnRILmessage("RIL_NOTIFY_DTMFSIGNAL: " + ((RIL_NOTIFY_MISC)dwCode).ToString() + ":" + c.ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_GPRSCLASS_NETWORKCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_GPRSCLASS_NETWORKCHANGED: " + ((RIL_GPRSCLASS)i32).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_GPRSCLASS_RADIOCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_GPRSCLASS_RADIOCHANGED: " + ((RIL_GPRSCLASS)i32).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_SIGNALQUALITY:
                            RilSignalQuality rsq = new RilSignalQuality(lpData);
                            OnRILmessage("RIL_NOTIFY_SIGNALQUALITY: " + rsq.dump());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_MAINTREQUIRED:
                            OnRILmessage("RIL_NOTIFY_MAINTREQUIRED");
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_PRIVACYCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_PRIVACYCHANGED: " + ((RIL_CALLPRIVACY)i32).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_SIM_DATACHANGE:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_SIM_DATACHANGE: " + ((RIL_SIM_DATACHANGE)i32).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_ATLOGGING:
                            OnRILmessage("RIL_NOTIFY_ATLOGGING: " + "AT command logging data is available");
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_SIMSTATUSCHANGED:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_SIMSTATUSCHANGED: " + ((RIL_SIMSTATUSCHANGED)i32).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_EONS:
                            OnRILmessage("RIL_NOTIFY_EONS: " + "Enhanced Operator Name String (EONS) information is available or updated");
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_SIMSECURITYSTATUS:
                            RIL_SIMSECURITYSTATE sss= (RIL_SIMSECURITYSTATE)Marshal.PtrToStructure(lpData, typeof(RIL_SIMSECURITYSTATE));
                            OnRILmessage("RIL_NOTIFY_SIMSECURITYSTATUS: " + ((RIL_SIMSECURITYSTATE)sss).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_LINESTATE:
                            i32 = Marshal.ReadInt32(lpData);
                            OnRILmessage("RIL_NOTIFY_LINESTATE: " + ((RIL_LINE_STAT)i32).ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_BEARERSVCINFO:
                            RILBEARERSVCINFO bsi = (RILBEARERSVCINFO)Marshal.PtrToStructure(lpData, typeof(RILBEARERSVCINFO));
                            OnRILmessage("RIL_NOTIFY_SIMSECURITYSTATUS: " + bsi.ToString());
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_DATACOMPINFO:
                            ///TODO: see RILDATACOMPINFO and 
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_EQUIPMENTINFO:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_ERRORCORRECTIONINFO:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_GPRSADDRESS:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_GPRSATTACHED:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_GPRSCONTEXT:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_GPRSCONTEXTACTIVATED:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_QOSMIN:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_QOSREQ:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_RLPOPTIONS:
                            break;
                        case RIL_NOTIFY_MISC.RIL_NOTIFY_NITZ:
                            RILNITZINFO nitz = (RILNITZINFO)Marshal.PtrToStructure(lpData, typeof(RILNITZINFO));
                            OnRILmessage("RIL_NOTIFY_NITZ: " + nitz.ToString());
                            break;
                    }
                    break;
                default:
                    OnRILmessage("NotifyCallback: " + dwClass.ToString());
                    break;
            }//RIL_NCLASS
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
            preferredOperatorInfoListReady = 1,
            currentOperator = 2,
            RSSI = 3,
            CellTowerInfo = 4,
            EquipmentInfo = 5,
            operatorInfoListReady,

        }

        public class RILnetEventArgs : EventArgs
        {
            public RILnetEventArgs(string s, int iStatus, object o)
            {
                _msg = s;
                _status = iStatus;
                _object = o;
            }
            public RILnetEventArgs(string s, RILnotiType iStatus, object o)
            {
                _msg = s;
                _status = (int)iStatus;
                _object = o;
            }
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
            public object _object;
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
        //changed according to http://www.codeproject.com/Articles/37474/Threadsafe-Events
        //public delegate void RILnetDelegate(object sender, RILnetEventArgs e);
        private EventHandler<RILnetEventArgs> onRILnetMessage;
        public event EventHandler<RILnetEventArgs> OnRILnetMessage
        {
            add { this.onRILnetMessage += value; }
            remove { this.onRILnetMessage -= value; }
        }
        protected virtual void OnRILmessageHandler(RILnetEventArgs e)
        {
            if (this.onRILnetMessage != null)
            {
                onRILnetMessage(this, e);
            }
        }
        void OnRILmessage(string s)
        {
            Debug.WriteLine(s);
            if (this.onRILnetMessage != null)
                this.onRILnetMessage(this, new RILnetEventArgs(s));
        }
        void OnRILmessage(RILnetEventArgs e)
        {
            Debug.Write(e.Message);
            if (this.onRILnetMessage != null)
                this.onRILnetMessage(this, e);
        }
        #endregion
    }
}

