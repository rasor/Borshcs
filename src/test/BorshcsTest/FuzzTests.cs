//====================================================================================================
//The Free Edition of Java to C# Converter limits conversion output to 100 lines per file.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================

using System;
using System.Numerics;
using System.Reflection;
using System.Text;

/* This is free and unencumbered software released into the public domain. */
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//import static org.junit.jupiter.api.Assertions.*;
using BeanGenerator = net.sf.cglib.beans.BeanGenerator;
using BeforeEach = org.junit.jupiter.api.BeforeEach;
using RepeatedTest = org.junit.jupiter.api.RepeatedTest;
using RepetitionInfo = org.junit.jupiter.api.RepetitionInfo;
using Test = org.junit.jupiter.api.Test;
using Borsh = Borshcs.Borsh;
public class FuzzTests
{
  internal const int MAX_ITERATIONS = 1000;
  internal const int MAX_RECURSION = 2;
  internal const int MAX_FIELDS = 10;
  internal const int MAX_STRING_LEN = 100;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test void testBeanGenerator() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
  internal virtual void testBeanGenerator()
  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final net.sf.cglib.beans.BeanGenerator beanGenerator = new net.sf.cglib.beans.BeanGenerator();
	BeanGenerator beanGenerator = new BeanGenerator();
	beanGenerator.Superclass = typeof(Bean);
	beanGenerator.addProperty("name", typeof(string));
	beanGenerator.addProperty("email", typeof(string));
	beanGenerator.addProperty("age", typeof(Integer));
	beanGenerator.addProperty("twitter", typeof(Boolean));
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object bean = beanGenerator.create();
	object bean = beanGenerator.create();
	bean.GetType().GetMethod("setName", typeof(string)).invoke(bean, "J. Random Hacker");
	bean.GetType().GetMethod("setEmail", typeof(string)).invoke(bean, "jhacker@example.org");
	bean.GetType().GetMethod("setAge", typeof(Integer)).invoke(bean, 42);
	bean.GetType().GetMethod("setTwitter", typeof(Boolean)).invoke(bean, true);
	assertEquals(bean, Borsh.deserialize(Borsh.serialize(bean), bean.GetType()));
  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @RepeatedTest(MAX_ITERATIONS) void testRandomBean(final org.junit.jupiter.api.RepetitionInfo test) throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
  internal virtual void testRandomBean(in RepetitionInfo test)
  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Random random = new java.util.Random(test.getCurrentRepetition());
	Random random = new Random(test.CurrentRepetition);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object bean = newRandomBean(random, 0);
	object bean = newRandomBean(random, 0);
	assertEquals(bean, Borsh.deserialize(Borsh.serialize(bean), bean.GetType()));
  }
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private Object newRandomBean(final java.util.Random random, final int level) throws Exception
  private object newRandomBean(in Random random, in int level)
  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final net.sf.cglib.beans.BeanGenerator beanGenerator = new net.sf.cglib.beans.BeanGenerator();
	BeanGenerator beanGenerator = new BeanGenerator();
	beanGenerator.Superclass = typeof(Bean);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int fieldCount = random.nextInt(MAX_FIELDS);
	int fieldCount = random.Next(MAX_FIELDS);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object[] fieldValues = new Object[fieldCount];
	object[] fieldValues = new object[fieldCount];
	for (int i = 0; i < fieldCount; i++)
	{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String fieldName = String.format("field%d", i);
	  string fieldName = string.Format("field{0:D}", i);
	  fieldValues[i] = newRandomValue(random, level);
	  beanGenerator.addProperty(fieldName, fieldValues[i].GetType());
	}
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object bean = beanGenerator.create();
	object bean = beanGenerator.create();
	for (int i = 0; i < fieldCount; i++)
	{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String setterName = String.format("setField%d", i);
	  string setterName = string.Format("setField{0:D}", i);
	  bean.GetType().GetMethod(setterName, fieldValues[i].GetType()).invoke(bean, fieldValues[i]);
	}
	//System.err.println(bean.toString());  // DEBUG
	return bean;
  }
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private Object newRandomValue(final java.util.Random random, final int level) throws Exception
  private object newRandomValue(in Random random, in int level)
  {
	switch (Math.Abs(random.Next()) % 10)
	{
	  case 0:
		  if (level < MAX_RECURSION)
		  {
			  return newRandomBean(random, level + 1);
		  }
		  else
		  {
		  }
		  goto case 1;
	  case 1:
		  return random.nextBoolean();
	  case 2:
		  return (sbyte)random.Next(sbyte.MaxValue);
	  case 3:
		  return (short)random.Next(short.MaxValue);
	  case 4:
		  return random.Next();
	  case 5:
		  return random.nextLong();
	  case 6:
		  return BigInteger.valueOf(random.nextLong()).abs();
	  case 7:
		  return random.nextFloat();
	  case 8:
		  return random.NextDouble();
	  case 9:
//JAVA TO C# CONVERTER TODO TASK: Method reference constructor syntax is not converted by Java to C# Converter:
		return random.ints('a', 'z' + 1).limit(random.Next(MAX_STRING_LEN)).collect(StringBuilder::new, StringBuilder.appendCodePoint, StringBuilder.append).ToString();
	  default:
		  throw new AssertionError("unreachable");
	}
  }
  public class Bean : Borsh
  {
	public override string ToString()
	{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final StringBuilder buffer = new StringBuilder();
	  StringBuilder buffer = new StringBuilder();
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
	  buffer.Append(this.GetType().FullName);
	  buffer.Append('(');
	  try
	  {
		foreach (System.Reflection.FieldInfo field in this.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
		{
		  field.Accessible = true;
		  buffer.Append(field.Name);
		  buffer.Append('=');
		  buffer.Append(field.get(this));
		  buffer.Append(',');
		}
	  }
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not available in C#:
//ORIGINAL LINE: catch (final IllegalAccessException e)
	  catch (IllegalAccessException e)
	  {
		  Console.WriteLine(e.ToString());
		  Console.Write(e.StackTrace);
	  }
	  buffer.Append(')');
	  return buffer.ToString();
	}
	public override bool Equals(in object @object)
	{
	  if (@object == null || @object.GetType() != this.GetType())
	  {
		  return false;
	  }
	  try
	  {
		foreach (System.Reflection.FieldInfo field in this.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
		{
		  field.Accessible = true;
		  if (!field.get(this).Equals(field.get(@object)))
		  {
			  return false;
		  }
		}
		return true;
	  }
//JAVA TO C# CONVERTER WARNING: 'final' catch parameters are not available in C#:
//ORIGINAL LINE: catch (final IllegalAccessException e)
	  catch (IllegalAccessException e)
	  {

//====================================================================================================
//End of the allowed output for the Free Edition of Java to C# Converter.

//To purchase the Premium Edition, visit our website:
//https://www.tangiblesoftwaresolutions.com/order/order-java-to-csharp.html
//====================================================================================================
