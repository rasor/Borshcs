using System.Diagnostics;

/* This is free and unencumbered software released into the public domain. */

namespace Borshcs
{

	using NonNull = androidx.annotation.NonNull;

	public class BorshBuffer : BorshInput, BorshOutput<BorshBuffer>
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: protected final @NonNull ByteBuffer buffer;
	  protected internal readonly ByteBuffer buffer;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: protected BorshBuffer(final @NonNull ByteBuffer buffer)
	  protected internal BorshBuffer(in ByteBuffer buffer)
	  {
		this.buffer = requireNonNull(buffer);
		this.buffer.order(ByteOrder.LITTLE_ENDIAN);
		this.buffer.mark();
	  }
	  protected internal virtual sbyte[] array()
	  {
		Debug.Assert((this.buffer.hasArray()));
		return this.buffer.array();
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BorshBuffer allocate(final int capacity)
	  public static BorshBuffer allocate(in int capacity)
	  {
		return new BorshBuffer(ByteBuffer.allocate(capacity));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BorshBuffer allocateDirect(final int capacity)
	  public static BorshBuffer allocateDirect(in int capacity)
	  {
		return new BorshBuffer(ByteBuffer.allocateDirect(capacity));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull BorshBuffer wrap(final byte[] array)
	  public static BorshBuffer wrap(in sbyte[] array)
	  {
		return new BorshBuffer(ByteBuffer.wrap(array));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull byte[] toByteArray()
	  public virtual sbyte[] toByteArray()
	  {
		Debug.Assert((this.buffer.hasArray()));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int arrayOffset = this.buffer.arrayOffset();
		int arrayOffset = this.buffer.arrayOffset();
		return Arrays.CopyOfRange(this.buffer.array(), arrayOffset, arrayOffset + this.buffer.position());
	  }
	  public virtual int capacity()
	  {
		return this.buffer.capacity();
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull BorshBuffer reset()
	  public virtual BorshBuffer reset()
	  {
		this.buffer.reset();
		return this;
	  }
	  public virtual short readU16()
	  {
		return this.buffer.Short;
	  }
	  public virtual int readU32()
	  {
		return this.buffer.Int;
	  }
	  public virtual long readU64()
	  {
		return this.buffer.Long;
	  }
	  public virtual float readF32()
	  {
		return this.buffer.Float;
	  }
	  public virtual double readF64()
	  {
		return this.buffer.Double;
	  }
	  public virtual sbyte read()
	  {
		return this.buffer.get();
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public void read(final @NonNull byte[] result, final int offset, final int length)
	  public virtual void read(in sbyte[] result, in int offset, in int length)
	  {
		this.buffer.get(result, offset, length);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshBuffer writeU16(final short value)
	  internal virtual BorshBuffer writeU16(in short value)
	  {
		this.buffer.putShort(value);
		return this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshBuffer writeU32(final int value)
	  internal virtual BorshBuffer writeU32(in int value)
	  {
		this.buffer.putInt(value);
		return this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshBuffer writeU64(final long value)
	  internal virtual BorshBuffer writeU64(in long value)
	  {
		this.buffer.putLong(value);
		return this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshBuffer writeF32(final float value)
	  internal virtual BorshBuffer writeF32(in float value)
	  {
		this.buffer.putFloat(value);
		return this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshBuffer writeF64(final double value)
	  internal virtual BorshBuffer writeF64(in double value)
	  {
		this.buffer.putDouble(value);
		return this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshBuffer write(final @NonNull byte[] bytes)
	  internal virtual BorshBuffer write(in sbyte[] bytes)
	  {
		this.buffer.put(bytes);
		return this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public @NonNull BorshBuffer write(final byte b)
	  internal virtual BorshBuffer write(in sbyte b)
	  {
		this.buffer.put(b);
		return this;
	  }
	}

}