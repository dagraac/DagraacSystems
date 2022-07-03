﻿using System; // Math


namespace DagraacSystems
{
	public struct Vector2
	{
		public double X;
		public double Y;

		public Vector2(double x, double y)
		{
			X = x;
			Y = y;
		}

		public static Vector2 Zero = new Vector2 { X = 0, Y = 0 };
		public static Vector2 Right = new Vector2 { X = 1, Y = 0 };
		public static Vector2 Up = new Vector2 { X = 0, Y = 1 };

		public static Vector2 operator +(Vector2 left, double right) => VectorHelper.Add(left, right);
		public static Vector2 operator -(Vector2 left, double right) => VectorHelper.Subtract(left, right);
		public static Vector2 operator *(Vector2 left, double right) => VectorHelper.Multiply(left, right);
		public static Vector2 operator /(Vector2 left, double right) => VectorHelper.Divide(left, right);
		public static Vector2 operator +(Vector2 left, Vector2 right) => VectorHelper.Add(left, right);
		public static Vector2 operator -(Vector2 left, Vector2 right) => VectorHelper.Subtract(left, right);
		public static Vector2 operator *(Vector2 left, Vector2 right) => VectorHelper.Multiply(left, right);
		public static Vector2 operator /(Vector2 left, Vector2 right) => VectorHelper.Divide(left, right);

		public static implicit operator Vector3(Vector2 value) => new Vector3 { X = value.X, Y = value.Y, Z = default };
		public static implicit operator Vector4(Vector2 value) => new Vector4 { X = value.X, Y = value.Y, Z = default, W = default };
	}


	public struct Vector3
	{
		public double X;
		public double Y;
		public double Z;

		public static Vector3 Zero = new Vector3 { X = 0, Y = 0, Z = 0 };
		public static Vector3 One = new Vector3 { X = 1, Y = 1, Z = 1 };
		public static Vector3 Left = new Vector3 { X = -1, Y = 0, Z = 0 };
		public static Vector3 Right = new Vector3 { X = 1, Y = 0, Z = 0 };
		public static Vector3 Up = new Vector3 { X = 0, Y = 1, Z = 0 };
		public static Vector3 Down = new Vector3 { X = 0, Y = -1, Z = 0 };
		public static Vector3 Forward = new Vector3 { X = 0, Y = 1, Z = 1 };
		public static Vector3 Back = new Vector3 { X = 0, Y = 1, Z = -1 };

		public static implicit operator Vector2(Vector3 value)
		{
			return new Vector2 { X = value.X, Y = value.Y };
		}

		public static implicit operator Vector4(Vector3 value)
		{
			return new Vector4 { X = value.X, Y = value.Y, Z = value.Z, W = default };
		}
	}


	public struct Vector4
	{
		public double X;
		public double Y;
		public double Z;
		public double W;

		public static Vector4 Zero = new Vector4 { X = 0, Y = 0, Z = 0, W = 0 };

		public static implicit operator Vector2(Vector4 value)
		{
			return new Vector2 { X = value.X, Y = value.Y };
		}

		public static implicit operator Vector3(Vector4 value)
		{
			return new Vector4 { X = value.X, Y = value.Y, Z = value.Z };
		}
	}


	public static class VectorHelper
	{
		public static double Length(this Vector2 value)
		{
			return Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
		}

		public static double Length(this Vector3 value)
		{
			return Math.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z));
		}

		public static double Length(this Vector4 value)
		{
			return Math.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z) + (value.W * value.W));
		}

		public static Vector2 Normalize(this Vector2 value)
		{
			var length = Length(value);
			return new Vector2 { X = value.X / length, Y = value.Y / length };
		}

		public static Vector3 Normalize(this Vector3 value)
		{
			var length = Length(value);
			return new Vector3 { X = value.X / length, Y = value.Y / length, Z = value.Z / length };
		}

		public static Vector4 Normalize(this Vector4 value)
		{
			var length = Length(value);
			return new Vector4 { X = value.X / length, Y = value.Y / length, Z = value.Z / length, W = value.W / length };
		}

		public static Vector2 Add(this Vector2 left, double right)
		{
			return new Vector2 { X = left.X + right, Y = left.Y + right };
		}

		public static Vector2 Subtract(this Vector2 left, double right)
		{
			return new Vector2 { X = left.X - right, Y = left.Y - right };
		}

		public static Vector2 Multiply(this Vector2 left, double right)
		{
			return new Vector2 { X = left.X * right, Y = left.Y * right };
		}

		public static Vector2 Divide(this Vector2 left, double right)
		{
			return new Vector2 { X = left.X / right, Y = left.Y / right };
		}

		public static Vector2 Add(this Vector2 left, Vector2 right)
		{
			return new Vector2 { X = left.X + right.X, Y = left.Y + right.Y };
		}

		public static Vector2 Subtract(this Vector2 left, Vector2 right)
		{
			return new Vector2 { X = left.X - right.X, Y = left.Y - right.Y };
		}

		public static Vector2 Multiply(this Vector2 left, Vector2 right)
		{
			return new Vector2 { X = left.X * right.X, Y = left.Y * right.Y };
		}

		public static Vector2 Divide(this Vector2 left, Vector2 right)
		{
			return new Vector2 { X = left.X / right.X, Y = left.Y / right.Y };
		}
	}
}