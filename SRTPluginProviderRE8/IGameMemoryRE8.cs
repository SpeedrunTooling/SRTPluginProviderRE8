using System;
using SRTPluginProviderRE8.Structs;
using SRTPluginProviderRE8.Structs.GameStructs;

namespace SRTPluginProviderRE8
{
    public interface IGameMemoryRE8
    {
        string GameName { get; }
        string VersionInfo { get; }
        GamePlayerStatus PlayerStatus { get; set; }
        GamePlayer Player { get; set; }
        string PlayerName { get; }
        GamePlayerPosition PlayerPosition { get; set; }
        int RankScore { get; set; }
        int Rank { get; set; }
        int Lei { get; set; }
        InventoryEntry[] PlayerInventory { get; set; }
        EnemyHP[] EnemyHealth { get; set; }
        InventoryEntry LastKeyItem { get; set; }

    }
}
