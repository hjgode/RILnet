//-----------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    using System;
    using System.Text;

    /// <summary>
    /// Utils.
    /// </summary>
    internal static class Utils
    {
        internal static string AsciiEncoding(byte[] data)
        {
            if (data == null || data.Length == 0)
                return String.Empty;

            return Encoding.ASCII.GetString(data, 0, data.Length).Replace("\0", "");
        }
    }
}
