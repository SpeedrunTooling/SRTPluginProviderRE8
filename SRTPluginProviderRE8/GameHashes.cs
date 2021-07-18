﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace SRTPluginProviderRE8
{
    /// <summary>
    /// SHA256 hashes for the RE8/BIO8 game executables.
    /// 
    /// Resident Evil 8: Village (WW): https://steamdb.info/app/1196590/ / https://steamdb.info/depot/1196591/
    /// Biohazard 8: Village (CERO Z): https://steamdb.info/app/1196600/ / https://steamdb.info/depot/1196601/
    /// </summary>
    public static class GameHashes
    {
        private static readonly byte[] re8WW_20210506_1 = new byte[32] { 0x03, 0x62, 0x8B, 0x43, 0x59, 0xB1, 0x08, 0x61, 0xB3, 0x27, 0xA8, 0x24, 0x5F, 0xE2, 0x4E, 0x5B, 0x97, 0xB1, 0xC0, 0xBE, 0x8C, 0xA8, 0x20, 0x8E, 0xA7, 0x92, 0x17, 0x01, 0x07, 0xBD, 0x5B, 0xE1 }; // Steam WW RTM
        private static readonly byte[] re8ceroD_20210506_1 = new byte[32] { 248, 18, 212, 128, 184, 219, 12, 144, 5, 248, 18, 119, 67, 167, 153, 209, 150, 26, 72, 170, 14, 208, 57, 29, 8, 208, 168, 231, 124, 196, 77, 49 };
        private static readonly byte[] re8ceroZ_20210508_1 = new byte[32] { 0x8A, 0x92, 0x8C, 0x97, 0xEC, 0xF0, 0x40, 0x88, 0xE8, 0x2A, 0x24, 0x19, 0x93, 0x1E, 0x59, 0x26, 0x9A, 0x8B, 0x56, 0xD6, 0x2C, 0x72, 0x22, 0xE9, 0xE2, 0xB4, 0x04, 0xF7, 0x68, 0x96, 0x72, 0x2F };
        private static readonly byte[] re8promo01_20210426_1 = new byte[32] { 0xEF, 0x08, 0x39, 0xEF, 0xBB, 0x3D, 0x59, 0x92, 0x5D, 0xB0, 0xB0, 0xA5, 0x3D, 0xD6, 0x63, 0xD1, 0x08, 0x7F, 0xCD, 0xDE, 0xE1, 0x6A, 0x3C, 0xAC, 0x37, 0x50, 0xB4, 0x37, 0xCE, 0x5D, 0x07, 0x9F };
        private static readonly byte[] re8UNK_20210710_1 = new byte[32] { 0x56, 0xFC, 0x17, 0x28, 0xB1, 0x2C, 0x5C, 0xBF, 0x03, 0x92, 0x45, 0x33, 0x75, 0x07, 0x8B, 0x80, 0x1B, 0x92, 0xF9, 0xD7, 0xC1, 0x77, 0x11, 0x8B, 0x8F, 0x7A, 0xB8, 0xB8, 0x34, 0xED, 0x85, 0x00 }; // Unknown version
        private static readonly byte[] re8UNK_20210714_1 = new byte[32] { 0x59, 0x35, 0xB9, 0x93, 0xE9, 0x68, 0x4E, 0x1E, 0x6F, 0xAD, 0x20, 0xD2, 0xBD, 0x37, 0x71, 0xB4, 0x6E, 0x96, 0x9D, 0x3F, 0xA4, 0xE7, 0x90, 0xC5, 0xAD, 0x0F, 0x50, 0x53, 0xAC, 0x78, 0x47, 0xBE }; // Unknown version

        public static GameVersion DetectVersion(string filePath)
        {
            byte[] checksum;
            using (SHA256 hashFunc = SHA256.Create())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                checksum = hashFunc.ComputeHash(fs);

            if (checksum.SequenceEqual(re8WW_20210506_1))
            {
                Console.WriteLine("Steam v1.0 Detected.");
                return GameVersion.RE8_WW_20210506_1;
            }

            else if (checksum.SequenceEqual(re8promo01_20210426_1))
            {
                Console.WriteLine("Steam Promo v1.0 Detected.");
                return GameVersion.RE8_PROMO_01_20210426_1;
            }

            else if (checksum.SequenceEqual(re8ceroZ_20210508_1))
            {
                Console.WriteLine("Steam CeroZ v1.0 Detected.");
                return GameVersion.RE8_CEROZ_20210508_1;
            }

            else if (checksum.SequenceEqual(re8ceroD_20210506_1))
            {
                Console.WriteLine("Steam CeroD v1.0 Detected.");
                return GameVersion.RE8_CEROD_20210506_1;
            }

            else if (checksum.SequenceEqual(re8UNK_20210710_1))
            {
                Console.WriteLine("Unknown 2021-07-10 Detected.");
                return GameVersion.RE8_UNK_20210710_1;
            }

            else if (checksum.SequenceEqual(re8UNK_20210714_1))
            {
                Console.WriteLine("Unknown 2021-07-14 Detected.");
                return GameVersion.RE8_UNK_20210714_1;
            }

            Console.WriteLine("Unknown Version. If you have installed any third party mods, please uninstall and try again.");
            return GameVersion.Unknown;
        }
    }
}
