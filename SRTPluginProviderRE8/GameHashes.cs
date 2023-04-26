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
        // PATCH 1.00
        private static readonly byte[] re8WW_20210506_1 = new byte[32] { 0x03, 0x62, 0x8B, 0x43, 0x59, 0xB1, 0x08, 0x61, 0xB3, 0x27, 0xA8, 0x24, 0x5F, 0xE2, 0x4E, 0x5B, 0x97, 0xB1, 0xC0, 0xBE, 0x8C, 0xA8, 0x20, 0x8E, 0xA7, 0x92, 0x17, 0x01, 0x07, 0xBD, 0x5B, 0xE1 }; // Steam WW RTM
        private static readonly byte[] re8ceroD_20210506_1 = new byte[32] { 248, 18, 212, 128, 184, 219, 12, 144, 5, 248, 18, 119, 67, 167, 153, 209, 150, 26, 72, 170, 14, 208, 57, 29, 8, 208, 168, 231, 124, 196, 77, 49 };
        private static readonly byte[] re8ceroZ_20210508_1 = new byte[32] { 0x8A, 0x92, 0x8C, 0x97, 0xEC, 0xF0, 0x40, 0x88, 0xE8, 0x2A, 0x24, 0x19, 0x93, 0x1E, 0x59, 0x26, 0x9A, 0x8B, 0x56, 0xD6, 0x2C, 0x72, 0x22, 0xE9, 0xE2, 0xB4, 0x04, 0xF7, 0x68, 0x96, 0x72, 0x2F };
        private static readonly byte[] re8promo01_20210426_1 = new byte[32] { 0xEF, 0x08, 0x39, 0xEF, 0xBB, 0x3D, 0x59, 0x92, 0x5D, 0xB0, 0xB0, 0xA5, 0x3D, 0xD6, 0x63, 0xD1, 0x08, 0x7F, 0xCD, 0xDE, 0xE1, 0x6A, 0x3C, 0xAC, 0x37, 0x50, 0xB4, 0x37, 0xCE, 0x5D, 0x07, 0x9F };
        private static readonly byte[] re8UNK_20210710_1 = new byte[32] { 0x56, 0xFC, 0x17, 0x28, 0xB1, 0x2C, 0x5C, 0xBF, 0x03, 0x92, 0x45, 0x33, 0x75, 0x07, 0x8B, 0x80, 0x1B, 0x92, 0xF9, 0xD7, 0xC1, 0x77, 0x11, 0x8B, 0x8F, 0x7A, 0xB8, 0xB8, 0x34, 0xED, 0x85, 0x00 }; // Unknown version
        private static readonly byte[] re8UNK_20210714_1 = new byte[32] { 0x59, 0x35, 0xB9, 0x93, 0xE9, 0x68, 0x4E, 0x1E, 0x6F, 0xAD, 0x20, 0xD2, 0xBD, 0x37, 0x71, 0xB4, 0x6E, 0x96, 0x9D, 0x3F, 0xA4, 0xE7, 0x90, 0xC5, 0xAD, 0x0F, 0x50, 0x53, 0xAC, 0x78, 0x47, 0xBE }; // Unknown version

        // PATCH 1.01
        private static readonly byte[] re8WW_20210719_2 = new byte[32] { 0x77, 0x16, 0x3C, 0x39, 0x0F, 0x48, 0x32, 0x0C, 0x07, 0xDF, 0xD5, 0x70, 0x85, 0x48, 0x1A, 0xF9, 0x7B, 0xD3, 0xCD, 0xBD, 0xD1, 0xEC, 0x19, 0xD9, 0x31, 0x56, 0x31, 0xFC, 0x4B, 0xD4, 0x0F, 0xB0 }; // Steam WW 1.01
        //private static readonly byte[] re8ceroD_20210719_2 = new byte[32] { 248, 18, 212, 128, 184, 219, 12, 144, 5, 248, 18, 119, 67, 167, 153, 209, 150, 26, 72, 170, 14, 208, 57, 29, 8, 208, 168, 231, 124, 196, 77, 49 };
        //private static readonly byte[] re8ceroZ_20210719_2 = new byte[32] { 0x8A, 0x92, 0x8C, 0x97, 0xEC, 0xF0, 0x40, 0x88, 0xE8, 0x2A, 0x24, 0x19, 0x93, 0x1E, 0x59, 0x26, 0x9A, 0x8B, 0x56, 0xD6, 0x2C, 0x72, 0x22, 0xE9, 0xE2, 0xB4, 0x04, 0xF7, 0x68, 0x96, 0x72, 0x2F };
        //private static readonly byte[] re8promo01_20210719_2 = new byte[32] { 0xEF, 0x08, 0x39, 0xEF, 0xBB, 0x3D, 0x59, 0x92, 0x5D, 0xB0, 0xB0, 0xA5, 0x3D, 0xD6, 0x63, 0xD1, 0x08, 0x7F, 0xCD, 0xDE, 0xE1, 0x6A, 0x3C, 0xAC, 0x37, 0x50, 0xB4, 0x37, 0xCE, 0x5D, 0x07, 0x9F };
        //private static readonly byte[] re8UNK_20210719_2 = new byte[32] { 0x56, 0xFC, 0x17, 0x28, 0xB1, 0x2C, 0x5C, 0xBF, 0x03, 0x92, 0x45, 0x33, 0x75, 0x07, 0x8B, 0x80, 0x1B, 0x92, 0xF9, 0xD7, 0xC1, 0x77, 0x11, 0x8B, 0x8F, 0x7A, 0xB8, 0xB8, 0x34, 0xED, 0x85, 0x00 }; // Unknown version
        //private static readonly byte[] re8UNK2_20210719_2 = new byte[32] { 0x59, 0x35, 0xB9, 0x93, 0xE9, 0x68, 0x4E, 0x1E, 0x6F, 0xAD, 0x20, 0xD2, 0xBD, 0x37, 0x71, 0xB4, 0x6E, 0x96, 0x9D, 0x3F, 0xA4, 0xE7, 0x90, 0xC5, 0xAD, 0x0F, 0x50, 0x53, 0xAC, 0x78, 0x47, 0xBE }; // Unknown version

        // PATCH 1.02
        private static readonly byte[] re8WW_20210810_3 = new byte[32] { 0xBF, 0x47, 0xB8, 0x0F, 0xE1, 0xD1, 0xD8, 0xAD, 0x33, 0x96, 0xA2, 0xAC, 0xC3, 0xCC, 0xB3, 0x51, 0x43, 0x26, 0x2E, 0xB6, 0xB8, 0x01, 0xC7, 0x4E, 0xC5, 0x22, 0xCF, 0x2D, 0x1B, 0xF6, 0xCE, 0xC3 };
        //private static readonly byte[] re8ceroD_20210810_3 = new byte[32] { 248, 18, 212, 128, 184, 219, 12, 144, 5, 248, 18, 119, 67, 167, 153, 209, 150, 26, 72, 170, 14, 208, 57, 29, 8, 208, 168, 231, 124, 196, 77, 49 };
        //private static readonly byte[] re8ceroZ_20210810_3 = new byte[32] { 0x8A, 0x92, 0x8C, 0x97, 0xEC, 0xF0, 0x40, 0x88, 0xE8, 0x2A, 0x24, 0x19, 0x93, 0x1E, 0x59, 0x26, 0x9A, 0x8B, 0x56, 0xD6, 0x2C, 0x72, 0x22, 0xE9, 0xE2, 0xB4, 0x04, 0xF7, 0x68, 0x96, 0x72, 0x2F };

        // PATCH 1.03
        private static readonly byte[] re8WW_20210824_4 = new byte[32] { 0x31, 0x63, 0xAE, 0xD5, 0x4F, 0x11, 0x11, 0xD4, 0x03, 0x59, 0x84, 0x37, 0x6E, 0x5C, 0x91, 0xEA, 0x79, 0x0C, 0x8A, 0x72, 0x43, 0x6F, 0x83, 0xD9, 0xB5, 0x4D, 0xEA, 0x2E, 0x16, 0x61, 0x78, 0x7F };

        // PATCH 1.04
        private static readonly byte[] re8WW_20211012_5 = new byte[32] { 0xB2, 0x20, 0x23, 0xD3, 0x51, 0x04, 0x4C, 0xDA, 0x36, 0x99, 0x31, 0x55, 0xED, 0x18, 0x0F, 0xB9, 0x1F, 0x8C, 0x32, 0xAE, 0xC4, 0x93, 0xC9, 0x9B, 0xC6, 0x09, 0x20, 0x42, 0x8A, 0x90, 0x97, 0x85 };
        
        // "PATCH 1.05"
        private static readonly byte[] re8WW_20211217_1 = new byte[32] { 0xCA, 0x49, 0x7E, 0x08, 0x4A, 0xE3, 0x20, 0xBC, 0xC7, 0x0C, 0xE2, 0xF0, 0x9E, 0x6D, 0xDA, 0x03, 0x24, 0x29, 0x43, 0x27, 0x7C, 0xD3, 0x43, 0xA0, 0x86, 0x10, 0xFD, 0x52, 0x61, 0xD3, 0xB2, 0x7D };

        // DLC Update 2022-10-14
        private static readonly byte[] re8WW_20221014_1 = new byte[32] { 0x62, 0x73, 0x31, 0xE0, 0x3D, 0x35, 0x59, 0x70, 0xBB, 0xF6, 0xAB, 0xDE, 0x6F, 0x09, 0x37, 0xA8, 0xB5, 0x3E, 0xA1, 0x59, 0x83, 0x3D, 0xC5, 0x8F, 0xF2, 0xCB, 0x11, 0x11, 0x85, 0x5C, 0x51, 0x88 };

        // Update 2022-11-18
        private static readonly byte[] re8WW_20221118_1 = new byte[32] { 0xD6, 0x43, 0x19, 0xCD, 0x29, 0xEF, 0x92, 0x2A, 0xC7, 0x7C, 0xA4, 0x9E, 0xC1, 0x0E, 0x58, 0xD6, 0x7C, 0xA7, 0xCA, 0x40, 0x0D, 0xA5, 0x67, 0x04, 0xDE, 0xAA, 0x1C, 0xFD, 0x75, 0x3D, 0x03, 0x63 };

        // Update 2022-12-01
        private static readonly byte[] re8WW_20221201_1 = new byte[32] { 0x44, 0xBC, 0xAD, 0x51, 0x36, 0x0E, 0x50, 0x35, 0x75, 0x99, 0x67, 0xE7, 0xC5, 0x62, 0x11, 0x44, 0x38, 0x20, 0xBC, 0x8B, 0xAF, 0xC4, 0x09, 0xC2, 0x55, 0x80, 0xB7, 0xFF, 0x3D, 0xB4, 0x7C, 0xDC };

        // Update 2023
        private static readonly byte[] re8WW_2023_1 = new byte[32] { 0x41, 0x1f, 0x98, 0x37, 0xff, 0x66, 0xa5, 0x74, 0xb9, 0x15, 0xb7, 0x24, 0x71, 0xf5, 0x6d, 0x90, 0x0c, 0x89, 0x1d, 0xa9, 0x0c, 0x28, 0xa4, 0xd4, 0x0e, 0xee, 0x6b, 0x7c, 0xf8, 0x5d, 0x99, 0xd8 };

        public static GameVersion DetectVersion(string filePath)
        {
            byte[] checksum;
            using (SHA256 hashFunc = SHA256.Create())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                checksum = hashFunc.ComputeHash(fs);

            if (checksum.SequenceEqual(re8WW_20210506_1))
            {
                Console.WriteLine("Steam v1.00 Detected.");
                return GameVersion.RE8_WW_20210506_1;
            }

            else if (checksum.SequenceEqual(re8WW_20210719_2))
            {
                Console.WriteLine("Steam v1.01 Detected.");
                return GameVersion.RE8_WW_20210719_2;
            }

            else if (checksum.SequenceEqual(re8WW_20210810_3))
            {
                Console.WriteLine("Steam v1.02 Detected.");
                return GameVersion.RE8_WW_20210810_3;
            }

            else if (checksum.SequenceEqual(re8WW_20210824_4))
            {
                Console.WriteLine("Steam v1.03 Detected.");
                return GameVersion.RE8_WW_20210824_4;
            }

            else if (checksum.SequenceEqual(re8WW_20211012_5))
            {
                Console.WriteLine("Steam v1.04 Detected.");
                return GameVersion.RE8_WW_20211012_5;
            }

            else if (checksum.SequenceEqual(re8WW_20211217_1))
            {
                Console.WriteLine("Steam v1.05 Detected.");
                return GameVersion.RE8_WW_20211217_1;
            }

            else if (checksum.SequenceEqual(re8WW_20221014_1))
            {
                Console.WriteLine("Steam 2022-10-14 DLC Detected.");
                return GameVersion.RE8_WW_20221014_1;
            }

            else if (checksum.SequenceEqual(re8WW_20221118_1))
            {
                Console.WriteLine("Steam 2022-11-18 Detected.");
                return GameVersion.RE8_WW_20221118_1;
            }

            else if (checksum.SequenceEqual(re8WW_20221201_1))
            {
                Console.WriteLine("Steam 2022-12-01 Detected.");
                return GameVersion.RE8_WW_20221201_1;
            }

            else if (checksum.SequenceEqual(re8promo01_20210426_1))
            {
                Console.WriteLine("Steam Promo v1.00 Detected.");
                return GameVersion.RE8_PROMO_01_20210426_1;
            }

            else if (checksum.SequenceEqual(re8ceroZ_20210508_1))
            {
                Console.WriteLine("Steam CeroZ v1.00 Detected.");
                return GameVersion.RE8_CEROZ_20210508_1;
            }

            else if (checksum.SequenceEqual(re8ceroD_20210506_1))
            {
                Console.WriteLine("Steam CeroD v1.00 Detected.");
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

            else if (checksum.SequenceEqual(re8WW_2023_1))
            {
                Console.WriteLine("Unknown 2023 Detected.");
                return GameVersion.RE8_WW_2023_1;
            }

            Console.WriteLine("Unknown Version. If you have installed any third party mods, please uninstall and try again.");
            return GameVersion.Unknown;
        }
    }
}
