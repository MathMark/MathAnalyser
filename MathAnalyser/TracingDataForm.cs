using System;
using System.Drawing;
using System.Windows.Forms;
using BL;
using System.Drawing.Drawing2D;

namespace MathAnalyser
{
    public partial class TracingDataForm : Form
    {
        public string X
        {
            get
            {
                return labelX.Text;
            }
            set
            {
                labelX.Text = $"X: {value}";
            }
        }
        public string Y
        {
            get
            {
                return labelY.Text;
            }
            set
            {
                if (double.IsInfinity(Convert.ToDouble(value)))
                {
                    labelY.Text = "Y: \u00b1 \u221e";
                }
                else
                {
                    labelY.Text = $"Y: {value}";
                }
                
            }
        }

        public Bitmap Scene
        {
            get
            {
                return (Bitmap)scene.Image;
            }
            set
            {
                scene.Image = value;
            }
        }

        string FunctionPostfix;
        decimal Increment;
        int Scale;
        decimal offset;
        float functionValue;

        Pen penForCurve;
        Pen penForCross;

        Depiction Painter;
        IMainForm View;

        Bitmap buffer;

        public TracingDataForm()
        {
            InitializeComponent();
        }
        public TracingDataForm(IMainForm View,string function,decimal Increment,int scale,CoordinatePlane offets)
        {
            InitializeComponent();

            penForCurve = new Pen(Color.Blue, 2);
            penForCross = new Pen(Color.Red, 2);
            penForCross.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            Scale = scale;
            this.View = View;
            FunctionPostfix = Parser.ConvertToPostfix(function);
            this.Increment = Increment;
            offset = 0;

            functionLabel.Text = $"f(x) = {function}";

            Painter = new Depiction(scene.Width, scene.Height, offets);

            DrawScene(Color.FromArgb(30, 121, 120, 122), 
                      Color.FromArgb(155, 121, 120, 122),
                      scale);

            Scene = Painter.DrawCurve(penForCurve, scale, FunctionPostfix);
            buffer =new Bitmap(Scene);

            this.MouseDown += TracingDataForm_MouseDown;
            this.MouseUp += TracingDataForm_MouseUp;
            this.MouseMove += TracingDataForm_MouseMove;
            this.DoneButton.Click += DoneButton_Click;

            this.MoveLeftButton.Click += MoveLeftButton_Click;
            this.MoveRightButton.Click += MoveRightButton_Click;

            this.KeyPreview = true;
            this.PreviewKeyDown += TracingDataForm_PreviewKeyDown;


            this.LostFocus += TracingDataForm_LostFocus;

            
        }

        private void FunctionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void TracingDataForm_LostFocus(object sender, EventArgs e)
        {
            if((MoveLeftButton.Focused)||
                (MoveRightButton.Focused))
            {
                Focus();
            }   
        }

        private void TracingDataForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
            switch (e.KeyCode)
            {
                case Keys.Oemcomma://<
                    MoveLineLeft();
                    break;
                case Keys.OemPeriod://>
                    MoveLineRight();
                    break;
            }

        }


        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            MoveLineRight();
        }

        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            MoveLineLeft();
        }
        void MoveLineLeft()
        {
            offset -= Increment * Scale;

            functionValue = Parser.GetValue(FunctionPostfix,
                             (double)offset/Scale);

            Scene = Painter.SetCross(buffer,
                             penForCross,
                             (int)offset,
                             -Scale * Parser.GetValue(FunctionPostfix,
                             (double)offset / Scale));

            X = (offset/Scale).ToString();
            Y = (functionValue).ToString();
        }

        void MoveLineRight()
        {
            offset += Increment * Scale;

            functionValue = Parser.GetValue(FunctionPostfix,
                            (double)offset/Scale);

            Scene = Painter.SetCross(buffer,
                             penForCross,
                             (int)offset,
                             -Scale * Parser.GetValue(FunctionPostfix,
                             (double)offset / Scale));

            X = (offset / Scale).ToString();
            Y = (functionValue).ToString();
        }
        bool TogMove;
        int MValX;
        int MValY;

        private void TracingDataForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void TracingDataForm_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void TracingDataForm_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            View.TraceMode = false;
            this.Close();
        }

        public void DrawScene(Color colorNet,Color colorAxes,int scale/*int dx,int dy*/)
        {
            Painter.Clear();
           // Painter.StartPosition = new Point(dx, dy);

            Scene=Painter.BuildNet(colorNet, scale, 0, 0);
            Scene = Painter.BuildAxes(colorAxes, 2, 0, 0);
            Scene = Painter.SetNumberNet(scale);
        }


    }
}
