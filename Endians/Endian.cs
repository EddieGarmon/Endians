using System;

namespace Endians;

public static class Endian
{

    public static IEndian Big { get; } = new BigEndian();

    public static IEndian Intel => Little;

    public static IEndian Little { get; } = new LittleEndian();

    public static bool MachineIsLittleEndian => BitConverter.IsLittleEndian;

    public static IEndian Motorola => Big;

    public static short Swap(short value) {
        return (short)Swap((ushort)value);
    }

    public static ushort Swap(ushort value) {
        uint temp = (value & 0x00ffu) << 8;
        temp |= (value & 0xff00u) >> 8;
        return (ushort)temp;
    }

    public static int Swap(int value) {
        return (int)Swap((uint)value);
    }

    public static uint Swap(uint value) {
        uint temp = (value & 0x000000ffu) << 24;
        temp |= (value & 0x0000ff00u) << 8;
        temp |= (value & 0x00ff0000u) >> 8;
        temp |= (value & 0xff000000u) >> 24;
        return temp;
    }

    public static long Swap(long value) {
        return (long)Swap((ulong)value);
    }

    public static ulong Swap(ulong value) {
        ulong temp = (value & 0x00000000000000FFul) << 56;
        temp |= (value & 0x000000000000FF00ul) << 40;
        temp |= (value & 0x0000000000FF0000ul) << 24;
        temp |= (value & 0x00000000FF000000ul) << 8;
        temp |= (value & 0x000000FF00000000ul) >> 8;
        temp |= (value & 0x0000FF0000000000ul) >> 24;
        temp |= (value & 0x00FF000000000000ul) >> 40;
        temp |= (value & 0xFF00000000000000ul) >> 56;
        return temp;
    }

}