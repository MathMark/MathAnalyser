﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MathAnalyser
{
    public interface IMainForm
    {
        string MessageBoard { get; set; }
        string InputData { get; }
        Bitmap Sheet { set; }
        int SheetWidth { get; }
        int SheetHeight { get; }


        event KeyPressEventHandler EnterPressed;
        event EventHandler SheetSizeChanged;
        event MouseEventHandler SheetMouseWheel;
        event EventHandler SetColor;
        event EventHandler SetDashStyle;

        event Action<int,int> MoveGraph;
        event Action<int, int> FinishMoving;

    }
    public partial class MainForm : Form,IMainForm
    {
        //TrigonometryStatementsPanel statementsPanel;

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

            Build p = new Build(pictureBox.Width, pictureBox.Height);
            Sheet = p.BuildAxes(Color.FromArgb(155,121,120,122),2,0,0);
            Sheet = p.BuildNet(Color.FromArgb(10, 121, 120, 122), 25,0,0);

            textBox_Function.KeyPress += TextBox_Function_KeyPress;
            pictureBox.SizeChanged += PictureBox_SizeChanged;
            pictureBox.MouseHover += PictureBox_MouseHover;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
            SetColorButton.Click += SetColorButton_Click;
            SetDashStyleButton.Click += SetDashStyleButton_Click;

            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseMove += PictureBox_MouseMove;
        }

        bool IsPressed;
        int MouseX;
        int MouseY;
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsPressed)
            {
                MoveGraph(e.X-MouseX, e.Y - MouseY);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            IsPressed = false;
            FinishMoving(e.X - MouseX, e.Y - MouseY);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            IsPressed = true;
            MouseX = e.X;
            MouseY = e.Y;
        }

        private void SetDashStyleButton_Click(object sender, EventArgs e)
        {
            SetDashStyle(this, e);
        }

        private void SetColorButton_Click(object sender, EventArgs e)
        {
            SetColor(this, e);
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
        public event EventHandler SetColor;
        public event EventHandler SetDashStyle;


        public event Action<int,int> MoveGraph;
        public event Action<int, int> FinishMoving;

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
        public string InputData
        {
            get
            {
                return textBox_Function.Text;
            }
        }

        //public ListViewItem FunctionListBox
      //  {
           // get
          //  {
               // return functionListBox.It
           // }
       // }//
       

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void TrigonometryStatementsButton_Click(object sender, EventArgs e)
        {
           // TrigonometryStatementsPanel statementsPanel = new TrigonometryStatementsPanel(this);
            //statementsPanel.Show();
        }

        private void HyperbolicalStatementsButton_Click(object sender, EventArgs e)
        {
           // HyperbolicalStatementsPanel hyperbolicalPanel = new HyperbolicalStatementsPanel(this);
           // hyperbolicalPanel.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideWindowButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MaximizeWindowButton_Click(object sender, EventArgs e)
        {
            if(this.WindowState== FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            
        }

        bool TogMove;
        int MValX;
        int MValY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X-MValX, MousePosition.Y - MValY);
            }
        }

        private void ClearMessageBoardButton_Click(object sender, EventArgs e)
        {
            MessageBoard = string.Empty;
        }
    }
}
