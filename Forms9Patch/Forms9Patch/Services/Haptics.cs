﻿using System;
using Forms9Patch.Interfaces;
using Xamarin.Forms;

namespace Forms9Patch
{
    /// <summary>
    /// Access to device's haptic feedback system
    /// </summary>
    public static class Haptics
    {
        static Haptics()
            => Settings.ConfirmInitialization();

        static IHapticsService _service;
        static IHapticsService Service => _service = _service ?? DependencyService.Get<IHapticsService>();

        /// <summary>
        /// Invoke haptic feedback
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="mode"></param>
        [Obsolete("Use Forms9Patch.Feedback.PlayHaptic")]
        public static void Feedback(HapticEffect effect, FeedbackMode mode = default)
            => throw new Exception("OBSOLETE: Use Forms9Patch.Feedback.PlaySound");

    }
}
