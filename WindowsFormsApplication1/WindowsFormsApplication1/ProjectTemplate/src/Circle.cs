using System;
using SwinGameSDK;
using Color=System.Drawing.Color;


namespace MyGame
{
	public class Circle: Shape
	{
		private int _radius;

		public Circle(Color clr, int radius):base(clr)
		{
			_radius = radius;
		}
		public Circle():this(Color.Green,50)
		{
		}
			
		public int Radius
		{
			get {
				return _radius;
			}
			set {
				_radius = value;
			}
		}

		public override void Draw ()
		{
			if (Selected)
				DrawOutline ();
			SwinGame.FillCircle (MyColor, X, Y, Radius);
		}
		public override void DrawOutline ()
		{
			SwinGame.DrawCircle (Color.Black, X, Y, Radius + 2);
		}

		public override bool IsAt(Point2D pt)//checking the point
		{
			return SwinGame.PointInCircle (pt, X, Y, Radius);
		}
	}
}

