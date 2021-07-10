using System.Runtime.InteropServices;

namespace SRTPluginProviderRE8.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x8)]

    public struct GameRank
    {
        [FieldOffset(0x0)] public int Score;
        [FieldOffset(0x4)] public int Rank;
    }
}