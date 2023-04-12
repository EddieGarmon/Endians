using System;

namespace Endians;

public interface IEndian
{

    int ReadInt(ReadOnlySpan<byte> buffer, int startIndex = 0);

    long ReadLong(ReadOnlySpan<byte> buffer, int startIndex = 0);

    short ReadShort(ReadOnlySpan<byte> buffer, int startIndex = 0);

    uint ReadUInt(ReadOnlySpan<byte> buffer, int startIndex = 0);

    ulong ReadULong(ReadOnlySpan<byte> buffer, int startIndex = 0);

    ushort ReadUShort(ReadOnlySpan<byte> buffer, int startIndex = 0);

    byte[] ToBytes(short value);

    byte[] ToBytes(ushort value);

    byte[] ToBytes(int value);

    byte[] ToBytes(uint value);

    byte[] ToBytes(long value);

    byte[] ToBytes(ulong value);

    void WriteValue(short value, Span<byte> buffer, int startIndex);

    void WriteValue(ushort value, Span<byte> buffer, int startIndex);

    void WriteValue(int value, Span<byte> buffer, int startIndex);

    void WriteValue(uint value, Span<byte> buffer, int startIndex);

    void WriteValue(long value, Span<byte> buffer, int startIndex);

    void WriteValue(ulong value, Span<byte> buffer, int startIndex);

}