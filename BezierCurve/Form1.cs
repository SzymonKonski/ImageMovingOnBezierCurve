using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Xml.Serialization;
using BezierCurveApp.Properties;

namespace BezierCurveApp
{
    public partial class Form1
    {
        private readonly Pen bezierPen = new(Color.Black);
        private readonly Pen polylLinePen = new(Color.Blue);
        private readonly Timer timer;
        private readonly SolidBrush vertexBrush = new(Color.Red);
        private Point mousePosition;
        private Vertex selectedVertex;
        private bool addingVertices;
        private int addV;

        public Form1()
        {
            InitializeComponent();
            LoadImage(Resources.chessboard);
        
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += HandleAnimation;
            GeneratePoints();
            CalculateBezier();
            pictureBox.Refresh();
        }

        #region Buttons

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = @"image files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.jpeg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(dialog.FileName);
                LoadImage(img);
            }

            pictureBox.Refresh();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            StopAnimation();
            LockAllButtons();
            ControlPoints.Clear();
            bezierIndex = 0;
            Bezier.Clear();
            addV = (int)numberOfPointsNumeric.Value;
            addingVertices = true;
            pictureBox.MouseDown -= pictureBox1_MouseDown;
            pictureBox.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartAnimation();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAnimation();
            pictureBox.Refresh();
        }

        private void btnLoadPolyline_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = @"XML file | *.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var serializer = new XmlSerializer(typeof(List<Point>));
                using var stream = File.OpenRead(dialog.FileName);
                var points = (List<Point>) serializer.Deserialize(stream);
                ControlPoints.Clear();
                foreach (var p in points) ControlPoints.Add(new Vertex(p.X, p.Y));
                CalculateBezier();
                pictureBox.Refresh();
            }
        }

        private void btnSavePolyline_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = @"XML file | *.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var serializer = new XmlSerializer(typeof(List<Point>));
                using var stream = File.Create(dialog.FileName);
                var points = new List<Point>();
                foreach (var v in ControlPoints) points.Add(v.Point);
                serializer.Serialize(stream, points);
            }
        }

        #endregion

        #region Mouse

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var pos = new Point(e.Location.X, e.Location.Y);

            foreach (var v in ControlPoints)
                if (Library.DistanceBetweenPoints(v.Point, pos) <= (double) Vertex.Size / 2)
                {
                    selectedVertex = v;
                    mousePosition = pos;
                    return;
                }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (addingVertices)
                {
                    ControlPoints.Add(new Vertex(e.Location.X, e.Location.Y));
                    addV--;

                    if (addV == 0)
                    {
                        pictureBox.MouseDown -= pictureBox1_MouseDown;
                        pictureBox.MouseDown += pictureBox1_MouseDown;
                        addingVertices = false;
                        CalculateBezier();
                        UnlockAllButtons();
                    }
                    pictureBox.Refresh();
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedVertex != null)
            {
                var xDiff = mousePosition.X - e.X;
                var yDiff = mousePosition.Y - e.Y;
                selectedVertex.Position =
                    new Vector2(selectedVertex.Position.X - xDiff, selectedVertex.Position.Y - yDiff);
                mousePosition = e.Location;
                CalculateBezier();
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            selectedVertex = null;
        }

        #endregion

        #region RaddioButtons

        private void polylineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox.Refresh();
        }

        private void grayScaleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            imagePictureBox.Image = grayScaleCheckbox.Checked ? grayImage.Bitmap : image.Bitmap;
            imagePictureBox.Refresh();
        }

        private void naiveRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            rotationType = naiveRadioButton.Checked ? RotationType.Naive : RotationType.Filtered;
        }

        private void rotationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            animationType = rotationRadioButton.Checked ? AnimationType.Rotation : AnimationType.MovingOnCurve;
        }

        #endregion


        // Cześć labowa, Uwaga: redukcja zmienia jedynie obraz w tej małej ramce, nie dziala tez ze zmiana skali na szarosc
        private void reductionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!reductionCheckBox.Checked)
            {
                imagePictureBox.Image = image.Bitmap;
                imagePictureBox.Refresh();
                return;
            }

            Dictionary<(int r, int g, int b), int> colorPopularity1 = new Dictionary<(int r, int g, int b), int>();
            Dictionary<(int r, int g, int b), int> colorPopularity2 = new Dictionary<(int r, int g, int b), int>();
            Dictionary<(int r, int g, int b), int> colorPopularity3 = new Dictionary<(int r, int g, int b), int>();
            Dictionary<(int r, int g, int b), int> colorPopularity4 = new Dictionary<(int r, int g, int b), int>();
            Dictionary<(int r, int g, int b), int> colorPopularity5 = new Dictionary<(int r, int g, int b), int>();
            Dictionary<(int r, int g, int b), int> colorPopularity6 = new Dictionary<(int r, int g, int b), int>();
            Dictionary<(int r, int g, int b), int> colorPopularity7 = new Dictionary<(int r, int g, int b), int>();
            Dictionary<(int r, int g, int b), int> colorPopularity8 = new Dictionary<(int r, int g, int b), int>();

            for (int y = 0; y < image.Height; ++y)
            for (int x = 0; x < image.Width; ++x)
            {
                Color c = image.GetPixel(x, y);

                if (PointIsInCube(((int) c.R, (int) c.G, (int) c.B), 255 / 2, 0, 255 / 2, 0, 255 / 2, 0))
                {
                    if (colorPopularity1.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity1[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity1.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255/2, 255 / 2, 0, 255 / 2, 0))
                {
                    if (colorPopularity2.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity2[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity2.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }
                else if(PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255/2, 0, 255, 255/2, 255 / 2, 0))
                {
                    if (colorPopularity3.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity3[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity3.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255/2, 255, 255/2, 255 / 2, 0))
                {
                    if (colorPopularity4.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity4[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity4.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }

                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255 / 2, 0, 255 / 2, 0, 255, 255/2))
                {
                    if (colorPopularity5.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity5[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity5.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255 / 2, 255 / 2, 0, 255, 255/2))
                {
                    if (colorPopularity6.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity6[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity6.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255 / 2, 0, 255, 255 / 2, 255, 255/2))
                {
                    if (colorPopularity7.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity7[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity7.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255 / 2, 255, 255 / 2, 255, 255/2))
                {
                    if (colorPopularity8.ContainsKey((c.R, c.G, c.B)))
                        colorPopularity8[(c.R, c.G, c.B)]++;
                    else
                        colorPopularity8.Add(((int)c.R, (int)c.G, (int)c.B), 1);
                }
            }

            var list1 = GetList(colorPopularity1);
            var list2 = GetList(colorPopularity2);
            var list3 = GetList(colorPopularity3);
            var list4 = GetList(colorPopularity4);
            var list5 = GetList(colorPopularity5);
            var list6 = GetList(colorPopularity6);
            var list7 = GetList(colorPopularity7);
            var list8 = GetList(colorPopularity8);

            for (int y = 0; y < image.Height; ++y)
            for (int x = 0; x < image.Width; ++x)
            {

                Color c = image.GetPixel(x, y);

                if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255 / 2, 0, 255 / 2, 0, 255 / 2, 0))
                {
                   SetPixel(list1, c, x, y);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255 / 2, 255 / 2, 0, 255 / 2, 0))
                {
                    SetPixel(list2, c, x, y);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255 / 2, 0, 255, 255 / 2, 255 / 2, 0))
                {
                    SetPixel(list3, c, x, y);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255 / 2, 255, 255 / 2, 255 / 2, 0))
                {
                    SetPixel(list4, c, x, y);
                }

                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255 / 2, 0, 255 / 2, 0, 255, 255 / 2))
                {
                    SetPixel(list5, c, x, y);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255 / 2, 255 / 2, 0, 255, 255 / 2))
                {
                    SetPixel(list6, c, x, y);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255 / 2, 0, 255, 255 / 2, 255, 255 / 2))
                {
                    SetPixel(list7, c, x, y);
                }
                else if (PointIsInCube(((int)c.R, (int)c.G, (int)c.B), 255, 255 / 2, 255, 255 / 2, 255, 255 / 2))
                {
                    SetPixel(list8, c, x, y);
                }
            }

            imagePictureBox.Image = reducImage.Bitmap;
            imagePictureBox.Refresh();
        }

        private void SetPixel(List<(int r, int g, int b)> colors, Color c, int x, int y)
        {
            int minDistance = int.MaxValue;
            int id = -1;

            for (int i = 0; i < colors.Count; ++i)
            {
                int distance = (int)Math.Pow(c.R - colors[i].r, 2) + (int)Math.Pow(c.G - colors[i].g, 2) + (int)Math.Pow(c.B - colors[i].b, 2);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    id = i;
                }
            }
            reducImage.SetPixel(x, y, Color.FromArgb((byte)colors[id].r, (byte)colors[id].g, (byte)colors[id].b));
        }

        bool PointIsInCube((int r,int g,int b) color, float x_max, float x_min, float y_max, float y_min, float z_max, float z_min)
        {
            return (color.r <= x_max && color.r >= x_min) && (color.g <= y_max && color.g >= y_min) && (color.b <= z_max && color.b >= z_min);
        }

        private List<(int r, int g, int b)> GetList(Dictionary<(int r, int g, int b), int> colorPopularity)
        {
            int count = Math.Min((int)kNumericValue.Value / 8, colorPopularity.Count);

            var sortedArray = (from entry in colorPopularity orderby entry.Value descending select entry).Take(count).ToArray();
            List<(int r, int g, int b)> colors = new List<(int r, int g, int b)>();

            for (int i = 0; i < count; ++i)
                colors.Add(sortedArray[i].Key);

            return colors;
        }
    }
}