using System;
using System.IO;

/* This is free and unencumbered software released into the public domain. */

namespace Borshcs
{

	using NonNull = androidx.annotation.NonNull;

	public class BorshReader : BorshInput, System.IDisposable
	{
	  private readonly Stream stream;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public BorshReader(final @NonNull InputStream stream)
	  public BorshReader(in Stream stream)
	  {
		this.stream = requireNonNull(stream);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void close() throws java.io.IOException
	  public virtual void Dispose()
	  {
		this.stream.Close();
	  }

	  public virtual sbyte read()
	  {
		try
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int result = this.stream.read();
		  int result = this.stream.Read();
		  if (result == -1)
		  {
			throw new EOFException();
		  }
		  return (sbyte)result;
		}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not available in C#:
//ORIGINAL LINE: catch (final java.io.IOException error)
		catch (IOException error)
		{
		  throw new Exception(error);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public void read(final @NonNull byte[] result, final int offset, final int length)
	  public virtual void read(in sbyte[] result, in int offset, in int length)
	  {
		if (offset < 0 || length < 0 || length > result.Length - offset)
		{
		  throw new System.IndexOutOfRangeException();
		}
		try
		{
		  int n = 0;
		  while (n < length)
		  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int count = this.stream.read(result, offset + n, length - n);
			int count = this.stream.Read(result, offset + n, length - n);
			if (count == -1)
			{
			  throw new EOFException();
			}
			n += count;
		  }
		}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not available in C#:
//ORIGINAL LINE: catch (final java.io.IOException error)
		catch (IOException error)
		{
		  throw new Exception(error);
		}
	  }
	}

}