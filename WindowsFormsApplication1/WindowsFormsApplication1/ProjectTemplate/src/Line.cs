using System;
using SwinGameSDK;
using Color=System.Drawing.Color;

namespace MyGame
{

	public class Line: Shape
	{
		private float _endX,_endY;
		public Line(Color clr, float startX, float startY,float endX,float endY):base(clr)
		{
			X = startX;
			Y = startY;
			_endX = endX;
			_endY = endY;
		}

		public Line(): this(Color.Green, 0,0,100,100)
		{
		}

		public float EndX  // The property for _width
		{
			get {
				return _endX;
			}
			set {
				_endX = value;
			}
		}

		public float EndY  // The property for _height
		{
			get {
				return _endY;
			}
			set {
				_endY = value;
			}
		}

		public override void Draw ()
		{
			if (Selected)
				DrawOutline ();
			SwinGame.DrawLine (MyColor, X, Y, EndX, EndY);
		}
		public override void DrawOutline ()
		{
			SwinGame.DrawCircle (Color.Black, X, Y, 5);
			SwinGame.DrawCircle (Color.Black, EndX, EndX, 5);

		}

		public override bool IsAt(Point2D pt)//checking the point
		{
			return SwinGame.PointOnLine (pt,X, Y, EndX, EndY);
		}

	}
}

