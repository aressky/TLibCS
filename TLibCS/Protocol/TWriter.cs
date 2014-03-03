using System;
using System.Text;

namespace TLibCS.Protocol
{
    public abstract class TWriter
    {
        protected System.IO.Stream writer;

        public TWriter(System.IO.Stream sout)
        {
            writer = sout;
        }


        public virtual void WriteStructBegin(string struct_name)
        {

        }

        public virtual void WriteStructEnd(string name)
        {

        }

        public virtual void WriteUnionBegin(string union_name)
        {
        }

        public virtual void WriteUnionEnd(string union_name)
        {
        }

        public virtual void WriteEnumBegin(string enum_name)
        {
        }

        public virtual void WriteEnumEnd(string enum_name)
        {
        }

        public virtual void WriteVectorBegin()
        {
        }

        public virtual void WriteVectorEnd()
        {
        }

        public virtual bool WriteFieldBegin(string var_name)
        {
            return true;
        }

        public virtual void WriteFieldEnd(string var_name)
        {
        }

        public virtual bool WriteVectorElementBegin(string var_name, uint index)
        {
            return true;
        }

        public virtual void WriteVectorElementEnd(string var_name, uint index)
        {
        }

        public virtual void Write(sbyte val)
        {
        }

        public virtual void Write(short val)
        {
        }

        public virtual void Write(int val)
        {
        }

        public virtual void Write(long val)
        {
        }

        public virtual void Write(byte val)
        {
        }

        public virtual void Write(ushort val)
        {
        }

        public virtual void Write(uint val)
        {
        }

        public virtual void Write(ulong val)
        {

        }

        public virtual void Write(double val)
        {
        }

        public virtual void Write(char val)
        {
        }

        public virtual void Write(string str)
        {

        }

    }
}
