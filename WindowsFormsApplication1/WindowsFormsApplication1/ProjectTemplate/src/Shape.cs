using System;
using System.Reflection;
using SwinGameSDK;
using Color=System.Drawing.Color;


namespace MyGame
{
	public abstract class Shape
	{
		private Color _color;
		private float _x,_y;
		private bool _selected;


		public Shape (Color color) //seeeting values
		{
			_color = color; 
		}

		public Shape(): this(Color.White) //default construction
		{
		}


		public Color MyColor  // The property for _x
		{
			get {
				return _color;
			}
			set {
				_color = value;
			}
		}
		public float X  // The property for _x
		{
			get {
				return _x;
			}
			set {
				_x = value;
			}
		}

		public float Y  // The property for _y
		{
			get {
				return _y;
			}
			set {
				_y = value;
			}
		}



		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}


		public abstract void Draw ();//Drawing the rectangle
		public abstract void DrawOutline (); //drawing border
		public abstract bool IsAt (Point2D pt);//checking the point






	}
}

