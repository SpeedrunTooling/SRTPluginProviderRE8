using System;
using System.Globalization;
using System.Runtime.InteropServices;
using SRTPluginProviderRE8.Structs;
using SRTPluginProviderRE8.Structs.GameStructs;
using System.Diagnostics;
using System.Reflection;

namespace SRTPluginProviderRE8
{
    public class GameMemoryRE8 : IGameMemoryRE8
    {
        public string GameName => "RE8";
        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
        public GamePlayerStatus PlayerStatus { get => _playerstatus; set => _playerstatus = value; }
        internal GamePlayerStatus _playerstatus;

        public GamePlayer Player { get => _player; set => _player = value; }
        internal GamePlayer _player;

        public string PlayerName => PlayerStatus.IsChris ? "Chris: " : "Ethan: ";

        public GamePlayerPosition PlayerPosition { get => _playerPosition; set => _playerPosition = value; }
        internal GamePlayerPosition _playerPosition;

        public int RankScore { get => _rankScore; set => _rankScore = value; }
        internal int _rankScore;

        public int Rank { get => _rank; set => _rank = value; }
        internal int _rank;

        public int Lei { get => _lei; set => _lei = value; }
        internal int _lei;

        public int EnemyTableCount { get => _enemyTableCount; set => _enemyTableCount = value; }
        internal int _enemyTableCount;

        public EnemyHP[] EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }
        internal EnemyHP[] _enemyHealth;

        public int PlayerInventoryCount { get => _playerInventoryCount; set => _playerInventoryCount = value; }
        internal int _playerInventoryCount;

        public InventoryEntry LastKeyItem { get => _lastKeyItem; set => _lastKeyItem = value; }
        internal InventoryEntry _lastKeyItem;

        public InventoryEntry[] PlayerInventory { get => _playerInventory; set => _playerInventory = value; }
        internal InventoryEntry[] _playerInventory;
    }
}
