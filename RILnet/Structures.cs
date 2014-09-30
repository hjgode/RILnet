//-----------------------------------------------------------------------------------------
// <copyright file="Structures.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    using System;
    using System.Runtime.InteropServices;    

    /// <summary>
    /// This structure defines information associated with a ringing call.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILRINGINFO 
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_RI">RIL_PARAM_RI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_RI dwParams;

        /// <summary>
        /// Specifies the type of the offered call. Must be one of the call type constants.
        /// </summary>
        public RIL_CALLTYPE dwCallType;

        /// <summary>
        /// Specifies the number that identifies the line that the incoming call is ringing on. The first line is typically line zero (0), while the second line is line 1.
        /// </summary>
        public uint dwAddressId;

        /// <summary>
        /// Not supported. Service information for incoming data calls. This member is only valid if <see cref="F:RilNET.RILL_CALLTYPE.DATA">RILL_CALLTYPE.DATA</see> is specified for the <see cref="P:RilNET.RILRINGINFO.dwCallType">dwCallType</see> member.
        /// </summary>
        public RILSERVICEINFO rsiServiceInfo;
    }

    /// <summary>
    /// This structure stores connection service information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILSERVICEINFO
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_SVCI">RIL_PARAM_SVCI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_SVCI dwParams;

        /// <summary>
        /// TRUE if connection service is synchronous, FALSE if asynchronous.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fSynchronous;

        /// <summary>
        /// TRUE if connection service is transparent, FALSE if non-transparent.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fTransparent;
    }

    /// <summary>
    /// This structure stores High Speed Circuit Switched Data (HSCSD) information for the current call.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILCALLHSCSDINFO
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_CHSCSDI">RIL_PARAM_CHSCSDI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_CHSCSDI dwParams;

        /// <summary>
        /// Specifies the number of receive timeslots currently in use.
        /// </summary>
        public uint dwRxTimeslots;

        /// <summary>
        /// Specifies the number of transmit timeslots currently in use.
        /// </summary>
        public uint dwTxTimeslots;

        /// <summary>
        /// Specifies the air interface user rate currently in use.
        /// </summary>
        public uint dwAirInterfaceUserRate;

        /// <summary>
        /// Specifies current channel coding.
        /// </summary>
        public uint dwChannelCoding;
    }

    /// <summary>
    /// This structure stores ring information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILDIALINFO
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_DI">RIL_PARAM_DI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_DI dwParams;

        /// <summary>
        /// Handle of call being dialed.
        /// </summary>
        public IntPtr hrCmdId;

        /// <summary>
        /// Specifies the ID of the call being dialed.
        /// </summary>
        public uint dwCallId;
    }

    /// <summary>
    /// This structure stores information about a specific call.
    /// </summary>
    /// <remarks>The <see cref="P:RilNET.RILCALLINFO.dwID">dwID</see> and <see cref="P:RilNET.RILCALLINFO.dwStatus">dwStatus</see> members must always be valid.</remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RILCALLINFO
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_CI">RIL_PARAM_CI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_CI dwParams;

        /// <summary>
        /// Specifies the unique value that identifies a call, starting with 1. This value should be constant for the duration of the call.
        /// </summary>
        public uint dwID;

        /// <summary>
        /// Specifies the direction of a call.
        /// </summary>
        public RIL_CALLDIR dwDirection;

        /// <summary>
        /// Specifies the status of a call.
        /// </summary>
        /// <remarks>
        /// If <see cref="P:RilNET.RILCALLINFO.dwParams">dwParams</see> is set to <see cref="P:RilNET.RIL_PARAM_CI.STATUS">RIL_PARAM_CI.STATUS</see>, this value is interpreted as one of the <see cref="T:RilNET.RIL_CALLSTAT">RIL_CALLSTAT</see>. If dwParams is set to <see cref="P:RilNET.RIL_PARAM_CI.CPISTATUS">RIL_PARAM_CI.CPISTATUS</see>, this value is interpreted as one of the <see cref="T:RilNET.RIL_CPISTAT">RIL_CPISTAT</see>. 
        /// </remarks>
        public uint dwStatus;
        
        /// <summary>
        /// Specifies the call type.
        /// </summary>
        public RIL_CALLTYPE dwType;

        /// <summary>
        /// Specifies whether a call is a single-party call or a multi-party conference call.
        /// </summary>
        public RIL_CALL dwMultiparty;

        /// <summary>
        /// Phone number of the remote party of the call.
        /// </summary>
        public RILADDRESS raAddress;

        /// <summary>
        /// String type representation of the phone number corresponding to the entry in the radio phone book, if applicable.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Ril.MAXLENGTH_DESCRIPTION)]
        public string wszDescription;

        /// <summary>
        /// Specifies the disconnect code if <see cref="P:RilNET.RILCALLINFO.dwStatus">dwStatus</see> is disconnected.
        /// </summary>
        public uint dwDisconnectCode;
}

    /// <summary>
    /// This structure represents a phone number.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RILADDRESS
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_A">RIL_PARAM_A</see> parameter constants.
        /// </summary>
        public RIL_PARAM_A dwParams;

        /// <summary>
        /// Specifies the type of address.
        /// </summary>
        public RIL_ADDRTYPE dwType;

        /// <summary>
        /// Specifies the numbering scheme of the address.
        /// </summary>
        public RIL_NUMPLAN dwNumPlan;

        /// <summary>
        /// Array of address characters.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Ril.MAXLENGTH_ADDRESS)]
        public string wszAddress;
    }

    /// <summary>
    /// This structure defines the state of the radio equipment.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILEQUIPMENTSTATE
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_EQUIPMENTSTATE">RIL_PARAM_EQUIPMENTSTATE</see> parameter constants.
        /// </summary>
        public RIL_PARAM_EQUIPMENTSTATE dwParams;
        
        /// <summary>
        /// Specifies whether the radio is enabled or disabled.
        /// </summary>
        public RIL_RADIOSUPPORT dwRadioSupport;

        /// <summary>
        /// Specifies whether transmit or receive functionality is enabled.
        /// </summary>
        public RIL_EQSTATE dwEqState;

        /// <summary>
        /// Specifies the features that are currently ready on the phone. 
        /// </summary>
        public RIL_READYSTATE dwReadyState;
    }    
    
    /// <summary>
    /// This structure stores cell tower information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILCELLTOWERINFO
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_CTI">RIL_PARAM_CTI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_CTI dwParams;

        /// <summary>
        /// Specifies the country/region code.
        /// </summary>
        public uint dwMobileCountryCode;

        /// <summary>
        /// Specifies the code of the mobile network.
        /// </summary>
        public uint dwMobileNetworkCode;

        /// <summary>
        /// Specifies the area code of the current location.
        /// </summary>
        public uint dwLocationAreaCode;

        /// <summary>
        /// Specifies the ID of the cellular tower.
        /// </summary>
        public uint dwCellID;

        /// <summary>
        /// Specifies the ID of the base station.
        /// </summary>
        public uint dwBaseStationID;

        /// <summary>
        /// Specifies the Broadcast Control Channel (BCCH).
        /// </summary>
        public uint dwBroadcastControlChannel;

        /// <summary>
        /// Specifies the received signal level.
        /// </summary>
        public uint dwRxLevel;

        /// <summary>
        /// Specifies the received signal level in the full network.
        /// </summary>
        public uint dwRxLevelFull;

        /// <summary>
        /// Specifies the received signal level in the subsystem.
        /// </summary>
        public uint dwRxLevelSub;

        /// <summary>
        /// Specifies the received signal quality.
        /// </summary>
        public uint dwRxQuality;

        /// <summary>
        /// Specifies the received signal quality in the full network.
        /// </summary>
        public uint dwRxQualityFull;

        /// <summary>
        /// Specifies the received signal quality in the subsystem.
        /// </summary>
        public uint dwRxQualitySub;

        /// <summary>
        /// Specifies the idle timeslot.
        /// </summary>
        public uint dwIdleTimeSlot;

        /// <summary>
        /// Specifies the timing advance.
        /// </summary>
        public uint dwTimingAdvance;

        /// <summary>
        /// Specifies the ID of the GPRS cellular tower.
        /// </summary>
        public uint dwGPRSCellID;

        /// <summary>
        /// Specifies the ID of the GPRS base station.
        /// </summary>
        public uint dwGPRSBaseStationID;

        /// <summary>
        /// Specifies the number of the BCCH. 
        /// </summary>
        public uint dwNumBCCH;

        /// <summary>
        /// Range of the BCCH, in bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_BCCH)]
        public byte[] rgbBCCH;

        /// <summary>
        /// Length of the Non-Membership Report (NMR), in bytes.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_NMR)]
        public byte[] rgbNMR;        
    }

    /// <summary>
    /// This structure stores the different representations of an operator.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILOPERATORNAMES
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_ON">RIL_PARAM_ON</see> parameter constants.
        /// </summary>
        public RIL_PARAM_ON dwParams;

        /// <summary>
        /// Long representation.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_OPERATOR_LONG)]
        public byte[] szLongName;

        /// <summary>
        /// Short representation.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_OPERATOR_SHORT)]
        public byte[] szShortName;

        /// <summary>
        /// Numeric representation. Contains the 3-digit country/region code and the 2-digit network code.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_OPERATOR_NUMERIC)]
        public byte[] szNumName;

        /// <summary>
        /// Country/region code. Must be the 2-character International Organization for Standardization (ISO) 3166 country/region representation of the Mobile Country Code (MCC).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_OPERATOR_COUNTRY_CODE)]
        public byte[] szCountryCode;

        /// <summary>
        /// Gets long representation in string format.
        /// </summary>
        /// <returns>Long representation.</returns>
        public string GetLongName()
        {
            return Utils.AsciiEncoding(szLongName);
        }

        /// <summary>
        /// Gets short representation in string format.
        /// </summary>
        /// <returns>Short representation.</returns>
        public string GetShortName()
        {
            return Utils.AsciiEncoding(szShortName);
        }

        /// <summary>
        /// Gets numeric representation in string format.
        /// </summary>
        /// <returns>Numeric representation.</returns>
        public string GetNumName()
        {
            return Utils.AsciiEncoding(szNumName);
        }

        /// <summary>
        /// Gets country/region code in string format.
        /// </summary>
        /// <returns>Country/region code.</returns>
        public string GetCountryCode()
        {
            return Utils.AsciiEncoding(szCountryCode);
        }
    }

    /// <summary>
    /// This structure stores equipment information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILEQUIPMENTINFO
    {   
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;

        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_EI">RIL_PARAM_EI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_EI dwParams;

        /// <summary>
        /// Manufacturer of the radio hardware.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_EQUIPINFO)]
        public byte[] szManufacturer;

        /// <summary>
        /// Model of the radio hardware.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_EQUIPINFO)]
        public byte[] szModel;

        /// <summary>
        /// Software version of the radio stack.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_EQUIPINFO)]
        public byte[] szRevision;

        /// <summary>
        /// Equipment identity (IMEI).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Ril.MAXLENGTH_EQUIPINFO)]
        public byte[] szSerialNumber;

        /// <summary>
        /// Gets manufacturer in string format.
        /// </summary>
        /// <returns>Manufacturer of the radio hardware.</returns>
        public string GetManufacturer()
        {
            return Utils.AsciiEncoding(szManufacturer);
        }

        /// <summary>
        /// Gets model in string format.
        /// </summary>
        /// <returns>Long representation</returns>
        public string GetModel()
        {
            return Utils.AsciiEncoding(szModel);
        }

        /// <summary>
        /// Gets version in string format.
        /// </summary>
        /// <returns>Version.</returns>
        public string GetRevision()
        {
            return Utils.AsciiEncoding(szRevision);
        }

        /// <summary>
        /// Gets equipment identity in string format.
        /// </summary>
        /// <returns>Equipment identity.</returns>
        public string GetSerialNumber()
        {
            return Utils.AsciiEncoding(szSerialNumber);
        }
    }

    /// <summary>
    /// This structure indicates status of a particular operator.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RILOPERATORINFO
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;
        
        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_OI">RIL_PARAM_OI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_OI dwParams;
        public enum RIL_PARAM_OI_Type
        {
            RIL_PARAM_OI_INDEX = 0x01,//	The dwIndex member of the structure is valid.
            RIL_PARAM_OI_STATUS = 0x02,//	The dwStatus member of the structure is valid.
            RIL_PARAM_OI_NAMES = 0x04,//	The ronNames member of the structure is valid.
            RIL_PARAM_OI_ALL = 0x07,//	All members of the structure are valid.
        }

        /// <summary>
        /// Specifies the index, if applicable.
        /// </summary>
        public RIL_PREFOPINDEX dwIndex;
        const Int32 RIL_PREFOPINDEX_FIRSTAVAILABLE = -1 /*0xffffffff*/;      // @constdefine Used to specify that a preferred operator is

        /// <summary>
        /// Specifies the registration status, if applicable.
        /// </summary>
        public uint dwStatus;
        public enum dwStatus_Type{
        RIL_OPSTATUS_UNKNOWN=0x00,//    Unknown status.
        RIL_OPSTATUS_AVAILABLE=0x01,//  Operator is available.
        RIL_OPSTATUS_CURRENT=0x02,//    Operator is current.
        RIL_OPSTATUS_FORBIDDEN=0x03,//  Operator is forbidden.
        }

        /// <summary>
        /// Representations of an operator.
        /// </summary>
        public RILOPERATORNAMES ronNames;
    }

    public class RilSignalQuality
    {
        RILSIGNALQUALITY rilsignalquality=new RILSIGNALQUALITY();
        public RilSignalQuality(IntPtr pStruct)
        {
            try
            {
                rilsignalquality = (RILSIGNALQUALITY)Marshal.PtrToStructure(pStruct, typeof(RILSIGNALQUALITY));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("exception in RilSignalQuality: " + ex.Message + "\r\n" + ex.InnerException);
            }
        }
        public string dump()
        {
            string s = "";
            s += rilsignalquality.dwParams.ToString("G") + "\r\n";

            if ((rilsignalquality.dwParams & (int)RIL_PARAM_SQ.SIGNALSTRENGTH) != 0 || 
                (rilsignalquality.dwParams & (int)RIL_PARAM_SQ.ALL) == (int)RIL_PARAM_SQ.ALL )
                s += " signal: " + rilsignalquality.nSignalStrength.ToString();
            if ((rilsignalquality.dwParams & (int)RIL_PARAM_SQ.MINSIGNALSTRENGTH) == (int)RIL_PARAM_SQ.MINSIGNALSTRENGTH ||
                (rilsignalquality.dwParams & (int)RIL_PARAM_SQ.ALL) == (int)RIL_PARAM_SQ.ALL)
                s += " min signal: " + rilsignalquality.nMinSignalStrength.ToString();
            if ((rilsignalquality.dwParams & (int)RIL_PARAM_SQ.MAXSIGNALSTRENGTH) == (int)RIL_PARAM_SQ.MAXSIGNALSTRENGTH ||
                (rilsignalquality.dwParams & (int)RIL_PARAM_SQ.ALL) == (int)RIL_PARAM_SQ.ALL)
                s += " max signal: " + rilsignalquality.nMaxSignalStrength.ToString();
            if ((rilsignalquality.dwParams & (int)RIL_PARAM_SQ.LOWSIGNALSTRENGTH) == (int)RIL_PARAM_SQ.LOWSIGNALSTRENGTH ||
                (rilsignalquality.dwParams & (int)RIL_PARAM_SQ.ALL) == (int)RIL_PARAM_SQ.ALL)
                s += " low signal: " + rilsignalquality.nLowSignalStrength.ToString();
            if ((rilsignalquality.dwParams & (int)RIL_PARAM_SQ.HIGHSIGNALSTRENGTH) == (int)RIL_PARAM_SQ.HIGHSIGNALSTRENGTH ||
                (rilsignalquality.dwParams & (int)RIL_PARAM_SQ.ALL) == (int)RIL_PARAM_SQ.ALL)
                s += " high signal: " + rilsignalquality.nHighSignalStrength.ToString();

            if ((rilsignalquality.dwParams & (int)RIL_PARAM_SQ.BITERRORRATE) == (int)RIL_PARAM_SQ.BITERRORRATE ||
                (rilsignalquality.dwParams & (int)RIL_PARAM_SQ.ALL) == (int)RIL_PARAM_SQ.ALL)
                s += " bit error rate: " + rilsignalquality.dwBitErrorRate.ToString();

            return s;
        }
    }

    public class RilBearSvcInfo
    {
        RILBEARERSVCINFO svcInfo = new RILBEARERSVCINFO();
        public RilBearSvcInfo(IntPtr ptr)
        {
            svcInfo = (RILBEARERSVCINFO)Marshal.PtrToStructure(ptr, typeof(RILBEARERSVCINFO));
        }
        public override string ToString()
        {
            string s = "";
            if (FlagSettings.isFlagSet(BEARSVCINFOPARMS.RIL_PARAM_BSI_CONNECTIONELEMENT, svcInfo.dwParams) ||
                FlagSettings.isFlagSet(BEARSVCINFOPARMS.RIL_PARAM_BSI_ALL, svcInfo.dwParams))
                s += "Bear Svc Conn Element: " + svcInfo.dwConnectionElement.ToString() + "\r\n";
            if (FlagSettings.isFlagSet(BEARSVCINFOPARMS.RIL_PARAM_BSI_SERVICENAME, svcInfo.dwParams) ||
                FlagSettings.isFlagSet(BEARSVCINFOPARMS.RIL_PARAM_BSI_ALL, svcInfo.dwParams))
                s += "Bear Svc Name: " + svcInfo.dwServiceName.ToString() + "\r\n";
            if (FlagSettings.isFlagSet(BEARSVCINFOPARMS.RIL_PARAM_BSI_SPEED, svcInfo.dwParams) ||
                FlagSettings.isFlagSet(BEARSVCINFOPARMS.RIL_PARAM_BSI_ALL, svcInfo.dwParams))
                s += "Bear Svc Speed: " + svcInfo.dwSpeed.ToString() + "\r\n";

            return s;
        }
    }
    [StructLayout(LayoutKind.Explicit)]    
    public struct RILBEARERSVCINFO
    {
        [FieldOffset(0)]
        Int32 cbSize;                              // @field structure size in bytes
        [FieldOffset(4)]
        public BEARSVCINFOPARMS dwParams;          // @field indicates valid parameters
        [FieldOffset(8)]
        public Int32 dwSpeed;                      // @field offered data speed (protocol dependant)
        [FieldOffset(12)]
        public RILBSVCNAME dwServiceName;                // @field type of data service
        [FieldOffset(16)]
        public BEARERSVCCONNECTIONELEMENT dwConnectionElement;          // @field indicates transparent or non-transparent connection
    } 
    public enum BEARSVCINFOPARMS:int{
        RIL_PARAM_BSI_SPEED                         =(0x00000001), // @paramdefine
        RIL_PARAM_BSI_SERVICENAME                   =(0x00000002), // @paramdefine
        RIL_PARAM_BSI_CONNECTIONELEMENT             =(0x00000004), // @paramdefine
        RIL_PARAM_BSI_ALL                           =(0x00000007), // @paramdefine
    }
    /// <summary>
    /// This structure stores signal quality information.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    class RILSIGNALQUALITY
    {
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        [FieldOffset(0)]
        int dwSize;
        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_SQ">RIL_PARAM_SQ</see>
        /// </summary>
        [FieldOffset(4)]
        public int dwParams;
        [FieldOffset(8)]
        /// <summary>
        /// Specifies the signal strength.
        /// </summary>
        public int nSignalStrength;
        [FieldOffset(12)]
        /// <summary>
        /// Specifies the minimum signal strength.
        /// </summary>
        public int nMinSignalStrength;
        [FieldOffset(16)]
        /// <summary>
        /// Specifies the maximum signal strength.
        /// </summary>
        public int nMaxSignalStrength;
        [FieldOffset(20)]
        /// <summary>
        /// Bit error rate in 1/100 of a percent. Must be one of the bit error rate constants.
        /// </summary>
        public uint dwBitErrorRate;
        [FieldOffset(24)]
        /// <summary>
        /// Indicates a low signal strength.
        /// </summary>
        public int nLowSignalStrength;
        /// <summary>
        /// Indicates a high signal strength.
        /// </summary>
        [FieldOffset(28)]
        public int nHighSignalStrength;
    } 
    //public class SignalQuality { 
        
    //    public SignalQuality() { } 
    //    /// Gets or sets the signal strength (RSSI) 
    //    public int SignalStrength { get ; set ; } 
    //    /// Gets or sets Minimiun RSSI 
    //    public int nMinSignalStrength { get ; set ; } 
    //    /// Gets or sets Max RSSI 
    //    public int nMaxSignalStrength { get ; set ; } 
    //    /// Gets or sets Minimiun BER 
    //    public uint BitErrorRate { get ; set ; } 
    //    /// Gets or sets Low RSSI 
    //    public int nLowSignalStrength { get ; set ; } 
    //    /// Gets or sets High RSSI 
    //    public int nHighSignalStrength { get ; set ; } 
    //}

    [StructLayout(LayoutKind.Explicit)]
    public struct RILSIMSECURITYSTATUS
    {
        [FieldOffset(0)]
        UInt32 cbSize;                   // @field structure size in bytes
        [FieldOffset(4)]
        RIL_LOCKEDSTATE dwLockedState;            // @field one of RIL_LOCKEDSTATE_*
        [FieldOffset(8)]
        RIL_SIMSECURITYSTATE dwSimSecurityState;       // @field one of RIL_SIMSECURITYSTATE_*
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct RILDATACOMPINFO
    {
        [FieldOffset(0)]
        UInt32 cbSize;                       // @field structure size in bytes
        [FieldOffset(4)]
        public UInt32 dwParams;                     // @field indicates valid parameters
        [FieldOffset(8)]
        public RIL_DATACOMPDIR dwDirection;                  // @field compression in transmit and/or receive direcitons
        [FieldOffset(12)]
        public RIL_DATACOMP_NEG dwNegotiation;                // @field compression is required or optional
        [FieldOffset(16)]
        public UInt32 dwMaxDictEntries;             // @field maximum number of dictionary entries
        [FieldOffset(20)]
        public UInt32 dwMaxStringLength;            // @field maximum string length
    }

    public class RilNITZInfo
    {
        RILNITZINFO nitzInfo = new RILNITZINFO();
        public RilNITZInfo(IntPtr ptr)
        {
            nitzInfo = (RILNITZINFO)Marshal.PtrToStructure(ptr, typeof(RILNITZINFO));
        }
        public override string ToString()
        {
            string s = "";
            if(FlagSettings.isFlagSet(nitzInfo.dwParam, RIL_PARAM_NITZ.RIL_PARAM_NITZ_DAYLIGHTSAVINGOFFSET))
                s+="DST offset=" + nitzInfo.DaylightSavingOffsetMinutes.ToString()+"\r\n";
            if (FlagSettings.isFlagSet(nitzInfo.dwParam, RIL_PARAM_NITZ.RIL_PARAM_NITZ_SYSTEMTIME))
                s += "time: " + nitzInfo.SysTime.ToString() + "\r\n";
            if (FlagSettings.isFlagSet(nitzInfo.dwParam, RIL_PARAM_NITZ.RIL_PARAM_NITZ_TIMEZONEOFFSET))
                s += "TZ offset=" +nitzInfo.TimeZoneOffsetMinutes.ToString() + "\r\n";
            return s;
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct RILNITZINFO{
        [FieldOffset(0)]
        UInt32  cbSize;             // size of this struct.
        [FieldOffset(4)]
        public RIL_PARAM_NITZ dwParam;           // valid fields RIL_PARAM_NITZ_
        [FieldOffset(8)]
        public UInt32 dwNotificationCode; // type of notifcation RIL_NOTIFY_NITZ
        [FieldOffset(12)]
        public int TimeZoneOffsetMinutes;// Indicates the time zone offset +/-
        [FieldOffset(16)]
        public int DaylightSavingOffsetMinutes; // Indicates the daylight saving offset in minutes
        [FieldOffset(20)]
        public SYSTEMTIME SysTime;        // If available from network
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        [MarshalAs(UnmanagedType.U2)]
        public short Year;
        [MarshalAs(UnmanagedType.U2)]
        public short Month;
        [MarshalAs(UnmanagedType.U2)]
        public short DayOfWeek;
        [MarshalAs(UnmanagedType.U2)]
        public short Day;
        [MarshalAs(UnmanagedType.U2)]
        public short Hour;
        [MarshalAs(UnmanagedType.U2)]
        public short Minute;
        [MarshalAs(UnmanagedType.U2)]
        public short Second;
        [MarshalAs(UnmanagedType.U2)]
        public short Milliseconds;

        public SYSTEMTIME(DateTime dt)
        {
            dt = dt.ToUniversalTime();  // SetSystemTime expects the SYSTEMTIME in UTC
            Year = (short)dt.Year;
            Month = (short)dt.Month;
            DayOfWeek = (short)dt.DayOfWeek;
            Day = (short)dt.Day;
            Hour = (short)dt.Hour;
            Minute = (short)dt.Minute;
            Second = (short)dt.Second;
            Milliseconds = (short)dt.Millisecond;
        }
        public override string ToString()
        {
            return (string.Format("{0:02}.{1:02}.{2:04} {3:02}:{4:02}:{5:02}:{6:02}",
                Day, Month, Year,
                Hour, Minute, Second, Milliseconds));
        }
    }
}