using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace MathAnalyser
{
    class Presenter
    {
        IMainForm View;
        public Presenter(IMainForm View)
        {
            this.View = View;

            View.EnterPressed += View_EnterPressed;
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
