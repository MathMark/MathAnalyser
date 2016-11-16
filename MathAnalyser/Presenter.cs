using System;
using System.Collections.Generic;
using System.Drawing;
using BL;
using System.Windows.Forms;

namespace MathAnalyser
{
    class Presenter
    {
        IMainForm View;
        Build p;

        int scale = 25;


        Color ColorNet = Color.FromArgb(30, 121, 120, 122);
        Color ColorAxes = Color.FromArgb(155, 121, 120, 122);

        Pen pen;
        ColorDialog colordialog;
        List<string> Postfix;

        List<Curve> Functions;


        public Presenter(IMainForm View)
        {
            this.View = View;

            View.EnterPressed += View_EnterPressed;
            View.SheetSizeChanged += View_SheetSizeChanged;
            View.SheetMouseWheel += View_SheetMouseWheel;
            View.SetColor += View_SetColor;
            View.SetDashStyle += View_SetDashStyle;


            View.MoveGraph += View_MoveGraph;
            View.FinishMoving += View_FinishMoving;

            Functions = new List<Curve>();
            p = new Build(View.SheetWidth, View.SheetHeight);
            pen = new Pen(Color.Red,2);
            colordialog = new ColorDialog();

        }

        private void View_FinishMoving(int dx, int dy)
        {
            p.StartPosition = new Point(dx,dy);
            if(Functions.Count!=0)
            {
                foreach (Curve function in Functions)
                {
                    View.Sheet = p.DrawFunction(function.CurvePen, scale,
                        function.PostfixNotation);
                }
            }

        }

        private void View_MoveGraph(int dx, int dy)
        {
            View.Sheet = p.BuildAxes(ColorAxes, 2, dx, dy);
            View.Sheet = p.BuildNet(ColorNet, scale,dx,dy);;
            
        }

        private void View_SetDashStyle(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void View_SetColor(object sender, EventArgs e)
        {
           if( colordialog.ShowDialog()==DialogResult.OK)
            {
                pen.Color = colordialog.Color;
            }
        }

        private void View_SheetMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            View.Sheet = p.BuildAxes(ColorAxes, 2,0,0);
            if (e.Delta>0)
            {
                if(scale<50)
                {
                    scale++;
                }
            }
            else
            {
                if (scale >10)
                {
                    scale--;
                }
            }
            View.Sheet = p.BuildNet(ColorNet, scale,0,0);
            if (Functions.Count != 0)
            {
                foreach (Curve function in Functions)
                {
                    View.Sheet = p.DrawFunction(function.CurvePen, scale,
                        function.PostfixNotation);
                }
            }

        }

        private void View_SheetSizeChanged(object sender, EventArgs e)
        {
            p = new Build(View.SheetWidth, View.SheetHeight);
            View.Sheet = p.BuildAxes(ColorAxes, 2,0,0);
            View.Sheet = p.BuildNet(ColorNet, scale,0,0);

            if (Functions.Count != 0)
            {
                foreach (Curve function in Functions)
                {
                    View.Sheet = p.DrawFunction(function.CurvePen, scale,
                        function.PostfixNotation);
                }
            }
        }

        private void View_EnterPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                View.MessageBoard += "Input Line: " + View.InputData + " Output Line: " +
                    String.Concat<string>(Converter.ConvertToPostfix(View.InputData));
            }
            catch(InvalidOperationException)
            {
                View.MessageBoard += "InvalidOperationException - Stack is empty";
                View.MessageBoard += "Possible reason: The argument might have been forgotten";
            }
            try
            {
                Postfix = Converter.ConvertToPostfix(View.InputData);
                View.Sheet = p.DrawFunction(pen, scale, Postfix);
                Functions.Add(new Curve(Postfix,pen.Color,pen.Width,pen.DashStyle));
            }
            catch(Exception exception)
            {
                View.MessageBoard += "Error: " + exception.Message;
            }

        }
    }
}
