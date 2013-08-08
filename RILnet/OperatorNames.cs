using System;

using System.Collections.Generic;
using System.Text;

namespace RilNET
{
    [Serializable]
    public class OperatorNames
    {
        /// <summary>
        /// Specifies valid parameters. Must be one or a combination of the <see cref="T:RilNET.RIL_PARAM_ON">RIL_PARAM_ON</see> parameter constants.
        /// </summary>
        public RIL_PARAM_ON dwParams;

        /// <summary>
        /// Long representation.
        /// </summary>
        public string szLongName;

        /// <summary>
        /// Short representation.
        /// </summary>
        public string szShortName;

        /// <summary>
        /// Numeric representation. Contains the 3-digit country/region code and the 2-digit network code.
        /// </summary>
        public string szNumName;

        /// <summary>
        /// Country/region code. Must be the 2-character International Organization for Standardization (ISO) 3166 country/region representation of the Mobile Country Code (MCC).
        /// </summary>
        public string szCountryCode;


        public OperatorNames(RILOPERATORNAMES on)
        {
            this.dwParams = on.dwParams;
            this.szCountryCode = on.GetCountryCode();
            this.szLongName = on.GetLongName();
            this.szNumName = on.GetNumName();
            this.szShortName = on.GetShortName();
        }
        public override string ToString()
        {
            return this.szLongName;
        }
    }
}
