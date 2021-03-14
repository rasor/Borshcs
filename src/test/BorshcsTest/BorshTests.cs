/* This is free and unencumbered software released into the public domain. */

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//import static org.junit.jupiter.api.Assertions.*;

using Test = org.junit.jupiter.api.Test;
using Borsh = Borshcs.Borsh;

public class BorshTests
{
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test void roundtripPoint2Df()
  internal virtual void roundtripPoint2Df()
  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Point2Df point = new Point2Df(123, 456);
	Point2Df point = new Point2Df(123, 456);
	assertEquals(point, Borsh.deserialize(Borsh.serialize(point), typeof(Point2Df)));
  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test void roundtripRect2Df()
  internal virtual void roundtripRect2Df()
  {
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Point2Df topLeft = new Point2Df(-123, -456);
	Point2Df topLeft = new Point2Df(-123, -456);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Point2Df bottomRight = new Point2Df(123, 456);
	Point2Df bottomRight = new Point2Df(123, 456);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Rect2Df rect = new Rect2Df(topLeft, bottomRight);
	Rect2Df rect = new Rect2Df(topLeft, bottomRight);
	assertEquals(rect, Borsh.deserialize(Borsh.serialize(rect), typeof(Rect2Df)));
  }

  public class Point2Df : Borsh
  {
	internal float x;
	internal float y;

	public Point2Df()
	{
	}

	public Point2Df(in float x, in float y)
	{
	  this.x = x;
	  this.y = y;
	}

	public override string ToString()
	{
	  return string.Format("Point2Df({0:F}, {1:F})", this.x, this.y);
	}

	public override bool Equals(in object @object)
	{
	  if (@object == null || @object.GetType() != this.GetType())
	  {
		  return false;
	  }
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Point2Df other = (Point2Df)object;
	  Point2Df other = (Point2Df)@object;
	  return this.x == other.x && this.y == other.y;
	}
  }

  public class Rect2Df : Borsh
  {
	internal Point2Df topLeft;
	internal Point2Df bottomRight;

	public Rect2Df()
	{
	}

	public Rect2Df(in Point2Df topLeft, in Point2Df bottomRight)
	{
	  this.topLeft = topLeft;
	  this.bottomRight = bottomRight;
	}

	public override string ToString()
	{
	  return string.Format("Rect2Df({0}, {1})", this.topLeft.ToString(), this.bottomRight.ToString());
	}

	public override bool Equals(in object @object)
	{
	  if (@object == null || @object.GetType() != this.GetType())
	  {
		  return false;
	  }
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Rect2Df other = (Rect2Df)object;
	  Rect2Df other = (Rect2Df)@object;
	  return this.topLeft.Equals(other.topLeft) && this.bottomRight.Equals(other.bottomRight);
	}
  }
}
