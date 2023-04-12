using Shouldly;
using Xunit;

namespace Endians.Tests;

public class BigEndianReadTests
{

    [Fact]
    public void ReadIntegers() {
        byte[] data = { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70 };
        Endian.Big.ReadInt(data).ShouldBe(0x10203040);
        Endian.Big.ReadInt(data, 1).ShouldBe(0x20304050);
        Endian.Big.ReadInt(data, 2).ShouldBe(0x30405060);
    }

    [Fact]
    public void ReadLongs() {
        byte[] data = { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90, 0xA0 };
        Endian.Big.ReadLong(data).ShouldBe(0x1020304050607080);
        Endian.Big.ReadLong(data, 1).ShouldBe(0x2030405060708090);
        Endian.Big.ReadLong(data, 2).ShouldBe(0x30405060708090A0);
    }

    [Fact]
    public void ReadShorts() {
        byte[] data = { 0x10, 0x20, 0x30, 0x40 };
        Endian.Big.ReadShort(data).ShouldBe((short)0x1020);
        Endian.Big.ReadShort(data, 1).ShouldBe((short)0x2030);
        Endian.Big.ReadShort(data, 2).ShouldBe((short)0x3040);
    }

}