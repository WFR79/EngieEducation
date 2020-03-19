namespace SynapseCore
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Base class for Synapse Application Exceptions
    /// </summary>
    /// <remarks>Only a class derived from this one should be used.
    /// E.g. "SynapseCoreException" or "Synapse[Module]Exception"
    /// </remarks>
    /// <see cref="http://msdn.microsoft.com/en-us/library/vstudio/ms229064(v=vs.100).aspx"/>
    [Serializable]
    public class SynapseException : Exception, ISerializable
    {
        public SynapseException()
            : base()
        {
        }

        public SynapseException(string message)
            : base(message)
        {
        }

        public SynapseException(string message, Exception inner)
            : base(message, inner)
        {
        }

        // This constructor is needed for serialization.
        protected SynapseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        [SecurityPermission(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
