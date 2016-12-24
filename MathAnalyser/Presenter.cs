using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        string Postfix;

        List<Curve> FunctionsToDraw;
        int DX;
        int DY;


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

            View.DeleteFunctionsButtonPressed += View_DeleteFunctionsButtonPressed;

            View.ChildFormOkPressed += View_ChildFormOkPressed;
            View.DeleteFunctionButtonPressed += View_DeleteFunctionButtonPressed;

            FunctionsToDraw = new List<Curve>();
            p = new Build(View.SheetWidth, View.SheetHeight);
            pen = new Pen(Color.Red,2);
            colordialog = new ColorDialog();

            DX = 0;
            DY = 0;
        }
        private bool Exists(string InputFunctionName)
        {
            /*Checks if input function has already existed in list or not*/

            Curve inputfunction = new Curve(InputFunctionName);

            foreach(Curve function in FunctionsToDraw)
            {
                if(inputfunction==function)
                {
                    return true;
                }
            }
            return false;
        }
        //private 
        private void View_DeleteFunctionButtonPressed(string FunctionToDelete)
        {
            FunctionsToDraw.Remove(new Curve(FunctionToDelete,string.Empty,
                                             Color.AliceBlue, 0, DashStyle.Custom));

            View.MessageBoard += $"Delete {FunctionToDelete}";

            p.Clear();
            View.Sheet = p.BuildAxes(ColorAxes, 2, 0, 0);
            View.Sheet = p.BuildNet(ColorNet, scale, 0, 0);
            if (FunctionsToDraw.Count != 0)
            {
                foreach (Curve function in FunctionsToDraw)
                {
                    View.Sheet = p.DrawFunction(function.CurvePen, scale,
                        function.PostfixNotation);
                }
            }



        }

        private void View_ChildFormOkPressed(string function, decimal step)
        {
            TracingDataForm tracingDataForm = new TracingDataForm(View,function, step, scale, DX, DY);
            tracingDataForm.Show();
        }
  

        private void View_DeleteFunctionsButtonPressed(object sender, EventArgs e)
        {
            FunctionsToDraw.Clear();
            View.MessageBoard += "Delete all functions";

            p.Clear();
            View.Sheet = p.BuildAxes(ColorAxes, 2, 0, 0);
            View.Sheet = p.BuildNet(ColorNet, scale, 0, 0);
        }

        private void View_FinishMoving(int dx, int dy)
        {
            p.StartPosition = new Point(dx,dy);
            DX = dx;
            DY = dy;

            if(FunctionsToDraw.Count!=0)
            {
                foreach (Curve function in FunctionsToDraw)
                {
                    View.Sheet = p.DrawFunction(function.CurvePen, scale,
                        function.PostfixNotation);
                }
            }

        }

        private void View_MoveGraph(int dx, int dy)
        {
            p.Clear();
            View.Sheet = p.BuildAxes(ColorAxes, 2, dx, dy);
            View.Sheet = p.BuildNet(ColorNet, scale,dx,dy);             
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
            p.Clear();
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
            if (FunctionsToDraw.Count != 0)
            {
                foreach (Curve function in FunctionsToDraw)
                {
                    View.Sheet = p.DrawFunction(function.CurvePen, scale,
                        function.PostfixNotation);
                }
            }

        }

        private void View_SheetSizeChanged(object sender, EventArgs e)
        {
            p = new Build(View.SheetWidth, View.SheetHeight);
            p.Clear();
            View.Sheet = p.BuildAxes(ColorAxes, 2,0,0);
            View.Sheet = p.BuildNet(ColorNet, scale,0,0);

            if (FunctionsToDraw.Count != 0)
            {
                foreach (Curve function in FunctionsToDraw)
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
               // if(!Exists(View.InputData))
                {
                    Postfix = Parser.ConvertToPostfix(View.InputData);
                    View.Sheet = p.DrawFunction(pen, scale, Postfix);

                    FunctionsToDraw.Add(new Curve(View.InputData, Postfix, pen.Color, pen.Width, pen.DashStyle));

                    View.MessageBoard += $"Input Line: {View.InputData} Output Line: {Postfix}";

                    View.AddfunctionInListBox(View.InputData, pen.Color);
                }

            }
            catch(InvalidOperationException)
            {
                View.MessageBoard += "InvalidOperationException - Stack is empty";
                View.MessageBoard += "Hint: The argument might have been forgotten";
            }
            catch(Exception exception)
            {
                View.MessageBoard += "Error: " + exception.Message;
            }

        }
    }
}
