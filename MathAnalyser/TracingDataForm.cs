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

        bool derivativeDepiction;
        bool extremumDepiction;
        Pen penForDerivativeCurve;

        PointF[] derivativeValues;
        PointF[] extremumValues;

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

            //////Scene = Painter.DrawCurve(penForCurve, scale, FunctionPostfix);

            Scene = Painter.DrawCurve(penForCurve, Parser.GetValues(FunctionPostfix,
                            scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));

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

            derivativeDepiction = false;
            extremumDepiction = false;
            checkBoxDerivative.CheckedChanged += CheckBox_CheckedChanged;
            checkBoxExt.CheckedChanged += CheckBoxExt_CheckedChanged;

            penForDerivativeCurve = new Pen(Color.CadetBlue, 2);
            penForDerivativeCurve.DashStyle=DashStyle.Dash;

            derivativeValues = Parser.FindDerivativeValues(FunctionPostfix, Scale,
                    Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge);
            extremumValues = Parser.FindExtrermums(FunctionPostfix, Scale, derivativeValues);
        }

        private void CheckBoxExt_CheckedChanged(object sender, EventArgs e)
        {
            extremumDepiction = !extremumDepiction;
            if(extremumDepiction)
            {
                buffer = new Bitmap(Scene);
                Scene = Painter.DrawDots(Painter, buffer, 5, Color.AliceBlue, extremumValues);
            }
            else
            {
                DrawScene(Color.FromArgb(30, 121, 120, 122),
                       Color.FromArgb(155, 121, 120, 122),
                       Scale);
                Scene = Painter.DrawCurve(penForCurve, Parser.GetValues(FunctionPostfix,
                             Scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));
                
                if (derivativeDepiction)
                {
                    buffer = new Bitmap(Scene);
                    Scene = Painter.DrawDots(Painter, buffer, 5, Color.AliceBlue, extremumValues);
                }

            }
            buffer = new Bitmap(Scene);
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            derivativeDepiction = !derivativeDepiction;
            if (derivativeDepiction)
            {
                buffer = new Bitmap(Scene);
                Scene = Painter.DrawCurve(penForDerivativeCurve, derivativeValues);
            }
            else
            {
                DrawScene(Color.FromArgb(30, 121, 120, 122),
                       Color.FromArgb(155, 121, 120, 122),
                       Scale);
                Scene = Painter.DrawCurve(penForCurve, Parser.GetValues(FunctionPostfix,
                             Scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));
                
                if (extremumDepiction)
                {
                    buffer = new Bitmap(Scene);
                    Scene = Painter.DrawDots(Painter, buffer, 5, Color.AliceBlue, extremumValues);
                }
                
            }
            buffer = new Bitmap(Scene);


        }

        private void FunctionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void TracingDataForm_LostFocus(object sender, EventArgs e)
        {
            //the code keeps focus only on the form
            if((MoveLeftButton.Focused)||
                (MoveRightButton.Focused)||
                checkBoxDerivative.Focused||
                checkBoxExt.Focused
                )
            {
                this.Focus();
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
            derivativeLabel.Text = $"f'(x): {Parser.GetDerivativeInPoint(FunctionPostfix, (float)(offset / Scale))}";
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
            derivativeLabel.Text = $"f'(x): {Parser.GetDerivativeInPoint(FunctionPostfix, (float)(offset / Scale))}";
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
