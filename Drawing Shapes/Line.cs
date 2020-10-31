using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
    public class Line : Shape
    {

        private float _width;
        public Line(Color clr, float x, float y, int width)
            : base(clr)
        {
            X = x;
            Y = y;
            _width = X + 100;
         
            
        }

        public Line()
            : this(Color.Red, 0, 0, 100)
        {
        }

 

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SwinGame.DrawLine(Color, X, Y, _width, Y);
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, 20);
            SwinGame.DrawCircle(Color.Black, X + 100, Y, 20);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.OnLine(X, Y, _width, Y);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);

            writer.WriteLine(_width);
            writer.WriteLine(Y);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
