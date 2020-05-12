using System.Runtime.InteropServices;
using System.Text;

namespace Gobi.SharpHost
{
    internal static class Api
    {
        [DllImport("../../../../../rust_lib/target/release/rust_ffi.dll", 
            EntryPoint = "about",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string About();
    }
}