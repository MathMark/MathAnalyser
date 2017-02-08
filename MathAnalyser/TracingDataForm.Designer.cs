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
            this.MoveLeftButton = new System.Windows.Forms.Button();
            this.MoveRightButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.derivativeLabel = new System.Windows.Forms.Label();
            this.checkBoxDerivative = new System.Windows.Forms.CheckBox();
            this.checkBoxExt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.scene)).BeginInit();
            this.panel1.SuspendLayout();
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
            // MoveLeftButton
            // 
            this.MoveLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MoveLeftButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoveLeftButton.ForeColor = System.Drawing.Color.White;
            this.MoveLeftButton.Location = new System.Drawing.Point(392, 404);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(97, 30);
            this.MoveLeftButton.TabIndex = 5;
            this.MoveLeftButton.TabStop = false;
            this.MoveLeftButton.Text = "Move Left";
            this.MoveLeftButton.UseVisualStyleBackColor = true;
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MoveRightButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoveRightButton.ForeColor = System.Drawing.Color.White;
            this.MoveRightButton.Location = new System.Drawing.Point(495, 404);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(97, 30);
            this.MoveRightButton.TabIndex = 6;
            this.MoveRightButton.TabStop = false;
            this.MoveRightButton.Text = "Move Right";
            this.MoveRightButton.UseVisualStyleBackColor = true;
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
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 386);
            this.panel1.TabIndex = 7;
            // 
            // derivativeLabel
            // 
            this.derivativeLabel.AutoSize = true;
            this.derivativeLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.derivativeLabel.ForeColor = System.Drawing.Color.White;
            this.derivativeLabel.Location = new System.Drawing.Point(450, 336);
            this.derivativeLabel.Name = "derivativeLabel";
            this.derivativeLabel.Size = new System.Drawing.Size(56, 15);
            this.derivativeLabel.TabIndex = 8;
            this.derivativeLabel.Text = "f\'(x): ";
            // 
            // checkBoxDerivative
            // 
            this.checkBoxDerivative.AutoSize = true;
            this.checkBoxDerivative.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDerivative.ForeColor = System.Drawing.Color.White;
            this.checkBoxDerivative.Location = new System.Drawing.Point(16, 404);
            this.checkBoxDerivative.Name = "checkBoxDerivative";
            this.checkBoxDerivative.Size = new System.Drawing.Size(187, 19);
            this.checkBoxDerivative.TabIndex = 8;
            this.checkBoxDerivative.Text = "Depict derivative curve";
            this.checkBoxDerivative.UseVisualStyleBackColor = true;
            // 
            // checkBoxExt
            // 
            this.checkBoxExt.AutoSize = true;
            this.checkBoxExt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExt.ForeColor = System.Drawing.Color.White;
            this.checkBoxExt.Location = new System.Drawing.Point(16, 430);
            this.checkBoxExt.Name = "checkBoxExt";
            this.checkBoxExt.Size = new System.Drawing.Size(138, 19);
            this.checkBoxExt.TabIndex = 9;
            this.checkBoxExt.Text = "Depict extremums";
            this.checkBoxExt.UseVisualStyleBackColor = true;
            // 
            // TracingDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.checkBoxExt);
            this.Controls.Add(this.checkBoxDerivative);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MoveRightButton);
            this.Controls.Add(this.MoveLeftButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TracingDataForm";
            this.Text = "Trigonometry";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.scene)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox scene;
        private System.Windows.Forms.Button MoveLeftButton;
        private System.Windows.Forms.Button MoveRightButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label derivativeLabel;
        private System.Windows.Forms.CheckBox checkBoxDerivative;
        private System.Windows.Forms.CheckBox checkBoxExt;
    }
}