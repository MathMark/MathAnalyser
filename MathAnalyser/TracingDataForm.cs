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

        public Bitmap ViewPort
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

        string functionPostfix;
        string functionInfix;
        int Scale;
        float offset;
        double functionValue;

        Pen penForCurve;
        Pen penForCross;
        Color colorNet = Color.FromArgb(30, 121, 120, 122);
        Color colorAxes = Color.FromArgb(150, 121, 120, 122);
        Depiction Painter;
        IMainForm View;

        Bitmap buffer;

        Pen penForDerivativeCurve;
        float Increment
        {
            get
            {
                return (float)incrementValueBox.Value;
            }
        }
        public TracingDataForm()
        {
            InitializeComponent();
        }
        public TracingDataForm(IMainForm View,int scale, ListView.ListViewItemCollection items)
        {
            InitializeComponent();
            ///Add all available explicit functions to the list
            foreach (ListViewItem item in items)
            {
                if(!item.Text.Contains("["))
                {
                    comboBoxForFunctions.Items.Add(item.Text);
                }

            }
            if(comboBoxForFunctions.Items.Count!=0)
            {
                this.comboBoxForFunctions.SelectedItem = comboBoxForFunctions.Items[0];
            }
            ///Set colors for pens
            penForCurve = new Pen(Color.Blue, 2);
            penForCross = new Pen(Color.Red, 2);
            penForCross.DashStyle = DashStyle.Dash;
            ///Set the scale
            Scale = scale;

            this.View = View;
            ///Choose the first function in the list
            functionInfix = comboBoxForFunctions.Items[0].ToString();
            functionPostfix = Parser.ConvertToPostfix(functionInfix);

            offset = 0;

            functionLabel.Text = $"f(x) = {functionInfix}";

            Painter = new Depiction(scene.Width, scene.Height);

            Painter.DrawScene(colorNet, colorAxes,scale);

            ViewPort = Painter.DrawCurve(penForCurve, Parser.GetValues(functionPostfix,
                            scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));

            buffer =new Bitmap(ViewPort);

            this.DoneButton.Click += DoneButton_Click;

            this.comboBoxForFunctions.SelectedIndexChanged += ComboBoxForFunctions_SelectedIndexChanged;

            penForDerivativeCurve = new Pen(Color.CadetBlue, 2);
            penForDerivativeCurve.DashStyle=DashStyle.Dash;


            comboBoxForFunctions.LostFocus += ComboBoxForFunctions_LostFocus;
           // this.KeyPreview = true;

            ///Prohibit to edit the text
            comboBoxForFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            incrementValueBox.ReadOnly = true;

            incrementValueBox.ValueChanged += IncrementValueBox_ValueChanged;

            segmentXLabel.Text = $"Segment X: [{Painter.CoordinatePlaneLocation.leftEdge / Scale};{Painter.CoordinatePlaneLocation.rightEdge / Scale}]";
            segmentYLabel.Text = $"Segment Y: [{Painter.CoordinatePlaneLocation.bottomEdge / Scale};{Painter.CoordinatePlaneLocation.topEdge / Scale}]";
        }
        private void IncrementValueBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxForFunctions_LostFocus(object sender, EventArgs e)
        {
           // this.Focus();
        }

        private void ComboBoxForFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Painter = new Depiction(scene.Width, scene.Height);

            Painter.DrawScene(colorNet, colorAxes, Scale);
            functionInfix = comboBoxForFunctions.SelectedItem.ToString();
            functionLabel.Text = $"f(x) = {functionInfix}";
            functionPostfix = Parser.ConvertToPostfix(functionInfix);
            ViewPort = Painter.DrawCurve(penForCurve, Parser.GetValues(functionPostfix,
                            Scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));

            buffer = new Bitmap(ViewPort);
        }

       
        private void FunctionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        void MoveLineLeft()
        {
            offset -= Increment * Scale;
            
            functionValue = Parser.GetValue(functionPostfix,
                             (double)offset/Scale);

            
            ViewPort = Painter.SetCross(buffer,
                             penForCross,
                             (int)offset,
                             -Scale * Parser.GetValue(functionPostfix,
                             (double)offset / Scale));

            X = "\n"+Math.Round((offset/Scale),2).ToString();
            Y = "\n" + functionValue;
            derivativeLabel.Text = $"f'(x): {Parser.GetDerivativeInPoint(functionPostfix, (float)(offset / Scale))}";
        }

        void MoveLineRight()
        {
            offset += Increment * Scale;

            functionValue = Parser.GetValue(functionPostfix,
                            (double)offset/Scale);

            ViewPort = Painter.SetCross(buffer,
                             penForCross,
                             (int)offset,
                             -Scale * Parser.GetValue(functionPostfix,
                             (double)offset / Scale));
            

            X = "\n" + (offset / Scale).ToString();
            Y = "\n" + functionValue;
            derivativeLabel.Text = $"f'(x): {Parser.GetDerivativeInPoint(functionPostfix, (float)(offset / Scale))}";
        }
       

        private void DoneButton_Click(object sender, EventArgs e)
        {
            View.TraceMode = false;
            this.Close();
        }

        private void TracingDataForm_KeyDown(object sender, KeyEventArgs e)
        {
            int offsetX = Scale;
            int offsetY = Scale;
 
            switch (e.KeyCode)
            {
                case Keys.Oemcomma://<
                    MoveLineLeft();
                    break;
                case Keys.OemPeriod://>
                    MoveLineRight();
                    break;
                case Keys.Left:
                    Painter.StartPosition = new Point(offsetX,0);
                    Painter.DrawScene(colorNet, colorAxes, Scale);
                    ViewPort = Painter.DrawCurve(penForCurve, Parser.GetValues(functionPostfix,
                           Scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));
                    buffer = new Bitmap(ViewPort);
                    segmentXLabel.Text = $"Segment X: [{Painter.CoordinatePlaneLocation.leftEdge/Scale};{Painter.CoordinatePlaneLocation.rightEdge/Scale}]";
                    segmentYLabel.Text = $"Segment Y: [{Painter.CoordinatePlaneLocation.bottomEdge / Scale};{Painter.CoordinatePlaneLocation.topEdge / Scale}]";
                    break;
                case Keys.Right:
                    Painter.StartPosition = new Point(-offsetX, 0);
                    Painter.DrawScene(colorNet, colorAxes, Scale);
                    ViewPort = Painter.DrawCurve(penForCurve, Parser.GetValues(functionPostfix,
                           Scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));
                    buffer = new Bitmap(ViewPort);
                    segmentXLabel.Text = $"Segment X: [{Painter.CoordinatePlaneLocation.leftEdge / Scale};{Painter.CoordinatePlaneLocation.rightEdge / Scale}]";
                    segmentYLabel.Text = $"Segment Y: [{Painter.CoordinatePlaneLocation.bottomEdge / Scale};{Painter.CoordinatePlaneLocation.topEdge / Scale}]";
                    break;
                case Keys.Up:
                    Painter.StartPosition = new Point(0, offsetY);
                    Painter.DrawScene(colorNet, colorAxes, Scale);
                    ViewPort = Painter.DrawCurve(penForCurve, Parser.GetValues(functionPostfix,
                           Scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));
                    buffer = new Bitmap(ViewPort);
                    segmentXLabel.Text = $"Segment X: [{Painter.CoordinatePlaneLocation.leftEdge / Scale};{Painter.CoordinatePlaneLocation.rightEdge / Scale}]";
                    segmentYLabel.Text = $"Segment Y: [{Painter.CoordinatePlaneLocation.bottomEdge / Scale};{Painter.CoordinatePlaneLocation.topEdge / Scale}]";
                    break;
                case Keys.Down:
                    Painter.StartPosition = new Point(0, -offsetY);
                    Painter.DrawScene(colorNet, colorAxes, Scale);
                    ViewPort = Painter.DrawCurve(penForCurve, Parser.GetValues(functionPostfix,
                           Scale, Painter.CoordinatePlaneLocation.leftEdge, Painter.CoordinatePlaneLocation.rightEdge));
                    buffer = new Bitmap(ViewPort);
                    segmentXLabel.Text = $"Segment X: [{Painter.CoordinatePlaneLocation.leftEdge / Scale};{Painter.CoordinatePlaneLocation.rightEdge / Scale}]";
                    segmentYLabel.Text = $"Segment Y: [{Painter.CoordinatePlaneLocation.bottomEdge / Scale};{Painter.CoordinatePlaneLocation.topEdge / Scale}]";
                    break;
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
