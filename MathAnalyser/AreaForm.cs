using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace MathAnalyser
{
    public partial class AreaForm : Form
    {
        IMainForm View;
        int Scale;

        string selectedfunction_Infix;
        string selectedfunction_Postfix;

        Depiction depiction;
        Color colorNet = Color.FromArgb(30, 121, 120, 122);
        Color colorAxes = Color.FromArgb(150, 121, 120, 122);

        float Area;
        //flags
        bool RM = false;//rectangles method
        bool McM = false;//Monte-Carlo method
        bool TM = false;//Trapezoid method
        public AreaForm()
        {
            InitializeComponent();
        }
        public AreaForm(IMainForm View, int Scale, ListView.ListViewItemCollection items)
        {
            InitializeComponent();
            this.View = View;
            this.Scale = Scale;
            
            foreach (ListViewItem item in items)
            {
                functionComboBox.Items.Add(item.Text);
            }
            this.functionComboBox.SelectedItem = functionComboBox.Items[0];
            selectedfunction_Infix = functionComboBox.SelectedItem.ToString();
            selectedfunction_Postfix = Parser.ConvertToPostfix(selectedfunction_Infix);

            analyzeButton.Click += AnalyzeButton_Click;
            exitButton.Click += ExitButton_Click;
            this.KeyDown += AreaForm_KeyDown;

            functionComboBox.SelectedIndexChanged += FunctionComboBox_SelectedIndexChanged;

            depiction = new Depiction(viewPort.Width, viewPort.Height);
            ViewPort = depiction.DrawScene(colorNet, colorAxes, Scale);
            ViewPort = depiction.DrawCurve(Pens.Red, Parser.GetValues(selectedfunction_Postfix, Scale, 
                depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));


            ShowVisibleSegments();
            functionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            rectanglesCount.ReadOnly = true;
            iterationsCount.ReadOnly = true;

            this.DoneButton.Click += DoneButton_Click;
            rectanglesCount.ValueChanged += NumericUpDown_ValueChanged;
            trapezoidsCount.ValueChanged += TrapezoidsCount_ValueChanged;

        }

        private void TrapezoidsCount_ValueChanged(object sender, EventArgs e)
        {
            if (trapezoidsCount.Value < 500 && trapezoidsCount.Value >= 100)
            {
                trapezoidsCount.Increment = 10;
            }
            else if (trapezoidsCount.Value < 100)
            {
                trapezoidsCount.Increment = 1;
            }
            if (trapezoidsCount.Value >= 500)
            {
                trapezoidsCount.Increment = 50;
            }

            try
            {
                if (TM)
                {
                    depiction.DrawScene(colorNet, colorAxes, Scale);
                    ViewPort = depiction.DrawCurve(Pens.Red, Parser.GetValues(selectedfunction_Postfix,
                           Scale, depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));
                    ViewPort = depiction.DrawVerticalLine((float)x1NUD.Value * Scale);
                    ViewPort = depiction.DrawVerticalLine((float)x2NUD.Value * Scale);

                    GetValueByTrapezoidRule();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (rectanglesCount.Value < 500 && rectanglesCount.Value >= 100)
            {
                rectanglesCount.Increment = 10;
            }
            else if(rectanglesCount.Value<100)
            {
                rectanglesCount.Increment = 1;
            }
            if(rectanglesCount.Value >= 500)
            {
                rectanglesCount.Increment = 50;
            }
            
            try
            {
                if (RM)
                {
                    depiction.DrawScene(colorNet, colorAxes, Scale);
                    ViewPort = depiction.DrawCurve(Pens.Red, Parser.GetValues(selectedfunction_Postfix,
                           Scale, depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));
                    ViewPort = depiction.DrawVerticalLine((float)x1NUD.Value * Scale);
                    ViewPort = depiction.DrawVerticalLine((float)x2NUD.Value * Scale);

                    GetValueByRectanglesRule();
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        void GetValueByMonteCarloRule()
        {
            ViewPort = depiction.DrawScene(colorNet, colorAxes, Scale);

            ViewPort = depiction.DrawCurve(Pens.Red,
                                           Parser.GetValues(selectedfunction_Postfix,
                                           Scale,
                                           depiction.CoordinatePlaneLocation.leftEdge,
                                           depiction.CoordinatePlaneLocation.rightEdge));

            float maxy = Math.Max(Math.Abs(Parser.GetValue(selectedfunction_Postfix, (float)x1NUD.Value)),
                             Math.Abs(Parser.GetValue(selectedfunction_Postfix, (float)x2NUD.Value)));
            RectangleF rectangle = new RectangleF((float)(x1NUD.Value * Scale), -maxy * Scale, (float)(x2NUD.Value - x1NUD.Value) * Scale, maxy * Scale);
            ViewPort = depiction.DrawRectangle(new Pen(Color.White), rectangle);

            float rfx = 0;
            float rfy = 0;
            int hits = 0;
            Color tempColor;
            for (int i = 0; i < iterationsCount.Value; i++)
            {
                rfx = (float)new Random(new Random().Next((int)(rfy * 1000))).NextDouble();
                rfy = (float)new Random(new Random().Next((int)(rfx * 1000))).NextDouble();
                PointF rp = new PointF(((float)x2NUD.Value - (float)x1NUD.Value) * rfx + (float)x1NUD.Value, maxy * rfy);
                if (rp.Y > Parser.GetValue(selectedfunction_Postfix, rp.X))
                    tempColor = Color.Pink;
                else
                {
                    tempColor = Color.DeepPink;
                    hits++;
                }
                
                depiction.DrawDot(1, tempColor, new PointF(rp.X * Scale, -rp.Y * Scale));
               progressBar1.Value = (int)(i / iterationsCount.Value * 100);
            }
        }
        void GetValueByRectanglesRule()
        {
            ViewPort = depiction.DrawRectangles(selectedfunction_Postfix,
                                                 (float)x1NUD.Value,
                                                 (float)x2NUD.Value,
                                                 (int)rectanglesCount.Value, 
                                                 Scale,
                                                 out Area);
            AreaText = Area;
        }
        void GetValueByTrapezoidRule()
        {
            ViewPort = depiction.DrawPolygons(selectedfunction_Postfix,
                                                     (float)x1NUD.Value,
                                                     (float)x2NUD.Value,
                                                     (int)trapezoidsCount.Value,
                                                     Scale, 
                                                     out Area);
            AreaText = Area;

        }
        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            depiction.DrawScene(colorNet, colorAxes, Scale);
            ViewPort = depiction.DrawCurve(Pens.Red, Parser.GetValues(selectedfunction_Postfix,
                   Scale, depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));
            RM = false;
            McM = false;
            TM = false;
        }

        void ShowVisibleSegments()
        {
            segmentXLabel.Text =
                $"Segment X: [{depiction.CoordinatePlaneLocation.leftEdge / Scale};{ depiction.CoordinatePlaneLocation.rightEdge / Scale}]";
            segmentYLabel.Text =
               $"Segment Y: [{-depiction.CoordinatePlaneLocation.bottomEdge / Scale};{ -depiction.CoordinatePlaneLocation.topEdge / Scale}]";

        }
        Bitmap ViewPort
        {
            get
            {
                return (Bitmap)viewPort.Image;
            }
            set
            {
                viewPort.Image = value;
            }
        }
        float AreaText
        {
            get
            {
                return Convert.ToSingle(resultTextBox.Text);
            }
            set
            {
                resultTextBox.Text = value.ToString();
            }
        }
        private void FunctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedfunction_Infix = functionComboBox.SelectedItem.ToString();
            selectedfunction_Postfix = Parser.ConvertToPostfix(selectedfunction_Infix);
            ViewPort = depiction.DrawScene(colorNet, colorAxes, Scale);
            ViewPort = depiction.DrawCurve(Pens.Red, Parser.GetValues(selectedfunction_Postfix, Scale,
                depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));
        }

        private void AreaForm_KeyDown(object sender, KeyEventArgs e)
        {
            int offsetX = Scale;
            int offsetY = Scale;
            bool keyPressed = false;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    depiction.StartPosition = new Point(offsetX, 0);
                    keyPressed = true;
                    break;
                case Keys.Right:
                    depiction.StartPosition = new Point(-offsetX, 0);
                    keyPressed = true;
                    break;
                case Keys.Up:
                    depiction.StartPosition = new Point(0, offsetY);
                    keyPressed = true;
                    break;
                case Keys.Down:
                    depiction.StartPosition = new Point(0, -offsetY);
                    keyPressed = true;
                    break;
            }
            if(keyPressed)
            {
                ShowVisibleSegments();
                depiction.DrawScene(colorNet, colorAxes, Scale);
                ViewPort = depiction.DrawCurve(Pens.Red, Parser.GetValues(selectedfunction_Postfix,
                       Scale, depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));
                
                if (RM)
                {
                    try
                    {
                        ViewPort = depiction.DrawVerticalLine((float)x1NUD.Value * Scale);
                        ViewPort = depiction.DrawVerticalLine((float)x2NUD.Value * Scale);
                        GetValueByRectanglesRule();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(McM)
                {
                    GetValueByMonteCarloRule();
                }
                if(TM)
                {
                    ViewPort = depiction.DrawVerticalLine((float)x1NUD.Value * Scale);
                    ViewPort = depiction.DrawVerticalLine((float)x2NUD.Value * Scale);
                    GetValueByTrapezoidRule();
                }
            }

        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                RM = false;
                TM = false;
                McM = true;
                GetValueByMonteCarloRule();
            }
            if(radioButton2.Checked)
            {
                try
                {
                    RM = true;
                    TM = false;
                    McM = false;
                    ViewPort = depiction.DrawScene(colorNet, colorAxes, Scale);

                    ViewPort = depiction.DrawCurve(Pens.Red,
                                                   Parser.GetValues(selectedfunction_Postfix,
                                                   Scale,
                                                   depiction.CoordinatePlaneLocation.leftEdge,
                                                   depiction.CoordinatePlaneLocation.rightEdge));
                    ViewPort = depiction.DrawVerticalLine((float)x1NUD.Value*Scale);
                    ViewPort = depiction.DrawVerticalLine((float)x2NUD.Value*Scale);
                    GetValueByRectanglesRule();
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message,"Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(radioButton3.Checked)
            {
                RM = false;
                TM = true;
                McM = false;
                ViewPort = depiction.DrawScene(colorNet, colorAxes, Scale);

                ViewPort = depiction.DrawCurve(Pens.Red,
                                               Parser.GetValues(selectedfunction_Postfix,
                                               Scale,
                                               depiction.CoordinatePlaneLocation.leftEdge,
                                               depiction.CoordinatePlaneLocation.rightEdge));
                ViewPort = depiction.DrawVerticalLine((float)x1NUD.Value * Scale);
                ViewPort = depiction.DrawVerticalLine((float)x2NUD.Value * Scale);

                GetValueByTrapezoidRule();
            }
        }

        bool TogMove;
        int MValX;
        int MValY;

        private void head_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void head_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void head_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }
    }
}
