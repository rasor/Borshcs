using System;
using System.Collections.Generic;
using System.Numerics;

/* This is free and unencumbered software released into the public domain. */
namespace Borshcs
{
	using NonNull = androidx.annotation.NonNull;
	public interface BorshOutput<Self>
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self write(final @NonNull Object object)
	  Self write(in object @object)
	  {
		requireNonNull(@object);
		if (@object instanceof sbyte?)
		{
			return this.writeU8((sbyte)@object);
		}
		else if (@object instanceof short?)
		{
			return this.writeU16((short)@object);
		}
		else if (@object instanceof int?)
		{
			return this.writeU32((int)@object);
		}
		else if (@object instanceof long?)
		{
			return this.writeU64((long)@object);
		}
		else if (@object instanceof float?)
		{
			return this.writeF32((float)@object);
		}
		else if (@object instanceof double?)
		{
			return this.writeF64((double)@object);
		}
		else if (@object instanceof BigInteger)
		{
			return this.writeU128((BigInteger)@object);
		}
		else if (@object instanceof string)
		{
			return this.writeString((string)@object);
		}
		else if (@object instanceof System.Collections.IList)
		{
			return (Self)this.writeArray((System.Collections.IList)@object);
		}
		else if (@object instanceof bool?)
		{
			return (Self)this.writeBoolean((bool?)@object);
		}
		else if (@object instanceof Optional)
		{
			return (Self)this.writeOptional((Optional)@object);
		}
		else if (@object instanceof Borsh)
		{
			return this.writePOJO(@object);
		}
		throw new System.ArgumentException();
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writePOJO(final @NonNull Object object)
	  Self writePOJO(in object @object)
	  {
		try
		{
		  for (final System.Reflection.FieldInfo field : @object.getClass().getDeclaredFields())
		  {
			field.setAccessible(true);
			this.write(field.get(@object));
		  }
		}
		catch (IllegalAccessException error)
		{
			throw new Exception(error);
		}
		return (Self)this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU8(final int value)
	  Self writeU8(in int value)
	  {
		  return this.writeU8((sbyte)value);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU8(final byte value)
	  Self writeU8(in sbyte value)
	  {
		  return this.write(value);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU16(final int value)
	  Self writeU16(in int value)
	  {
		  return this.writeU16((short)value);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU16(final short value)
	  Self writeU16(in short value)
	  {
		  return this.writeBuffer(BorshBuffer.allocate(2).writeU16(value));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU32(final int value)
	  Self writeU32(in int value)
	  {
		  return this.writeBuffer(BorshBuffer.allocate(4).writeU32(value));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU64(final long value)
	  Self writeU64(in long value)
	  {
		  return this.writeBuffer(BorshBuffer.allocate(8).writeU64(value));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU128(final long value)
	  Self writeU128(in long value)
	  {
		  return this.writeU128(BigInteger.valueOf(value));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeU128(final @NonNull BigInteger value)
	  Self writeU128(in BigInteger value)
	  {
		if (value.signum() == -1)
		{
			throw new ArithmeticException("integer underflow");
		}
		if (value.bitLength() > 128)
		{
			throw new ArithmeticException("integer overflow");
		}
		final sbyte[] bytes = value.toByteArray();
		for (int i = bytes.length - 1; i >= 0; i--)
		{
			this.write(bytes[i]);
		}
		for (int i = 0; i < 16 - bytes.length; i++)
		{
			this.write((sbyte)0);
		}
		return (Self)this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeF32(final float value)
	  Self writeF32(in float value)
	  {
		  return this.writeBuffer(BorshBuffer.allocate(4).writeF32(value));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeF64(final double value)
	  Self writeF64(in double value)
	  {
		  return this.writeBuffer(BorshBuffer.allocate(8).writeF64(value));
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeString(final @NonNull String string)
	  Self writeString(in string @string)
	  {
		final sbyte[] bytes = @string.getBytes(StandardCharsets.UTF_8);
		this.writeU32(bytes.length);
		return this.write(bytes);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeFixedArray(final @NonNull byte[] array)
	  Self writeFixedArray(in sbyte[] array)
	  {
		  return this.write(array);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull <T> Self writeArray(final @NonNull T[] array)
	  Self writeArray<T>(in T[] array)
	  {
		this.writeU32(array.length);
		for (final T element : array)
		{
			this.write(element);
		}
		return (Self)this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull <T> Self writeArray(final @NonNull List<T> list)
	  Self writeArray<T>(in IList<T> list)
	  {
		this.writeU32(list.size());
		for (final T element : list)
		{
			this.write(element);
		}
		return (Self)this;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull <T> Self writeBoolean(final boolean value)
	  Self writeBoolean<T>(in bool value)
	  {
		  return this.writeU8(value ? 1 : 0);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull <T> Self writeOptional(final @NonNull Optional<T> optional)
	  Self writeOptional<T>(in Optional<T> optional)
	  {
		if (optional.isPresent())
		{
		  this.writeU8(1);
		  return this.write(optional.get());
		}
		else
		{
			return this.writeU8(0);
		}
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull Self writeBuffer(final @NonNull BorshBuffer buffer)
	  Self writeBuffer(in BorshBuffer buffer)
	  {
		return this.write(buffer.toByteArray()); // TODO: optimize
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Self write(final @NonNull byte[] bytes);
	  Self write(in sbyte[] bytes);
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public @NonNull Self write(final byte b);
	  Self write(in sbyte b);
	}

}