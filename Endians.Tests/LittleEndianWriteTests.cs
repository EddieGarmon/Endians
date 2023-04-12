using Shouldly;
using Xunit;

namespace Endians.Tests;

public class LittleEndianWriteTests
{

    [Fact]
    public void WriteIntegers() {
        byte[] data = new byte[6];
        Endian.Little.WriteValue(0x01020304, data, 0);
        data.ShouldBe(new byte[] { 0x04, 0x03, 0x02, 0x01, 0x00, 0x00 });

        data = new byte[6];
        Endian.Little.WriteValue(0x01020304, data, 1);
        data.ShouldBe(new byte[] { 0x00, 0x04, 0x03, 0x02, 0x01, 0x00 });

        data = new byte[6];
        Endian.Little.WriteValue(0x01020304, data, 2);
        data.ShouldBe(new byte[] { 0x00, 0x00, 0x04, 0x03, 0x02, 0x01 });
    }

    [Fact]
    public void WriteLongs() {
        byte[] data = new byte[10];
        Endian.Little.WriteValue(0x0102030405060708, data, 0);
        data.ShouldBe(new byte[] { 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00, 0x00 });

        data = new byte[10];
        Endian.Little.WriteValue(0x0102030405060708, data, 1);
        data.ShouldBe(new byte[] { 0x00, 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00 });

        data = new byte[10];
        Endian.Little.WriteValue(0x0102030405060708, data, 2);
        data.ShouldBe(new byte[] { 0x00, 0x00, 0x08, 0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01 });
    }

    [Fact]
    public void WriteShorts() {
        byte[] data = new byte[4];
        Endian.Little.WriteValue((short)12, data, 0);
        data.ShouldBe(new byte[] { 0x0C, 0x00, 0x00, 0x00 });

        data = new byte[4];
        Endian.Little.WriteValue((short)12, data, 1);
        data.ShouldBe(new byte[] { 0x00, 0x0C, 0x00, 0x00 });

        data = new byte[4];
        Endian.Little.WriteValue((short)12, data, 2);
        data.ShouldBe(new byte[] { 0x00, 0x00, 0x0C, 0x00 });
    }

}