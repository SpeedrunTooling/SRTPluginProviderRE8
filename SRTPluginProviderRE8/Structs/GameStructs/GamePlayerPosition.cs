using System.Numerics;
using System.Runtime.InteropServices;

namespace SRTPluginProviderRE8.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0xC)]

    public struct GamePlayerPosition
    {
        [FieldOffset(0x0)] private Vector3 position;
        public float X => position.X;
        public float Y => position.Y;
        public float Z => position.Z;
    }
}