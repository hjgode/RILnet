//-----------------------------------------------------------------------------------------
// <copyright file="Maxlenghts.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    /// <summary>
    /// Radio Interface Layer functions.
    /// </summary>
    public static partial class Ril
    {
        /// <summary>
        /// MAXLENGTH_EQUIPINFO
        /// </summary>
        internal const int MAXLENGTH_EQUIPINFO = 128;

        /// <summary>
        /// MAXLENGTH_BCCH
        /// </summary>
        internal const int MAXLENGTH_BCCH = 48;

        /// <summary>
        /// MAXLENGTH_NMR
        /// </summary>
        internal const int MAXLENGTH_NMR = 16;

        /// <summary>
        /// MAXLENGTH_OPERATOR_LONG
        /// </summary>
        internal const int MAXLENGTH_OPERATOR_LONG = 32;

        /// <summary>
        /// MAXLENGTH_OPERATOR_SHORT
        /// </summary>
        internal const int MAXLENGTH_OPERATOR_SHORT = 16;

        /// <summary>
        /// MAXLENGTH_OPERATOR_NUMERIC
        /// </summary>
        internal const int MAXLENGTH_OPERATOR_NUMERIC = 16;

        /// <summary>
        /// MAXLENGTH_OPERATOR_COUNTRY_CODE
        /// </summary>
        internal const int MAXLENGTH_OPERATOR_COUNTRY_CODE = 8;

        /// <summary>
        /// MAXLENGTH_ADDRESS
        /// </summary>
        internal const int MAXLENGTH_ADDRESS = 256;

        /// <summary>
        /// MAXLENGTH_DESCRIPTION
        /// </summary>
        internal const int MAXLENGTH_DESCRIPTION = 256;
    }
}
