﻿//-----------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    using System;

    /// <summary>
    /// Operator name formats.
    /// </summary>
    public enum RIL_OPFORMAT : uint
    {
        /// <summary>
        /// Long alphanumeric name
        /// </summary>
        LONG = 0x00000001,

        /// <summary>
        /// Short alphanumeric name
        /// </summary>
        SHORT = 0x00000002,

        /// <summary>
        /// Numeric name
        /// </summary>
        NUM = 0x00000003
    }

    /// <summary>
    /// Call types.
    /// </summary>
    public enum RIL_CALLTYPE : uint
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        UNKNOWN = 0x00000000,

        /// <summary>
        /// Voice call.
        /// </summary>
        VOICE = 0x00000001,

        /// <summary>
        /// Data call.
        /// </summary>
        DATA = 0x00000002,

        /// <summary>
        /// Fax call.
        /// </summary>
        FAX = 0x00000003
    }
  
    /// <summary>
    /// Call direction.
    /// </summary>
    public enum RIL_CALLDIR : uint
    {
        /// <summary>
        /// Incoming call.
        /// </summary>
        INCOMING = 0x00000001,

        /// <summary>
        /// Outgoing call.
        /// </summary>
        OUTGOING = 0x00000002
    }

    /// <summary>
    /// Call multiparty status values.
    /// </summary>
    public enum RIL_CALL : uint
    {
        /// <summary>
        /// Not in a conference.
        /// </summary>
        SINGLEPARTY = 0x00000000,

        /// <summary>
        /// Participating in a conference.
        /// </summary>
        MULTIPARTY = 0x00000001
    }    

    /// <summary>
    /// Different phone number representations.
    /// </summary>
    public enum RIL_ADDRTYPE : uint
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        UNKNOWN = 0x00000000,

        /// <summary>
        /// International number.
        /// </summary>
        INTERNATIONAL = 0x00000001,

        /// <summary>
        /// National number.
        /// </summary>
        NATIONAL = 0x00000002,

        /// <summary>
        /// Network specific number.
        /// </summary>
        NETWKSPECIFIC = 0x00000003,

        /// <summary>
        /// Subscriber number (protocol-specific).
        /// </summary>
        SUBSCRIBER = 0x00000004,

        /// <summary>
        /// Alphanumeric address.
        /// </summary>
        ALPHANUM = 0x00000005,

        /// <summary>
        /// Abbreviated number.
        /// </summary>
        ABBREV = 0x00000006
    }

    /// <summary>
    /// Different numbering schemes.
    /// </summary>
    /// <remarks>
    /// Used for <see cref="F:RilNET.RIL_ADDRTYPE.UNKNOWN">RIL_ADDRTYPE.UNKNOWN</see>, <see cref="F:RilNET.RIL_ADDRTYPE.INTERNATIONAL">RIL_ADDRTYPE.INTERNATIONAL</see>, and <see cref="F:RilNET.RIL_ADDRTYPE.NATIONAL">RIL_ADDRTYPE.NATIONAL</see>.
    /// </remarks>
    public enum RIL_NUMPLAN : uint
    {
        /// <summary>
        /// Unknown numbering plan.
        /// </summary>
        UNKNOWN = 0x00000000,

        /// <summary>
        /// ISDN/telephone numbering plan (E.164/E.163).
        /// </summary>
        TELEPHONE = 0x00000001,

        /// <summary>
        /// Data numbering plan (X.121).
        /// </summary>
        DATA = 0x00000002,

        /// <summary>
        /// Telex numbering plan.
        /// </summary>
        TELEX = 0x00000003,

        /// <summary>
        /// National numbering plan.
        /// </summary>
        NATIONAL = 0x00000004,

        /// <summary>
        /// Private numbering plan.
        /// </summary>
        PRIVATE = 0x00000005,

        /// <summary>
        /// ERMES numbering plan (ETSI DE/PS 3 01-3).
        /// </summary>
        ERMES = 0x00000006
    }

    /// <summary>
    /// Call status values.
    /// </summary>
    public enum RIL_CALLSTAT : uint
    {
        /// <summary>
        /// Active call.
        /// </summary>
        ACTIVE = 0x00000001,

        /// <summary>
        /// Call on hold.
        /// </summary>
        ONHOLD = 0x00000002,

        /// <summary>
        /// In the process of dialing.
        /// </summary>
        DIALING = 0x00000003,

        /// <summary>
        /// In the process of ringing.
        /// </summary>
        ALERTING = 0x00000004,

        /// <summary>
        /// Incoming (unanswered) call.
        /// </summary>
        INCOMING = 0x00000005,

        /// <summary>
        /// Incoming call waiting call.
        /// </summary>
        WAITING = 0x00000006
    }

    /// <summary>
    /// CPI status values.
    /// </summary>
    public enum RIL_CPISTAT : uint
    {
        /// <summary>
        /// CPI status unknown.
        /// </summary>
        UNKNOWN = 0x00000000,

        /// <summary>
        /// New outgoing call.
        /// </summary>
        NEW_OUTGOING = 0x00000001,

        /// <summary>
        /// New incoming call.
        /// </summary>
        NEW_INCOMING = 0x00000002,

        /// <summary>
        /// Call is connected.
        /// </summary>
        CONNECTED = 0x00000003,

        /// <summary>
        /// Call is disconnected.
        /// </summary>
        DISCONNECTED = 0x00000004
    }
    
    /// <summary>
    /// Radio ON/OFF states.
    /// </summary>
    /// <remarks>
    /// These values typically depend on the equipment state.
    /// </remarks>
    public enum RIL_RADIOSUPPORT : uint
    {
        /// <summary>
        /// Radio functionality is in an intermediate state.
        /// </summary>
        UNKNOWN = 0x00000000, 

        /// <summary>
        /// Radio functionality is OFF. This does not necessarily mean safe for flight. 
        /// </summary>
        OFF = 0x00000001, 

        /// <summary>
        /// Radio functionality is ON.
        /// </summary>
        ON = 0x00000002
    }

    /// <summary>
    /// Equipment states.
    /// </summary>
    public enum RIL_EQSTATE : uint
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        UNKNOWN = 0x00000000, 

        /// <summary>
        /// Minimum power state.
        /// </summary>
        MINIMUM = 0x00000001, 

        /// <summary>
        /// Full functionality.
        /// </summary>
        FULL = 0x00000002, 

        /// <summary>
        /// Transmitter disabled.
        /// </summary>
        DISABLETX = 0x00000003, 

        /// <summary>
        /// Receiver disabled.
        /// </summary>
        DISABLERX = 0x00000004, 

        /// <summary>
        /// Transmitter and receiver disabled.
        /// </summary>
        DISABLETXANDRX = 0x00000005
    }

    /// <summary>
    /// Various components states.
    /// </summary>
    public enum RIL_READYSTATE : uint
    {
        /// <summary>
        /// Nothing is ready yet.
        /// </summary>
        NONE = 0x00000000, 

        /// <summary>
        /// The radio is initialized.
        /// </summary>
        INITIALIZED = 0x00000001, 

        /// <summary>
        /// SIM functionality is ready.
        /// </summary>
        SIM = 0x00000002, 

        /// <summary>
        /// Short Message Service (SMS) functionality is ready.
        /// </summary>
        SMS = 0x00000004, 

        /// <summary>
        /// The SIM is unlocked, if applicable.
        /// </summary>
        UNLOCKED = 0x00000008
    }

    /// <summary>
    /// Radio presence states.
    /// </summary>
    public enum RIL_RADIOPRESENCE : uint
    {
        /// <summary>
        /// There is not radio module present in the device.
        /// </summary>
        NOTPRESENT = 0x00000000,

        /// <summary>
        /// There is a radio module present that the RIL can use.
        /// </summary>
        PRESENT = 0x00000001
    }

    /// <summary>
    /// Special preferred operator index value.
    /// </summary>
    public enum RIL_PREFOPINDEX : uint
    {
        /// <summary>
        /// Used to specify that a preferred operator is to be stored at the first available index.
        /// </summary>
        FIRSTAVAILABLE = 0xffffffff
    }

    /// <summary>
    /// Operator status.
    /// </summary>
    public enum RIL_OPSTATUS : uint
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        UNKNOWN = 0x00000000,

        /// <summary>
        /// Operator is available.
        /// </summary>
        AVAILABLE = 0x00000001,

        /// <summary>
        /// Operator is current.
        /// </summary>
        CURRENT = 0x00000002,

        /// <summary>
        /// Operator is forbidden.
        /// </summary>
        FORBIDDEN = 0x00000003
    }

    /// <summary>
    /// Operator selection modes. Some options are only supported by global phones. Global phones support two radio types, GSM and CDMA. Only one radio can be active at a time, but the device is able to switch between them without rebooting.
    /// </summary>
    public enum RIL_OPSELMODE : uint
    {
        /// <summary>
        /// Automatic operator selection.
        /// </summary>
        AUTOMATIC = 0x00000001,

        /// <summary>
        /// Manual operator selection.
        /// </summary>
        MANUAL = 0x00000002,

        /// <summary>
        /// Manual/automatic operator selection. If manual selection fails, automatic selection mode is entered. 
        /// </summary>
        MANUALAUTOMATIC = 0x00000003,
        AUTOMATIC_GSM =0x04,
        MANUAL_GSM=0x05,
        AUTOMATIC_CDMA = 0x06,
        MANUAL_CDMA = 0x07,

        /*
        #define RIL_OPSELMODE_AUTOMATIC                     (0x00000001)      // @constdefine Automatic operator selection (GSM and/or CDMA)
        #define RIL_OPSELMODE_MANUAL                        (0x00000002)      // @constdefine Manual operator selection (GSM and/or CDMA)
        #define RIL_OPSELMODE_MANUALAUTOMATIC               (0x00000003)      // @constdefine Manual/automatic operator selection (GSM and/or CDMA)
                                                                              // (if manual selection fails, automatic selection mode is entered)
        #define RIL_OPSELMODE_AUTOMATIC_GSM                 (0x00000004)      // @constdefine GSM Only, automatic GSM operator selection
        #define RIL_OPSELMODE_MANUAL_GSM                    (0x00000005)      // @constdefine GSM Only, manual GSM operator selection
        #define RIL_OPSELMODE_AUTOMATIC_CDMA                (0x00000006)      // @constdefine CDMA Only, automatic CDMA operator selection
        #define RIL_OPSELMODE_MANUAL_CDMA                   (0x00000007)      // @constdefine CDMA Only, manual CDMA operator selection
        #define RIL_OPSELMODE_LAST_VALUE                    RIL_OPSELMODE_MANUAL_CDMA      // This is the last entry in the list.
        */
    }
    /// <summary>
    /// constants Notification Class | Notification classes
    /// </summary>
    public enum NOTIFICATIONCLASSES:uint{
        /// <summary>
        /// API call results
        /// </summary>
        RIL_NCLASS_FUNCRESULT                       = (0x00000000), 
        /// <summary>
        /// Call control notifications
        /// </summary>
        RIL_NCLASS_CALLCTRL                         = (0x00010000), 
        /// <summary>
        /// Messaging notifications
        /// </summary>
        RIL_NCLASS_MESSAGE                          = (0x00020000), 
        /// <summary>
        /// Network-related notifications
        /// </summary>
        RIL_NCLASS_NETWORK                          = (0x00040000), 
        /// <summary>
        /// Supplementary service notifications
        /// </summary>
        RIL_NCLASS_SUPSERVICE                       = (0x00080000), 
        /// <summary>
        /// Phonebook notifications
        /// </summary>
        RIL_NCLASS_PHONEBOOK                        = (0x00100000), 
        /// <summary>
        /// SIM Toolkit notifications
        /// </summary>
        RIL_NCLASS_SIMTOOLKIT                       = (0x00200000), 
        /// <summary>
        /// Miscellaneous notifications
        /// </summary>
        RIL_NCLASS_MISC                             = (0x00400000), 
        /// <summary>
        /// Notifications Pertaining to changes in Radio State
        /// </summary>
        RIL_NCLASS_RADIOSTATE                       = (0x00800000), 
        /// <summary>
        /// polling related APIs
        /// </summary>
        RIL_NCLASS_POLLING                          = (0x01000000), 
        /// <summary>
        /// Nofitifcations that won't be picked up by all.
        /// </summary>
        RIL_NCLASS_NDIS                             = (0x40000000), 
        /// <summary>
        /// Reserved for device specific notifications
        /// </summary>
        RIL_NCLASS_DEVSPECIFIC                      = (0x80000000), 
        /// <summary>
        /// All notification classes (except DevSpecifc)
        /// </summary>
        RIL_NCLASS_ALL                              = (0x01ff0000), 
    }
    /// <summary>
    /// constants API Result | API call results (RIL_NCLASS_FUNCRESULT)
    /// </summary>
    public enum RIL_FUNCRESULT : uint
    {
        /// <summary>
        /// RIL API call succeded; lpData is NULL
        /// </summary>
        RIL_RESULT_OK = (0x00000001 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),  
        /// <summary>
        /// RIL API failed because no carrier was detected; lpData is NULL
        /// </summary>
        RIL_RESULT_NOCARRIER = (0x00000002 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),  
        /// <summary>
        /// RIL API failed; lpData points to RIL_E_* constant
        /// </summary>
        RIL_RESULT_ERROR = (0x00000003 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),  
        /// <summary>
        /// RIL API failed because no dialtone was detected; lpData is NULL
        /// </summary>
        RIL_RESULT_NODIALTONE = (0x00000004 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),  
        /// <summary>
        /// RIL API failed because the line was busy; lpData is NULL
        /// </summary>
        RIL_RESULT_BUSY = (0x00000005 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),              
        /// <summary>
        /// RIL API failed because of the lack of answer; lpData is NULL
        /// </summary>
        RIL_RESULT_NOANSWER = (0x00000006 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),         
        /// <summary>
        /// RIL API failed because it was cancelled prior to completion; lpData is NULL
        /// </summary>
        RIL_RESULT_CALLABORTED = (0x00000007 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),  
        /// <summary>
        /// RIL API failed because the network dropped the call; lpData is NULL
        /// </summary>
        RIL_RESULT_CALLDROPPED = (0x00000008 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT),  
        /// <summary>
        /// RIL API failed because the radio was shut offl; lpData is NULL
        /// </summary>
        RIL_RESULT_RADIOOFF = (0x00000009 | NOTIFICATIONCLASSES.RIL_NCLASS_FUNCRESULT)  
    }
}