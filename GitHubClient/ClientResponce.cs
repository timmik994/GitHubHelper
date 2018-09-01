using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubClient
{
    /// <summary>
    /// Responce object from libraly.
    /// </summary>
    public class ClientResponce<T>
    {
        /// <summary>
        /// Gets or sets status of operation.
        /// </summary>
        public OperationStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the message of operation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data returned by operation.
        /// </summary>
        public T ResponceData { get; set; }
    }
}

/// <summary>
/// Statuses of operations with gitHub api.
/// </summary>
public enum OperationStatus
{
    Susseess,
    Error,
    NotFound,
    UnknownState
}