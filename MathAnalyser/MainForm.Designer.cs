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
            this.textBox_Function = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.View_Button = new System.Windows.Forms.ToolStripDropDownButton();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_White_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_Black_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_BlackBlue_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrigonometryStatementsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.HyperbolicalStatementsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.otherStatementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.messageBoard = new System.Windows.Forms.RichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.FunctionList = new System.Windows.Forms.ListView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SetColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.SetDashStyleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Function
            // 
            this.textBox_Function.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Function.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox_Function.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Function.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Function.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_Function.Location = new System.Drawing.Point(3, 28);
            this.textBox_Function.Name = "textBox_Function";
            this.textBox_Function.Size = new System.Drawing.Size(300, 19);
            this.textBox_Function.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.View_Button,
            this.AboutButton,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(870, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // View_Button
            // 
            this.View_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.View_Button.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.toolStripSeparator1,
            this.panelsToolStripMenuItem});
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
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // Theme_White_Button
            // 
            this.Theme_White_Button.Name = "Theme_White_Button";
            this.Theme_White_Button.Size = new System.Drawing.Size(159, 22);
            this.Theme_White_Button.Text = "White (standart)";
            // 
            // Theme_Black_Button
            // 
            this.Theme_Black_Button.Name = "Theme_Black_Button";
            this.Theme_Black_Button.Size = new System.Drawing.Size(159, 22);
            this.Theme_Black_Button.Text = "Black";
            // 
            // Theme_BlackBlue_Button
            // 
            this.Theme_BlackBlue_Button.Name = "Theme_BlackBlue_Button";
            this.Theme_BlackBlue_Button.Size = new System.Drawing.Size(159, 22);
            this.Theme_BlackBlue_Button.Text = "Black and Blue";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // panelsToolStripMenuItem
            // 
            this.panelsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatementsToolStripMenuItem,
            this.TrigonometryStatementsButton,
            this.HyperbolicalStatementsButton,
            this.otherStatementsToolStripMenuItem});
            this.panelsToolStripMenuItem.Name = "panelsToolStripMenuItem";
            this.panelsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.panelsToolStripMenuItem.Text = "Panels";
            // 
            // mainStatementsToolStripMenuItem
            // 
            this.mainStatementsToolStripMenuItem.Name = "mainStatementsToolStripMenuItem";
            this.mainStatementsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.mainStatementsToolStripMenuItem.Text = "Main Statements";
            // 
            // TrigonometryStatementsButton
            // 
            this.TrigonometryStatementsButton.Name = "TrigonometryStatementsButton";
            this.TrigonometryStatementsButton.Size = new System.Drawing.Size(209, 22);
            this.TrigonometryStatementsButton.Text = "Trigonometry Statements";
            this.TrigonometryStatementsButton.Click += new System.EventHandler(this.TrigonometryStatementsButton_Click);
            // 
            // HyperbolicalStatementsButton
            // 
            this.HyperbolicalStatementsButton.Name = "HyperbolicalStatementsButton";
            this.HyperbolicalStatementsButton.Size = new System.Drawing.Size(209, 22);
            this.HyperbolicalStatementsButton.Text = "Hyperbolical Statements";
            this.HyperbolicalStatementsButton.Click += new System.EventHandler(this.HyperbolicalStatementsButton_Click);
            // 
            // otherStatementsToolStripMenuItem
            // 
            this.otherStatementsToolStripMenuItem.Name = "otherStatementsToolStripMenuItem";
            this.otherStatementsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.otherStatementsToolStripMenuItem.Text = "Other Statements";
            // 
            // AboutButton
            // 
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(44, 22);
            this.AboutButton.Text = "About";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // messageBoard
            // 
            this.messageBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.messageBoard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageBoard.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageBoard.ForeColor = System.Drawing.Color.SteelBlue;
            this.messageBoard.Location = new System.Drawing.Point(3, 28);
            this.messageBoard.Name = "messageBoard";
            this.messageBoard.ReadOnly = true;
            this.messageBoard.Size = new System.Drawing.Size(269, 105);
            this.messageBoard.TabIndex = 4;
            this.messageBoard.Text = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FunctionList
            // 
            this.FunctionList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FunctionList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FunctionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FunctionList.ForeColor = System.Drawing.Color.White;
            listViewItem2.StateImageIndex = 0;
            this.FunctionList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.FunctionList.Location = new System.Drawing.Point(3, 28);
            this.FunctionList.Name = "FunctionList";
            this.FunctionList.Size = new System.Drawing.Size(249, 105);
            this.FunctionList.TabIndex = 6;
            this.FunctionList.UseCompatibleStateImageBehavior = false;
            this.FunctionList.View = System.Windows.Forms.View.SmallIcon;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator4});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(275, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::MathAnalyser.Properties.Resources.Cross;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator3});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(536, 15);
            this.toolStrip3.TabIndex = 9;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 12);
            this.toolStripButton2.Text = "toolStripButton1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 15);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 340);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 18);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(530, 319);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.messageBoard, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 374);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.80342F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.19658F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(275, 136);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.toolStrip4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBox_Function, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(552, 28);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(306, 92);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.SetColorButton,
            this.toolStripSeparator6,
            this.SetDashStyleButton,
            this.toolStripDropDownButton2});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(306, 25);
            this.toolStrip4.TabIndex = 7;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // SetColorButton
            // 
            this.SetColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SetColorButton.Image = ((System.Drawing.Image)(resources.GetObject("SetColorButton.Image")));
            this.SetColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetColorButton.Name = "SetColorButton";
            this.SetColorButton.Size = new System.Drawing.Size(59, 22);
            this.SetColorButton.Text = "Set Color";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.toolStrip5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.FunctionList, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(291, 374);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(255, 136);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // toolStrip5
            // 
            this.toolStrip5.AutoSize = false;
            this.toolStrip5.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripSeparator7,
            this.toolStripButton7,
            this.toolStripSeparator8});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip5.Size = new System.Drawing.Size(255, 25);
            this.toolStrip5.TabIndex = 7;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::MathAnalyser.Properties.Resources.Cross;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton1";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "toolStripButton3";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // SetDashStyleButton
            // 
            this.SetDashStyleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SetDashStyleButton.Image = ((System.Drawing.Image)(resources.GetObject("SetDashStyleButton.Image")));
            this.SetDashStyleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetDashStyleButton.Name = "SetDashStyleButton";
            this.SetDashStyleButton.Size = new System.Drawing.Size(84, 22);
            this.SetDashStyleButton.Text = "Set Dash Style";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(870, 522);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBox_Function;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton View_Button;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Theme_White_Button;
        private System.Windows.Forms.ToolStripMenuItem Theme_Black_Button;
        private System.Windows.Forms.ToolStripMenuItem Theme_BlackBlue_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.RichTextBox messageBoard;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ListView FunctionList;
        private System.Windows.Forms.ToolStripMenuItem panelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrigonometryStatementsButton;
        private System.Windows.Forms.ToolStripMenuItem HyperbolicalStatementsButton;
        private System.Windows.Forms.ToolStripMenuItem mainStatementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherStatementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton AboutButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton SetColorButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton SetDashStyleButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
    }
}

