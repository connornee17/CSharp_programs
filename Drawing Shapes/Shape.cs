using System;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        private bool _selected;

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
       
        public Shape (Color clr)
        {
            _color = clr;
        }

        public Shape()
            : this(Color.Yellow)
        { 
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public abstract void Draw();



        public abstract bool IsAt(Point2D pt);
       
        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(_color.ToArgb());
            writer.WriteLine(_x);
            writer.WriteLine(_y);
        }
       
        public virtual void LoadFrom (StreamReader reader)
        {
            Color = Color.FromArgb(reader.ReadInteger());
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
