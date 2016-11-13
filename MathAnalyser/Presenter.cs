using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        int offset = 0;

        Pen pen;
        ColorDialog colordialog;

        List<Curve> Functions;

        public Presenter(IMainForm View)
        {
            this.View = View;

            View.EnterPressed += View_EnterPressed;
            View.SheetSizeChanged += View_SheetSizeChanged;
            View.SheetMouseWheel += View_SheetMouseWheel;
            View.SetColor += View_SetColor;
            View.SetDashStyle += View_SetDashStyle;

            Functions = new List<Curve>();
            p = new Build(View.SheetWidth, View.SheetHeight);
            pen = new Pen(Color.Red,2);
            colordialog = new ColorDialog();

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
            p = new Build(View.SheetWidth, View.SheetHeight);
            
            View.Sheet = p.BuildAxes(Color.FromArgb(155, 121, 120, 122), 2);
            if (e.Delta>0)
            {
                if(offset<50)
                {
                    offset++;
                }
            }
            else
            {
                if (offset >-20)
                {
                    offset--;
                }
            }
            View.Sheet = p.BuildNet(Color.FromArgb(10, 121, 120, 122), scale + offset);
            if (Functions.Count != 0)
            {
                foreach (Curve function in Functions)
                {
                    View.Sheet = p.DrawFunction(function.PostfixNotation,
                        function.CurvePen, scale + offset);
                }
            }

        }

        private void View_SheetSizeChanged(object sender, EventArgs e)
        {
            p = new Build(View.SheetWidth, View.SheetHeight);
            View.Sheet = p.BuildAxes(Color.FromArgb(155, 121, 120, 122), 2);
            View.Sheet = p.BuildNet(Color.FromArgb(10, 121, 120, 122), scale + offset);

            if (Functions.Count != 0)
            {
                foreach (Curve function in Functions)
                {
                    View.Sheet = p.DrawFunction(function.PostfixNotation,
                        function.CurvePen, scale + offset);
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
                List<string> Postfix = Converter.ConvertToPostfix(View.InputData);
                View.Sheet = p.DrawFunction(Postfix,
                   pen, scale);
                Functions.Add(new Curve(Postfix,pen.Color,pen.Width,pen.DashStyle));
            }
            catch(Exception exception)
            {
                View.MessageBoard += "Error: " + exception.Message;
            }

        }
    }
}
