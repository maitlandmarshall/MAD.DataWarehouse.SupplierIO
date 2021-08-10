using System;
using System.Runtime.Serialization;

namespace MAD.DataWarehouse.SupplierIO.Jobs
{
    [Serializable]
    internal class RemoteJobFailedException : Exception
    {
        public RemoteJobFailedException()
        {
        }

        public RemoteJobFailedException(string message) : base(message)
        {
        }

        public RemoteJobFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RemoteJobFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}