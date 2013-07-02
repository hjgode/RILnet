//-----------------------------------------------------------------------------------------
// <copyright file="Parameters.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    using System;

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILRINGINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILRINGINFO">RILRINGINFO</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILRINGINFO"/>
    [Flags]
    public enum RIL_PARAM_RI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILRINGINFO.dwCallType">dwCallType</see> member of the structure is valid.
        /// </summary>
        CALLTYPE = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILRINGINFO.rsiServiceInfo">rsiServiceInfo</see> member of the structure is valid.
        /// </summary>
        SERVICEINFO = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILRINGINFO.dwAddressId">dwAddressId</see> member of the structure is valid.
        /// </summary>
        ADDRESSID = 0x00000004,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x00000007
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILSERVICEINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILSERVICEINFO">RILSERVICEINFO</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILSERVICEINFO"/>
    [Flags]
    public enum RIL_PARAM_SVCI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILSERVICEINFO.fSynchronous">fSynchronous</see> member of the structure is valid.
        /// </summary>
        SYNCHRONOUS = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILSERVICEINFO.fTransparent">fTransparent</see> member of the structure is valid.
        /// </summary>
        TRANSPARENT = 0x00000002,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x00000003
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILCALLHSCSDINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILCALLHSCSDINFO">RILCALLHSCSDINFO</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILCALLHSCSDINFO"/>
    [Flags]
    public enum RIL_PARAM_CHSCSDI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILCALLHSCSDINFO.dwRxTimeSlots">dwRxTimeSlots</see> member of the structure is valid.
        /// </summary>
        RXTIMESLOTS = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLHSCSDINFO.dwTxTimeSlots">dwTxTimeSlots</see> member of the structure is valid.
        /// </summary>
        TXTIMESLOTS = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLHSCSDINFO.dwAirInterfaceUserRate">dwAirInterfaceUserRate</see> member of the structure is valid.
        /// </summary>
        AIRINTERFACEUSERRATE = 0x00000004,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLHSCSDINFO.dwChannelCoding">dwChannelCoding</see> member of the structure is valid.
        /// </summary>
        CHANNELCODING = 0x00000008,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x0000000f
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILDIALINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILDIALINFO">RILDIALINFO</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILDIALINFO"/>
    [Flags]
    public enum RIL_PARAM_DI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILDIALINFO.hrCmdId">hrCmdId</see> member of the structure is valid.
        /// </summary>
        CMDID = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILDIALINFO.dwCallId">dwCallId</see> member of the structure is valid.
        /// </summary>
        CALLID = 0x00000002,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x00000003
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILCALLINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILCALLINFO">RILCALLINFO</see> structure.
    /// </summary>
    /// <remarks>
    /// <see cref="P:RilNET.RIL_PARAM_CI.STATUS">RIL_PARAM_CI.STATUS</see> and <see cref="P:RilNET.RIL_PARAM_CI.STATUS">RIL_PARAM_CI.CPISTATUS</see> are mutually exclusive parameters because they define how the <see cref="P:RilNET.RILCALLINFO.dwStatus">dwStatus</see> member is used. To avoid any ambiguity, no RIL_PARAM_CI.ALL value exists for the <see cref="T:RilNET.RIL_PARAM_CI">RIL_PARAM_CI</see> parameter constants. 
    /// </remarks>
    /// <seealso cref="T:RilNET.RILCALLINFO"/>
    [Flags]
    public enum RIL_PARAM_CI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.dwID">dwID</see> member of the structure is valid.
        /// </summary>
        ID = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.dwDirection">dwDirection</see> member of the structure is valid.
        /// </summary>
        DIRECTION = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.dwStatus">dwStatus</see> member of the structure is valid.
        /// </summary>
        STATUS = 0x00000004,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.dwType">dwType</see> member of the structure is valid.
        /// </summary>
        TYPE = 0x00000008,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.dwMultiParty">dwMultiParty</see> member of the structure is valid.
        /// </summary>
        MULTIPARTY = 0x00000010,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.raAddress">raAddress</see> member of the structure is valid.
        /// </summary>
        ADDRESS = 0x00000020,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.wszDescription">wszDescription</see> member of the structure is valid.
        /// </summary>
        DESCRIPTION = 0x00000040,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.dwStatus">dwStatus</see> member of the structure is valid.
        /// </summary>
        CPISTATUS = 0x00000080,

        /// <summary>
        /// The <see cref="P:RilNET.RILCALLINFO.dwDisconnectCode">dwDisconnectCode</see> member of the structure is valid.
        /// </summary>
        DISCONNECTCODE = 0x00000100
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILADDRESS.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILADDRESS">RILADDRESS</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILADDRESS"/>
    [Flags]
    public enum RIL_PARAM_A : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILADDRESS.dwType">dwType</see> member of the structure is valid.
        /// </summary>
        TYPE = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILADDRESS.dwNumPlan">dwNumPlan</see> member of the structure is valid.
        /// </summary>
        NUMPLAN = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILADDRESS.wszAddress">wszAddress</see> member of the structure is valid.
        /// </summary>
        ADDRESS = 0x00000004,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x00000007
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILEQUIPMENTSTATE.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILEQUIPMENTSTATE">RILEQUIPMENTSTATE</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILEQUIPMENTSTATE"/>
    [Flags]
    public enum RIL_PARAM_EQUIPMENTSTATE : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILEQUIPMENTSTATE.dwRadioSupport">dwRadioSupport</see> member of the structure is valid.
        /// </summary>
        RADIOSUPPORT = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILEQUIPMENTSTATE.dwEqState">dwEqState</see> member of the structure is valid.
        /// </summary>
        EQSTATE = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILEQUIPMENTSTATE.dwReadyState">dwReadyState</see> member of the structure is valid.
        /// </summary>
        READYSTATE = 0x00000004,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x00000007
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILOPERATORNAMES.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILOPERATORNAMES">RILOPERATORNAMES</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILOPERATORNAMES"/>
    [Flags]
    public enum RIL_PARAM_ON
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILOPERATORNAMES.szLongName">szLongName</see> member of the structure is valid.
        /// </summary>
        LONGNAME = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILOPERATORNAMES.szShortName">szShortName</see> member of the structure is valid.
        /// </summary>
        SHORTNAME = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILOPERATORNAMES.szNumName">szNumName</see> member of the structure is valid.
        /// </summary>
        NUMNAME = 0x00000004,

        /// <summary>
        /// The <see cref="P:RilNET.RILOPERATORNAMES.szCountryCode">szCountryCode</see> member of the structure is valid.
        /// </summary>
        COUNTRY_CODE = 0x00000008,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x00000007
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILCELLTOWERINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILCELLTOWERINFO">RILCELLTOWERINFO</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILCELLTOWERINFO"/>
    [Flags]
    public enum RIL_PARAM_CTI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwMobileCountryCode">dwMobileCountryCode</see> member of the structure is valid.
        /// </summary>
        MOBILECOUNTRYCODE = 0x00000001, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwMobileNetworkCode">dwMobileNetworkCode</see> member of the structure is valid.
        /// </summary>
        MOBILENETWORKCODE = 0x00000002, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwLocationAreaCode">dwLocationAreaCode</see> member of the structure is valid.
        /// </summary>
        LOCATIONAREACODE = 0x00000004, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwCellID">dwCellID</see> member of the structure is valid.
        /// </summary>
        CELLID = 0x00000008, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwBaseStationID">dwBaseStationID</see> member of the structure is valid.
        /// </summary>
        BASESTATIONID = 0x00000010, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwBroadCastControlChannel">dwBroadCastControlChannel</see> member of the structure is valid.
        /// </summary>
        BROADCASTCONTROLCHANNEL = 0x00000020, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwRxLevel">dwRxLevel</see> member of the structure is valid.
        /// </summary>
        RXLEVEL = 0x00000040, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwRxLevelFull">dwRxLevelFull</see> member of the structure is valid.
        /// </summary>
        RXLEVELFULL = 0x00000080, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwRxLevelSub">dwRxLevelSub</see> member of the structure is valid.
        /// </summary>
        RXLEVELSUB = 0x00000100, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwRxQuality">dwRxQuality</see> member of the structure is valid.
        /// </summary>
        RXQUALITY = 0x00000200, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwRxQualityFull">dwRxQualityFull</see> member of the structure is valid.
        /// </summary>
        RXQUALITYFULL = 0x00000400, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwRxQualitySub">dwRxQualitySub</see> member of the structure is valid.
        /// </summary>
        RXQUALITYSUB = 0x00000800, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwIdleTimeSlot">dwIdleTimeSlot</see> member of the structure is valid.
        /// </summary>
        IDLETIMESLOT = 0x00001000, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwTimingAdvance">dwTimingAdvance</see> member of the structure is valid.
        /// </summary>
        TIMINGADVANCE = 0x00002000, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwGPRSCellID">dwGPRSCellID</see> member of the structure is valid.
        /// </summary>
        GPRSCELLID = 0x00004000, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwGPRSBaseStationID">dwGPRSBaseStationID</see> member of the structure is valid.
        /// </summary>
        GPRSBASESTATIONID = 0x00008000, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.dwNumBCCH">dwNumBCCH</see> member of the structure is valid.
        /// </summary>
        NUMBCCH = 0x00010000, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.rgbNMR">rgbNMR</see> member of the structure is valid.
        /// </summary>
        NMR = 0x00020000, 

        /// <summary>
        /// The <see cref="P:RilNET.RILCELLTOWERINFO.rgbBCCH">rgbBCCH</see> member of the structure is valid. 
        /// </summary>
        BCCH = 0x00040000, 

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x0007ffff
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILEQUIPMENTINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILEQUIPMENTINFO">RILEQUIPMENTINFO</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILEQUIPMENTINFO"/>
    [Flags]
    public enum RIL_PARAM_EI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILEQUIPMENTINFO.szManufacturer">szManufacturer</see> member of the structure is valid.
        /// </summary>
        MANUFACTURER = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILEQUIPMENTINFO.szModel">szModel</see> member of the structure is valid.
        /// </summary>
        MODEL = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILEQUIPMENTINFO.szRevision">szRevision</see> member of the structure is valid.
        /// </summary>
        REVISION = 0x00000004,

        /// <summary>
        /// The <see cref="P:RilNET.RILEQUIPMENTINFO.szSerialNumber">szSerialNumber</see> member of the structure is valid.
        /// </summary>
        SERIALNUMBER = 0x00000008,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x0000000f
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILOPERATORINFO.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILOPERATORINFO">RILOPERATORINFO</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILOPERATORINFO"/>
    [Flags]
    public enum RIL_PARAM_OI : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILOPERATORINFO.dwIndex">dwIndex</see> member of the structure is valid.
        /// </summary>
        INDEX = 0x00000001,

        /// <summary>
        /// The <see cref="P:RilNET.RILOPERATORINFO.dwStatus">dwStatus</see> member of the structure is valid.
        /// </summary>
        STATUS = 0x00000002,

        /// <summary>
        /// The <see cref="P:RilNET.RILOPERATORINFO.ronNames">ronNames</see> member of the structure is valid.
        /// </summary>
        NAMES = 0x00000004,

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x00000007
    }

    /// <summary>
    /// The following table shows the valid values for the <see cref="P:RilNET.RILSIGNALQUALITY.dwParams">dwParams</see> member of the <see cref="T:RilNET.RILSIGNALQUALITY">RILSIGNALQUALITY</see> structure.
    /// </summary>
    /// <seealso cref="T:RilNET.RILSIGNALQUALITY"/>
    [Flags]
    public enum RIL_PARAM_SQ : uint
    {
        /// <summary>
        /// The <see cref="P:RilNET.RILSIGNALQUALITY.nSignalStrength">nSignalStrength</see> member of the structure is valid.
        /// </summary>
        SIGNALSTRENGTH = 0x00000001, 

        /// <summary>
        /// The <see cref="P:RilNET.RILSIGNALQUALITY.nMinSignalStrength">nMinSignalStrength</see> member of the structure is valid.
        /// </summary>
        MINSIGNALSTRENGTH = 0x00000002, 

        /// <summary>
        /// The <see cref="P:RilNET.RILSIGNALQUALITY.nMaxSignalStrength">nMaxSignalStrength</see> member of the structure is valid.
        /// </summary>
        MAXSIGNALSTRENGTH = 0x00000004, 

        /// <summary>
        /// The <see cref="P:RilNET.RILSIGNALQUALITY.dwBitErrorRate">dwBitErrorRate</see> member of the structure is valid.
        /// </summary>
        BITERRORRATE = 0x00000008, 

        /// <summary>
        /// The <see cref="P:RilNET.RILSIGNALQUALITY.nLowSignalStrength">nLowSignalStrength</see> member of the structure is valid.
        /// </summary>
        LOWSIGNALSTRENGTH = 0x00000010, 

        /// <summary>
        /// The <see cref="P:RilNET.RILSIGNALQUALITY.nHighSignalStrength">nHighSignalStrength</see> member of the structure is valid.
        /// </summary>
        HIGHSIGNALSTRENGTH = 0x00000020, 

        /// <summary>
        /// All members of the structure are valid.
        /// </summary>
        ALL = 0x0000003f
    }
}
