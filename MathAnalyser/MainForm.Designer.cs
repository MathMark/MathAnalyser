namespace MathAnalyser
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "sin(x)"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Red, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "cos(x)"}, "(отсутствует)", System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192))))), null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "x^2-5"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Teal, null);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "abs(x+3)"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.RosyBrown, null);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "x-2"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_Function = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.View_Button = new System.Windows.Forms.ToolStripDropDownButton();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_White_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_Black_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_BlackBlue_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.messageBoard = new System.Windows.Forms.RichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.function1_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pictureBox1.Location = new System.Drawing.Point(10, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(536, 303);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_Function
            // 
            this.textBox_Function.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.textBox_Function.Location = new System.Drawing.Point(25, 37);
            this.textBox_Function.Name = "textBox_Function";
            this.textBox_Function.Size = new System.Drawing.Size(231, 23);
            this.textBox_Function.TabIndex = 1;
            this.textBox_Function.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Function_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.function1_label);
            this.groupBox1.Controls.Add(this.textBox_Function);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(552, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 94);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.View_Button});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(870, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // View_Button
            // 
            this.View_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.View_Button.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.toolStripSeparator1});
            this.View_Button.Image = ((System.Drawing.Image)(resources.GetObject("View_Button.Image")));
            this.View_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.View_Button.Name = "View_Button";
            this.View_Button.Size = new System.Drawing.Size(45, 22);
            this.View_Button.Text = "View";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Theme_White_Button,
            this.Theme_Black_Button,
            this.Theme_BlackBlue_Button});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // Theme_White_Button
            // 
            this.Theme_White_Button.Name = "Theme_White_Button";
            this.Theme_White_Button.Size = new System.Drawing.Size(159, 22);
            this.Theme_White_Button.Text = "White (standart)";
            this.Theme_White_Button.Click += new System.EventHandler(this.Theme_White_Button_Click);
            // 
            // Theme_Black_Button
            // 
            this.Theme_Black_Button.Name = "Theme_Black_Button";
            this.Theme_Black_Button.Size = new System.Drawing.Size(159, 22);
            this.Theme_Black_Button.Text = "Black";
            this.Theme_Black_Button.Click += new System.EventHandler(this.Theme_Black_Button_Click);
            // 
            // Theme_BlackBlue_Button
            // 
            this.Theme_BlackBlue_Button.Name = "Theme_BlackBlue_Button";
            this.Theme_BlackBlue_Button.Size = new System.Drawing.Size(159, 22);
            this.Theme_BlackBlue_Button.Text = "Black and Blue";
            this.Theme_BlackBlue_Button.Click += new System.EventHandler(this.Theme_BlackBlue_Button_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // messageBoard
            // 
            this.messageBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.messageBoard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBoard.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageBoard.ForeColor = System.Drawing.Color.White;
            this.messageBoard.Location = new System.Drawing.Point(10, 399);
            this.messageBoard.Name = "messageBoard";
            this.messageBoard.ReadOnly = true;
            this.messageBoard.Size = new System.Drawing.Size(536, 114);
            this.messageBoard.TabIndex = 4;
            this.messageBoard.Text = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel.Location = new System.Drawing.Point(7, 28);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(539, 485);
            this.panel.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            listViewItem2.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listView1.Location = new System.Drawing.Point(10, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(536, 56);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // function1_label
            // 
            this.function1_label.AutoSize = true;
            this.function1_label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.function1_label.ForeColor = System.Drawing.SystemColors.Control;
            this.function1_label.Location = new System.Drawing.Point(22, 19);
            this.function1_label.Name = "function1_label";
            this.function1_label.Size = new System.Drawing.Size(63, 15);
            this.function1_label.TabIndex = 7;
            this.function1_label.Text = "y = f(x)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(870, 522);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.messageBoard);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_Function;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton View_Button;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Theme_White_Button;
        private System.Windows.Forms.ToolStripMenuItem Theme_Black_Button;
        private System.Windows.Forms.ToolStripMenuItem Theme_BlackBlue_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.RichTextBox messageBoard;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label panel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label function1_label;
    }
}

