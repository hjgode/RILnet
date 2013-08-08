using System;

using System.Collections.Generic;
using System.Text;

namespace RilNET
{
    [Serializable]
    public class OperatorInfo
    {
        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_OI">RIL_PARAM_OI</see> parameter constants.
        /// </summary>
        public RIL_PARAM_OI dwParams;

        /// <summary>
        /// Specifies the index, if applicable.
        /// </summary>
        public RIL_PREFOPINDEX dwIndex;

        /// <summary>
        /// Specifies the registration status, if applicable.
        /// </summary>
        public uint dwStatus;

        /// <summary>
        /// Representations of an operator.
        /// </summary>
        public RILOPERATORNAMES ronNames;
        
        /// <summary>
        /// Structure size, in bytes.
        /// </summary>
        private uint cbSize;


        public OperatorInfo(RILOPERATORINFO oi)
        {
            this.dwIndex = oi.dwIndex;
            this.dwParams = oi.dwParams;
            this.dwStatus = oi.dwStatus;
            this.ronNames = oi.ronNames;
        }
        public override string ToString()
        {
            return this.ronNames.GetLongName();
        }
    }
}
