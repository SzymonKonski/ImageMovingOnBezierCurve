
namespace BezierCurveApp
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfPointsNumeric = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.polylineCheckbox = new System.Windows.Forms.CheckBox();
            this.imageGroupBox = new System.Windows.Forms.GroupBox();
            this.kNumericValue = new System.Windows.Forms.NumericUpDown();
            this.reductionCheckBox = new System.Windows.Forms.CheckBox();
            this.grayScaleCheckbox = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.rotatingGroupBox = new System.Windows.Forms.GroupBox();
            this.filteringRadioButton = new System.Windows.Forms.RadioButton();
            this.naiveRadioButton = new System.Windows.Forms.RadioButton();
            this.animationGroupBox = new System.Windows.Forms.GroupBox();
            this.movingRadioButton = new System.Windows.Forms.RadioButton();
            this.rotationRadioButton = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLoadPolyline = new System.Windows.Forms.Button();
            this.btnSavePolyline = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsNumeric)).BeginInit();
            this.imageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kNumericValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.rotatingGroupBox.SuspendLayout();
            this.animationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(237, 1);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(813, 794);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bezier\'s curve";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of points:";
            // 
            // numberOfPointsNumeric
            // 
            this.numberOfPointsNumeric.Location = new System.Drawing.Point(109, 47);
            this.numberOfPointsNumeric.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numberOfPointsNumeric.Name = "numberOfPointsNumeric";
            this.numberOfPointsNumeric.Size = new System.Drawing.Size(81, 20);
            this.numberOfPointsNumeric.TabIndex = 3;
            this.numberOfPointsNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(120, 89);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(81, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // polylineCheckbox
            // 
            this.polylineCheckbox.AutoSize = true;
            this.polylineCheckbox.Checked = true;
            this.polylineCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.polylineCheckbox.Location = new System.Drawing.Point(16, 127);
            this.polylineCheckbox.Name = "polylineCheckbox";
            this.polylineCheckbox.Size = new System.Drawing.Size(94, 17);
            this.polylineCheckbox.TabIndex = 5;
            this.polylineCheckbox.Text = "Visible polyline";
            this.polylineCheckbox.UseVisualStyleBackColor = true;
            this.polylineCheckbox.CheckedChanged += new System.EventHandler(this.polylineCheckbox_CheckedChanged);
            // 
            // imageGroupBox
            // 
            this.imageGroupBox.Controls.Add(this.kNumericValue);
            this.imageGroupBox.Controls.Add(this.reductionCheckBox);
            this.imageGroupBox.Controls.Add(this.grayScaleCheckbox);
            this.imageGroupBox.Controls.Add(this.btnLoad);
            this.imageGroupBox.Controls.Add(this.imagePictureBox);
            this.imageGroupBox.Location = new System.Drawing.Point(16, 227);
            this.imageGroupBox.Name = "imageGroupBox";
            this.imageGroupBox.Size = new System.Drawing.Size(215, 182);
            this.imageGroupBox.TabIndex = 6;
            this.imageGroupBox.TabStop = false;
            this.imageGroupBox.Text = "Image";
            // 
            // kNumericValue
            // 
            this.kNumericValue.Location = new System.Drawing.Point(16, 138);
            this.kNumericValue.Name = "kNumericValue";
            this.kNumericValue.Size = new System.Drawing.Size(92, 20);
            this.kNumericValue.TabIndex = 4;
            this.kNumericValue.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // reductionCheckBox
            // 
            this.reductionCheckBox.AutoSize = true;
            this.reductionCheckBox.Location = new System.Drawing.Point(115, 44);
            this.reductionCheckBox.Name = "reductionCheckBox";
            this.reductionCheckBox.Size = new System.Drawing.Size(72, 17);
            this.reductionCheckBox.TabIndex = 3;
            this.reductionCheckBox.Text = "Redukcja";
            this.reductionCheckBox.UseVisualStyleBackColor = true;
            this.reductionCheckBox.CheckedChanged += new System.EventHandler(this.reductionCheckBox_CheckedChanged);
            // 
            // grayScaleCheckbox
            // 
            this.grayScaleCheckbox.AutoSize = true;
            this.grayScaleCheckbox.Location = new System.Drawing.Point(115, 20);
            this.grayScaleCheckbox.Name = "grayScaleCheckbox";
            this.grayScaleCheckbox.Size = new System.Drawing.Size(73, 17);
            this.grayScaleCheckbox.TabIndex = 2;
            this.grayScaleCheckbox.Text = "Grayscale";
            this.grayScaleCheckbox.UseVisualStyleBackColor = true;
            this.grayScaleCheckbox.CheckedChanged += new System.EventHandler(this.grayScaleCheckbox_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(125, 138);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(16, 20);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(90, 90);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePictureBox.TabIndex = 0;
            this.imagePictureBox.TabStop = false;
            // 
            // rotatingGroupBox
            // 
            this.rotatingGroupBox.Controls.Add(this.filteringRadioButton);
            this.rotatingGroupBox.Controls.Add(this.naiveRadioButton);
            this.rotatingGroupBox.Location = new System.Drawing.Point(16, 415);
            this.rotatingGroupBox.Name = "rotatingGroupBox";
            this.rotatingGroupBox.Size = new System.Drawing.Size(200, 100);
            this.rotatingGroupBox.TabIndex = 7;
            this.rotatingGroupBox.TabStop = false;
            this.rotatingGroupBox.Text = "Rotating";
            // 
            // filteringRadioButton
            // 
            this.filteringRadioButton.AutoSize = true;
            this.filteringRadioButton.Location = new System.Drawing.Point(25, 67);
            this.filteringRadioButton.Name = "filteringRadioButton";
            this.filteringRadioButton.Size = new System.Drawing.Size(83, 17);
            this.filteringRadioButton.TabIndex = 1;
            this.filteringRadioButton.TabStop = true;
            this.filteringRadioButton.Text = "With filtering";
            this.filteringRadioButton.UseVisualStyleBackColor = true;
            // 
            // naiveRadioButton
            // 
            this.naiveRadioButton.AutoSize = true;
            this.naiveRadioButton.Checked = true;
            this.naiveRadioButton.Location = new System.Drawing.Point(25, 30);
            this.naiveRadioButton.Name = "naiveRadioButton";
            this.naiveRadioButton.Size = new System.Drawing.Size(53, 17);
            this.naiveRadioButton.TabIndex = 0;
            this.naiveRadioButton.TabStop = true;
            this.naiveRadioButton.Text = "Naive";
            this.naiveRadioButton.UseVisualStyleBackColor = true;
            this.naiveRadioButton.CheckedChanged += new System.EventHandler(this.naiveRadioButton_CheckedChanged);
            // 
            // animationGroupBox
            // 
            this.animationGroupBox.Controls.Add(this.movingRadioButton);
            this.animationGroupBox.Controls.Add(this.rotationRadioButton);
            this.animationGroupBox.Location = new System.Drawing.Point(16, 550);
            this.animationGroupBox.Name = "animationGroupBox";
            this.animationGroupBox.Size = new System.Drawing.Size(200, 100);
            this.animationGroupBox.TabIndex = 8;
            this.animationGroupBox.TabStop = false;
            this.animationGroupBox.Text = "Animation";
            // 
            // movingRadioButton
            // 
            this.movingRadioButton.AutoSize = true;
            this.movingRadioButton.Checked = true;
            this.movingRadioButton.Location = new System.Drawing.Point(16, 68);
            this.movingRadioButton.Name = "movingRadioButton";
            this.movingRadioButton.Size = new System.Drawing.Size(105, 17);
            this.movingRadioButton.TabIndex = 1;
            this.movingRadioButton.TabStop = true;
            this.movingRadioButton.Text = "Moving on curve";
            this.movingRadioButton.UseVisualStyleBackColor = true;
            // 
            // rotationRadioButton
            // 
            this.rotationRadioButton.AutoSize = true;
            this.rotationRadioButton.Location = new System.Drawing.Point(16, 29);
            this.rotationRadioButton.Name = "rotationRadioButton";
            this.rotationRadioButton.Size = new System.Drawing.Size(65, 17);
            this.rotationRadioButton.TabIndex = 0;
            this.rotationRadioButton.TabStop = true;
            this.rotationRadioButton.Text = "Rotation";
            this.rotationRadioButton.UseVisualStyleBackColor = true;
            this.rotationRadioButton.CheckedChanged += new System.EventHandler(this.rotationRadioButton_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 700);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(131, 700);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLoadPolyline
            // 
            this.btnLoadPolyline.Location = new System.Drawing.Point(16, 165);
            this.btnLoadPolyline.Name = "btnLoadPolyline";
            this.btnLoadPolyline.Size = new System.Drawing.Size(97, 23);
            this.btnLoadPolyline.TabIndex = 11;
            this.btnLoadPolyline.Text = "Load a polyline";
            this.btnLoadPolyline.UseVisualStyleBackColor = true;
            this.btnLoadPolyline.Click += new System.EventHandler(this.btnLoadPolyline_Click);
            // 
            // btnSavePolyline
            // 
            this.btnSavePolyline.Location = new System.Drawing.Point(120, 165);
            this.btnSavePolyline.Name = "btnSavePolyline";
            this.btnSavePolyline.Size = new System.Drawing.Size(96, 23);
            this.btnSavePolyline.TabIndex = 12;
            this.btnSavePolyline.Text = "Save the polyline";
            this.btnSavePolyline.UseVisualStyleBackColor = true;
            this.btnSavePolyline.Click += new System.EventHandler(this.btnSavePolyline_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 759);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(418, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Uwaga do częsci labowej: redukcja koloow jest widoczne jedynie w tym malym okienk" +
    "u";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 795);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSavePolyline);
            this.Controls.Add(this.btnLoadPolyline);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.animationGroupBox);
            this.Controls.Add(this.rotatingGroupBox);
            this.Controls.Add(this.imageGroupBox);
            this.Controls.Add(this.polylineCheckbox);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.numberOfPointsNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsNumeric)).EndInit();
            this.imageGroupBox.ResumeLayout(false);
            this.imageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kNumericValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.rotatingGroupBox.ResumeLayout(false);
            this.rotatingGroupBox.PerformLayout();
            this.animationGroupBox.ResumeLayout(false);
            this.animationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberOfPointsNumeric;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox polylineCheckbox;
        private System.Windows.Forms.GroupBox imageGroupBox;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox rotatingGroupBox;
        private System.Windows.Forms.RadioButton naiveRadioButton;
        private System.Windows.Forms.RadioButton filteringRadioButton;
        private System.Windows.Forms.GroupBox animationGroupBox;
        private System.Windows.Forms.RadioButton rotationRadioButton;
        private System.Windows.Forms.RadioButton movingRadioButton;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox grayScaleCheckbox;
        private System.Windows.Forms.Button btnLoadPolyline;
        private System.Windows.Forms.Button btnSavePolyline;
        private System.Windows.Forms.CheckBox reductionCheckBox;
        private System.Windows.Forms.NumericUpDown kNumericValue;
        private System.Windows.Forms.Label label3;
    }
}

