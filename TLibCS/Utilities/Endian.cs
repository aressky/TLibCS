using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLibCS.Utilities
{
    class Endian
    {
        //host to little endian.
        public static ushort htole16(ushort n)
        {
            if (BitConverter.IsLittleEndian)
            {
                return n;
            }
            else
            {
                byte[] b = BitConverter.GetBytes(n);
                return BitConverter.ToUInt16(b, 0);
            }
        }

        public static uint htole32(uint n)
        {
            if (BitConverter.IsLittleEndian)
            {
                return n;
            }
            else
            {
                byte[] b = BitConverter.GetBytes(n);
                return BitConverter.ToUInt32(b, 0);
            }
        }
        
        public static ulong htole64(ulong n)
        {
            if (BitConverter.IsLittleEndian)
            {
                return n;
            }
            else
            {
                byte[] b = BitConverter.GetBytes(n);
                return BitConverter.ToUInt64(b, 0);
            }
        }



        public static ushort le16toh(ushort n)
        {
            if (BitConverter.IsLittleEndian)
            {
                return n;
            }
            else
            {
                byte[] b = BitConverter.GetBytes(n);
                return BitConverter.ToUInt16(b, 0);
            }
        }

        public static uint le32toh(uint n)
        {
            if (BitConverter.IsLittleEndian)
            {
                return n;
            }
            else
            {
                byte[] b = BitConverter.GetBytes(n);
                return BitConverter.ToUInt32(b, 0);
            }
        }

        public static ulong le64toh(ulong n)
        {
            if (BitConverter.IsLittleEndian)
            {
                return n;
            }
            else
            {
                byte[] b = BitConverter.GetBytes(n);
                return BitConverter.ToUInt64(b, 0);
            }
        }
    }
}
