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

        bool rectangleMode = false;
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
                MessageBox.Show(item.Text);
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
            numericUpDown.ReadOnly = true;
            iterationsUpDown.ReadOnly = true;

            this.DoneButton.Click += DoneButton_Click;

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
            rectangleMode = false;
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
                
                if (rectangleMode)
                {
                    ViewPort = depiction.DrawRectangles(selectedfunction_Postfix,
                                                  (float)x1NUD.Value,
                                                  (float)x2NUD.Value,
                                                  (int)numericUpDown.Value, Scale);
                }
            }

        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {

            }
            if(radioButton2.Checked)
            {
                rectangleMode = true;

                ViewPort= depiction.DrawScene(colorNet, colorAxes, Scale);

                ViewPort = depiction.DrawCurve(Pens.Red,
                                               Parser.GetValues(selectedfunction_Postfix,
                                               Scale, 
                                               depiction.CoordinatePlaneLocation.leftEdge, 
                                               depiction.CoordinatePlaneLocation.rightEdge));

                ViewPort = depiction.DrawRectangles(selectedfunction_Postfix,
                                                 (float)x1NUD.Value,
                                                 (float)x2NUD.Value,
                                                 (int)numericUpDown.Value, Scale);

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
