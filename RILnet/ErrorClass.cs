using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Reflection;

namespace RilNET
{
    public class RilErrorClass
    {
        static uint RILERRORCLASS(uint rilerror)
        {
            uint uRet = 0;
            uRet = ((rilerror >> 8) & 0xff);
            //((unsigned long) (((rilerror) >> 8) & 0xff))
            return uRet;
        }
        static int MAKE_RILERROR(int errclass, int code)
        {
            int uRet = 0;
            //#define MAKE_RILERROR(errclass,code) ((unsigned long) (errclass) << 8) | ((unsigned long)(code))
            uRet = ((errclass << 8) | code);
            return uRet;
        }

        static int MAKE_HRESULT(int sev, int fac, int code)
        {
            return (int)(((uint)sev) << 31 | ((uint)fac) << 16 | ((uint)code));
        }

        public enum RIL_ERROR_CLASS : int
        {
            RIL_ERRORCLASS_NONE = 0x00, //  Misc error
            RIL_ERRORCLASS_PASSWORD = 0x01, //  Unspecified phone failure
            RIL_ERRORCLASS_SIM = 0x02, //  Problem with the SIM
            RIL_ERRORCLASS_NETWORKACCESS = 0x03, //  Can't access the network
            RIL_ERRORCLASS_NETWORK = 0x04, //  Error in the network
            RIL_ERRORCLASS_MOBILE = 0x05, //  Error in the mobile
            RIL_ERRORCLASS_NETWORKUNSUPPORTED = 0x06, //  Unsupported by the network
            RIL_ERRORCLASS_MOBILEUNSUPPORTED = 0x07, //  Unsupported by the mobile
            RIL_ERRORCLASS_BADPARAM = 0x08, //  An invalid parameter was supplied
            RIL_ERRORCLASS_STORAGE = 0x09, //  Error relating to storage
            RIL_ERRORCLASS_SMSC = 0x0A, //  Error relates to the SMSC
            RIL_ERRORCLASS_DESTINATION = 0x0B, //  Error in the destination mobile
            RIL_ERRORCLASS_DESTINATIONUNSUPPORTED = 0x0C, //  Unsupported by destination mobile
            RIL_ERRORCLASS_RADIOUNAVAILABLE = 0x0D, //  The Radio Module is Off or a radio module may not be present
            RIL_ERRORCLASS_GPRS = 0x0E, // @constdefine GPRS related failures
        }

        const int FACILITY_RIL = 0x100;
        const int SEVERITY_ERROR = 1;

