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
        Preparation p;
        int scale = 25;
        int offset = 0;
        public Presenter(IMainForm View)
        {
            this.View = View;

            View.EnterPressed += View_EnterPressed;
            View.SheetSizeChanged += View_SheetSizeChanged;
            View.SheetMouseWheel += View_SheetMouseWheel; ;
        }

        private void View_SheetMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            p = new Preparation(View.SheetWidth, View.SheetHeight);
            
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

        }

        private void View_SheetSizeChanged(object sender, EventArgs e)
        {
            p = new Preparation(View.SheetWidth, View.SheetHeight);
            View.Sheet = p.BuildAxes(Color.FromArgb(155, 121, 120, 122), 2);
            View.Sheet = p.BuildNet(Color.FromArgb(10, 121, 120, 122), scale + offset);
        }

        private void View_EnterPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                View.MessageBoard += "Input Line: " + View.InputBoard + " Output Line: " +
                    String.Concat<string>(Converter.ConvertToPostfix(View.InputBoard));
            }
            catch(InvalidOperationException)
            {
                View.MessageBoard += "InvalidOperationException - Stack is empty";
                View.MessageBoard += "Possible reason: The argument might have been forgotten";
            }
        }
    }
}
