using System;

namespace Endians;

internal abstract class EndianBase : IEndian
{

    public int ReadInt(ReadOnlySpan<byte> buffer, int startIndex = 0) {
        ValidateBuffer(buffer, startIndex, 4);
        return unchecked((int)Extract(buffer, startIndex, 4));
    }

    public long ReadLong(ReadOnlySpan<byte> buffer, int startIndex = 0) {
        ValidateBuffer(buffer, startIndex, 8);
        return Extract(buffer, startIndex, 8);
    }

    public short ReadShort(ReadOnlySpan<byte> buffer, int startIndex = 0) {
        ValidateBuffer(buffer, startIndex, 2);
        return unchecked((short)Extract(buffer, startIndex, 2));
    }

    public uint ReadUInt(ReadOnlySpan<byte> buffer, int startIndex = 0) {
        ValidateBuffer(buffer, startIndex, 4);
        return unchecked((uint)Extract(buffer, startIndex, 4));
    }

    public ulong ReadULong(ReadOnlySpan<byte> buffer, int startIndex = 0) {
        ValidateBuffer(buffer, startIndex, 8);
        return unchecked((ulong)Extract(buffer, startIndex, 8));
    }

    public ushort ReadUShort(ReadOnlySpan<byte> buffer, int startIndex = 0) {
        ValidateBuffer(buffer, startIndex, 2);
        return unchecked((ushort)Extract(buffer, startIndex, 2));
    }

    public byte[] ToBytes(short value) {
        byte[] result = new byte[2];
        Fill(result, value, 0, 2);
        return result;
    }

    public byte[] ToBytes(ushort value) {
        byte[] result = new byte[2];
        Fill(result, value, 0, 2);
        return result;
    }

    public byte[] ToBytes(int value) {
        byte[] result = new byte[4];
        Fill(result, value, 0, 4);
        return result;
    }

    public byte[] ToBytes(uint value) {
        byte[] result = new byte[4];
        Fill(result, value, 0, 4);
        return result;
    }

    public byte[] ToBytes(long value) {
        byte[] result = new byte[8];
        Fill(result, value, 0, 8);
        return result;
    }

    public byte[] ToBytes(ulong value) {
        byte[] result = new byte[8];
        Fill(result, unchecked((long)value), 0, 8);
        return result;
    }

    public void WriteValue(short value, Span<byte> buffer, int startIndex) {
        ValidateBuffer(buffer, startIndex, 2);
        Fill(buffer, value, startIndex, 2);
    }

    public void WriteValue(ushort value, Span<byte> buffer, int startIndex) {
        ValidateBuffer(buffer, startIndex, 2);
        Fill(buffer, value, startIndex, 2);
    }

    public void WriteValue(int value, Span<byte> buffer, int startIndex) {
        ValidateBuffer(buffer, startIndex, 4);
        Fill(buffer, value, startIndex, 4);
    }

    public void WriteValue(uint value, Span<byte> buffer, int startIndex) {
        ValidateBuffer(buffer, startIndex, 4);
        Fill(buffer, value, startIndex, 4);
    }

    public void WriteValue(long value, Span<byte> buffer, int startIndex) {
        ValidateBuffer(buffer, startIndex, 8);
        Fill(buffer, value, startIndex, 8);
    }

    public void WriteValue(ulong value, Span<byte> buffer, int startIndex) {
        ValidateBuffer(buffer, startIndex, 8);
        Fill(buffer, unchecked((long)value), startIndex, 8);
    }

    protected abstract long Extract(ReadOnlySpan<byte> buffer, int startIndex, int length);

    protected abstract void Fill(Span<byte> buffer, long value, int startIndex, int length);

    private static void ValidateBuffer(ReadOnlySpan<byte> buffer, int startIndex, int length) {
        if (buffer == null) {
            throw new ArgumentNullException(nameof(buffer));
        }
        if (startIndex < 0 || startIndex >= buffer.Length) {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (startIndex + length > buffer.Length) {
            throw new ArgumentOutOfRangeException(nameof(length));
        }
    }

}