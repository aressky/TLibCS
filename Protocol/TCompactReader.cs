using System;
using System.IO;
using System.Text;
using TLibCS.Utilities;

namespace TLibCS.Protocol
{
    public class TCompactReader : TReader
    {
        protected short zigzag_decode16(ushort n)
        {
            return (short)(((short)n >> 1) ^ -(short)(n & 1));
        }

        protected int zigzag_decode32(uint n)
        {
            return (int)(((int)n >> 1) ^ -(int)(n & 1));
        }

        protected long zigzag_decode64(ulong n)
        {
            return (long)(((long)n >> 1) ^ -(long)(n & 1));
        }

        public TCompactReader(Stream sin)
            : base(sin)
        {
        }

        public override void Read(out sbyte val)
        {
            val = (sbyte)reader.ReadByte();
        }

        public override void Read(out short val)
        {
            ushort _val;
            Read(out _val);
            _val = Endian.le16toh(_val);
            val = zigzag_decode16(_val);
        }

        public override void Read(out int val)
        {
            uint _val;
            Read(out _val);
            _val = Endian.le32toh(_val);
            val = zigzag_decode32(_val);
        }

        public override void Read(out long val)
        {
            ulong _val;
            Read(out _val);
            _val = Endian.le64toh(_val);
            val = zigzag_decode64(_val);
        }

        public override void Read(out byte val)
        {
            val = (byte)reader.ReadByte();
        }

        public override void Read(out ushort result)
        {
            byte b;
            int ir;

            result = 0;
            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result = (ushort)(b & 0x7F);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result |= (ushort)((b & 0x7F) << 7);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result |= (ushort)((b & 0x7F) << 14);
            if ((b & 0x80) == 0)
            {
                goto done;
            }
        done:
            return;

        not_enough_byte_size:
            throw new TProtocolException(TProtocolException.TLIBCS_OUT_OF_MEMORY, "stream reach end.");
        }

        public override void Read(out uint result)
        {
            byte b;
            int ir;

            result = 0;
            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result = (ushort)(b & 0x7F);
            if ((b & 0x80) == 0)
            {                
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result |= (ushort)((b & 0x7F) << 7);
            if ((b & 0x80) == 0)
            {                
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result |= (ushort)((b & 0x7F) << 14);
            if ((b & 0x80) == 0)
            {                
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result |= (ushort)((b & 0x7F) << 21);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            result |= (ushort)((b & 0x7F) << 28);
            if ((b & 0x80) == 0)
            {
                goto done;
            }


        done:
            return;

        not_enough_byte_size:
            throw new TProtocolException(TProtocolException.TLIBCS_OUT_OF_MEMORY, "stream reach end.");
        }

        public override void Read(out ulong result)
        {
            byte b;
            int ir;

            result = 0;

            uint par0 = 0;
            uint par1 = 0;
            uint par2 = 0;

            //par0
            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;

            par0 = (uint)(b & 0x7F);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;

            par0 |= (uint)((b & 0x7F) << 7);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;

            par0 |= (uint)((b & 0x7F) << 14);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            par0 |= (uint)((b & 0x7F) << 21);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            //par1
            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;

            par1 = (uint)(b & 0x7F);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            par1 |= (uint)((b & 0x7F) << 7);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;

            par1 |= (uint)((b & 0x7F) << 14);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;

            par1 |= (uint)((b & 0x7F) << 21);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            //par2
            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;

            par2 = (uint)(b & 0x7F);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

            ir = reader.ReadByte();
            if (ir == -1)
            {
                goto not_enough_byte_size;
            }
            b = (byte)ir;
            par2 |= (uint)((b & 0x7F) << 7);
            if ((b & 0x80) == 0)
            {
                goto done;
            }

        done:
            result = ((ulong)par0) | ((ulong)par1 << 28) | ((ulong)par2 << 56);
            return;

        not_enough_byte_size:
            throw new TProtocolException(TProtocolException.TLIBCS_OUT_OF_MEMORY, "stream reach end.");
        }



        public override void Read(out double val)
        {
            long i64;

            Read(out i64);
            val = BitConverter.Int64BitsToDouble(i64);
        }

        public override void Read(out char val)
        {
            int ir = reader.ReadByte();
            if (ir == -1)
            {
                throw new TProtocolException(TProtocolException.TLIBCS_OUT_OF_MEMORY, "stream reach end.");
            }
            val = (char)ir;
        }

        public override void Read(out string str)
        {
            MemoryStream buff = new MemoryStream();
            for(;;)
            {
                int ir = reader.ReadByte();
                if(ir == -1)
                {
                    throw new TProtocolException(TProtocolException.TLIBCS_OUT_OF_MEMORY, "stream reach end.");
                }
                byte b = (byte)ir;
                if(b == 0)
                {
                    break;
                }
                buff.WriteByte(b);
            }

            byte[] bb = buff.GetBuffer();

            str = Encoding.UTF8.GetString(bb, 0, (int)buff.Length);
        }
    }
}
