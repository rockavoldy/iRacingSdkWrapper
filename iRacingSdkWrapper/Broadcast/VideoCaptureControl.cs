using System;
using iRSDKSharp;

namespace iRacingSdkWrapper.Broadcast
{
    /// <summary>
    /// Provides control over the video capture system.
    /// </summary>
    public class VideoCaptureControl : BroadcastBase
    {
        internal VideoCaptureControl(SdkWrapper wrapper) : base(wrapper)
        {
        }

        /// <summary>
        /// Save a screenshot to disk.
        /// </summary>
        public void TriggerScreenShot()
        {
            Broadcast(BroadcastMessageTypes.VideoCapture, (int)VideoCaptureModeTypes.TriggerScreenShot, 0);
        }

        /// <summary>
        /// Start capturing video.
        /// </summary>
        public void StartCapture()
        {
            Broadcast(BroadcastMessageTypes.VideoCapture, (int)VideoCaptureModeTypes.StartVideoCapture, 0);
        }

        /// <summary>
        /// Stop capturing video.
        /// </summary>
        public void StopCapture()
        {
            Broadcast(BroadcastMessageTypes.VideoCapture, (int)VideoCaptureModeTypes.EndVideoCapture, 0);
        }

        /// <summary>
        /// Toggle video capture on or off.
        /// </summary>
        public void ToggleCapture()
        {
            Broadcast(BroadcastMessageTypes.VideoCapture, (int)VideoCaptureModeTypes.ToggleVideoCapture, 0);
        }

        /// <summary>
        /// Show the video timer in the upper left corner of the display.
        /// </summary>
        public void ShowTimer()
        {
            Broadcast(BroadcastMessageTypes.VideoCapture, (int)VideoCaptureModeTypes.ShowVideoTimer, 0);
        }

        /// <summary>
        /// Hide the video timer.
        /// </summary>
        public void HideTimer()
        {
            Broadcast(BroadcastMessageTypes.VideoCapture, (int)VideoCaptureModeTypes.HideVideoTimer, 0);
        }
    }
}
