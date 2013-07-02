//-----------------------------------------------------------------------------------------
// <copyright file="Callbacks.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    using System;
   
    /// <summary>
    /// This callback function is called when the radio sends an unsolicited notification.
    /// </summary>
    /// <param name="dwCode">Specifies the notification code. </param>
    /// <param name="lpData">Data associated with the notification.</param>
    /// <param name="cbData">Size of the structure pointed to by lpData.</param>
    /// <param name="dwParam">Specifies the parameter passed to <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
    public delegate void RILNOTIFYCALLBACK(
        uint dwCode,
        IntPtr lpData,
        uint cbData,
        uint dwParam);

    /// <summary>
    /// This callback function is called to send a return value after an asynchronous RIL function call.
    /// </summary>
    /// <param name="dwCode">Specifies the result code.</param>
    /// <param name="hrCmdID">ID returned by the command that originated this response.</param>
    /// <param name="lpData">Data associated with the notification.</param>
    /// <param name="cbData">Size of the structure pointed to by lpData.</param>
    /// <param name="dwParam">Specifies the parameter passed to <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
    public delegate void RILRESULTCALLBACK(
        uint dwCode,
        int hrCmdID,
        IntPtr lpData,
        uint cbData,
        uint dwParam);
}
