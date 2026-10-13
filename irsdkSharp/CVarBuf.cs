using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace iRSDKSharp
{
    public class CVarBuf
    {
        public const int VarHeaderOffset = 56;
        public int VarHeaderSize = 144;
        //VarBuf offsets
        public int VarBufOffset = 48;
        public const int VarTickCountOffset = 0;
        public const int VarBufOffsetOffset = 4;
        public int VarBufSize = 32;

        MemoryMappedViewAccessor FileMapView = null;
        CiRSDKHeader Header = null;

        public CVarBuf(MemoryMappedViewAccessor mapView, CiRSDKHeader header)
        {
            FileMapView = mapView;
            Header = header;
            VarHeaderSize = Marshal.SizeOf(typeof(VarHeader));
            VarBufSize = Marshal.SizeOf(typeof(VarBuf));
        }

        /// <summary>
        /// The tick count of the most recently written buffer.
        /// </summary>
        public int TickCount
        {
            get
            {
                return FileMapView.ReadInt32(VarBufOffset + ((Latest * VarBufSize) + VarTickCountOffset));
            }
        }

        /// <summary>
        /// The tick count that is updated before a write starts, used to detect
        /// torn reads (a write that was in progress while reading).
        /// </summary>
        public int TickCountBegin
        {
            get
            {
                return FileMapView.ReadInt32(VarBufOffset + ((Latest * VarBufSize) + VarTickCountOffset + 4 + 4));
            }
        }

        /// <summary>
        /// Index of the most recently written buffer as reported by the header.
        /// Falls back to buffer 0 if the value is out of range.
        /// </summary>
        public int Latest
        {
            get
            {
                int latest = Header.CurBuf;
                if (latest < 0 || latest >= Header.BufferCount)
                    latest = 0;
                return latest;
            }
        }

        /// <summary>
        /// Byte offset of the most recently written buffer.
        /// </summary>
        public int OffsetLatest
        {
            get
            {
                return FileMapView.ReadInt32(VarBufOffset + ((Latest * VarBufSize) + VarBufOffsetOffset));
            }
        }

        /// <summary>
        /// Byte offset of the buffer at the specified index.
        /// </summary>
        public int Offset(int index)
        {
            if (index < 0 || index >= Header.BufferCount)
                index = 0;
            return FileMapView.ReadInt32(VarBufOffset + ((index * VarBufSize) + VarBufOffsetOffset));
        }
    }
}
