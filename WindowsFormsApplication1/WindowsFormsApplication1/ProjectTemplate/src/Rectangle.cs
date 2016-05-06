using System;
using SwinGameSDK;
using Color=System.Drawing.Color;


namespace MyGame
{
	public class Rectangle: Shape
	{
		private int _width,_height;
		public Rectangle(Color clr, float x, float y, int width, int height):base(clr)
		{
			X = x;
			Y = y;
			_width = width;
			_height = height;
		}

		public Rectangle(): this(Color.Green, 0,0,100,100)
		{
		}

		public int Width  // The property for _width
		{
			get {
				return _width;
			}
			set {
				_width = value;
			}
		}

		public int Height  // The property for _height
		{
			get {
				return _height;
			}
			set {
				_height = value;
			}
		}

		public override void Draw ()
		{
			if (Selected)
				DrawOutline ();
			SwinGame.FillRectangle (MyColor, X, Y, Width, Height);
		}
		public override void DrawOutline ()
		{
			SwinGame.DrawRectangle (Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
		}

		public override bool IsAt(Point2D pt)//checking the point
		{
			return SwinGame.PointInRect (pt, X, Y, Width, Height);
		}

	}
}

