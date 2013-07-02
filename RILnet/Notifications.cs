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
        RADIOPRESENCECHANGED = 0x00000002 | RIL_NCLASS.RADIOSTATE
    }
}
