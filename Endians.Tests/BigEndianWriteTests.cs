using Shouldly;
using Xunit;

namespace Endians.Tests;

public class BigEndianWriteTests
{

    [Fact]
    public void WriteIntegers() {
        byte[] data = new byte[6];
        Endian.Big.WriteValue(0x01020304, data, 0);
        data.ShouldBe(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x00, 0x00 });

        data = new byte[6];
        Endian.Big.WriteValue(0x01020304, data, 1);
        data.ShouldBe(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x00 });

        data = new byte[6];
        Endian.Big.WriteValue(0x01020304, data, 2);
        data.ShouldBe(new byte[] { 0x00, 0x00, 0x01, 0x02, 0x03, 0x04 });
    }

    [Fact]
    public void WriteLongs() {
        byte[] data = new byte[10];
        Endian.Big.WriteValue(0x0102030405060708, data, 0);
        data.ShouldBe(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x00, 0x00 });

        data = new byte[10];
        Endian.Big.WriteValue(0x0102030405060708, data, 1);
        data.ShouldBe(new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x00 });

        data = new byte[10];
        Endian.Big.WriteValue(0x0102030405060708, data, 2);
        data.ShouldBe(new byte[] { 0x00, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 });
    }

    [Fact]
    public void WriteShorts() {
        byte[] data = new byte[4];
        Endian.Big.WriteValue((short)12, data, 0);
        data.ShouldBe(new byte[] { 0x00, 0x0C, 0x00, 0x00 });

        data = new byte[4];
        Endian.Big.WriteValue((short)12, data, 1);
        data.ShouldBe(new byte[] { 0x00, 0x00, 0x0C, 0x00 });

        data = new byte[4];
        Endian.Big.WriteValue((short)12, data, 2);
        data.ShouldBe(new byte[] { 0x00, 0x00, 0x00, 0x0C });
    }

}