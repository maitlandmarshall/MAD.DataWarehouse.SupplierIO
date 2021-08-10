using System;
using System.Runtime.Serialization;

namespace MAD.DataWarehouse.SupplierIO.Jobs
{
    [Serializable]
    internal class WaitingForRemoteJobToCompleteException : Exception
    {
        public WaitingForRemoteJobToCompleteException()
        {
        }

        public WaitingForRemoteJobToCompleteException(string message) : base(message)
        {
        }

        public WaitingForRemoteJobToCompleteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WaitingForRemoteJobToCompleteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}