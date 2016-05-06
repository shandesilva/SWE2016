using NUnit.Framework;
using System.Reflection;
using SwinGameSDK;
using Color=System.Drawing.Color;
namespace MyGame
{

	[TestFixture ()]
	public class ShapeTests
	{
		[Test ()]
		public void TestShapeAt ()
		{

			Rectangle s = new Rectangle ();
			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt(SwinGame.PointAt(50,50)));
			Assert.IsTrue (s.IsAt(SwinGame.PointAt(25,25)));
			Assert.IsFalse (s.IsAt(SwinGame.PointAt(10,50)));
			Assert.IsFalse (s.IsAt(SwinGame.PointAt(50,10)));


		
		}

		[Test ()]
		public void TestShapeAtWhenMoved ()
		{

			Rectangle s = new Rectangle ();
			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;
			Assert.IsTrue (s.IsAt(SwinGame.PointAt(50,50)));

			s.X = 100;
			s.Y = 100;
			s.Width = 50;
			s.Height = 50;
			Assert.IsFalse (s.IsAt(SwinGame.PointAt(50,50)));


		}

		[Test ()]
		public void TestShapeAtWhenResized ()
		{

			Rectangle s = new Rectangle ();
			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;
			Assert.IsTrue (s.IsAt(SwinGame.PointAt(50,50)));

			s.X = 25;
			s.Y = 25;
			s.Width = 10;
			s.Height = 10;
			Assert.IsFalse (s.IsAt(SwinGame.PointAt(50,50)));


		}

		[Test ()]
		public void TestSelected () //Test for selected
		{
			Shape s = new Rectangle ();
			s.Selected = true;
			Assert.AreEqual (s.Selected, true);
			Assert.AreNotEqual (s.Selected, false);
		}

		[Test ()]
		public void TestShapeConstructor () //Test for new shape constructor
		{
			Rectangle s = new Rectangle (Color.White,10,20,50,50);
			Assert.AreEqual (s.MyColor, Color.White);
			Assert.AreEqual (s.X, 10);
			Assert.AreEqual (s.Y, 20);
			Assert.AreEqual (s.Width, 50);
			Assert.AreEqual (s.Height, 50);
		}



	}
}

