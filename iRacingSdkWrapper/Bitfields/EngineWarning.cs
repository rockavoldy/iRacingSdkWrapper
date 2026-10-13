using System;

namespace iRacingSdkWrapper.Bitfields
{
    public class EngineWarning : BitfieldBase<EngineWarnings>
    {
        public EngineWarning(int value)
            : base(value)
        {
        }
    }

    [Flags]
    public enum EngineWarnings : uint
    {
        WaterTemperatureWarning = 0x0001,
        FuelPressureWarning = 0x0002,
        OilPressureWarning = 0x0004,
        EngineStalled = 0x0008,
        PitSpeedLimiter = 0x0010,
        RevLimiterActive = 0x0020,
        OilTemperatureWarning = 0x0040,

        // car needs mandatory repairs
        MandatoryRepairsNeeded = 0x0080,
        // car needs optional repairs
        OptionalRepairsNeeded = 0x0100
    }
}
