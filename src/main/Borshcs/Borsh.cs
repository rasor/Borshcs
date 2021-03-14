using System;

/* This is free and unencumbered software released into the public domain. */

namespace Borshcs
{

	using NonNull = androidx.annotation.NonNull;
	using Nullable = androidx.annotation.Nullable;

	public interface Borsh
	{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull byte[] serialize(final @NonNull Object object)
	  static sbyte[] serialize(in object @object)
	  {
		return BorshBuffer.allocate(4096).write(requireNonNull(@object)).toByteArray();
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull <T> T deserialize(final @NonNull byte[] bytes, final @NonNull Class klass)
	  static T deserialize<T>(in sbyte[] bytes, in Type klass)
	  {
		return deserialize(BorshBuffer.wrap(requireNonNull(bytes)), klass);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static @NonNull <T> T deserialize(final @NonNull BorshBuffer buffer, final @NonNull Class klass)
	  static T deserialize<T>(in BorshBuffer buffer, in Type klass)
	  {
		return buffer.read(requireNonNull(klass));
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: public static boolean isSerializable(final @Nullable Class klass)
	  static bool isSerializable(in Type klass)
	  {
		if (klass == null)
			return false;
		return klass.getInterfaces().Any(iface => iface == Borsh.class) || isSerializable(klass.getSuperclass());
	  }
	}

}