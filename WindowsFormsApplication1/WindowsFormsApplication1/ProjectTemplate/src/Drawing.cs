using System;
using System.Collections.Generic;
using SwinGameSDK;
using Color=System.Drawing.Color;
namespace MyGame
{

	public class Drawing
	{
		private readonly List<Shape> _shapes; //List of shapes
		private Color _background; //Backgroud Color

		public Drawing ( Color background) // seting color and new shapes
		{
			_shapes = new List<Shape> ();
			_background = background;
		}

		public Drawing ():this(Color.White) // by default white
		{
		}

		public List<Shape>  SelectedShapes // The property for selected shapes
		{
			get {
				List<Shape> result = new List<Shape> ();
				foreach (Shape s in _shapes)
				{
					if (s.Selected)
						result.Add (s);
				}
				return result;
			}

		}

		public Color Background  // The property for _background
		{
			get {
				return _background;
			}
			set{
				_background = value;
			}

		}

		public int ShapeCount                //spae count property
		{
			get
			{
				return _shapes.Count;
			}

		}
			
		public void AddShape (Shape shape) //adding shapes
		{
			_shapes.Add (shape);
		}

		public void Draw()                      //drawing a shapes
		{
			SwinGame.ClearScreen (this.Background);
			foreach (Shape s in _shapes)
			{
				s.Draw ();
				/*
				if (s.Selected)
					s.DrawOutline ();*/
			}
		}

		public void SelectShapesAt (Point2D pt) //checking if the shapes are selected
		{
			foreach (Shape s in _shapes)
			{
				if (s.IsAt (pt))
					s.Selected = true;
				else
					s.Selected = false;
			}
		}

		public void RemoveShape (Shape shape) //removing a shape
		{
			Shape todelete=null;
			foreach (Shape s in _shapes)
			{
				if (s.Equals (shape))
				{
					todelete = s;
				}
			}
			_shapes.Remove (todelete);
		}
	}
}

