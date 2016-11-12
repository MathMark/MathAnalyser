using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BL;

namespace MathAnalyser
{
    class Presenter
    {
        IMainForm View;
        Build p;
        int scale = 25;
        int offset = 0;
        List<string> Functions;

        public Presenter(IMainForm View)
        {
            this.View = View;

            View.EnterPressed += View_EnterPressed;
            View.SheetSizeChanged += View_SheetSizeChanged;
            View.SheetMouseWheel += View_SheetMouseWheel;

            Functions = new List<string>();
            p = new Build(View.SheetWidth, View.SheetHeight);
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
                foreach (string function in Functions)
                {
                    View.Sheet = p.DrawFunction(Converter.ConvertToPostfix(function),
                        Color.Red, 2, System.Drawing.Drawing2D.DashStyle.Solid, scale + offset);
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
                foreach (string function in Functions)
                {
                    View.Sheet = p.DrawFunction(Converter.ConvertToPostfix(function),
                        Color.Red, 2, System.Drawing.Drawing2D.DashStyle.Solid, scale + offset);
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
            View.Sheet = p.DrawFunction(Converter.ConvertToPostfix(View.InputData),
                Color.Red, 2, System.Drawing.Drawing2D.DashStyle.Solid, scale);
            Functions.Add(View.InputData);

        }
    }
}
