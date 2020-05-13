using System.Runtime.InteropServices;

namespace Gobi.SharpHost.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Foo
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
}