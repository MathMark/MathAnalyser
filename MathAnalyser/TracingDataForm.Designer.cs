namespace MathAnalyser
{
    partial class TracingDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TracingDataForm));
            this.functionLabel = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.scene = new System.Windows.Forms.PictureBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.segmentYLabel = new System.Windows.Forms.Label();
            this.segmentXLabel = new System.Windows.Forms.Label();
            this.derivativeLabel = new System.Windows.Forms.Label();
            this.comboBoxForFunctions = new System.Windows.Forms.ComboBox();
            this.incrementValueBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.head = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scene)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incrementValueBox)).BeginInit();
            this.head.SuspendLayout();
            this.SuspendLayout();
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.functionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.functionLabel.Location = new System.Drawing.Point(3, 5);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(42, 15);
            this.functionLabel.TabIndex = 0;
            this.functionLabel.Text = "f(x):";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.ForeColor = System.Drawing.SystemColors.Control;
            this.labelX.Location = new System.Drawing.Point(586, 28);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(28, 15);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X: ";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY.ForeColor = System.Drawing.SystemColors.Control;
            this.labelY.Location = new System.Drawing.Point(643, 28);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(28, 15);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y: ";
            // 
            // scene
            // 
            this.scene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.scene.Location = new System.Drawing.Point(6, 28);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(574, 295);
            this.scene.TabIndex = 3;
            this.scene.TabStop = false;
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.Red;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoneButton.ForeColor = System.Drawing.Color.White;
            this.DoneButton.Location = new System.Drawing.Point(724, 3);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(26, 25);
            this.DoneButton.TabIndex = 4;
            this.DoneButton.TabStop = false;
            this.DoneButton.Text = "X";
            this.DoneButton.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.labelY);
            this.panel1.Controls.Add(this.labelX);
            this.panel1.Controls.Add(this.segmentYLabel);
            this.panel1.Controls.Add(this.segmentXLabel);
            this.panel1.Controls.Add(this.derivativeLabel);
            this.panel1.Controls.Add(this.scene);
            this.panel1.Controls.Add(this.functionLabel);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 337);
            this.panel1.TabIndex = 7;
            // 
            // segmentYLabel
            // 
            this.segmentYLabel.AutoSize = true;
            this.segmentYLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.segmentYLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.segmentYLabel.Location = new System.Drawing.Point(586, 308);
            this.segmentYLabel.Name = "segmentYLabel";
            this.segmentYLabel.Size = new System.Drawing.Size(112, 15);
            this.segmentYLabel.TabIndex = 10;
            this.segmentYLabel.Text = "Segment Y: [;] ";
            // 
            // segmentXLabel
            // 
            this.segmentXLabel.AutoSize = true;
            this.segmentXLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.segmentXLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.segmentXLabel.Location = new System.Drawing.Point(586, 288);
            this.segmentXLabel.Name = "segmentXLabel";
            this.segmentXLabel.Size = new System.Drawing.Size(112, 15);
            this.segmentXLabel.TabIndex = 9;
            this.segmentXLabel.Text = "Segment X: [;] ";
            // 
            // derivativeLabel
            // 
            this.derivativeLabel.AutoSize = true;
            this.derivativeLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.derivativeLabel.ForeColor = System.Drawing.Color.White;
            this.derivativeLabel.Location = new System.Drawing.Point(586, 95);
            this.derivativeLabel.Name = "derivativeLabel";
            this.derivativeLabel.Size = new System.Drawing.Size(56, 15);
            this.derivativeLabel.TabIndex = 8;
            this.derivativeLabel.Text = "f\'(x): ";
            // 
            // comboBoxForFunctions
            // 
            this.comboBoxForFunctions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.comboBoxForFunctions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxForFunctions.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxForFunctions.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxForFunctions.FormattingEnabled = true;
            this.comboBoxForFunctions.Location = new System.Drawing.Point(84, 383);
            this.comboBoxForFunctions.Name = "comboBoxForFunctions";
            this.comboBoxForFunctions.Size = new System.Drawing.Size(217, 23);
            this.comboBoxForFunctions.TabIndex = 10;
            // 
            // incrementValueBox
            // 
            this.incrementValueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.incrementValueBox.DecimalPlaces = 2;
            this.incrementValueBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incrementValueBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.incrementValueBox.InterceptArrowKeys = false;
            this.incrementValueBox.Location = new System.Drawing.Point(385, 383);
            this.incrementValueBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.incrementValueBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.incrementValueBox.Name = "incrementValueBox";
            this.incrementValueBox.Size = new System.Drawing.Size(58, 23);
            this.incrementValueBox.TabIndex = 11;
            this.incrementValueBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(9, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Function:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(307, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Increment:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // head
            // 
            this.head.BackColor = System.Drawing.Color.SteelBlue;
            this.head.Controls.Add(this.DoneButton);
            this.head.Controls.Add(this.label4);
            this.head.Controls.Add(this.label3);
            this.head.Location = new System.Drawing.Point(0, 0);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(753, 34);
            this.head.TabIndex = 14;
            this.head.MouseDown += new System.Windows.Forms.MouseEventHandler(this.head_MouseDown);
            this.head.MouseMove += new System.Windows.Forms.MouseEventHandler(this.head_MouseMove);
            this.head.MouseUp += new System.Windows.Forms.MouseEventHandler(this.head_MouseUp);
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
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(48, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Function tracing";
            // 
            // TracingDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(752, 416);
            this.Controls.Add(this.head);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.incrementValueBox);
            this.Controls.Add(this.comboBoxForFunctions);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TracingDataForm";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TracingDataForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.scene)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incrementValueBox)).EndInit();
            this.head.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox scene;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label derivativeLabel;
        private System.Windows.Forms.ComboBox comboBoxForFunctions;
        private System.Windows.Forms.NumericUpDown incrementValueBox;
        private System.Windows.Forms.Label segmentXLabel;
        private System.Windows.Forms.Label segmentYLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel head;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}