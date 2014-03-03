namespace TLibCS.Protocol
{
    public abstract class TReader
    {
        protected System.IO.Stream reader;

        public TReader(System.IO.Stream sin)
        {
            reader = sin;
        }

        public virtual void ReadStructBegin(string struct_name)
        {

        }

        public virtual void ReadStructEnd(string name)
        {

        }

        public virtual void ReadUnionBegin(string union_name)
        {
        }

        public virtual void ReadUnionEnd(string union_name)
        {
        }

        public virtual void ReadEnumBegin(string enum_name)
        {
        }

        public virtual void ReadEnumEnd(string enum_name)
        {
        }

        public virtual void ReadVectorBegin()
        {
        }

        public virtual void ReadVectorEnd()
        {
        }

        public virtual bool ReadFieldBegin(string var_name)
        {
            return true;
        }

        public virtual void ReadFieldEnd(string var_name)
        {
        }

        public virtual bool ReadVectorElementBegin(string var_name, uint index)
        {
            return true;
        }

        public virtual void ReadVectorElementEnd(string var_name, uint index)
        {
        }

        public virtual void Read(out sbyte val)
        {
            val = 0;
        }

        public virtual void Read(out short val)
        {
            val = 0;
        }

        public virtual void Read(out int val)
        {
            val = 0;
        }

        public virtual void Read(out long val)
        {
            val = 0;
        }

        public virtual void Read(out byte val)
        {
            val = 0;
        }

        public virtual void Read(out ushort val)
        {
            val = 0;
        }

        public virtual void Read(out uint val)
        {
            val = 0;
        }

        public virtual void Read(out ulong val)
        {
            val = 0;
        }

        public virtual void Read(out double val)
        {
            val = 0;
        }

        public virtual void Read(out char val)
        {
            val = '\0';
        }

        public virtual void Read(out string str)
        {
            str = null;
        }
    }
}
