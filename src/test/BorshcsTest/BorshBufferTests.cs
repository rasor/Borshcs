using System.Numerics;

/* This is free and unencumbered software released into the public domain. */

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//import static org.junit.jupiter.api.Assertions.*;

using BeforeEach = org.junit.jupiter.api.BeforeEach;
using Test = org.junit.jupiter.api.Test;
using BorshBuffer = Borshcs.BorshBuffer;

public class BorshBufferTests
{
	private BorshBuffer buffer;
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @BeforeEach void newBuffer()
	internal virtual void newBuffer()
	{
		buffer = BorshBuffer.allocate(256);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readU8()
	internal virtual void readU8()
	{
		buffer = BorshBuffer.wrap(new sbyte[] { 0x42 });
		assertEquals(0x42, buffer.readU8());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readU16()
	internal virtual void readU16()
	{
		buffer = BorshBuffer.wrap(new sbyte[] { 0x11, 0x00 });
		assertEquals(0x0011, buffer.readU16());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readU32()
	internal virtual void readU32()
	{
		buffer = BorshBuffer.wrap(new sbyte[] { 0x33, 0x22, 0x11, 0x00 });
		assertEquals(0x00112233, buffer.readU32());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readU64()
	internal virtual void readU64()
	{
		buffer = BorshBuffer.wrap(new sbyte[] { 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00 });
		assertEquals(0x0011223344556677L, buffer.readU64());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readU128()
	internal virtual void readU128()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] input = new byte[] { 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
		sbyte[] input = new sbyte[] { 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		buffer = BorshBuffer.wrap(input);
		assertEquals(BigInteger.valueOf(0x0011223344556677L), buffer.readU128());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readF32()
	internal virtual void readF32()
	{
		assertEquals(0.0f, BorshBuffer.wrap(new sbyte[] { 0, 0, 0, 0 }).readF32());
		assertEquals(1.0f, BorshBuffer.wrap(new sbyte[] { 0, 0, unchecked((sbyte)0x80), (sbyte)0x3f }).readF32());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readF64()
	internal virtual void readF64()
	{
		assertEquals(0.0, BorshBuffer.wrap(new sbyte[] { 0, 0, 0, 0, 0, 0, 0, 0 }).readF64());
		assertEquals(1.0, BorshBuffer.wrap(new sbyte[] { 0, 0, 0, 0, 0, 0, unchecked((sbyte)0xf0), (sbyte)0x3f }).readF64());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readString()
	internal virtual void readString()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] input = new byte[] {5, 0, 0, 0, 'B', 'o', 'r', 's', 'h'};
		sbyte[] input = new sbyte[] { 5, 0, 0, 0, (sbyte)'B', (sbyte)'o', (sbyte)'r', (sbyte)'s', (sbyte)'h' };
		buffer = BorshBuffer.wrap(input);
		assertEquals("Borsh", buffer.readString());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readFixedArray()
	internal virtual void readFixedArray()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] input = new byte[]{1, 2, 3, 4, 5};
		sbyte[] input = new sbyte[] { 1, 2, 3, 4, 5 };
		buffer = BorshBuffer.wrap(input);
		assertEquals(0, buffer.reset().readFixedArray(0).length);
		assertEquals(1, buffer.reset().readFixedArray(1).length);
		assertEquals(5, buffer.reset().readFixedArray(5).length);
		assertArrayEquals(input, buffer.reset().readFixedArray(5));
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readArray()
	internal virtual void readArray()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] input = new byte[]{3, 0, 0, 0, 1, 0, 2, 0, 3, 0};
		sbyte[] input = new sbyte[] { 3, 0, 0, 0, 1, 0, 2, 0, 3, 0 };
		buffer = BorshBuffer.wrap(input);
		assertArrayEquals(new short?[] { 1, 2, 3 }, buffer.readArray(typeof(Short)));
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readBoolean()
	internal virtual void readBoolean()
	{
		assertEquals(false, BorshBuffer.wrap(new sbyte[] { 0 }).readBoolean());
		assertEquals(true, BorshBuffer.wrap(new sbyte[] { 1 }).readBoolean());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void readOptional()
	internal virtual void readOptional()
	{
		assertEquals(null, BorshBuffer.wrap(new sbyte[] { 0 }).readOptional());
		assertEquals(42, BorshBuffer.wrap(new sbyte[] { 1, 42, 0, 0, 0 }).readOptional(typeof(Integer)));
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeU8()
	internal virtual void writeU8()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeU8(0x42).toByteArray();
		sbyte[] actual = buffer.writeU8(0x42).toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] {0x42};
		sbyte[] expected = new sbyte[] { 0x42 };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeU16()
	internal virtual void writeU16()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeU16(0x0011).toByteArray();
		sbyte[] actual = buffer.writeU16(0x0011).toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] {0x11, 0x00};
		sbyte[] expected = new sbyte[] { 0x11, 0x00 };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeU32()
	internal virtual void writeU32()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeU32(0x00112233).toByteArray();
		sbyte[] actual = buffer.writeU32(0x00112233).toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] {0x33, 0x22, 0x11, 0x00};
		sbyte[] expected = new sbyte[] { 0x33, 0x22, 0x11, 0x00 };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeU64()
	internal virtual void writeU64()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeU64(0x0011223344556677L).toByteArray();
		sbyte[] actual = buffer.writeU64(0x0011223344556677L).toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] { 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00};
		sbyte[] expected = new sbyte[] { 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00 };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeU128()
	internal virtual void writeU128()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeU128(0x0011223344556677L).toByteArray();
		sbyte[] actual = buffer.writeU128(0x0011223344556677L).toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] { 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
		sbyte[] expected = new sbyte[] { 0x77, 0x66, 0x55, 0x44, 0x33, 0x22, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeF32()
	internal virtual void writeF32()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeF32(1.0f).toByteArray();
		sbyte[] actual = buffer.writeF32(1.0f).toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] {0, 0, (byte)0x80, (byte)0x3f};
		sbyte[] expected = new sbyte[] { 0, 0, unchecked((sbyte)0x80), (sbyte)0x3f };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeF64()
	internal virtual void writeF64()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeF64(1.0).toByteArray();
		sbyte[] actual = buffer.writeF64(1.0).toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] {0, 0, 0, 0, 0, 0, (byte)0xf0, (byte)0x3f};
		sbyte[] expected = new sbyte[] { 0, 0, 0, 0, 0, 0, unchecked((sbyte)0xf0), (sbyte)0x3f };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeString()
	internal virtual void writeString()
	{
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.writeString("Borsh").toByteArray();
		sbyte[] actual = buffer.writeString("Borsh").toByteArray();
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[] {5, 0, 0, 0, 'B', 'o', 'r', 's', 'h'};
		sbyte[] expected = new sbyte[] { 5, 0, 0, 0, (sbyte)'B', (sbyte)'o', (sbyte)'r', (sbyte)'s', (sbyte)'h' };
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeFixedArray()
	internal virtual void writeFixedArray()
	{
		buffer.writeFixedArray(new sbyte[] { 1, 2, 3, 4, 5 });
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[]{1, 2, 3, 4, 5};
		sbyte[] expected = new sbyte[] { 1, 2, 3, 4, 5 };
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.toByteArray();
		sbyte[] actual = buffer.toByteArray();
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeArray()
	internal virtual void writeArray()
	{
		buffer.writeArray(new short?[] { 1, 2, 3 });
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[]{3, 0, 0, 0, 1, 0, 2, 0, 3, 0};
		sbyte[] expected = new sbyte[] { 3, 0, 0, 0, 1, 0, 2, 0, 3, 0 };
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.toByteArray();
		sbyte[] actual = buffer.toByteArray();
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeArrayOfList()
	internal virtual void writeArrayOfList()
	{
		buffer.writeArray(Arrays.asList(new short?[] { 1, 2, 3 }));
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] expected = new byte[]{3, 0, 0, 0, 1, 0, 2, 0, 3, 0};
		sbyte[] expected = new sbyte[] { 3, 0, 0, 0, 1, 0, 2, 0, 3, 0 };
		//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
		//ORIGINAL LINE: final byte[] actual = buffer.toByteArray();
		sbyte[] actual = buffer.toByteArray();
		assertArrayEquals(expected, actual);
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeBoolean()
	internal virtual void writeBoolean()
	{
		assertArrayEquals(new sbyte[] { 0 }, buffer.reset().writeBoolean(false).toByteArray());
		assertArrayEquals(new sbyte[] { 1 }, buffer.reset().writeBoolean(true).toByteArray());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void writeOptional()
	internal virtual void writeOptional()
	{
		assertArrayEquals(new sbyte[] { 0 }, buffer.reset().writeOptional(null).toByteArray());
		assertArrayEquals(new sbyte[] { 1, 42, 0, 0, 0 }, buffer.reset().writeOptional(42).toByteArray());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void testF32()
	internal virtual void testF32()
	{
		const float value = 3.1415f;
		assertEquals(value, BorshBuffer.wrap(buffer.writeF32(value).toByteArray()).readF32());
	}
	//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
	//ORIGINAL LINE: @Test void testF64()
	internal virtual void testF64()
	{
		const double value = 3.1415;
		assertEquals(value, BorshBuffer.wrap(buffer.writeF64(value).toByteArray()).readF64());
	}
}
