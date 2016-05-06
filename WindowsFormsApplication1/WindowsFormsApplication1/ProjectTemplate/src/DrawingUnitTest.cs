using NUnit.Framework;
using System;
using SwinGameSDK;
using Color=System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{

	[TestFixture ()]
	public class DrawingUnitTest
	{
		[Test ()]
		public void TestDefaultInitialization () //testing deafult initialization
		{
			Drawing d = new Drawing ();
			Assert.AreEqual (d.Background, Color.White); //color shoud be white
			Assert.AreNotEqual (d.Background, Color.Blue);
		}

		[Test ()]
		public void TestInitializationWithColor () //testing color initialization		
		{
			Drawing d = new Drawing (Color.Blue);
			Assert.AreNotEqual (d.Background, Color.White); //color shoud be blue
			Assert.AreEqual (d.Background, Color.Blue);
		}

		[ Test()] 
		public void TestAddShape () 
		{ 
			Drawing myDrawing = new Drawing(); 
			int count = myDrawing.ShapeCount; 
			Assert.AreEqual( 0, count, "Drawing should start with no shapes" ); 
			myDrawing.AddShape( new Rectangle() ); 
			myDrawing.AddShape( new Rectangle() ); 
			count = myDrawing.ShapeCount; 
			Assert.AreEqual( 2, count, "Adding two shapes should increase the count to 2" ); 

		}

		[ Test()]
		public void TestSelectShape ( ) //Testing selected shapes
		{ 
			Drawing myDrawing = new Drawing(); 
			Shape[] testShapes = { 
				new Rectangle (Color.Red, 25, 25, 50, 50), 
				new Rectangle (Color.Green, 25, 10, 50, 50), 
				new Rectangle (Color.Blue, 10, 25, 50, 50) 
			}; 

			foreach(Shape s in testShapes) myDrawing.AddShape( s ); 
			List<Shape> selected; 
			Point2D point; 
			point = SwinGame.PointAt( 70, 70 ); 
			myDrawing.SelectShapesAt( point ); 
			selected = myDrawing.SelectedShapes; 
			CollectionAssert.Contains( selected, testShapes[0] ); 
			Assert.AreEqual( selected.Count, 1 ); 
			point = SwinGame.PointAt( 70, 50 ); 
			myDrawing.SelectShapesAt( point ); 
			selected = myDrawing.SelectedShapes; 
			CollectionAssert.Contains( selected, testShapes[0] ); 
			CollectionAssert.Contains( selected, testShapes[1] );
			Assert.AreEqual( selected.Count, 2 );
		}

		[ Test()]
		public void DeleteShape ( ) //Deleting shapes
		{

			Drawing myDrawing = new Drawing(); 
			Shape[] testShapes = { 
				new Rectangle(Color.Red, 25, 25, 50, 50), 
				new Rectangle(Color.Green, 25, 10, 50, 50), 
				new Rectangle(Color.Blue, 10, 25, 50, 50) 
			}; 

			foreach(Shape s in testShapes) myDrawing.AddShape( s ); 
			Assert.AreEqual (myDrawing.ShapeCount, 3);
			myDrawing.RemoveShape (testShapes[0]);
			Assert.AreEqual (myDrawing.ShapeCount, 2);
			myDrawing.SelectShapesAt(SwinGame.PointAt( 70, 70 )); //selecting testshape 0, but it is not theres
			CollectionAssert.DoesNotContain (myDrawing.SelectedShapes, testShapes [0]);

		}

	}
}

