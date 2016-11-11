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
            View.MessageBoard+="Input Line: "+View.InputBoard+" Output Line: "+
                String.Concat<string>(Converter.ConvertToPostfix(View.InputBoard));
        }
    }
}
