namespace MathAnalyser
{
    partial class AreaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.iterationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.x2NUD = new System.Windows.Forms.NumericUpDown();
            this.x1NUD = new System.Windows.Forms.NumericUpDown();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.functionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.segmentYLabel = new System.Windows.Forms.Label();
            this.segmentXLabel = new System.Windows.Forms.Label();
            this.head = new System.Windows.Forms.Panel();
            this.DoneButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewPort = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x2NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x1NUD)).BeginInit();
            this.panel1.SuspendLayout();
            this.head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDown);
            this.groupBox1.Controls.Add(this.resultTextBox);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.iterationsUpDown);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.x2NUD);
            this.groupBox1.Controls.Add(this.x1NUD);
            this.groupBox1.Controls.Add(this.analyzeButton);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(606, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 369);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Area of the curvilinear trapezoid:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label9.Location = new System.Drawing.Point(13, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Quantity of rectangles:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // numericUpDown
            // 
            this.numericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown.Location = new System.Drawing.Point(168, 176);
            this.numericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown.TabIndex = 14;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // resultTextBox
            // 
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Location = new System.Drawing.Point(88, 319);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(128, 20);
            this.resultTextBox.TabIndex = 13;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(216, 8);
            this.progressBar1.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Iterations:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // iterationsUpDown
            // 
            this.iterationsUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iterationsUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.iterationsUpDown.Location = new System.Drawing.Point(104, 112);
            this.iterationsUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.iterationsUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.iterationsUpDown.Name = "iterationsUpDown";
            this.iterationsUpDown.Size = new System.Drawing.Size(64, 20);
            this.iterationsUpDown.TabIndex = 10;
            this.iterationsUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.iterationsUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // radioButton2
            // 
            this.radioButton2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.radioButton2.Location = new System.Drawing.Point(16, 136);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(136, 40);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "Rectangles method";
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioButton1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.radioButton1.Location = new System.Drawing.Point(16, 88);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(136, 24);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Monte-Carlo method";
            // 
            // x2NUD
            // 
            this.x2NUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x2NUD.DecimalPlaces = 2;
            this.x2NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.x2NUD.Location = new System.Drawing.Point(112, 53);
            this.x2NUD.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.x2NUD.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.x2NUD.Name = "x2NUD";
            this.x2NUD.Size = new System.Drawing.Size(56, 20);
            this.x2NUD.TabIndex = 7;
            this.x2NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.x2NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // x1NUD
            // 
            this.x1NUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.x1NUD.DecimalPlaces = 2;
            this.x1NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.x1NUD.Location = new System.Drawing.Point(40, 53);
            this.x1NUD.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.x1NUD.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.x1NUD.Name = "x1NUD";
            this.x1NUD.Size = new System.Drawing.Size(56, 20);
            this.x1NUD.TabIndex = 6;
            this.x1NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.x1NUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // analyzeButton
            // 
            this.analyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analyzeButton.Location = new System.Drawing.Point(6, 319);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(76, 24);
            this.analyzeButton.TabIndex = 0;
            this.analyzeButton.Text = "Analyze...";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(96, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 32);
            this.label7.TabIndex = 3;
            this.label7.Text = ";";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(168, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "]";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(16, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 32);
            this.label5.TabIndex = 1;
            this.label5.Text = "[";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Segment:";
            // 
            // functionComboBox
            // 
            this.functionComboBox.Location = new System.Drawing.Point(75, 405);
            this.functionComboBox.Name = "functionComboBox";
            this.functionComboBox.Size = new System.Drawing.Size(136, 21);
            this.functionComboBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(13, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Function:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(540, 405);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(60, 20);
            this.exitButton.TabIndex = 12;
            this.exitButton.Text = "Exit";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.segmentYLabel);
            this.panel1.Controls.Add(this.segmentXLabel);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 339);
            this.panel1.TabIndex = 17;
            // 
            // segmentYLabel
            // 
            this.segmentYLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.segmentYLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.segmentYLabel.Location = new System.Drawing.Point(3, 315);
            this.segmentYLabel.Name = "segmentYLabel";
            this.segmentYLabel.Size = new System.Drawing.Size(582, 16);
            this.segmentYLabel.TabIndex = 19;
            this.segmentYLabel.Text = "Segment Y:";
            // 
            // segmentXLabel
            // 
            this.segmentXLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.segmentXLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.segmentXLabel.Location = new System.Drawing.Point(3, 299);
            this.segmentXLabel.Name = "segmentXLabel";
            this.segmentXLabel.Size = new System.Drawing.Size(582, 16);
            this.segmentXLabel.TabIndex = 18;
            this.segmentXLabel.Text = "Segment X:";
            // 
            // head
            // 
            this.head.BackColor = System.Drawing.Color.SteelBlue;
            this.head.Controls.Add(this.DoneButton);
            this.head.Controls.Add(this.label2);
            this.head.Controls.Add(this.label3);
            this.head.Location = new System.Drawing.Point(0, 0);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(850, 34);
            this.head.TabIndex = 18;
            this.head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.head_MouseDown);
            this.head.MouseMove += new System.Windows.Forms.MouseEventHandler(this.head_MouseMove);
            this.head.MouseUp += new System.Windows.Forms.MouseEventHandler(this.head_MouseUp);
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.Red;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoneButton.ForeColor = System.Drawing.Color.White;
            this.DoneButton.Location = new System.Drawing.Point(821, 3);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(26, 25);
            this.DoneButton.TabIndex = 4;
            this.DoneButton.TabStop = false;
            this.DoneButton.Text = "X";
            this.DoneButton.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(48, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Calculating area beneath curve";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 21);
            this.label3.TabIndex = 10;
            // 
            // viewPort
            // 
            this.viewPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.viewPort.Location = new System.Drawing.Point(12, 57);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(588, 296);
            this.viewPort.TabIndex = 16;
            this.viewPort.TabStop = false;
            // 
            // AreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(850, 432);
            this.Controls.Add(this.head);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.functionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "AreaForm";
            this.Text = "AreaForm";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x2NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x1NUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.head.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown iterationsUpDown;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.NumericUpDown x2NUD;
        private System.Windows.Forms.NumericUpDown x1NUD;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox functionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox viewPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label segmentYLabel;
        private System.Windows.Forms.Label segmentXLabel;
        private System.Windows.Forms.Panel head;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}