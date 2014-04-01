using System;

namespace TLibCS.Protocol
{
    public class TProtocolException : Exception
    {
        public const int TLIBCS_NOERROR = 0;
        public const int TLIBCS_OUT_OF_MEMORY = 0;

        protected int type_ = TLIBCS_NOERROR;


        public TProtocolException(int type, String message)
            : base(message)
        {
            type_ = type;
        }
    }
}
