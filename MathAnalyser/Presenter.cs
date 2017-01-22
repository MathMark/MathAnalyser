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
        Depiction p;

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
            View.ChangeColorButtonPressed += View_ChangeColorButtonPressed;
            View.ParametricFunctionFormOkPressed += View_ParametricFunctionFormOkPressed;


            FunctionsToDraw = new List<Curve>();
            p = new Depiction(View.SheetWidth, View.SheetHeight);
            pen = new Pen(Color.Red,2);
            colordialog = new ColorDialog();

            DX = 0;
            DY = 0;
        }

        private void View_ParametricFunctionFormOkPressed(string arg1, string arg2)
        {
            try
            {
                string PostfixExpression_1;
                string PostfixExpression_2;

                if (!Exists($"[{arg1};{arg2}]"))
                {
                    PostfixExpression_1 = Parser.ConvertToPostfix(arg1);
                    PostfixExpression_2 = Parser.ConvertToPostfix(arg2);

                    View.Sheet = p.DrawCurve(pen, scale, PostfixExpression_1,PostfixExpression_2);

                    FunctionsToDraw.Add(new Curve(arg1, arg2, PostfixExpression_1, PostfixExpression_2, pen.Color, pen.Width, pen.DashStyle));

                    View.MessageBoard += $"Set Parametric function: [{arg1};{arg2}]";

                    View.AddfunctionInListBox("["+arg1+";"+arg2+"]", pen.Color);
                }
            }
            catch(Exception exception)
            {
                View.MessageBoard += exception.Message;
            }
        }

        private void View_ChangeColorButtonPressed(string FunctionToChangeColor)
        {
            
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
        private void DrawFunctionsInList()
        {
            if (FunctionsToDraw.Count != 0)
            {
                foreach (Curve function in FunctionsToDraw)
                {
                    if(function.Type=="explicit")
                    {
                        View.Sheet = p.DrawCurve(function.CurvePen, scale,
                            function.FirstPostfixExpression);
                    }
                    else
                    {
                        View.Sheet = p.DrawCurve(function.CurvePen, scale, function.FirstPostfixExpression, function.SecondPostfixExpression);
                    }
                    
                }
            }
        }
        private void View_DeleteFunctionButtonPressed(string FunctionToDelete)
        {
            if(FunctionToDelete.Contains("["))
            {
                /* if the line contains '[' symbol it means that it's parametric function
                 which contains two functions*/
                string[] parts = FunctionToDelete.Split('[', ';', ']');//here the functions is taken from the line and put in array
                FunctionsToDraw.Remove(new Curve(parts[1], parts[2]));
            }
            else
            {
                FunctionsToDraw.Remove(new Curve(FunctionToDelete));
            }
            
            View.MessageBoard += $"Delete {FunctionToDelete}";

            p.Clear();
            View.Sheet = p.BuildAxes(ColorAxes, 2, 0, 0);
            View.Sheet = p.BuildNet(ColorNet, scale, 0, 0);
            if (FunctionsToDraw.Count != 0)
            {
                foreach (Curve function in FunctionsToDraw)
                {
                    if(function.Type=="explicit")
                    {
                        View.Sheet = p.DrawCurve(function.CurvePen, scale,
                        function.FirstPostfixExpression);
                    }
                    else
                    {
                        View.Sheet = p.DrawCurve(function.CurvePen, scale,
                        function.FirstPostfixExpression,function.SecondPostfixExpression);
                    }
                    
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
            if(FunctionsToDraw.Count!=0)
            {
                FunctionsToDraw.Clear();
                View.MessageBoard += "Delete all functions";

                p.Clear();
                View.Sheet = p.BuildAxes(ColorAxes, 2, 0, 0);
                View.Sheet = p.BuildNet(ColorNet, scale, 0, 0);
            }
            
        }

        private void View_FinishMoving(int dx, int dy)
        {
            p.StartPosition = new Point(dx,dy);
            DX = dx;
            DY = dy;

            DrawFunctionsInList();

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
 
            DrawFunctionsInList();

        }

        private void View_SheetSizeChanged(object sender, EventArgs e)
        {
            p = new Depiction(View.SheetWidth, View.SheetHeight);
            p.Clear();
            View.Sheet = p.BuildAxes(ColorAxes, 2,0,0);
            View.Sheet = p.BuildNet(ColorNet, scale,0,0);

            DrawFunctionsInList();
        }

        private void View_EnterPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            try
            {
                if(!Exists(View.InputData))
                {
                    Postfix = Parser.ConvertToPostfix(View.InputData);
                    View.Sheet = p.DrawCurve(pen, scale, Postfix);

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
