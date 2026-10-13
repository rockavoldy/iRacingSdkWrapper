using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.MemoryMappedFiles;

namespace iRSDKSharp
{
    public class CiRSDKHeader
    {
        //Header offsets
        public const int HVerOffset = 0;
        public const int HStatusOffset = 4;
        public const int HTickRateOffset = 8;
        public const int HSesInfoUpdateOffset = 12;
        public const int HSesInfoLenOffset = 16;
        public const int HSesInfoOffsetOffset = 20;
        public const int HNumVarsOffset = 24;
        public const int HVarHeaderOffsetOffset = 28;
        public const int HNumBufOffset = 32;
        public const int HBufLenOffset = 36;
        public const int HCurBufTickCountOffset = 40;
        public const int HCurBufOffset = 44;

        MemoryMappedViewAccessor FileMapView = null;

        CVarBuf buffer = null;

        public CiRSDKHeader(MemoryMappedViewAccessor mapView)
        {
            FileMapView = mapView;
            buffer = new CVarBuf(mapView, this);
        }

        public int Version
        {
            get { return FileMapView.ReadInt32(HVerOffset); }
        }

        public int Status
        {
            get { return FileMapView.ReadInt32(HStatusOffset); }
        }

        public int TickRate
        {
            get { return FileMapView.ReadInt32(HTickRateOffset); }
        }

        public int SessionInfoUpdate
        {
            get { return FileMapView.ReadInt32(HSesInfoUpdateOffset); }
        }

        public int SessionInfoLength
        {
            get { return FileMapView.ReadInt32(HSesInfoLenOffset); }
        }

        public int SessionInfoOffset
        {
            get { return FileMapView.ReadInt32(HSesInfoOffsetOffset); }
        }

        public int VarCount
        {
            get { return FileMapView.ReadInt32(HNumVarsOffset); }
        }

        public int VarHeaderOffset
        {
            get { return FileMapView.ReadInt32(HVarHeaderOffsetOffset); }
        }

        public int BufferCount
        {
            get { return FileMapView.ReadInt32(HNumBufOffset); }
        }

        public int BufferLength
        {
            get { return FileMapView.ReadInt32(HBufLenOffset); }
        }

        /// <summary>
        /// Stashed copy of the current tick count, updated when new data is written.
        /// </summary>
        public int CurBufTickCount
        {
            get { return FileMapView.ReadInt32(HCurBufTickCountOffset); }
        }

        /// <summary>
        /// Index of the most recently written buffer (0 to BufferCount-1).
        /// </summary>
        public int CurBuf
        {
            get { return FileMapView.ReadByte(HCurBufOffset); }
        }

        public int Buffer
        {
            get
            {
                return buffer.OffsetLatest;
            }
        }
    }
}
