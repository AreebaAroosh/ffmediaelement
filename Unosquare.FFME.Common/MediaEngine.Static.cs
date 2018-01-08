﻿namespace Unosquare.FFME
{
    using Shared;
    using System;

    public partial class MediaEngine
    {
        /// <summary>
        /// The initialize lock
        /// </summary>
        private static readonly object InitLock = new object();

        /// <summary>
        /// The has intialized flag
        /// </summary>
        private static bool IsIntialized = default(bool);

        /// <summary>
        /// The ffmpeg directory
        /// </summary>
        private static string m_FFmpegDirectory = Defaults.FFmpegSearchPath;

        /// <summary>
        /// Stores the load mode flags
        /// </summary>
        private static int m_FFmpegLoadModeFlags = FFmpegLoadMode.FullFeatures;

        /// <summary>
        /// Gets the platform-specific implementation requirements.
        /// </summary>
        public static IPlatform Platform { get; private set; }

        /// <summary>
        /// Gets or sets the FFmpeg path from which to load the FFmpeg binaries.
        /// You must set this path before setting the Source property for the first time on any instance of this control.
        /// Settng this property when FFmpeg binaries have been registered will throw an exception.
        /// </summary>
        public static string FFmpegDirectory
        {
            get => m_FFmpegDirectory;
            set
            {
                if (IsFFmpegLoaded.Value == false)
                {
                    m_FFmpegDirectory = value;
                    return;
                }

                if ((value?.Equals(m_FFmpegDirectory) ?? false) == false)
                    throw new InvalidOperationException($"Unable to set a new FFmpeg registration path: {value}. FFmpeg binaries have already been registered.");
            }
        }

        /// <summary>
        /// Gets or sets the bitwise library identifiers to load.
        /// If FFmpeg is already loaded, the value cannot be changed.
        /// </summary>
        public static int FFmpegLoadModeFlags
        {
            get
            {
                return m_FFmpegLoadModeFlags;
            }
            set
            {
                if (IsFFmpegLoaded.Value)
                    return;

                m_FFmpegLoadModeFlags = value;
            }
        }

        /// <summary>
        /// Initializes the MedieElementCore.
        /// </summary>
        /// <param name="platform">The platform-specific implementation.</param>
        public static void Initialize(IPlatform platform)
        {
            lock (InitLock)
            {
                if (IsIntialized)
                    return;

                Platform = platform;
                IsIntialized = true;
            }
        }
    }
}