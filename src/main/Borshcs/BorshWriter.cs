using System;
using System.IO;

/* This is free and unencumbered software released into the public domain. */

namespace Borshcs
{

	using NonNull = androidx.annotation.NonNull;

	public class BorshWriter : BorshOutput<BorshWriter>, System.IDisposable, Flushable
	{
	  protected internal readonly Stream stream;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public BorshWriter(final @NonNull OutputStream stream)
	  public BorshWriter(in Stream stream)
	  {
		this.stream = requireNonNull(stream);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void close() throws java.io.IOException
	  public virtual void Dispose()
	  {
		this.stream.Close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: @Override public void flush() throws java.io.IOException
	  public override void flush()
	  {
		this.stream.Flush();
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshWriter write(final @NonNull byte[] array)
	  internal virtual BorshWriter write(in sbyte[] array)
	  {
		try
		{
		  this.stream.Write(array, 0, array.Length);
		  return this;
		}
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not available in C#:
//ORIGINAL LINE: catch (final java.io.IOException error)
		catch (IOException error)
		{
		  throw new Exception(error);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshWriter write(final byte b)
	  internal virtual BorshWriter write(in sbyte b)
	  {
		try
		{
		  this.stream.WriteByte(b);
		  return this;
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