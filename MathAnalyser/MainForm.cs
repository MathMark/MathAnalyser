﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MathAnalyser.Properties;

namespace MathAnalyser
{
    public interface IMainForm
    {
        string MessageBoard { get; set; }
        string InputBoard { get; }
        Bitmap Sheet { set; }
        int SheetWidth { get; }
        int SheetHeight { get; }


        event KeyPressEventHandler EnterPressed;
        event EventHandler SheetSizeChanged;
        event MouseEventHandler SheetMouseWheel;

    }
    public partial class MainForm : Form,IMainForm
    {
        TrigonometryStatementsPanel statementsPanel;

        public MainForm()
        {
            InitializeComponent();

            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            this.Height = 2*screenSize.Size.Height/3;
            this.Width= 2*screenSize.Size.Width / 3;

            //GetTheme((string)Settings.Default["Theme"]);
//
           // statementsPanel = new TrigonometryStatementsPanel(this);
           // statementsPanel.Show();

            Preparation p = new Preparation(pictureBox.Width, pictureBox.Height);
            Sheet = p.BuildAxes(Color.FromArgb(155,121,120,122),2);
            Sheet = p.BuildNet(Color.FromArgb(10, 121, 120, 122), 25);

            textBox_Function.KeyPress += TextBox_Function_KeyPress;
            pictureBox.SizeChanged += PictureBox_SizeChanged;
            pictureBox.MouseHover += PictureBox_MouseHover;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
        }

        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            pictureBox.Focus();
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            SheetMouseWheel(this, e);
        }

        private void PictureBox_SizeChanged(object sender, EventArgs e)
        {
            SheetSizeChanged(this, e);
        }

        private void TextBox_Function_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EnterPressed(this, e);
            }
            
        }

        public event KeyPressEventHandler EnterPressed;
        public event EventHandler SheetSizeChanged;
        public event MouseEventHandler SheetMouseWheel;

        public Bitmap Sheet
        {
            set
            {
                pictureBox.Image = value;
            }
        }
        public int SheetWidth
        {
            get
            {
                return pictureBox.Width;
            }
        }
        public int SheetHeight
        {
            get
            {
                return pictureBox.Height;
            }
        }
        public string MessageBoard
        {
            get
            {
                return messageBoard.Text;
            }
            set
            {
                messageBoard.Text=value+"\n";
            }
        }
        public string InputBoard
        {
            get
            {
                return textBox_Function.Text;
            }
        }
        //private void Theme_White_Button_Click(object sender, EventArgs e)
        //{
        //    Settings.Default["Theme"] = "White";
        //    Settings.Default.Save();
        //    GetTheme((string)Settings.Default["Theme"]);
        //}

        //private void Theme_Black_Button_Click(object sender, EventArgs e)
        //{
        //    Settings.Default["Theme"] = "Black";
        //    Settings.Default.Save();
        //    GetTheme((string)Settings.Default["Theme"]);
        //}

        //private void Theme_BlackBlue_Button_Click(object sender, EventArgs e)
        //{
        //    Settings.Default["Theme"] = "BlackBlue";
        //    Settings.Default.Save();
        //    GetTheme((string)Settings.Default["Theme"]);
        //}

        //private void GetTheme(string Parameter)
        //{
        //    switch(Parameter)
        //    {
        //        case "White":
        //            this.BackColor = Color.White;
        //            this.textBox_Function.BackColor = Color.White;
        //            this.textBox_Function.ForeColor = Color.Black;

        //            toolStrip1.BackColor = Color.White;

        //            foreach (ToolStripItem item in toolStrip1.Items)
        //            {
        //                if (item is ToolStripDropDownButton)
        //                {
        //                    item.ForeColor = Color.Black;
        //                }
        //            }

        //            messageBoard.BackColor = Color.FromArgb(255, 255, 255);
        //            messageBoard.ForeColor = Color.Gray;

        //            break;
        //        case "Black":
        //            this.BackColor = Color.FromArgb(40, 40, 40);

        //            this.textBox_Function.BackColor = Color.FromArgb(50, 50, 50);
        //            this.textBox_Function.ForeColor = Color.White;

        //            toolStrip1.BackColor = Color.FromArgb(20, 20, 20); 

        //            foreach(ToolStripItem item in toolStrip1.Items)
        //            {
        //                if(item is ToolStripDropDownButton)
        //                {
        //                    item.ForeColor = Color.White;
        //                }
        //            }

        //            messageBoard.BackColor= Color.FromArgb(20, 20, 20);
        //            messageBoard.ForeColor = Color.Gray;

        //            break;
        //        case "BlackBlue":
        //            break;
        //    }
        //}


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void TrigonometryStatementsButton_Click(object sender, EventArgs e)
        {
           // TrigonometryStatementsPanel statementsPanel = new TrigonometryStatementsPanel(this);
            statementsPanel.Show();
        }

        private void HyperbolicalStatementsButton_Click(object sender, EventArgs e)
        {
            HyperbolicalStatementsPanel hyperbolicalPanel = new HyperbolicalStatementsPanel(this);
            hyperbolicalPanel.Show();
        }
    }
}
