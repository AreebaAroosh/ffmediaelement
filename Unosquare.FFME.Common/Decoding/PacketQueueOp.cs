﻿namespace Unosquare.FFME.Decoding
{
    /// <summary>
    /// Defines the multiple packet queue operations
    /// </summary>
    public enum PacketQueueOp
    {
        /// <summary>
        /// The packet queue was cleared
        /// </summary>
        Clear = 0,

        /// <summary>
        /// The packet queue enqueued a packet
        /// </summary>
        Queued = 1,

        /// <summary>
        /// The packet queue dequeued a packet
        /// </summary>
        Dequeued = 2
    }
}