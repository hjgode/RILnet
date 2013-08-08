//-----------------------------------------------------------------------------------------
// <copyright file="Functions.cs" company="Jakub Florczyk (www.jakubflorczyk.pl)">
//      Copyright © 2009 Jakub Florczyk (www.jakubflorczyk.pl)
//      http://rilnet.codeplex.com
// </copyright>
//-----------------------------------------------------------------------------------------

namespace RilNET
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Radio Interface Layer functions.
    /// </summary>
    public static partial class Ril
    {
        /// <summary>
        /// This function initializes RIL for use by a client.
        /// </summary>
        /// <param name="dwIndex">Specifies the index of the RIL port to use, for example, 1 for RIL1:.</param>
        /// <param name="pfnResult">Function result callback.</param>
        /// <param name="pfnNotify">Notification callback.</param>
        /// <param name="dwNotificationClasses">Specifies the classes of notifications to be enabled for a client.</param>
        /// <param name="dwParam">Specifies the custom parameter passed to result and notification callbacks.</param>
        /// <param name="lphRil">Returned Handle to the RIL instance.</param>
        /// <returns>The function returns the HRESULT value.</returns>
        /// <remarks>
        /// This function is synchronous. Synchronous RIL only supports single-threaded RIL handles. The RIL validates the application's RIL handle before using it. An application cannot use a RIL handle that it does not own.
        /// <br/><br/>
        /// Call RIL_Deinitialize to release the handle. If the RIL client generates an exception or exits without calling RIL_Deinitialize, the RIL library will release the handle when the DLL is unloaded.
        /// <br/><br/>
        /// When a client calls RIL_Initialize, it can also register for notifications. If it registers for notifications, the driver will send a RIL_NOTIFY_RADIOPRESENCECHANGED indicating if the radio is present or not present. The proxy returns S_FALSE as an indication that the driver has not detected the radio presence yet. The pending notification is used by the client to determine when the radio is present. For more information about RIL_NOTIFY_RADIOPRESENCECHANGED, see Notification Radio State Change Constants.
        /// <br/><br/>
        /// If the client does not register for notifications when RIL_Initialize is called, it has two options.
        /// <br/><br/>
        /// The client can periodically call RIL_DeInitialize and then call RIL_Initialize until the proxy returns S_OK.
        /// <br/><br/>
        /// <list type="number">
        /// <item>1. The client can periodically call RIL_DeInitialize and then call RIL_Initialize until the proxy returns S_OK.</item>
        /// <item>2. The client can periodically call the desired RIL_API until the API no longer returns RIL_E_RADIOPRESENT.</item>
        /// </list>
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_Initialize", SetLastError = true)]
        public static extern int Initialize(
            [In] uint dwIndex, 
            [In, MarshalAs(UnmanagedType.FunctionPtr)] RILRESULTCALLBACK pfnResult,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] RILNOTIFYCALLBACK pfnNotify,
            [In] RIL_NCLASS dwNotificationClasses, 
            [In] uint dwParam, 
            [Out] out IntPtr lphRil);

        /// <summary>
        /// This function deinitializes RIL.
        /// </summary>
        /// <param name="hRil">Handle to an RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>An HRESULT value of S_OK indicates success. HRESULT values of E_XXX indicate an error.</returns>
        /// <remarks>This function is synchronous. An asynchronous result callback is not returned.</remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_Deinitialize", SetLastError = true)]
        public static extern int Deinitialize(
            [In] IntPtr hRil);

        /// <summary>
        /// This function retrieves information about the cell tower currently used by the phone.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/><br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter points to a <see cref="T:RilNET.RILCELLTOWERINFO">RILCELLTOWERINFO</see> structure. </returns>
        /// <remarks>The RIL proxy translates the RIL_GetCellTowerInfo function into IOCTL_RIL_GetCellTowerInfo when the RIL proxy calls RIL_IOControl.</remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_GetCellTowerInfo", SetLastError = true)]
        public static extern int GetCellTowerInfo(
            [In] IntPtr hRil);

        /// <summary>
        /// This function retrieves the operator the device is currently registered with.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <param name="dwFormat">Specifies the format of the operator name to return.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/><br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter points to a see <see cref="T:RilNET.RILOPERATORNAMES">RILOPERATORNAMES</see> structure. 
        /// </returns>
        /// <remarks>
        /// The RIL proxy translates the RIL_GetCurrentOperator function into IOCTL_RIL_GetCurrentOperator when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_GetCurrentOperator", SetLastError = true)]
        public static extern int GetCurrentOperator(
            [In] IntPtr hRil,
            [In] RIL_OPFORMAT dwFormat);

        /// <summary>
        /// This function retrieves the built-in list of all known operators.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error.
        /// <br/><br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter points to an array of <see cref="T:RilNET.RILOPERATORNAMES">RILOPERATORNAMES</see> structures. 
        /// </returns>
        /// <remarks >
        /// This function does not retrieve the list of operators available. To retrieve the list of operators available, see <see cref="M:RilNET.Ril.GetOperatorList">GetOperatorList</see>.
        /// <br/><br/>
        /// To enable the Network Access Technology to work for the fixed list of operator names, which is an array of <see cref="T:RilNET.RILOPERATORNAMES">RILOPERATORNAMES</see> structures, add an AcT parameter as a DWORD.
        /// </remarks >
        [DllImport("ril.dll", EntryPoint = "RIL_GetAllOperatorsList", SetLastError = true)]
        public static extern int GetAllOperatorsList(
            [In] IntPtr hRil);

        /// <summary>
        /// This function retrieves the list of available operators.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error.
        /// <br/><br/>
        /// An asychronous result of RIL_RESULT_OK indicates success. The lpData notification parameterpoints to an array of <see cref="T:RilNET.RILOPERATORINFO">RILOPERATORINFO</see> structures. 
        /// </returns>
        /// <remarks >
        /// The RIL proxy translates the RIL_GetOperatorList function into IOCTL_RIL_GetOperatorList when the RIL proxy calls RIL_IOControl.
        /// </remarks >
        [DllImport("ril.dll", EntryPoint = "RIL_GetOperatorList", SetLastError = true)]
        public static extern int GetOperatorList(
            [In] IntPtr hRil);

        /// <summary>
        /// This function retrieves manufacturer equipment information.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/><br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter points to a <see cref="T:RilNET.RILEQUIPMENTINFO">RILEQUIPMENTINFO</see> structure.
        /// </returns>
        /// <remarks>
        /// The RIL proxy translates the RIL_GetEquipmentInfo function into IOCTL_RIL_GetEquipmentInfo when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_GetEquipmentInfo", SetLastError = true)]
        public static extern int GetEquipmentInfo(
            [In] IntPtr hRil);

        /// <summary>
        /// This function retrieves information about the received signal quality.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error.
        /// <br/><br/>
        /// An asychronous result of RIL_RESULT_OK indicates success. The lpData notification parameter points to a <see cref="T:RilNET.RILSIGNALQUALITY">RILSIGNALQUALITY</see> structure. 
        /// </returns>
        /// <remarks>
        /// The RIL proxy translates the RIL_GetSignalQuality function into IOCTL_RIL_GetSignalQuality when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_GetSignalQuality", SetLastError = true)]
        public static extern int GetSignalQuality(
            [In] IntPtr hRil);

        /// <summary>
        /// This function unregisters the device from the network.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/>
        /// <br/>
        /// An asychronous result of RIL_RESULT_OK indicates success. The lpData notification parameter is set to NULL. 
        /// </returns>
        /// <remarks>
        /// This function is only used on GSM devices to unregister from the network.
        /// <br/>
        /// <br/>
        /// The RIL proxy translates the RIL_UnregisterFromNetwork function into IOCTL_RIL_UnregisterFromNetwork when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_UnregisterFromNetwork", SetLastError = true)]
        public static extern int UnregisterFromNetwork(
            [In] IntPtr hRil);

        /// <summary>
        /// This function registers a device on a wireless network.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <param name="dwMode">Specifies the operator selection mode to set.</param>
        /// <param name="lpOperatorNames">Operator to be selected. This value can be NULL if dwMode is set to <see cref="T:RilNET.RIL_OPSELMODE.AUTOMATIC">RIL_OPSELMODE.AUTOMATIC</see></param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/>
        /// <br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter is set to NULL.
        /// </returns>
        /// <remarks>
        /// This function is to be implemented by a RIL driver. It is called to cause a device to register on a network.
        /// <br/>
        /// <br/>
        /// The RIL proxy translates the RIL_RegisterOnNetwork function into IOCTL_RIL_RegisterOnNetwork when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_RegisterOnNetwork", SetLastError = true)]
        public static extern int RegisterOnNetwork(
            [In] IntPtr hRil,
            [In] RIL_OPSELMODE dwMode,
            [In] ref RILOPERATORNAMES lpOperatorNames); //const* as other pointers have to be given by ref!

        /// <summary>
        /// This function removes a specified operator from the list of preferred operators.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <param name="dwIndex">Specifies the storage index of the preferred operator to remove.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/>
        /// <br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter is set to NULL.
        /// </returns>
        /// <remarks>
        /// This function is to be implemented by a RIL driver. It is called to cause a device to register on a network.
        /// <br/>
        /// <br/>
        /// The RIL proxy translates the RIL_RegisterOnNetwork function into IOCTL_RIL_RegisterOnNetwork when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_RemovePreferredOperator", SetLastError = true)]
        public static extern int RemovePreferredOperator(
            [In] IntPtr hRil,
            [In] uint dwIndex);

        /// <summary>
        /// This function adds a specified operator to the list of preferred operators.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <param name="dwIndex">Specifies the storage index to use for the added operator.</param>
        /// <param name="lpOperatorNames">Operator names.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/>
        /// <br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter is set to NULL.
        /// </returns>
        /// <remarks>
        /// The RIL proxy translates the RIL_AddPreferredOperator function into IOCTL_RIL_AddPreferredOperator when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_AddPreferredOperator", SetLastError = true)]
        public static extern int AddPreferredOperator(
            [In] IntPtr hRil,
            [In] uint dwIndex,
            [In] RILOPERATORNAMES lpOperatorNames);

        /// <summary>
        /// This function retrieves the list of preferred operators.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <param name="dwFormat">Specifies the format to use for the operator names in the list.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/>
        /// <br/>
        /// An asychronous result of RIL_RESULT_OK indicates success. The lpData notification parameterpoints to an array of <see cref="T:RilNET.RILOPERATORINFO">RILOPERATORINFO</see> structures.
        /// </returns>
        /// <remarks>
        /// The RIL proxy translates the RIL_GetPreferredOperatorList function into IOCTL_RIL_GetPreferredOperatorList when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_GetPreferredOperatorList", SetLastError = true)]
        public static extern int GetPreferredOperatorList(
            [In] IntPtr hRil,
            [In] RIL_OPFORMAT dwFormat);

        /// <summary>
        /// This function is implemented by a RIL driver. It is responsible for querying the mute status of the radio. 
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. 
        /// <br/><br/>
        /// An asynchronous result of RIL_RESULT_OK indicates success. The lpData notification parameter points to a BOOL value that is TRUE if and only if the radio is muted. 
        /// </returns>
        /// <remarks>
        /// This function is called sporadically during voice calls. It is also called occasionally to update the mute indicator.
        /// <br/><br/>
        /// The RIL proxy translates the RIL_GetAudioMuting function into IOCTL_RIL_GetAudioMuting when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_GetAudioMuting", SetLastError = true)]
        public static extern int GetAudioMuting(
            [In] IntPtr hRil);

        /// <summary>
        /// This function mutes or un-mutes the input audio device.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by <see cref="M:RilNET.Ril.Initialize">Initialize</see>.</param>
        /// <param name="fEnable">Value set to TRUE if the input audio device is to be muted. Otherwise, value is set to FALSE.</param>
        /// <returns>
        /// Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error.
        /// <br/><br/>
        /// An asychronous result of RIL_RESULT_OK indicates success. The lpData notification parameter is set to NULL. 
        /// </returns>
        /// <remarks>
        /// The RIL proxy translates the RIL_SetAudioMuting function into IOCTL_RIL_SetAudioMuting when the RIL proxy calls RIL_IOControl.
        /// </remarks>
        [DllImport("ril.dll", EntryPoint = "RIL_SetAudioMuting", SetLastError = true)]
        public static extern int SetAudioMuting(
            [In] IntPtr hRil,
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

        /// <summary>
        /// This function enables additional classes of notifications for a client.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by RIL_Initialize</param>
        /// <param name="notificationClasses">Specifies the classes of notifications to enable. Valid values are listed in the topic Notification Class Constants.</param>
        /// <returns>Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. Errors are defined in the Ril.h file.</returns>
        [DllImport("ril.dll", EntryPoint = "RIL_SetAudioMuting", SetLastError = true)]
        public static extern int RIL_EnableNotifications([In]IntPtr hRil, [In]RIL_NCLASS notificationClasses);

        /// <summary>
        /// This function disables classes of notifications for a client.
        /// </summary>
        /// <param name="hRil">Handle to the RIL instance returned by RIL_Initialize.</param>
        /// <param name="notificationClasses">Specifies the classes of notifications to disable. Valid values are listed in the topic Notification Class Constants.</param>
        /// <returns>Positive HRESULT values indicate success and are used as command identifications for matching the asynchronous call result. Negative HRESULT values indicate an error. Errors are defined in the Ril.h file.</returns>
        [DllImport("ril.dll", EntryPoint = "RIL_SetAudioMuting", SetLastError = true)]
        public static extern int RIL_DisableNotifications([In]IntPtr hRil, [In]RIL_NCLASS notificationClasses);
    }
}
