using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;


namespace MyGame
{
    public class GameMain
    {
		private enum ShapeKind
		{
			Rectangle,
			Circle,
			Line
		}
        public static void Main()
        {
            //Start the audio system so sound can be played
			ShapeKind kindToAdd;
			kindToAdd = ShapeKind.Circle;
			Drawing myDrawing;
			myDrawing = new Drawing (); // The Drawing object
			//Shape myShape; // myshape a localvariable
			//myShape = new Shape ();// creating the object
            SwinGame.OpenAudio();
            
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            //Run the game loop

            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

				if (SwinGame.KeyTyped (KeyCode.vk_r))
				{
					kindToAdd = ShapeKind.Rectangle;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_c))
				{
					kindToAdd = ShapeKind.Circle;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_l))
				{
					kindToAdd = ShapeKind.Line;
				}

				/*adding the shape*/
				if (SwinGame.MouseClicked (MouseButton.LeftButton))
				{

					Shape newShape=null;
					if (kindToAdd == ShapeKind.Line)
					{
						Line newLine = new Line ();
						newShape = newLine;
					}

					if (kindToAdd == ShapeKind.Circle)
					{
						Circle newCircle = new Circle ();
						newShape = newCircle;
					}

					if (kindToAdd == ShapeKind.Rectangle)
					{
						Rectangle newRect = new Rectangle ();
						newShape = newRect;
					}
					newShape.X=SwinGame.MouseX (); //Removing Code duplication
					newShape.Y = SwinGame.MouseY ();
					newShape.MyColor=SwinGame.RandomRGBColor (255);
					myDrawing.AddShape (newShape);   //adding the shape

				}

				//drawing selecttions
				if (SwinGame.MouseClicked (MouseButton.RightButton))
				{
					Point2D pt = new Point2D ();
					pt.X=SwinGame.MouseX ();
					pt.Y=SwinGame.MouseY ();
					myDrawing.SelectShapesAt (pt);
				}

				if(SwinGame.KeyTyped (KeyCode.vk_DELETE)||SwinGame.KeyTyped (KeyCode.vk_BACKSPACE))
				{
					List<Shape> selected =myDrawing.SelectedShapes;
					foreach (Shape s in selected)
						myDrawing.RemoveShape (s);
				}

				if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
				{
					myDrawing.Background=SwinGame.RandomRGBColor (255);
				}
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
				myDrawing.Draw ();

                SwinGame.RefreshScreen();
            }
            
            //End the audio
            SwinGame.CloseAudio();
            
            //Close any resources we were using
            SwinGame.ReleaseAllResources();
        }
    }
}