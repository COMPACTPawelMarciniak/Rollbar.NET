﻿namespace Rollbar.DTOs
{
    using Rollbar.Common;
    using System.Collections.Generic;

    /// <summary>
    /// Abstract base for creating host data elements (like Server or Client)
    /// </summary>
    /// <seealso cref="Rollbar.DTOs.ExtendableDtoBase" />
    public abstract class HostBase
        : ExtendableDtoBase
    {
        /// <summary>
        /// The DTO reserved properties.
        /// </summary>
        public static class ReservedProperties
        {
            /// <summary>
            /// The CPU architecture
            /// </summary>
            public static readonly string Cpu = "cpu";
        }

        static HostBase()
        {
            HostBase.DetectedCpu = RuntimeEnvironmentUtility.GetCpuArchitecture();
        }

        private static readonly string DetectedCpu;

        /// <summary>
        /// Prevents a default instance of the <see cref="HostBase"/> class from being created.
        /// </summary>
        private HostBase()
            : this(null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HostBase"/> class.
        /// </summary>
        /// <param name="arbitraryKeyValuePairs">The arbitrary key value pairs.</param>
        protected HostBase(IDictionary<string, object> arbitraryKeyValuePairs)
            : base(arbitraryKeyValuePairs)
        {
            this.Cpu = HostBase.DetectedCpu;
        }

        /// <summary>
        /// Gets or sets the CPU architecture.
        /// </summary>
        /// <value>
        /// The CPU architecture.
        /// </value>
        public string Cpu
        {
            get { return this._keyedValues[ReservedProperties.Cpu] as string; }
            set { this._keyedValues[ReservedProperties.Cpu] = value; }
        }

    }
}
