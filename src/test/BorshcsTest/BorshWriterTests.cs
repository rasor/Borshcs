using System.IO;

/* This is free and unencumbered software released into the public domain. */

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//import static org.junit.jupiter.api.Assertions.*;

using BeforeEach = org.junit.jupiter.api.BeforeEach;
using Test = org.junit.jupiter.api.Test;
using BorshWriter = Borshcs.BorshWriter;

public class BorshWriterTests
{
  private MemoryStream output;
  private BorshWriter writer;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @BeforeEach void newWriter()
  internal virtual void newWriter()
  {
	output = new MemoryStream();
	writer = new BorshWriter(output);
  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test void constructWithNull()
  internal virtual void constructWithNull()
  {
	assertThrows(typeof(System.NullReferenceException), () => new BorshWriter(null));
  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test void captureOutput()
  internal virtual void captureOutput()
  {
	writer.writeString("Borsh");
	assertArrayEquals(new sbyte[] {5, 0, 0, 0, (sbyte)'B', (sbyte)'o', (sbyte)'r', (sbyte)'s', (sbyte)'h'}, output.toByteArray());
  }
}
