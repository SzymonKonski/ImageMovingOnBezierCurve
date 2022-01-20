using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace BezierCurveApp
{
    public partial class Form1 : Form
    {
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Drawlines
            if (polylineCheckbox.Checked)
                for (var i = 0; i < ControlPoints.Count - 1; i++)
                    e.Graphics.DrawLine(polylLinePen, ControlPoints[i].Point, ControlPoints[i + 1].Point);

            //Drawebezier
            for (var i = 0; i < Bezier.Count - 1; i++)
                e.Graphics.DrawLine(bezierPen, (float) Bezier[i].X, (float) Bezier[i].Y, (float) Bezier[i + 1].X,
                    (float) Bezier[i + 1].Y);

            //Drawpoints
            foreach (var v in ControlPoints)
                e.Graphics.FillEllipse(vertexBrush, v.X - Vertex.Size / 2, v.Y - Vertex.Size / 2, Vertex.Size,
                    Vertex.Size);

            //Animation
            if (animationState == AnimationState.Playing)
            {
                if (animationType == AnimationType.MovingOnCurve)
                {
                    if (rotationType == RotationType.Naive)
                        DrawNaive(e.Graphics);
                    else
                        DrawWithFiltering(e.Graphics);
                }
                else if (animationType == AnimationType.Rotation)
                {
                    if (rotationType == RotationType.Naive)
                        DrawNaive(e.Graphics);
                    else
                        DrawWithFiltering(e.Graphics);
                }
            }
        }
        private void DrawNaive(Graphics graphics)
        {
            var imageNaive = grayScaleCheckbox.Checked ? grayImage : image;
            var center = new Point(imageNaive.Width / 2, imageNaive.Height / 2);
            var angle = CalculateAngle();

            for (var i = 0; i < imageNaive.Width; i++)
            for (var j = 0; j < imageNaive.Height; j++)
            {
                var off = new Vector(i - center.X, j - center.Y);
                var newPos = new Vector(off.X * Math.Cos(angle) - off.Y * Math.Sin(angle),
                    off.X * Math.Sin(angle) + off.Y * Math.Cos(angle));

                graphics.DrawRectangle(
                    new Pen(imageNaive.GetPixel(i, j)),
                    (float) (Bezier[bezierIndex].X + newPos.X),
                    (float) (Bezier[bezierIndex].Y + newPos.Y), 1, 1);
            }
        }

        private void DrawWithFiltering(Graphics graphics)
        {
            var angle = CalculateAngle();
            var colors = grayScaleCheckbox.Checked ? imageGrayColors : imageColors;

            if (angle > 0) angle = -(2 * Math.PI - angle);

            while (angle <= -Math.PI / 2)
            {
                var width = colors.GetLength(0);
                var height = colors.GetLength(1);
                var tmp = new Color[height, width];

                for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    tmp[j, width - (i + 1)] = colors[i, j];

                colors = tmp;
                angle += Math.PI / 2;
            }

            colors = Xshear(colors, angle);
            colors = Yshear(colors, angle);
            colors = Xshear(colors, angle);

            var center = new Point(colors.GetLength(0) / 2, colors.GetLength(1) / 2);

            for (var i = 0; i < colors.GetLength(0); i++)
            for (var j = 0; j < colors.GetLength(1); j++)
            {
                if (colors[i, j] == Color.Transparent)
                    continue;

                var vec = new Vector(i - center.X, j - center.Y);

                graphics.DrawRectangle(
                    new Pen(colors[i, j]),
                    (float) (Bezier[bezierIndex].X + vec.X),
                    (float) (Bezier[bezierIndex].Y + vec.Y), 1, 1);
            }
        }

        private Color[,] Xshear(Color[,] colors, double angle)
        {
            var width = colors.GetLength(0);
            var height = colors.GetLength(1);
            var alpha = -Math.Tan(angle / 2f);
            var xd = Math.Abs((int) ((height - 1) * alpha));
            var newWidth = xd + width;
            var newColors = new Color[newWidth, height];
            FillArray(newColors, Color.Transparent);

            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                if (colors[i, j] == Color.Transparent)
                    continue;

                var k = i + (int) (j * alpha);

                if (i == 0)
                {
                    newColors[k, j] = colors[i, j];
                }
                else
                {
                    var frac = Library.FractionalPart(alpha * j);
                    var red = (int) ((1 - frac) * colors[i, j].R + frac * colors[i - 1, j].R);
                    var green = (int) ((1 - frac) * colors[i, j].G + frac * colors[i - 1, j].G);
                    var blue = (int) ((1 - frac) * colors[i, j].B + frac * colors[i - 1, j].B);
                    newColors[k, j] = Color.FromArgb(red, green, blue);
                }
            }

            return newColors;
        }

        private Color[,] Yshear(Color[,] colors, double angle)
        {
            var width = colors.GetLength(0);
            var height = colors.GetLength(1);
            var beta = Math.Sin(angle);
            var yd = Math.Abs((int) ((width - 1) * beta));
            var newHeight = yd + height;
            var newColors = new Color[width, newHeight];
            FillArray(newColors, Color.Transparent);

            for (var i = 0; i < width; i++)
            {
                var frac = Math.Abs(Library.FractionalPart(beta * i));

                for (var j = 0; j < height; j++)
                {
                    if (colors[i, j] == Color.Transparent)
                        continue;

                    var k = j + (int) (i * beta) + yd;

                    if (j == 0)
                    {
                        newColors[i, k] = colors[i, j];
                    }
                    else
                    {
                        var red = (int) ((1 - frac) * colors[i, j].R + frac * colors[i, j - 1].R);
                        var green = (int) ((1 - frac) * colors[i, j].G + frac * colors[i, j - 1].G);
                        var blue = (int) ((1 - frac) * colors[i, j].B + frac * colors[i, j - 1].B);
                        newColors[i, k] = Color.FromArgb(red, green, blue);
                    }
                }
            }

            return newColors;
        }

        private void FillArray(Color[,] colors, Color color)
        {
            for (var i = 0; i < colors.GetLength(0); i++)
            for (var j = 0; j < colors.GetLength(1); j++)
                colors[i, j] = color;
        }

        private double CalculateAngle()
        {
            double angle;

            // only right angle
            if (bezierIndex == 0)
                angle = Angle(bezierIndex + 1, bezierIndex);
            // only left angle
            else if (bezierIndex == Bezier.Count - 1)
                angle = Angle(bezierIndex, bezierIndex - 1);
            else
                angle = (Angle(bezierIndex + 1, bezierIndex) + Angle(bezierIndex, bezierIndex - 1)) / 2;

            angle = animationType == AnimationType.MovingOnCurve ? angle % 360 : angle + degree;

            return angle * Math.PI / 180;
        }

        private double Angle(int index1, int index2)
        {
            var vec = new Vector(Bezier[index1].X - Bezier[index2].X, Bezier[index1].Y - Bezier[index2].Y);
            var scal = -(Bezier[index1].Y - Bezier[index2].Y);

            if (vec.X == 0) return vec.Y > 0 ? 90 : -90;

            var angle = Math.Acos(scal / Library.VectorLength(vec));
            return vec.X >= 0 ? angle * 180 / Math.PI - 90 : angle * -180 / Math.PI - 90;
        }
    }
}