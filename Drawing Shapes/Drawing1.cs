using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
    class Drawing1
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing1(Color background)
        {
            _shapes = new List<Shape>();
            _background = Color.Green;

        }

        public Color Color
        {
            get { return _background; }
            set { _background = value; }
        }

        public Drawing1() : this(Color.White)
        { }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public void AddShapes(Shape shapes)
        {
            _shapes.Add(shapes);
        }

        public void Draw()
        {
            SwinGame.ClearScreen(_background);
            foreach (Shape s in _shapes)
                s.Draw();
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach(Shape s in _shapes)
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                    if (s.Selected)
                    {
                        result.Add(s);
                    }

                return result;
            }
        }

        public void RemoveShape(Shape shapes)
        {
            _shapes.Remove(shapes);
        }

        public void Save(string path)
        {
            StreamWriter writer;
            

            writer = new StreamWriter(path);

            try
            {
                writer.WriteLine(_background.ToArgb());
                writer.WriteLine(ShapeCount);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
        }

        public void Load(string path)
        {
            StreamReader reader;
            int count;
            string kind;
            Shape s;
            int i;

            reader = new StreamReader(path);
            try
            {
                _background = Color.FromArgb(reader.ReadInteger());
                count = reader.ReadInteger();

                for (i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new Rectangle();
                            break;
                        case "Circle":
                            s = new Circle(); ;
                            break;
                        case "Line":
                            s = new Line();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }

                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
