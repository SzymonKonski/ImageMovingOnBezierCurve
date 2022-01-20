using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Point = System.Windows.Point;

namespace BezierCurveApp
{
    public partial class Form1
    {
        private AnimationState animationState = AnimationState.Stopped;
        private AnimationType animationType = AnimationType.MovingOnCurve;
        private int bezierIndex;
        private int degree;
        private DirectBitmap grayImage;
        private DirectBitmap image;
        private DirectBitmap reducImage;
        private Color[,] imageColors;
        private Color[,] imageGrayColors;

        private RotationType rotationType = RotationType.Naive;
        private List<Vertex> ControlPoints { get; } = new();
        private List<Point> Bezier { get; set; } = new();

        public void CalculateBezier()
        {
            Bezier.Clear();
            var bezierPoints = 201;
            var bezierArray = new Point[bezierPoints];
            var n = ControlPoints.Count - 1;

            Parallel.For(0, bezierPoints, p =>
            {
                var t = p / (double) (bezierPoints - 1);
                double x = 0;
                double y = 0;

                for (var i = 0; i <= n; i++)
                {
                    var b = Library.BernsteinBasisPolynomial(n, i, t);
                    x += b * ControlPoints[i].X;
                    y += b * ControlPoints[i].Y;
                }

                bezierArray[p] = new Point(x, y);
            });

            Bezier = bezierArray.ToList();
            bezierIndex = Math.Min(Bezier.Count - 1, bezierIndex);
        }

        private void HandleAnimation(object sender, EventArgs e)
        {
            if (animationType == AnimationType.MovingOnCurve)
            {
                bezierIndex++;
                if (bezierIndex >= Bezier.Count) bezierIndex = 0;
            }
            else if (animationType == AnimationType.Rotation)
            {
                degree += 1;
                if (degree == 360)
                    degree = 0;
            }

            pictureBox.Refresh();
        }

        private void LoadImage(Bitmap bitmap)
        {
            image = new DirectBitmap(GetScaledImage(bitmap));
            grayImage = new DirectBitmap(GetScaledImage(bitmap));
            reducImage = new DirectBitmap(GetScaledImage(bitmap));
            imageColors = new Color[image.Width, image.Height];
            imageGrayColors = new Color[image.Width, image.Height];

            for (var i = 0; i < image.Width; i++)
            for (var j = 0; j < image.Height; j++)
            {
                var color = image.GetPixel(i, j);
                var grayScale = (int) (color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
                var grayColor = Color.FromArgb(color.A, grayScale, grayScale, grayScale);
                imageColors[i, j] = color;
                imageGrayColors[i, j] = grayColor;
                grayImage.SetPixel(i, j, grayColor);
            }


            imagePictureBox.Image = grayScaleCheckbox.Checked ? grayImage.Bitmap : image.Bitmap;
            imagePictureBox.Refresh();
        }

        private Bitmap GetScaledImage(Bitmap bitmap)
        {
            return new Bitmap(bitmap, imagePictureBox.Width, imagePictureBox.Height);
        }

        private void LockAllButtons()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnLoadPolyline.Enabled = false;
            btnSavePolyline.Enabled = false;
            btnLoad.Enabled = false;
        }

        private void UnlockAllButtons()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnLoadPolyline.Enabled = true;
            btnSavePolyline.Enabled = true;
            btnLoad.Enabled = true;
        }

        private void StopAnimation()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            animationState = AnimationState.Stopped;
            timer.Stop();
        }

        private void StartAnimation()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            animationState = AnimationState.Playing;
            timer.Start();
        }

        private void GeneratePoints()
        {
            ControlPoints.Clear();
            var startVertex = new Vertex(pictureBox.Width / 5, pictureBox.Height / 2);
            var endVertex = new Vertex(4 * pictureBox.Width / 5, pictureBox.Height / 2);
            var count = (int)numberOfPointsNumeric.Value;
            var hx = (endVertex.X - startVertex.X) / (double)(count - 1);
            var hy = (endVertex.Y - startVertex.Y) / (double)(count - 1);
            double x = startVertex.X;
            double y = startVertex.Y;
            ControlPoints.Add(startVertex);
            for (var i = 1; i < count - 1; i++)
            {
                x += hx;
                y += hy;
                ControlPoints.Add(new Vertex((int)x, (int)y));
            }

            ControlPoints.Add(endVertex);
        }
    }
}