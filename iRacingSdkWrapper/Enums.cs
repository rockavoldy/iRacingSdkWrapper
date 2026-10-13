using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iRacingSdkWrapper
{
    public enum TrackSurfaces
    {
        NotInWorld = -1,
        OffTrack,
        InPitStall,
        AproachingPits,
        OnTrack
    }

    public enum SessionStates
    {
        Invalid,
        GetInCar,
        Warmup,
        ParadeLaps,
        Racing,
        Checkered,
        CoolDown
    }

    /// <summary>
    /// Track surface material type. Unit: irsdk_TrkSurf
    /// </summary>
    public enum TrackSurfaceMaterials
    {
        NotInWorld = -1,
        UndefinedMaterial = 0,

        Asphalt1Material,
        Asphalt2Material,
        Asphalt3Material,
        Asphalt4Material,
        Concrete1Material,
        Concrete2Material,
        RacingDirt1Material,
        RacingDirt2Material,
        Paint1Material,
        Paint2Material,
        Rumble1Material,
        Rumble2Material,
        Rumble3Material,
        Rumble4Material,

        Grass1Material,
        Grass2Material,
        Grass3Material,
        Grass4Material,
        Dirt1Material,
        Dirt2Material,
        Dirt3Material,
        Dirt4Material,
        SandMaterial,
        Gravel1Material,
        Gravel2Material,
        GrasscreteMaterial,
        AstroturfMaterial
    }

    /// <summary>
    /// Pacing mode. Unit: irsdk_PaceMode
    /// </summary>
    public enum PaceModes
    {
        SingleFileStart = 0,
        DoubleFileStart,
        SingleFileRestart,
        DoubleFileRestart,
        NotPacing
    }

    /// <summary>
    /// Pacing status flags for each car. Unit: irsdk_PaceFlags
    /// </summary>
    [Flags]
    public enum PaceFlags : uint
    {
        None = 0x0000,
        EndOfLine = 0x0001,
        FreePass = 0x0002,
        WavedAround = 0x0004
    }

    /// <summary>
    /// Pit service status. Unit: irsdk_PitSvStatus
    /// </summary>
    public enum PitServiceStatus
    {
        None = 0,
        InProgress,
        Complete,

        // errors
        TooFarLeft = 100,
        TooFarRight,
        TooFarForward,
        TooFarBack,
        BadAngle,
        CantFixThat
    }

    /// <summary>
    /// Track wetness. Unit: irsdk_TrackWetness
    /// </summary>
    public enum TrackWetness
    {
        Unknown = 0,
        Dry,
        MostlyDry,
        VeryLightlyWet,
        LightlyWet,
        ModeratelyWet,
        VeryWet,
        ExtremelyWet
    }

    /// <summary>
    /// Incident report flags. First byte of the incident bitfield.
    /// </summary>
    public enum IncidentReportFlags
    {
        NoReport = 0x0000,
        OutOfControl = 0x0001,
        OffTrack = 0x0002,
        OffTrackOngoing = 0x0003,
        ContactWithWorld = 0x0004,
        CollisionWithWorld = 0x0005,
        CollisionWithWorldOngoing = 0x0006,
        ContactWithCar = 0x0007,
        CollisionWithCar = 0x0008
    }

    /// <summary>
    /// Incident penalty flags. Second byte of the incident bitfield.
    /// </summary>
    public enum IncidentPenaltyFlags
    {
        NoReport = 0x0000,
        ZeroX = 0x0100,
        OneX = 0x0200,
        TwoX = 0x0300,
        FourX = 0x0400
    }

    public static class IncidentFlags
    {
        public const uint ReportMask = 0x000000FF;
        public const uint PenaltyMask = 0x0000FF00;

        public static IncidentReportFlags GetReport(uint flags)
        {
            return (IncidentReportFlags)(flags & ReportMask);
        }

        public static IncidentPenaltyFlags GetPenalty(uint flags)
        {
            return (IncidentPenaltyFlags)(flags & PenaltyMask);
        }
    }
}
