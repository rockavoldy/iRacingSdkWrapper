using System;
using iRSDKSharp;

namespace iRacingSdkWrapper.Broadcast
{
    /// <summary>
    /// Provides control over the force feedback system.
    /// </summary>
    public class FFBControl : BroadcastBase
    {
        internal FFBControl(SdkWrapper wrapper) : base(wrapper)
        {
        }

        /// <summary>
        /// Set the maximum force when mapping steering torque force to direct input units.
        /// Pass a negative value to let the user control the FFB strength.
        /// </summary>
        /// <param name="force">The maximum force in Nm, or a negative value to use the user controlled FFB strength.</param>
        public void SetMaxForce(float force)
        {
            Broadcast(BroadcastMessageTypes.FFBCommand, (int)FFBCommandModeTypes.MaxForce, force);
        }
    }
}
