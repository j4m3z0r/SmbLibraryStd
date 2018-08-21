using System;
using System.Collections.Generic;
using System.Text;
using SmbLibraryStd.NetBios;
using Utilities;

namespace SmbLibraryStd
{
    public class NetBiosTests
    {
        public static void Test()
        {
            byte[] buffer = new byte[] { 0x20, 0x46, 0x47, 0x45, 0x4e, 0x44, 0x4a, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x00 };
            int offset = 0;
            string name = NetBiosUtils.DecodeName(buffer, ref offset);
            byte[] encodedName = NetBiosUtils.EncodeName(name, String.Empty);
            bool success = ByteUtils.AreByteArraysEqual(buffer, encodedName);
        }

        public static void Test2()
        {
            byte[] buffer = new byte[] { 0x20, 0x46, 0x47, 0x45, 0x4e, 0x44, 0x4a, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x43, 0x41, 0x41, 0x41, 0x00 };
            int offset = 0;
            string name = NetBiosUtils.DecodeName(buffer, ref offset);
            byte[] encodedName = NetBiosUtils.EncodeName(name, String.Empty);
            bool success = ByteUtils.AreByteArraysEqual(buffer, encodedName);
        }
    }
}
