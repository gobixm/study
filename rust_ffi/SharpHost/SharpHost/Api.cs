using System.Runtime.InteropServices;
using Gobi.SharpHost.Models;

namespace Gobi.SharpHost
{
    public static class Api
    {
        private const string LibPath = "../../../../../rust_lib/target/release/rust_ffi.dll";

        [DllImport(LibPath,
            EntryPoint = "about",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string About();

        [DllImport(LibPath,
            EntryPoint = "increment_foo",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern Foo IncrementFoo(Foo foo, int add);
    }
}