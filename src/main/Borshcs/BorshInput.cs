//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System;
using System.Numerics;

/* This is free and unencumbered software released into the public domain. */
namespace Borshcs
{
	//using NonNull = androidx.annotation.NonNull;
	public interface BorshInput
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public <T> T read(final @NonNull Class klass)
	  T read<T>(in Type klass)
	  {
		if (klass == typeof(Byte) || klass == typeof(sbyte))
		{
			return (T)Convert.ToSByte(this.readU8());
		}
		else if (klass == typeof(short))
		{
			return (T)Convert.ToInt16(this.readU16());
		}
		else if (klass == typeof(int))
		{
			return (T)Convert.ToInt32(this.readU32());
		}
		else if (klass == typeof(long))
		{
			return (T)Convert.ToInt64(this.readU64());
		}
		else if (klass == typeof(BigInteger))
		{
			return (T)this.readU128();
		}
		else if (klass == typeof(float))
		{
			return (T)Convert.ToSingle(this.readF32());
		}
		else if (klass == typeof(double))
		{
			return (T)Convert.ToDouble(this.readF64());
		}
		else if (klass == typeof(string))
		{
			return (T)this.readString();
		}
		else if (klass == typeof(Boolean))
		{
			return (T)Convert.ToBoolean(this.readBoolean());
		}
		//else if (klass == Optional.class)
		//{
		//	return (T)this.readOptional();
		//}
		else if (Borsh.isSerializable(klass))
		{
			return (T)this.readPOJO(klass);
		}
		throw new System.ArgumentException();
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public <T> T readPOJO(final @NonNull Class klass)
	  T readPOJO<T>(in Type klass)
	  {
		try
		{
		  final object @object = klass.getConstructor().newInstance();
		  for (final System.Reflection.FieldInfo field : klass.getDeclaredFields())
		  {
			field.setAccessible(true);
			final Type fieldClass = field.getType();
			if (fieldClass == Optional.class)
			{
			  final Type fieldType = field.getGenericType();
			  if (!(fieldType instanceof ParameterizedType))
			  {
				  throw new AssertionError("unsupported Optional type");
			  }
			  final Type[] optionalArgs = ((ParameterizedType)fieldType).getActualTypeArguments();
			  assert(optionalArgs.length == 1);
			  final Type optionalClass = (Type)optionalArgs[0];
			  field.set(@object, this.readOptional(optionalClass));
			}
			else
			{
				field.set(@object, this.read(field.getType()));
			}
		  }
		  return (T)@object;
		}
		catch (NoSuchMethodException error)
		{
			throw new Exception(error);
		}
		catch (InstantiationException error)
		{
			throw new Exception(error);
		}
		catch (IllegalAccessException error)
		{
			throw new Exception(error);
		}
		catch (InvocationTargetException error)
		{
			throw new Exception(error);
		}
	  }
	  sbyte readU8()
	  {
		  return this.read();
	  }
	  short readU16()
	  {
		  return BorshBuffer.wrap(this.read(2)).readU16();
	  }
	  int readU32()
	  {
		  return BorshBuffer.wrap(this.read(4)).readU32();
	  }
	  long readU64()
	  {
		  return BorshBuffer.wrap(this.read(8)).readU64();
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull BigInteger readU128()
	  BigInteger readU128()
	  {
		final sbyte[] bytes = new sbyte[16];
		this.read(bytes);
		for (int i = 0; i < 8; i++)
		{
		  final sbyte a = bytes[i];
		  final sbyte b = bytes[15 - i];
		  bytes[i] = b;
		  bytes[15 - i] = a;
		}
		return new BigInteger(bytes);
	  }
	  float readF32()
	  {
		  return BorshBuffer.wrap(this.read(4)).readF32();
	  }
	  double readF64()
	  {
		  return BorshBuffer.wrap(this.read(8)).readF64();
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull String readString()
	  string readString()
	  {
		final int length = this.readU32();
		final sbyte[] bytes = new sbyte[length];
		this.read(bytes);
		return new string(bytes, StandardCharsets.UTF_8);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull byte[] readFixedArray(final int length)
	  sbyte[] readFixedArray(in int length)
	  {
		if (length < 0)
		{
			throw new System.ArgumentException();
		}
		final sbyte[] bytes = new sbyte[length];
		this.read(bytes);
		return bytes;
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public @NonNull <T> T[] readArray(final @NonNull Class klass)
	  T[] readArray<T>(in Type klass)
	  {
		final int length = this.readU32();
		final T[] elements = (T[])Array.newInstance(klass, length);
		for (int i = 0; i < length; i++)
		{
			elements[i] = this.read(klass);
		}
		return elements;
	  }
	  bool readBoolean()
	  {
		  return (this.readU8() != 0);
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public <T> @NonNull Optional<T> readOptional()
	  Optional<T> readOptional<T>()
	  {
		final bool isPresent = (this.readU8() != 0);
		if (!isPresent)
		{
			return (Optional<T>)Optional.empty();
		}
		throw new AssertionError("Optional type has been erased and cannot be reconstructed");
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: default public <T> @NonNull Optional<T> readOptional(final @NonNull Class klass)
	  Optional<T> readOptional<T>(in Type klass)
	  {

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
