using Microsoft.Maui.Controls.Handlers;
using System;
using System.Runtime.InteropServices;

namespace NASMB.GO
{
    // All the code in this file is only included on Android.
    public class Egg1
    {

        static Egg1() {
            handler = DRecvHandler;
            SetCall(  handler);
        }


        #region netapi
        private static HandEvent handler;
        public delegate void DataRecvDelegate(int message);
        public static event DataRecvDelegate DataHandler;
        unsafe private static void DRecvHandler(int message)
        {
            if (DataHandler != null)
            {
                DataHandler.BeginInvoke(message,null,null);
            }
        }
        #endregion
        #region api
        // NASMB.GO.PlatformsClass plf = new PlatformsClass();
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void HandEvent(int message);

        [DllImport(PlatformsClass.Libname, EntryPoint = "GetEnEgg1Code", CallingConvention = CallingConvention.Cdecl)]
        public extern static UInt64 EnEgg1CodeDll(byte[] bufer, int maxcount);


        [DllImport(PlatformsClass.Libname, EntryPoint = "SetCall", CallingConvention = CallingConvention.Cdecl)]
        internal extern static void SetCall(HandEvent handEvent );

        [DllImport(PlatformsClass.Libname, EntryPoint = "TestCall", CallingConvention = CallingConvention.Cdecl)]
        public extern static void TestCall(int message);
        #endregion
    }
}