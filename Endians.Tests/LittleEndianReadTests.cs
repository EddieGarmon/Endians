using Shouldly;
using Xunit;

namespace Endians.Tests;

public class LittleEndianReadTests
{

    [Fact]
    public void ReadIntegers() {
        byte[] data = { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70 };
        Endian.Little.ReadInt(data).ShouldBe(0x40302010);
        Endian.Little.ReadInt(data, 1).ShouldBe(0x50403020);
        Endian.Little.ReadInt(data, 2).ShouldBe(0x60504030);
    }

    [Fact]
    public void ReadLongs() {
        byte[] data = { 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80, 0x90, 0xA0 };
        Endian.Little.ReadLong(data).ShouldBe(unchecked((long)0x8070605040302010));
        Endian.Little.ReadLong(data, 1).ShouldBe(unchecked((long)0x9080706050403020));
        Endian.Little.ReadLong(data, 2).ShouldBe(unchecked((long)0xA090807060504030));
    }

    [Fact]
    public void ReadShorts() {
        byte[] data = { 0x10, 0x20, 0x30, 0x40 };
        Endian.Little.ReadShort(data).ShouldBe((short)0x2010);
        Endian.Little.ReadShort(data, 1).ShouldBe((short)0x3020);
        Endian.Little.ReadShort(data, 2).ShouldBe((short)0x4030);
    }

}