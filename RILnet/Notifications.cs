//-----------------------------------------------------------------------------------------
// <copyright file="Notifications.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    using System;

    /// <summary>
    /// RIL notification classes.
    /// </summary>
    [Flags]
    public enum RIL_NCLASS : uint
    {
        /// <summary>
        /// API call results.
        /// </summary>
        FUNCRESULT = 0x80000000,

        /// <summary>
        /// Call control notifications.
        /// </summary>
        CALLCTRL = 0x00010000,

        /// <summary>
        /// Messaging notifications.
        /// </summary>
        MESSAGE = 0x00020000,

        /// <summary>
        /// Network-related notifications.
        /// </summary>
        NETWORK = 0x00040000,

        /// <summary>
        /// Supplementary service notifications.
        /// </summary>
        SUPSERVICE = 0x00080000,

        /// <summary>
        /// Phonebook notifications.
        /// </summary>
        PHONEBOOK = 0x00100000,

        /// <summary>
        /// SIM Toolkit notifications.
        /// </summary>
        SIMTOOLKIT = 0x00200000,

        /// <summary>
        /// Miscellaneous notifications.
        /// </summary>
        MISC = 0x00400000,

        /// <summary>
        /// Notifications pertaining to changes in radio state.
        /// </summary>
        RADIOSTATE = 0x00800000,

        /// <summary>
        /// Reserved for device specific notifications.
        /// </summary>
        DEVSPECIFIC = 0x80000000,

        /// <summary>
        /// All notification classes (except DevSpecifc).
        /// </summary>
        ALL = 0x00ff0000
    }


    public enum RIL_NOTIFY_NETWORK : uint
    {
        RIL_NOTIFY_REGSTATUSCHANGED = (0x00000001 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine Network registration status has changed; lpData points to the new status (RIL_REGSTAT_* constant)
        RIL_NOTIFY_CALLMETER = (0x00000002 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine Call meter has changed; lpData points to a DWORD containing new current call meter value
        RIL_NOTIFY_CALLMETERMAXREACHED = (0x00000003 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine Call meter maximum has been reached; lpData is NULL
        RIL_NOTIFY_GPRSREGSTATUSCHANGED = (0x00000004 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine Network registration status has changed; lpData points to the new status (RIL_REGSTAT_* constant)
        RIL_NOTIFY_SYSTEMCHANGED = (0x00000005 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine This indicates that the type of coverage which is available has changed.  Typically one would expect IS-95A or 1xRTT, however CDMA does allow overlay systems; lpData is <t DWORD> of type RIL_SYSTEMTYPE_ flags
        RIL_NOTIFY_GPRSCONNECTIONSTATUS = (0x00000006 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine This indicates the pdp context state has changed. lpData points to RILGPRSCONTEXTACTIVATED
        RIL_NOTIFY_SYSTEMCAPSCHANGED = (0x00000007 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine This indicates the system capability has changed. lpData points to the new system capability (RIL_SYSTEMCAPS_* constant)
        RIL_NOTIFY_LOCATIONUPDATE = (0x00000008 | NOTIFICATIONCLASSES.RIL_NCLASS_NETWORK),  // @constdefine This indicates the location data has changed. lpData points to RILLOCATIONINFO
    }

    public enum RIL_NOTIFY_SYSTEMCAPS : uint
    {
        RIL_SYSTEMCAPS_NONE = 0x00,
        RIL_SYSTEMCAPS_VOICEDATA = 0x01,
        RIL_SYSTEMCAPS_ALL = 0x01
    }

    public enum RIL_NOTIFY_SYSTEMCHANGED : uint
    {
        RIL_SYSTEMTYPE_NONE = (0x00000000),// @constdegine No Networks in Coverage
        RIL_SYSTEMTYPE_IS95A = (0x00000001),// @constdefine IS-95A network support (Low Packet, or Circuit Switched Service)
        RIL_SYSTEMTYPE_IS95B = (0x00000002),// @constdefine IS-95B network support
        RIL_SYSTEMTYPE_1XRTTPACKET = (0x00000004),// @constdefine CDMA-2000 Rev A (1xRTT) network support
        RIL_SYSTEMTYPE_GSM = (0x00000008),// @constdefine GSM network support
        RIL_SYSTEMTYPE_GPRS = (0x00000010),// @constdefine GPRS support
        RIL_SYSTEMTYPE_EDGE = (0x00000020),// @constdefine GSM EDGE network support
        RIL_SYSTEMTYPE_1XEVDOPACKET = (0x00000040),// @constdefine CDMA (1xEVDO) network support
        RIL_SYSTEMTYPE_1XEVDVPACKET = (0x00000080),// @constdefine CDMA (1xEVDV) network support
        RIL_SYSTEMTYPE_UMTS = (0x00000100),// @constdefine UMTS network support
        RIL_SYSTEMTYPE_HSDPA = (0x00000200),// @constdefine HSDPA support    
    }

    public enum RIL_REGISTRATION_CONSTANTS : uint
    {
        RIL_REGSTAT_UNKNOWN = (0x00000000),// @constdefine Registration unknown
        RIL_REGSTAT_UNREGISTERED = (0x00000001),// @constdefine Unregistered
        RIL_REGSTAT_HOME = (0x00000002),// @constdefine Registered on home network
        RIL_REGSTAT_ATTEMPTING = (0x00000003),// @constdefine Attempting to register
        RIL_REGSTAT_DENIED = (0x00000004),// @constdefine Registration denied
        RIL_REGSTAT_ROAMING = (0x00000005),// @constdefine Registered on roaming network
    }

    /// <summary>
    /// Call control notifications (<see cref="T:RIL_NCLASS.CALLCTRL">RIL_NCLASS.CALLCTRL</see>).
    /// </summary>
    public enum RIL_NOTIFY_CALLCTR : uint
    {
        /// <summary>
        /// Incoming call. The lpData notification parameter points to <see cref="T:RilNET.RILRINGINFO">RILRINGINFO</see>.
        /// </summary>
        RING = 0x00000001 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// Data/voice connection has been established. The lpData notification parameter points to <see cref="T:RilNET.RILCONNECTINFO">RILCONNECTINFO</see>. CellTSP ignores <see cref="F:RilNET.RIL_NOTIFY.CONNECT">RIL_NOTIFY.CONNECT</see>. Use <see cref="F:RilNET.RIL_NOTIFY.CALLPROGRESSINFO">RIL_NOTIFY.CALLPROGRESSINFO</see> to indicate call state transitions.
        /// </summary>
        CONNECT = 0x00000002 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// Data/voice connection has been terminated. The lpData notification parameter points to a disconnect initiation constant.
        /// </summary>
        DISCONNECT = 0x00000003 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// Data connection service has been negotiated. The lpData notification parameter points to <see cref="T:RilNET.RILSERVICEINFO">RILSERVICEINFO</see>.
        /// </summary>
        DATASVCNEGOTIATED = 0x00000004 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// The RIL has performed an operation that may have changed state of existing calls. The lpData notification parameter is NULL.
        /// </summary>
        CALLSTATECHANGED = 0x00000005 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// The RIL has entered emergency mode. The lpData notification parameter is NULL.
        /// </summary>
        EMERGENCYMODEENTERED = 0x00000006 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// The RIL has exited emergency mode. The lpData notification parameter is NULL.
        /// </summary>
        EMERGENCYMODEEXITED = 0x00000007 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// Existing calls (if any) were hung up in RIL emergency mode. The lpData notification parameter is NULL.
        /// </summary>
        EMERGENCYHANGUP = 0x00000008 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// High Speed Circuit Switched Data (HSCSD) parameter for a call has been negotiated. The lpData notification parameter points to <see cref="T:RilNET.RILCALLHSCSDINFO">RILCALLHSCSDINFO</see>.
        /// </summary>
        HSCSDPARAMSNEGOTIATED = 0x00000009 | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// Outgoing call. The lpData notification parameter points to <see cref="T:RilNET.RILDIALINFO">RILDIALINFO</see>.
        /// </summary>
        DIAL = 0x0000000A | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// CPI notification. The lpData notification points to <see cref="T:RilNET.RILCALLINFO">RILCALLINFO</see>.
        /// </summary>
        CALLPROGRESSINFO = 0x0000000B | RIL_NCLASS.CALLCTRL,

        /// <summary>
        /// The current line has changed. The lpData points to a new current address id.
        /// </summary>
        CURRENTLINE_CHANGED = 0x0000000C | RIL_NCLASS.CALLCTRL
    }

    /// <summary>
    /// Call control notifications (<see cref="T:RIL_NCLASS.RADIOSTATE">RIL_NCLASS.RADIOSTATE</see>).
    /// </summary>
    public enum RIL_NOTIFY_RADIOSTATE : uint
    {
        /// <summary>
        /// Carries a STRUCT (<see cref="T:RILEQUIPMENTSTATE">RILEQUIPMENTSTATE</see>) that indicates that the radio equipment state has changed. Also indicates a driver-defined radio ON or OFF state.
        /// </summary>
        RADIOEQUIPMENTSTATECHANGED = 0x00000001 | RIL_NCLASS.RADIOSTATE,

        /// <summary>
        /// Carries a DWORD with one of the <see cref="T:RIL_RADIOPRESENCE">RIL_RADIOPRESENCE</see> values. These constants indicate that a radio module or driver has been changed (for example, removed or inserted).
        /// </summary>
        RADIOPRESENCECHANGED = 0x00000002 | RIL_NCLASS.RADIOSTATE,

        RIL_NOTIFY_RADIORESET = 0x00000003 | RIL_NCLASS.RADIOSTATE,
    }

    // -----------------------------------------------------------------------------
    // @constants Notification Misc | Miscellaneous notifications (RIL_NCLASS_MISC)
    public enum RIL_NOTIFY_MISC :uint{
        RIL_NOTIFY_SIMNOTACCESSIBLE                 =(0x00000001 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine SIM card has been removed or has failed to respond; lpData is NULL
        RIL_NOTIFY_DTMFSIGNAL                       =(0x00000002 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine A DTMF signal has been detected; lpData points to char
        RIL_NOTIFY_GPRSCLASS_NETWORKCHANGED         =(0x00000003 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine Network has indicated a change in GPRS class
                                                                                     // lpData points to a DWORD containing the new RIL_GPRSCLASS_* value
        RIL_NOTIFY_GPRSCLASS_RADIOCHANGED           =(0x00000004 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine The radio has indicated a change in GPRS class
                                                                                     // lpData points to a DWORD containing the new RIL_GPRSCLASS_* value
        RIL_NOTIFY_SIGNALQUALITY                    =(0x00000005 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine Signal Quality Notification
                                                                                     // lpData points to a RILSIGNALQUALITY structure
        RIL_NOTIFY_MAINTREQUIRED                    =(0x00000006 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine BS notification that MS requires servicing; lpdata is NULL
        RIL_NOTIFY_PRIVACYCHANGED                   =(0x00000007 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine Call Privacy Status; lpData points to DWORD of value RIL_CALLPRIVACY_*
        RIL_NOTIFY_SIM_DATACHANGE                   =(0x00000008 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine data change notification; lpData points to DWORD of value RIL_SIMDATACHANGE_*
        RIL_NOTIFY_ATLOGGING                        =(0x00000009 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine at command log data present
        RIL_NOTIFY_SIMSTATUSCHANGED                 =(0x0000000A | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine SIM card state has changed. Carries a DWORD (RIL_SIMSTATUSCHANGED_*) with the current state.
                                                                                     // Notification is sent only when encountering error conditions from the radio.
        RIL_NOTIFY_EONS                             =(0x0000000B | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine EONS information ready or updated; lpData is NULL
        RIL_NOTIFY_SIMSECURITYSTATUS                =(0x0000000C | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine SIM security status change; lpData points to LPRILSIMSECURITYSTATUS
        RIL_NOTIFY_LINESTATE                        =(0x0000000D | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine line state; lpData points to a DWORD of value RIL_LINESTAT_*
        RIL_NOTIFY_BEARERSVCINFO                    =(0x0000000E | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine bearer service information; lpData points to LPRILBEARERSVCINFO
        RIL_NOTIFY_DATACOMPINFO                     =(0x0000000F | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine data compression information; lpData points to LPRILDATACOMPINFO
        RIL_NOTIFY_EQUIPMENTINFO                    =(0x00000010 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine equipment information; lpData points to LPRILEQUIPMENTINFO
        RIL_NOTIFY_ERRORCORRECTIONINFO              =(0x00000011 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine error correction information; lpData points to LPRILERRORCORRECTIONINFO
        RIL_NOTIFY_GPRSADDRESS                      =(0x00000012 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine GPRS address; lpData points to an array of WCHAR values that indicate the address
        RIL_NOTIFY_GPRSATTACHED                     =(0x00000013 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine GPRS attach state; lpData points to a BOOL that indicates attach state
        RIL_NOTIFY_GPRSCONTEXT                      =(0x00000014 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine GPRS context list; lpData points to LPRILGPRSCONTEXT
        RIL_NOTIFY_GPRSCONTEXTACTIVATED             =(0x00000015 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine GPRS context activated list; lpData points to LPRILGPRSCONTEXTACTIVATED 
        RIL_NOTIFY_QOSMIN                           =(0x00000016 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine minimum quality of service profile ; lpData points to LPRILGPRSQOSPROFILE
        RIL_NOTIFY_QOSREQ                           =(0x00000017 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine requested quality of service profile ; lpData points to LPRILGPRSQOSPROFILE
        RIL_NOTIFY_RLPOPTIONS                       =(0x00000018 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine requested quality of service profile ; lpData points to LPRILRLPINFO
        RIL_NOTIFY_NITZ                             =(0x00000019 | NOTIFICATIONCLASSES.RIL_NCLASS_MISC), // @constdefine NITZ Date/Time notification. lpData points to a RILNITZINFO structure.
    }

}
