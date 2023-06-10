using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.GO
{
    public class ASMB
    {
        //NewLightNode


        [DllImport(PlatformsClass.Asmbname, EntryPoint = "NewLightNode", CallingConvention = CallingConvention.Cdecl)]
        public extern static void NewLightNode(string pwd,string path);


        [DllImport(PlatformsClass.Asmbname, EntryPoint = "GetlastErr", CallingConvention = CallingConvention.Cdecl)]
        public extern static void GetlastErr(byte[] bufer, int maxcount);

        //[DllImport(PlatformsClass.Asmbname, EntryPoint = "Findslice", CallingConvention = CallingConvention.Cdecl)]
        //public extern static int Findslice( string addr, byte[] bufer, int maxcount);

        //[DllImport(PlatformsClass.Asmbname, EntryPoint = "TrySignAndPubmsg", CallingConvention = CallingConvention.Cdecl)]
        //public extern static bool TrySignAndPubmsg(string jsonmsg, string pwd);
        
    }
}