        public static string getRIL_Error(int iError)
        {
            string sErrorCode = "";
            if (iError == RIL_ERROR_CODES.RIL_E_CANCELLED) sErrorCode = "RIL_E_CANCELLED";
            else if (iError == RIL_ERROR_CODES.RIL_E_CANTREPLACEMSG) sErrorCode = "RIL_E_CANTREPLACEMSG";
            else if (iError == RIL_ERROR_CODES.RIL_E_LINKRESERVED) sErrorCode = "RIL_E_LINKRESERVED";
            else if (iError == RIL_ERROR_CODES.RIL_E_OPNOTALLOWED) sErrorCode = "RIL_E_OPNOTALLOWED";
            else if (iError == RIL_ERROR_CODES.RIL_E_OPNOTSUPPORTED) sErrorCode = "RIL_E_OPNOTSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_PHSIMPINREQUIRED) sErrorCode = "RIL_E_PHSIMPINREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_PHFSIMPINREQUIRED) sErrorCode = "RIL_E_PHFSIMPINREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_PHFSIMPUKREQUIRED) sErrorCode = "RIL_E_PHFSIMPUKREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMNOTINSERTED) sErrorCode = "RIL_E_SIMNOTINSERTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMPINREQUIRED) sErrorCode = "RIL_E_SIMPINREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMPUKREQUIRED) sErrorCode = "RIL_E_SIMPUKREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMFAILURE) sErrorCode = "RIL_E_SIMFAILURE";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMBUSY) sErrorCode = "RIL_E_SIMBUSY";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMWRONG) sErrorCode = "RIL_E_SIMWRONG";
            else if (iError == RIL_ERROR_CODES.RIL_E_INCORRECTPASSWORD) sErrorCode = "RIL_E_INCORRECTPASSWORD";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMPIN2REQUIRED) sErrorCode = "RIL_E_SIMPIN2REQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMPUK2REQUIRED) sErrorCode = "RIL_E_SIMPUK2REQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_MEMORYFULL) sErrorCode = "RIL_E_MEMORYFULL";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDINDEX) sErrorCode = "RIL_E_INVALIDINDEX";
            else if (iError == RIL_ERROR_CODES.RIL_E_NOTFOUND) sErrorCode = "RIL_E_NOTFOUND";
            else if (iError == RIL_ERROR_CODES.RIL_E_MEMORYFAILURE) sErrorCode = "RIL_E_MEMORYFAILURE";
            else if (iError == RIL_ERROR_CODES.RIL_E_TEXTSTRINGTOOLONG) sErrorCode = "RIL_E_TEXTSTRINGTOOLONG";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDTEXTSTRING) sErrorCode = "RIL_E_INVALIDTEXTSTRING";
            else if (iError == RIL_ERROR_CODES.RIL_E_DIALSTRINGTOOLONG) sErrorCode = "RIL_E_DIALSTRINGTOOLONG";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDDIALSTRING) sErrorCode = "RIL_E_INVALIDDIALSTRING";
            else if (iError == RIL_ERROR_CODES.RIL_E_NONETWORKSVC) sErrorCode = "RIL_E_NONETWORKSVC";
            else if (iError == RIL_ERROR_CODES.RIL_E_NETWORKTIMEOUT) sErrorCode = "RIL_E_NETWORKTIMEOUT";
            else if (iError == RIL_ERROR_CODES.RIL_E_EMERGENCYONLY) sErrorCode = "RIL_E_EMERGENCYONLY";
            else if (iError == RIL_ERROR_CODES.RIL_E_NETWKPINREQUIRED) sErrorCode = "RIL_E_NETWKPINREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_NETWKPUKREQUIRED) sErrorCode = "RIL_E_NETWKPUKREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SUBSETPINREQUIRED) sErrorCode = "RIL_E_SUBSETPINREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SUBSETPUKREQUIRED) sErrorCode = "RIL_E_SUBSETPUKREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SVCPINREQUIRED) sErrorCode = "RIL_E_SVCPINREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SVCPUKREQUIRED) sErrorCode = "RIL_E_SVCPUKREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_CORPPINREQUIRED) sErrorCode = "RIL_E_CORPPINREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_CORPPUKREQUIRED) sErrorCode = "RIL_E_CORPPUKREQUIRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_TELEMATICIWUNSUPPORTED) sErrorCode = "RIL_E_TELEMATICIWUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SMTYPE0UNSUPPORTED) sErrorCode = "RIL_E_SMTYPE0UNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_CANTREPLACEMSG) sErrorCode = "RIL_E_CANTREPLACEMSG";
            else if (iError == RIL_ERROR_CODES.RIL_E_PROTOCOLIDERROR) sErrorCode = "RIL_E_PROTOCOLIDERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_DCSUNSUPPORTED) sErrorCode = "RIL_E_DCSUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_MSGCLASSUNSUPPORTED) sErrorCode = "RIL_E_MSGCLASSUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_DCSERROR) sErrorCode = "RIL_E_DCSERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_CMDCANTBEACTIONED) sErrorCode = "RIL_E_CMDCANTBEACTIONED";
            else if (iError == RIL_ERROR_CODES.RIL_E_CMDUNSUPPORTED) sErrorCode = "RIL_E_CMDUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_CMDERROR) sErrorCode = "RIL_E_CMDERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_MSGBODYHEADERERROR) sErrorCode = "RIL_E_MSGBODYHEADERERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_SCBUSY) sErrorCode = "RIL_E_SCBUSY";
            else if (iError == RIL_ERROR_CODES.RIL_E_NOSCSUBSCRIPTION) sErrorCode = "RIL_E_NOSCSUBSCRIPTION";
            else if (iError == RIL_ERROR_CODES.RIL_E_SCSYSTEMFAILURE) sErrorCode = "RIL_E_SCSYSTEMFAILURE";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDADDRESS) sErrorCode = "RIL_E_INVALIDADDRESS";
            else if (iError == RIL_ERROR_CODES.RIL_E_DESTINATIONBARRED) sErrorCode = "RIL_E_DESTINATIONBARRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_REJECTEDDUPLICATE) sErrorCode = "RIL_E_REJECTEDDUPLICATE";
            else if (iError == RIL_ERROR_CODES.RIL_E_VPFUNSUPPORTED) sErrorCode = "RIL_E_VPFUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_VPUNSUPPORTED) sErrorCode = "RIL_E_VPUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMMSGSTORAGEFULL) sErrorCode = "RIL_E_SIMMSGSTORAGEFULL";
            else if (iError == RIL_ERROR_CODES.RIL_E_NOSIMMSGSTORAGE) sErrorCode = "RIL_E_NOSIMMSGSTORAGE";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMTOOLKITBUSY) sErrorCode = "RIL_E_SIMTOOLKITBUSY";
            else if (iError == RIL_ERROR_CODES.RIL_E_SIMDOWNLOADERROR) sErrorCode = "RIL_E_SIMDOWNLOADERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_MSGSVCRESERVED) sErrorCode = "RIL_E_MSGSVCRESERVED";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDMSGPARAM) sErrorCode = "RIL_E_INVALIDMSGPARAM";
            else if (iError == RIL_ERROR_CODES.RIL_E_UNKNOWNSCADDRESS) sErrorCode = "RIL_E_UNKNOWNSCADDRESS";
            else if (iError == RIL_ERROR_CODES.RIL_E_UNASSIGNEDNUMBER) sErrorCode = "RIL_E_UNASSIGNEDNUMBER";
            else if (iError == RIL_ERROR_CODES.RIL_E_MSGBARREDBYOPERATOR) sErrorCode = "RIL_E_MSGBARREDBYOPERATOR";
            else if (iError == RIL_ERROR_CODES.RIL_E_MSGCALLBARRED) sErrorCode = "RIL_E_MSGCALLBARRED";
            else if (iError == RIL_ERROR_CODES.RIL_E_MSGXFERREJECTED) sErrorCode = "RIL_E_MSGXFERREJECTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_DESTINATIONOUTOFSVC) sErrorCode = "RIL_E_DESTINATIONOUTOFSVC";
            else if (iError == RIL_ERROR_CODES.RIL_E_UNIDENTIFIEDSUBCRIBER) sErrorCode = "RIL_E_UNIDENTIFIEDSUBCRIBER";
            else if (iError == RIL_ERROR_CODES.RIL_E_SVCUNSUPPORTED) sErrorCode = "RIL_E_SVCUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_UNKNOWNSUBSCRIBER) sErrorCode = "RIL_E_UNKNOWNSUBSCRIBER";
            else if (iError == RIL_ERROR_CODES.RIL_E_NETWKOUTOFORDER) sErrorCode = "RIL_E_NETWKOUTOFORDER";
            else if (iError == RIL_ERROR_CODES.RIL_E_NETWKTEMPFAILURE) sErrorCode = "RIL_E_NETWKTEMPFAILURE";
            else if (iError == RIL_ERROR_CODES.RIL_E_CONGESTION) sErrorCode = "RIL_E_CONGESTION";
            else if (iError == RIL_ERROR_CODES.RIL_E_RESOURCESUNAVAILABLE) sErrorCode = "RIL_E_RESOURCESUNAVAILABLE";
            else if (iError == RIL_ERROR_CODES.RIL_E_SVCNOTSUBSCRIBED) sErrorCode = "RIL_E_SVCNOTSUBSCRIBED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SVCNOTIMPLEMENTED) sErrorCode = "RIL_E_SVCNOTIMPLEMENTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDMSGREFERENCE) sErrorCode = "RIL_E_INVALIDMSGREFERENCE";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDMSG) sErrorCode = "RIL_E_INVALIDMSG";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDMANDATORYINFO) sErrorCode = "RIL_E_INVALIDMANDATORYINFO";
            else if (iError == RIL_ERROR_CODES.RIL_E_MSGTYPEUNSUPPORTED) sErrorCode = "RIL_E_MSGTYPEUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_ICOMPATIBLEMSG) sErrorCode = "RIL_E_ICOMPATIBLEMSG";
            else if (iError == RIL_ERROR_CODES.RIL_E_INFOELEMENTUNSUPPORTED) sErrorCode = "RIL_E_INFOELEMENTUNSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_PROTOCOLERROR) sErrorCode = "RIL_E_PROTOCOLERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_NETWORKERROR) sErrorCode = "RIL_E_NETWORKERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_MESSAGINGERROR) sErrorCode = "RIL_E_MESSAGINGERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_NOTREADY) sErrorCode = "RIL_E_NOTREADY";
            else if (iError == RIL_ERROR_CODES.RIL_E_TIMEDOUT) sErrorCode = "RIL_E_TIMEDOUT";
            else if (iError == RIL_ERROR_CODES.RIL_E_CANCELLED) sErrorCode = "RIL_E_CANCELLED";
            else if (iError == RIL_ERROR_CODES.RIL_E_NONOTIFYCALLBACK) sErrorCode = "RIL_E_NONOTIFYCALLBACK";
            else if (iError == RIL_ERROR_CODES.RIL_E_OPFMTUNAVAILABLE) sErrorCode = "RIL_E_OPFMTUNAVAILABLE";
            else if (iError == RIL_ERROR_CODES.RIL_E_NORESPONSETODIAL) sErrorCode = "RIL_E_NORESPONSETODIAL";
            else if (iError == RIL_ERROR_CODES.RIL_E_SECURITYFAILURE) sErrorCode = "RIL_E_SECURITYFAILURE";
            else if (iError == RIL_ERROR_CODES.RIL_E_RADIOFAILEDINIT) sErrorCode = "RIL_E_RADIOFAILEDINIT";
            else if (iError == RIL_ERROR_CODES.RIL_E_DRIVERINITFAILED) sErrorCode = "RIL_E_DRIVERINITFAILED";
            else if (iError == RIL_ERROR_CODES.RIL_E_RADIONOTPRESENT) sErrorCode = "RIL_E_RADIONOTPRESENT";
            else if (iError == RIL_ERROR_CODES.RIL_E_RADIOOFF) sErrorCode = "RIL_E_RADIOOFF";
            else if (iError == RIL_ERROR_CODES.RIL_E_ILLEGALMS) sErrorCode = " RIL_E_ILLEGALMS";
            else if (iError == RIL_ERROR_CODES.RIL_E_ILLEGALME) sErrorCode = " RIL_E_ILLEGALME";
            else if (iError == RIL_ERROR_CODES.RIL_E_GPRSSERVICENOTALLOWED) sErrorCode = " RIL_E_GPRSSERVICENOTALLOWED";
            else if (iError == RIL_ERROR_CODES.RIL_E_PLMNNOTALLOWED) sErrorCode = " RIL_E_PLMNNOTALLOWED";
            else if (iError == RIL_ERROR_CODES.RIL_E_LOCATIONAREANOTALLOWED) sErrorCode = " RIL_E_LOCATIONAREANOTALLOWED";
            else if (iError == RIL_ERROR_CODES.RIL_E_ROAMINGNOTALLOWEDINTHISLOCATIONAREA) sErrorCode = " RIL_E_ROAMINGNOTALLOWEDINTHISLOCATIONAREA";
            else if (iError == RIL_ERROR_CODES.RIL_E_SERVICEOPTIONNOTSUPPORTED) sErrorCode = " RIL_E_SERVICEOPTIONNOTSUPPORTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_REQUESTEDSERVICEOPTIONNOTSUBSCRIBED) sErrorCode = " RIL_E_REQUESTEDSERVICEOPTIONNOTSUBSCRIBED";
            else if (iError == RIL_ERROR_CODES.RIL_E_SERVICEOPTIONTEMPORARILYOUTOFORDER) sErrorCode = " RIL_E_SERVICEOPTIONTEMPORARILYOUTOFORDER";
            else if (iError == RIL_ERROR_CODES.RIL_E_PDPAUTHENTICATIONFAILURE) sErrorCode = " RIL_E_PDPAUTHENTICATIONFAILURE";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDMOBILECLASS) sErrorCode = " RIL_E_INVALIDMOBILECLASS";
            else if (iError == RIL_ERROR_CODES.RIL_E_UNSPECIFIEDGPRSERROR) sErrorCode = " RIL_E_UNSPECIFIEDGPRSERROR";
            else if (iError == RIL_ERROR_CODES.RIL_E_RADIOREBOOTED) sErrorCode = " RIL_E_RADIOREBOOTED";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDCONTEXTSTATE) sErrorCode = " RIL_E_INVALIDCONTEXTSTATE";
            else if (iError == RIL_ERROR_CODES.RIL_E_MAXCONTEXTS) sErrorCode = " RIL_E_MAXCONTEXTS";
            else if (iError == RIL_ERROR_CODES.RIL_E_SYNCHRONOUS_DATA_UNAVAILABLE) sErrorCode = " RIL_E_SYNCHRONOUS_DATA_UNAVAILABLE";
            else if (iError == RIL_ERROR_CODES.RIL_E_INVALIDASYNCCOMMANDRESPONSE) sErrorCode = " RIL_E_INVALIDASYNCCOMMANDRESPONSE";
            else sErrorCode = "unknown";

            return sErrorCode;
        }

        public static class RIL_ERROR_CODES
        {
            public static readonly int RIL_E_PHONEFAILURE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_MOBILE, 0x01)));  // @constdefine Unspecified phone failure
            public static readonly int RIL_E_NOCONNECTION = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_MOBILE, 0x02)));  // @constdefine RIL has no connection to the phone
            public static readonly int RIL_E_LINKRESERVED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_MOBILE, 0x03))); // @constdefine RIL's link to the phone is reserved
            public static readonly int RIL_E_OPNOTALLOWED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_MOBILEUNSUPPORTED, 0x04))); // @constdefine Attempted operation isn't allowed
            public static readonly int RIL_E_OPNOTSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_MOBILEUNSUPPORTED, 0x05))); // @constdefine Attempted operation isn't supported
            public static readonly int RIL_E_PHSIMPINREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x06))); // @constdefine PH-SIM PIN is required to perform this operation
            public static readonly int RIL_E_PHFSIMPINREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x07))); // @constdefine PH-FSIM PIN is required to perform this operation
            public static readonly int RIL_E_PHFSIMPUKREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x08))); // @constdefine PH-FSIM PUK is required to perform this operation
            public static readonly int RIL_E_SIMNOTINSERTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SIM, 0x09))); // @constdefine SIM isn't inserted into the phone
            public static readonly int RIL_E_SIMPINREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x0a))); // @constdefine SIM PIN is required to perform this operation
            public static readonly int RIL_E_SIMPUKREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x0b))); // @constdefine SIM PUK is required to perform this operation
            public static readonly int RIL_E_SIMFAILURE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SIM, 0x0c))); // @constdefine SIM failure was detected
            public static readonly int RIL_E_SIMBUSY = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SIM, 0x0d))); // @constdefine SIM is busy
            public static readonly int RIL_E_SIMWRONG = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SIM, 0x0e))); // @constdefine Inorrect SIM was inserted
            public static readonly int RIL_E_INCORRECTPASSWORD = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x0f))); // @constdefine Incorrect password was supplied
            public static readonly int RIL_E_SIMPIN2REQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x10))); // @constdefine SIM PIN2 is required to perform this operation
            public static readonly int RIL_E_SIMPUK2REQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x11))); // @constdefine SIM PUK2 is required to perform this operation
            public static readonly int RIL_E_MEMORYFULL = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_STORAGE, 0x12))); // @constdefine Storage memory is full
            public static readonly int RIL_E_INVALIDINDEX = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_STORAGE, 0x13))); // @constdefine Invalid storage index was supplied
            public static readonly int RIL_E_NOTFOUND = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_STORAGE, 0x14))); // @constdefine A requested storage entry was not found
            public static readonly int RIL_E_MEMORYFAILURE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_STORAGE, 0x15))); // @constdefine Storage memory failure
            public static readonly int RIL_E_TEXTSTRINGTOOLONG = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x16))); // @constdefine Supplied text string is too long
            public static readonly int RIL_E_INVALIDTEXTSTRING = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x17))); // @constdefine Supplied text string contains invalid characters
            public static readonly int RIL_E_DIALSTRINGTOOLONG = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x18))); // @constdefine Supplied dial string is too long
            public static readonly int RIL_E_INVALIDDIALSTRING = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x19))); // @constdefine Supplied dial string contains invalid characters
            public static readonly int RIL_E_NONETWORKSVC = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKACCESS, 0x1a))); // @constdefine Network service isn't available
            public static readonly int RIL_E_NETWORKTIMEOUT = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORK, 0x1b))); // @constdefine Network operation timed out
            public static readonly int RIL_E_EMERGENCYONLY = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKACCESS, 0x1c))); // @constdefine Network can only be used for emergency calls
            public static readonly int RIL_E_NETWKPINREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x1d))); // @constdefine Network Personalization PIN is required to perform this operation
            public static readonly int RIL_E_NETWKPUKREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x1e))); // @constdefine Network Personalization PUK is required to perform this operation
            public static readonly int RIL_E_SUBSETPINREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x1f))); // @constdefine Network Subset Personalization PIN is required to perform this operation
            public static readonly int RIL_E_SUBSETPUKREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x20))); // @constdefine Network Subset Personalization PUK is required to perform this operation
            public static readonly int RIL_E_SVCPINREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x21))); // @constdefine Service Provider Personalization PIN is required to perform this operation
            public static readonly int RIL_E_SVCPUKREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x22))); // @constdefine Service Provider Personalization PUK is required to perform this operation
            public static readonly int RIL_E_CORPPINREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x23))); // @constdefine Corporate Personalization PIN is required to perform this operation
            public static readonly int RIL_E_CORPPUKREQUIRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_PASSWORD, 0x24))); // @constdefine Corporate Personalization PUK is required to perform this operation
            public static readonly int RIL_E_TELEMATICIWUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x25))); // @constdefine Telematic interworking isn't supported
            public static readonly int RIL_E_SMTYPE0UNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x26))); // @constdefine Type 0 messages aren't supported
            public static readonly int RIL_E_CANTREPLACEMSG = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x27))); // @constdefine Existing message cannot be replaced
            public static readonly int RIL_E_PROTOCOLIDERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x28))); // @constdefine Uspecified error related to the message Protocol ID
            public static readonly int RIL_E_DCSUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x29))); // @constdefine Specified message Data Coding Scheme isn't supported
            public static readonly int RIL_E_MSGCLASSUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x2a))); // @constdefine Specified message class isn't supported
            public static readonly int RIL_E_DCSERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x2b))); // @constdefine Unspecified error related to the message Data Coding Scheme
            public static readonly int RIL_E_CMDCANTBEACTIONED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x2c))); // @constdefine Specified message Command cannot be executed
            public static readonly int RIL_E_CMDUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x2d))); // @constdefine Specified message Command isn't supported
            public static readonly int RIL_E_CMDERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x2e))); // @constdefine Unspecified error related to the message Command
            public static readonly int RIL_E_MSGBODYHEADERERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x2f))); // @constdefine Unspecified error related to the message Body or Header
            public static readonly int RIL_E_SCBUSY = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x30))); // @constdefine Message Service Center is busy
            public static readonly int RIL_E_NOSCSUBSCRIPTION = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x31))); // @constdefine No message Service Center subscription
            public static readonly int RIL_E_SCSYSTEMFAILURE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x32))); // @constdefine Message service Center system failure occurred
            public static readonly int RIL_E_INVALIDADDRESS = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x33))); // @constdefine Specified address is invalid
            public static readonly int RIL_E_DESTINATIONBARRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x34))); // @constdefine Message destination is barred
            public static readonly int RIL_E_REJECTEDDUPLICATE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x35))); // @constdefine Duplicate message was rejected
            public static readonly int RIL_E_VPFUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x36))); // @constdefine Specified message Validity Period Format isn't supported
            public static readonly int RIL_E_VPUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x37))); // @constdefine Specified message Validity Period isn't supported
            public static readonly int RIL_E_SIMMSGSTORAGEFULL = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_STORAGE, 0x38))); // @constdefine Message storage on the SIM is full
            public static readonly int RIL_E_NOSIMMSGSTORAGE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SIM, 0x39))); // @constdefine SIM isn't capable of storing messages
            public static readonly int RIL_E_SIMTOOLKITBUSY = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SIM, 0x3a))); // @constdefine SIM Application Toolkit is busy
            public static readonly int RIL_E_SIMDOWNLOADERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SIM, 0x3b))); // @constdefine SIM data download error
            public static readonly int RIL_E_MSGSVCRESERVED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x3c))); // @constdefine Messaging service is reserved
            public static readonly int RIL_E_INVALIDMSGPARAM = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x3d))); // @constdefine One of the message parameters is invalid
            public static readonly int RIL_E_UNKNOWNSCADDRESS = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_SMSC, 0x3e))); // @constdefine Unknown message Service Center address was specified
            public static readonly int RIL_E_UNASSIGNEDNUMBER = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_DESTINATION, 0x3f))); // @constdefine Specified message destination address is a currently unassigned phone number
            public static readonly int RIL_E_MSGBARREDBYOPERATOR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKACCESS, 0x40))); // @constdefine Message sending was barred by an operator
            public static readonly int RIL_E_MSGCALLBARRED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKACCESS, 0x41))); // @constdefine Message sending was prevented by outgoing calls barring
            public static readonly int RIL_E_MSGXFERREJECTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_DESTINATION, 0x42))); // @constdefine Sent message has been rejected by the receiving equipment
            public static readonly int RIL_E_DESTINATIONOUTOFSVC = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_DESTINATION, 0x43))); // @constdefine Message could not be delivered because destination equipment is out of service
            public static readonly int RIL_E_UNIDENTIFIEDSUBCRIBER = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKACCESS, 0x44))); // @constdefine Sender's mobile ID isn't registered
            public static readonly int RIL_E_SVCUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x45))); // @constdefine Requested messaging service isn't supported
            public static readonly int RIL_E_UNKNOWNSUBSCRIBER = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKACCESS, 0x46))); // @constdefine Sender isn't recognized by the network
            public static readonly int RIL_E_NETWKOUTOFORDER = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORK, 0x47))); // @constdefine Long-term network failure
            public static readonly int RIL_E_NETWKTEMPFAILURE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORK, 0x48))); // @constdefine Short-term network failure
            public static readonly int RIL_E_CONGESTION = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORK, 0x49))); // @constdefine Operation failed because of the high network traffic
            public static readonly int RIL_E_RESOURCESUNAVAILABLE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x4a))); // @constdefine Unspecified resources weren't available
            public static readonly int RIL_E_SVCNOTSUBSCRIBED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x4b))); // @constdefine Sender isn't subscribed for the requested messaging service
            public static readonly int RIL_E_SVCNOTIMPLEMENTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x4c))); // @constdefine Requested messaging service isn't implemented on the network
            public static readonly int RIL_E_INVALIDMSGREFERENCE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x4d))); // @constdefine Imvalid message reference value was used
            public static readonly int RIL_E_INVALIDMSG = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x4e))); // @constdefine Message was determined to be invalid for unspecified reasons
            public static readonly int RIL_E_INVALIDMANDATORYINFO = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_BADPARAM, 0x4f))); // @constdefine Mandatory message information is invalid or missing
            public static readonly int RIL_E_MSGTYPEUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x50))); // @constdefine The message type is unsupported
            public static readonly int RIL_E_ICOMPATIBLEMSG = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x51))); // @constdefine Sent message isn't compatible with the network
            public static readonly int RIL_E_INFOELEMENTUNSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x52))); // @constdefine An information element specified in the message isn't supported
            public static readonly int RIL_E_PROTOCOLERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORK, 0x53))); // @constdefine Unspefied protocol error
            public static readonly int RIL_E_NETWORKERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORK, 0x54))); // @constdefine Unspecified network error
            public static readonly int RIL_E_MESSAGINGERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORK, 0x55))); // @constdefine Unspecified messaging error
            public static readonly int RIL_E_NOTREADY = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x56))); // @constdefine RIL isn't yet ready to perform the requested operation
            public static readonly int RIL_E_TIMEDOUT = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x57))); // @constdefine Operation timed out
            public static readonly int RIL_E_CANCELLED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x58))); // @constdefine Operation was cancelled
            public static readonly int RIL_E_NONOTIFYCALLBACK = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x59))); // @constdefine Requested operation requires an RIL notification callback, which wasn't provided
            public static readonly int RIL_E_OPFMTUNAVAILABLE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKUNSUPPORTED, 0x5a))); // @constdefine Operator format isn't available
            public static readonly int RIL_E_NORESPONSETODIAL = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NETWORKACCESS, 0x5b))); // @constdefine Dial operation hasn't received a response for a long time
            public static readonly int RIL_E_SECURITYFAILURE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x5c))); // @constdefine Security failure
            public static readonly int RIL_E_RADIOFAILEDINIT = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x5d))); // @constdefine Radio failed to initialize correctly
            public static readonly int RIL_E_DRIVERINITFAILED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_RADIOUNAVAILABLE, 0x5e))); // @constdefine There was a problem initializing the radio driver
            public static readonly int RIL_E_RADIONOTPRESENT = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_RADIOUNAVAILABLE, 0x5f))); // @constdefine The Radio is not present
            public static readonly int RIL_E_RADIOOFF = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_RADIOUNAVAILABLE, 0x60))); // @constdefine The Radio is in Off mode
            public static readonly int RIL_E_ILLEGALMS = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x61))); // @constdefine Illegal MS
            public static readonly int RIL_E_ILLEGALME = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x62))); // @constdefine Illegal ME
            public static readonly int RIL_E_GPRSSERVICENOTALLOWED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x63))); // @constdefine GPRS Service not allowed
            public static readonly int RIL_E_PLMNNOTALLOWED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x64))); // @constdefine PLMN not allowed
            public static readonly int RIL_E_LOCATIONAREANOTALLOWED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x65))); // @constdefine Location area not allowed
            public static readonly int RIL_E_ROAMINGNOTALLOWEDINTHISLOCATIONAREA = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x66))); // @constdefine Roaming not allowed in this location area
            public static readonly int RIL_E_SERVICEOPTIONNOTSUPPORTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x67))); // @constdefine Service option not supported
            public static readonly int RIL_E_REQUESTEDSERVICEOPTIONNOTSUBSCRIBED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x68))); // @constdefine Requested service option not subscribed
            public static readonly int RIL_E_SERVICEOPTIONTEMPORARILYOUTOFORDER = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x69))); // @constdefine Service option temporarily out of order
            public static readonly int RIL_E_PDPAUTHENTICATIONFAILURE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x6a))); // @constdefine PDP authentication failure
            public static readonly int RIL_E_INVALIDMOBILECLASS = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x6b))); // @constdefine invalid mobile class
            public static readonly int RIL_E_UNSPECIFIEDGPRSERROR = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_GPRS, 0x6c))); // @constdefine unspecific GPRS error
            public static readonly int RIL_E_RADIOREBOOTED = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x6d))); // @constdefine the command failed because the radio reset itself unexpectedly
            public static readonly int RIL_E_INVALIDCONTEXTSTATE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x6e))); // @constdefine the command failed because the requested context state is invalid
            public static readonly int RIL_E_MAXCONTEXTS = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x6f))); // @constdefine the command failed because there are no more radio contexts.
            public static readonly int RIL_E_SYNCHRONOUS_DATA_UNAVAILABLE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x70))); // @constdefine the cached notification data is not present
            public static readonly int RIL_E_INVALIDASYNCCOMMANDRESPONSE = (MAKE_HRESULT(SEVERITY_ERROR, FACILITY_RIL, MAKE_RILERROR((int)RIL_ERROR_CLASS.RIL_ERRORCLASS_NONE, 0x71))); // @constdefine The RIL driver has issued an invalid asynchronous command response (hr == 0)
        }

    }
}
