using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
    public class Circle : Shape
    {
        private int _radius;

        public Circle (Color clr, int radius)
            : base(clr)
        {
            _radius = radius;
        }

        public Circle()
            : this(Color.Blue, 50)
        {
        }

        public override void Draw ()
        {
            if (Selected)
                DrawOutline();
            SwinGame.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SwinGame.DrawCircle(Color.Black, X, Y, _radius+2);
        }

        public override bool IsAt(Point2D pt)
        {
            return (pt.InCircle(X, Y, _radius));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);

            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }
    }
}
