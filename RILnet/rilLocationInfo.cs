using System;

using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RilNET
{
    public class RilLocationInfo
    {
        [StructLayout(LayoutKind.Explicit)]
        struct RilLocationInfoStruct
        {
            [FieldOffset(0)]UInt32 cbSize;
            [FieldOffset(4)]public UInt32 dwLocationAreaCode;
            [FieldOffset(8)]public UInt32 dwCellID;
        }
        public UInt32 LocationAreaCode = 0;
        public UInt32 CellID = 0;
        public RilLocationInfo(IntPtr pRilLocationInfo)
        {
            RilLocationInfoStruct info=(RilLocationInfoStruct)Marshal.PtrToStructure(pRilLocationInfo, typeof(RilLocationInfoStruct));
            LocationAreaCode = info.dwLocationAreaCode;
            CellID = info.dwCellID;
        }
    }
}
