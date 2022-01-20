using System.Drawing;
using System.Numerics;

namespace BezierCurveApp
{
    public class Vertex
    {
        public const int Size = 10;

        public Vertex(int x, int y)
        {
            Position = new Vector2(x, y);
        }

        public Vector2 Position { get; set; }

        public Point Point
        {
            get => new(X, Y);
            set => Position = new Vector2(value.X, value.Y);
        }

        public int X => (int) Position.X;

        public int Y => (int) Position.Y;
    }
}