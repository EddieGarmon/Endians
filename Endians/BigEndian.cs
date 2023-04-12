using System;

namespace Endians;

/// <summary>
///     The native types are in machine endian, the byte[]s are in big endian
/// </summary>
internal class BigEndian : EndianBase
{

    protected override long Extract(ReadOnlySpan<byte> buffer, int startIndex, int length) {
        ReadOnlySpan<byte> slice = buffer.Slice(startIndex, length);
        long result = 0;
        unchecked {
            for (int i = 0; i < length; i++) {
                result = (result << 8) | slice[i];
            }
        }
        return result;
    }

    protected override void Fill(Span<byte> buffer, long value, int startIndex, int length) {
        Span<byte> slice = buffer.Slice(startIndex, length);
        unchecked {
            for (int i = length - 1; i >= 0; i--) {
                slice[i] = (byte)(value & 0xff);
                value >>= 8;
            }
        }
    }

}