using System;
using System.IO;
using System.Text;
using TLibCS.Utilities;

namespace TLibCS.Protocol
{
    public class TCompactWriter : TWriter
    {
        protected ushort zigzag_encode16(short n)
        {
            return (ushort)(((ushort)n << 1) ^ ((ushort)n >> 15));
        }

        protected uint zigzag_encode32(int n)
        {
            return (uint)(((uint)n << 1) ^ ((uint)n >> 31));
        }

        protected ulong zigzag_encode64(long n)
        {
            return (ulong)(((ulong)n << 1) ^ ((ulong)n >> 63));
        }

        public TCompactWriter(Stream sout)
            : base(sout)
        {
        }

        public override void Write(sbyte val)
        {
            writer.WriteByte((byte)val);
        }

        public override void Write(short val)
        {
            Write(zigzag_encode16(val));
        }

        public override void Write(int val)
        {
            Write(zigzag_encode32(val));
        }

        public override void Write(long val)
        {
            Write(zigzag_encode64(val));
        }


        public override void Write(byte val)
        {
            writer.WriteByte(val);
        }

        public override void Write(ushort val)
        {
            ushort n = Endian.htole16(val);
            byte []buff_ptr = new byte[3];
            int buff_size;

            buff_ptr[0] = (byte)(n | 0x80);
            if (n >= (1 << 7))
            {
                buff_ptr[1] = (byte)((n >> 7) | 0x80);
                if (n >= (1 << 14))
                {                    
                    buff_ptr[2] = (byte)(n >> 14);
                    buff_size = 3;
                    goto done;
                }
                else
                {
                    buff_ptr[1] &= 0x7F;
                    buff_size = 2;
                    goto done;
                }
            }
            else
            {
                buff_ptr[0] &= 0x7F;
                buff_size = 1;
                goto done;
            }
done:
            writer.Write(buff_ptr, 0, buff_size);
        }

        public override void Write(uint val)
        {
            uint n = Endian.htole32(val);
            byte[] buff_ptr = new byte[5];
            int buff_size;

            buff_ptr[0] = (byte)(n | 0x80);
            if (n >= (1 << 7))
            {
                buff_ptr[1] = (byte)((n >> 7) | 0x80);
                if (n >= (1 << 14))
                {
                    buff_ptr[2] = (byte)((n >> 14) | 0x80);

                    if (n >= (1 << 21))
                    {
                        buff_ptr[3] = (byte)((n >> 21) | 0x80);

                        if (n >= (1 << 28))
                        {
                            buff_ptr[4] = (byte)(n >> 28);
                            buff_size = 5;
                            goto done;
                        }
                        else
                        {
                            buff_ptr[3] &= 0x7F;
                            buff_size = 4;
                            goto done;
                        }
                    }
                    else
                    {
                        buff_ptr[2] &= 0x7F;
                        buff_size = 3;
                        goto done;
                    }
                }
                else
                {
                    buff_ptr[1] &= 0x7F;
                    buff_size = 2;
                    goto done;
                }
            }
            else
            {
                buff_ptr[0] &= 0x7F;
                buff_size = 1;
                goto done;
            }

        done:
            writer.Write(buff_ptr, 0, buff_size);
        }

        public override void Write(ulong val)
        {
            ulong n = Endian.htole64(val);
            byte[] buff_ptr = new byte[10];
            int buff_size;
            

            uint part0 = (uint)(n);
            uint part1 = (uint)(n >> 28);
            uint part2 = (uint)(n >> 56);
            uint size;

            if (part2 == 0)
            {
                if (part1 == 0)
                {
                    if (part0 < (1 << 14))
                    {
                        if (part0 < (1 << 7))
                        {
                            size = 1;
                            buff_size = 1;

                            goto size1;
                        }
                        else
                        {
                            size = 2;
                            buff_size = 2;

                            goto size2;
                        }
                    }
                    else
                    {
                        if (part0 < (1 << 21))
                        {
                            size = 3;
                            buff_size = 3;

                            goto size3;
                        }
                        else
                        {
                            size = 4;
                            buff_size = 4;

                            goto size4;
                        }
                    }
                }
                else
                {
                    if (part1 < (1 << 14))
                    {
                        if (part1 < (1 << 7))
                        {
                            size = 5;
                            buff_size = 5;
                            goto size5;
                        }
                        else
                        {
                            size = 6;
                            buff_size = 6;
                            goto size6;
                        }
                    }
                    else
                    {
                        if (part1 < (1 << 21))
                        {
                            size = 7;
                            buff_size = 7;
                            goto size7;
                        }
                        else
                        {
                            size = 8;
                            buff_size = 8;
                            goto size8;
                        }
                    }
                }
            }
            else
            {
                if (part2 < (1 << 7))
                {
                    size = 9;
                    buff_size = 9;
                    goto size9;
                }
                else
                {
                    size = 10;
                    buff_size = 10;
                    goto size10;
                }
            }


size10:
        buff_ptr[9] = (byte)((part2 >> 7) | 0x80);
size9:
        buff_ptr[8] = (byte)((part2) | 0x80);
size8:
        buff_ptr[7] = (byte)((part1 >> 21) | 0x80);
size7:
        buff_ptr[6] = (byte)((part1 >> 14) | 0x80);
size6:
        buff_ptr[5] = (byte)((part1 >> 7) | 0x80);
size5:
        buff_ptr[4] = (byte)((part1) | 0x80);
size4:
        buff_ptr[3] = (byte)((part0 >> 21) | 0x80);
size3:
        buff_ptr[2] = (byte)((part0 >> 14) | 0x80);
size2:
        buff_ptr[1] = (byte)((part0 >> 7) | 0x80);
size1:
        buff_ptr[0] = (byte)((part0) | 0x80);


            buff_ptr[size - 1] &= 0x7F;

            writer.Write(buff_ptr, 0, buff_size);
        }


        public override void Write(double val)
        {
            Write(BitConverter.DoubleToInt64Bits(val));
        }

        public override void Write(char val)
        {
            writer.WriteByte((byte)val);
        }

        public override void Write(string str)
        {
            byte[] buff = Encoding.UTF8.GetBytes(str);

            writer.Write(buff, 0, buff.Length);
            writer.WriteByte(0);
        }
    }
}
