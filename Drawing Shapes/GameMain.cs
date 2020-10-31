using System;
using SwinGameSDK;

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
            ShapeKind kindToAdd;
            kindToAdd = ShapeKind.Circle;

            Drawing1 myDrawing = new Drawing1();

            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);

                myDrawing.Draw();

                if (SwinGame.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SwinGame.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SwinGame.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                        if (kindToAdd == ShapeKind.Circle)
                    {
                        Circle newCircle = new Circle();
                        
                        newShape = newCircle;
                    }
                        else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        Rectangle newRect = new Rectangle();
                        
                        newShape = newRect;
                    }
                        else
                    {
                        Line newLine = new Line();
                        
                        newShape = newLine;

                    }
                    newShape.X = SwinGame.MouseX();
                    newShape.Y = SwinGame.MouseY(); 
                    myDrawing.AddShapes(newShape);
                }

                if (SwinGame.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Color = SwinGame.RandomRGBColor(255);
                }

                if (SwinGame.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SwinGame.MousePosition());
                }

                if(SwinGame.KeyTyped(KeyCode.DeleteKey) || (SwinGame.KeyTyped(KeyCode.BackspaceKey)))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                        myDrawing.RemoveShape(s);
                }

                if (SwinGame.KeyTyped(KeyCode.SKey))
                    {
                    myDrawing.Save(@"C:\Users\Connor\Desktop\C# Programs\5.2C\ShapeDrawing\file.txt");
                }

                if (SwinGame.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load(@"C:\Users\Connor\Desktop\C# Programs\5.2C\ShapeDrawing\file.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}