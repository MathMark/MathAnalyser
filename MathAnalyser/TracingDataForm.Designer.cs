﻿namespace MathAnalyser
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
            ((System.ComponentModel.ISupportInitialize)(this.scene)).BeginInit();
            this.SuspendLayout();
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.functionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.functionLabel.Location = new System.Drawing.Point(12, 9);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(49, 15);
            this.functionLabel.TabIndex = 0;
            this.functionLabel.Text = "label1";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.ForeColor = System.Drawing.SystemColors.Control;
            this.labelX.Location = new System.Drawing.Point(12, 416);
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
            this.labelY.Location = new System.Drawing.Point(12, 449);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(28, 15);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y: ";
            // 
            // scene
            // 
            this.scene.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.scene.Location = new System.Drawing.Point(12, 38);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(562, 364);
            this.scene.TabIndex = 3;
            this.scene.TabStop = false;
            // 
            // DoneButton
            // 
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DoneButton.ForeColor = System.Drawing.Color.White;
            this.DoneButton.Location = new System.Drawing.Point(499, 444);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 31);
            this.DoneButton.TabIndex = 4;
            this.DoneButton.TabStop = false;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MoveLeftButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MoveLeftButton.ForeColor = System.Drawing.Color.White;
            this.MoveLeftButton.Location = new System.Drawing.Point(374, 408);
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
            this.MoveRightButton.Location = new System.Drawing.Point(477, 408);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(97, 30);
            this.MoveRightButton.TabIndex = 6;
            this.MoveRightButton.TabStop = false;
            this.MoveRightButton.Text = "Move Right";
            this.MoveRightButton.UseVisualStyleBackColor = true;
            // 
            // TracingDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(588, 481);
            this.Controls.Add(this.MoveRightButton);
            this.Controls.Add(this.MoveLeftButton);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.scene);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.functionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TracingDataForm";
            this.Text = "Trigonometry";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.scene)).EndInit();
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
    }
}