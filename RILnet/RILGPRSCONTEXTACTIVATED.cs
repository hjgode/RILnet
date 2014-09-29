using System;

using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace RilNET
{
    public class RilGPRSContextActivated
    {
        [StructLayout(LayoutKind.Explicit)]
        struct RilGPRSContextActivatedStruct
        {
            [FieldOffset(0)]
            UInt32 cbSize;
            [FieldOffset(4)]
            public UInt32 dwContextID;
            [FieldOffset(8)]
            public bool fActivated;
        }
        public UInt32 contextID;
        public bool activated;
        public RilGPRSContextActivated(IntPtr pRilGPRSContextActivatedStruct)
        {
            RilGPRSContextActivatedStruct info = new RilGPRSContextActivatedStruct();
            Marshal.PtrToStructure(pRilGPRSContextActivatedStruct, info);
            contextID = info.dwContextID;
            activated = info.fActivated;
        }
    }
}
