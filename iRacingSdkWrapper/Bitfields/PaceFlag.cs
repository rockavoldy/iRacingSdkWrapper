using System;

namespace iRacingSdkWrapper.Bitfields
{
    /// <summary>
    /// Pacing status flags for a car. Unit: irsdk_PaceFlags
    /// </summary>
    public class PaceFlag : BitfieldBase<PaceFlags>
    {
        public PaceFlag() : this(0) { }

        public PaceFlag(int value) : base(value)
        {
        }
    }
}
