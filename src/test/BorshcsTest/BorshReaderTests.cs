using System.IO;

/* This is free and unencumbered software released into the public domain. */

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//import static org.junit.jupiter.api.Assertions.*;

using BeforeEach = org.junit.jupiter.api.BeforeEach;
using Test = org.junit.jupiter.api.Test;
using BorshReader = Borshcs.BorshReader;

public class BorshReaderTests
{
  private MemoryStream input;
  private BorshReader reader;

  protected internal virtual BorshReader newReader(in sbyte[] bytes)
  {
	input = new MemoryStream(bytes);
	reader = new BorshReader(input);
	return reader;
  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test void constructWithNull()
  internal virtual void constructWithNull()
  {
	assertThrows(typeof(System.NullReferenceException), () => new BorshReader(null));
  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test void parseInput()
  internal virtual void parseInput()
  {
	assertEquals("Borsh", newReader(new sbyte[] {5, 0, 0, 0, (sbyte)'B', (sbyte)'o', (sbyte)'r', (sbyte)'s', (sbyte)'h'}).readString());
  }
}
