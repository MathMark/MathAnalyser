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
            this.functionLabel = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.scene = new System.Windows.Forms.PictureBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.derivativeLabel = new System.Windows.Forms.Label();
            this.comboBoxForFunctions = new System.Windows.Forms.ComboBox();
            this.incrementValueBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.scene)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incrementValueBox)).BeginInit();
            this.SuspendLayout();
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.functionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.functionLabel.Location = new System.Drawing.Point(3, 13);
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
            this.labelX.Location = new System.Drawing.Point(17, 336);
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
            this.labelY.Location = new System.Drawing.Point(17, 362);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(28, 15);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y: ";
            // 
            // scene
            // 
            this.scene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.scene.Location = new System.Drawing.Point(3, 33);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(574, 289);
            this.scene.TabIndex = 3;
            this.scene.TabStop = false;
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.Red;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoneButton.ForeColor = System.Drawing.Color.DarkRed;
            this.DoneButton.Location = new System.Drawing.Point(551, 3);
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
            this.panel1.Controls.Add(this.derivativeLabel);
            this.panel1.Controls.Add(this.scene);
            this.panel1.Controls.Add(this.functionLabel);
            this.panel1.Controls.Add(this.labelX);
            this.panel1.Controls.Add(this.DoneButton);
            this.panel1.Controls.Add(this.labelY);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 386);
            this.panel1.TabIndex = 7;
            // 
            // derivativeLabel
            // 
            this.derivativeLabel.AutoSize = true;
            this.derivativeLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.derivativeLabel.ForeColor = System.Drawing.Color.White;
            this.derivativeLabel.Location = new System.Drawing.Point(434, 336);
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
            this.comboBoxForFunctions.Location = new System.Drawing.Point(12, 402);
            this.comboBoxForFunctions.Name = "comboBoxForFunctions";
            this.comboBoxForFunctions.Size = new System.Drawing.Size(327, 23);
            this.comboBoxForFunctions.TabIndex = 10;
            this.comboBoxForFunctions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TracingDataForm_KeyDown);
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
            this.incrementValueBox.Location = new System.Drawing.Point(12, 430);
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
            this.incrementValueBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TracingDataForm_KeyDown);
            // 
            // TracingDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.incrementValueBox);
            this.Controls.Add(this.comboBoxForFunctions);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TracingDataForm";
            this.Text = "Trigonometry";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TracingDataForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.scene)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incrementValueBox)).EndInit();
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
    }
}