using System;
using System.Collections.Generic;
using System.Drawing;
using BL;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MathAnalyser
{
    class Presenter
    {
        IMainForm View;
        Depiction depiction;

        int scale = 25;

        Color WhiteColorNet = Color.FromArgb(30, 121, 120, 122);
        Color WhiteColorAxes = Color.FromArgb(155, 121, 120, 122);
        Color BlackColorAxes = Color.Black;
        Color ColorNetWhiteBackground = Color.FromArgb(60, 121, 120, 122);

        Pen pen;
        ColorDialog colordialog;
        string Postfix;

        List<Curve> FunctionsToDraw;
        bool colorIsSet;

        //flags
        bool NL = true;//numeric line
        bool WB = false;//white background
        bool CN = true;//coordinate net

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

            View.DeleteFunctionButtonPressed += View_DeleteFunctionButtonPressed;
            View.ChangeColorButtonPressed += View_ChangeColorButtonPressed;
            View.ParametricFunctionFormOkPressed += View_ParametricFunctionFormOkPressed;
            View.OnOffNumericLinesButtonClick += View_OnOffNumericLinesButtonClick;
            View.ChangeBackroundButtonPressed += View_ChangeBackroundButtonPressed;
            View.OnOffCoordinateNetButtonPressed += View_OnOffCoordinateNetButtonPressed;

            FunctionsToDraw = new List<Curve>();
            depiction = new Depiction(View.SheetWidth, View.SheetHeight);
            pen = new Pen(Color.YellowGreen,2);
            colordialog = new ColorDialog();

            View.CenterButtonClick += View_CenterButtonClick;
            View.SaveButtonPressed += View_SaveButtonPressed;
            colorIsSet = false;
            View.PenWidthButtonPressed += View_PenWidthButtonPressed;

            RefreshScene(0, 0);
        }

        private void View_PenWidthButtonPressed(string width)
        {
           switch(width)
            {
                case "tiny":
                    pen.Width = 1;
                    break;
                case "middle":
                    pen.Width = 2;
                    break;
                case "large":
                    pen.Width = 3;
                    break;
            }
        }

        private void WriteFunctions(Bitmap fileToSave)
        {
            Graphics temp = Graphics.FromImage(fileToSave);
            SolidBrush brush;
            Font font = new Font("Consolas", 12);
            PointF point = new PointF(30, 20);
            foreach(Curve function in FunctionsToDraw)
            {
                brush = new SolidBrush(function.CurvePen.Color);
                temp.DrawString(function.FirstExcpression, font, brush, point);
                point = new PointF(point.X, point.Y += 15);
            }
        }
        private void View_SaveButtonPressed(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.png|All Files (*.*)|*.*";
            Bitmap pictureToSave = new Bitmap(View.Sheet);
            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                WriteFunctions(pictureToSave);
                pictureToSave.Save(saveFileDialog.FileName);
            }
        }

        private void View_OnOffCoordinateNetButtonPressed(object sender, EventArgs e)
        {
            CN = !CN;
            RefreshScene(0, 0);
            DrawFunctionsInList();
        }

        private void View_ChangeBackroundButtonPressed(object sender, EventArgs e)
        {
            WB = !WB;
            RefreshScene(0,0);
            DrawFunctionsInList();
        }

        private void View_OnOffNumericLinesButtonClick(object sender, EventArgs e)
        {
            NL = !NL;
            if(!NL)
            {
                View.Sheet = depiction.ClearNumericLines();
            }
            RefreshScene(0,0);
            DrawFunctionsInList();

        }

        private void View_SetDashStyle(string dashStyle)
        {
            switch (dashStyle)
            {
                case "Solid":
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case "Dash":
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case "Dash Dot":
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case "Dash Dot Dot":
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
            }
        }

        private Color GenerateColor()
        {
            Random randomColor = new Random();
            int red = randomColor.Next(0, 255);
            int green = randomColor.Next(0, 255);
            int blue = randomColor.Next(0, 255);
            return Color.FromArgb(red, green, blue);
        }
        private void RefreshScene(int dx,int dy)
        {
            
            if(WB)
            {
                depiction.Clear(Color.White);
                if(CN)
                {
                    View.Sheet = depiction.BuildNet(ColorNetWhiteBackground, scale, dx, dy);
                }
                View.Sheet = depiction.BuildAxes(BlackColorAxes, 1, dx, dy);
                
            }
            else
            {
                depiction.Clear(Color.FromArgb(30,30,30));
                if(CN)
                {
                    View.Sheet = depiction.BuildNet(WhiteColorNet, scale, dx, dy);
                }
                 View.Sheet = depiction.BuildAxes(WhiteColorAxes, 2, dx, dy);
                
            }
          
            SetNumericLines(0, 0);
        }
        private void View_CenterButtonClick(object sender, EventArgs e)
        {
            depiction = new Depiction(View.SheetWidth, View.SheetHeight);
            RefreshScene(0,0);
            DrawFunctionsInList();
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

                    View.Sheet = depiction.DrawCurve(pen, scale, PostfixExpression_1,PostfixExpression_2);

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
            int index=FunctionsToDraw.IndexOf(new Curve(FunctionToChangeColor));
            Color newColor = GenerateColor();
            FunctionsToDraw[index] = new Curve(FunctionToChangeColor,
                                            Parser.ConvertToPostfix(FunctionToChangeColor),
                                            newColor,
                                            pen.Width,
                                            pen.DashStyle);
           
            View.ChangeColorOfFunctionInListBox(FunctionToChangeColor, newColor);
            RefreshScene(0,0);
            DrawFunctionsInList();
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
                        View.Sheet = depiction.DrawCurve(function.CurvePen, Parser.GetValues(function.FirstPostfixExpression,
                            scale, depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));
                    }
                    else
                    {
                        View.Sheet = depiction.DrawCurve(function.CurvePen, scale, function.FirstPostfixExpression, function.SecondPostfixExpression);
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
            RefreshScene(0,0);
            DrawFunctionsInList();

        }


        private void View_DeleteFunctionsButtonPressed(object sender, EventArgs e)
        {
            if(FunctionsToDraw.Count!=0)
            {
                FunctionsToDraw.Clear();
                View.MessageBoard += "Delete all functions";
                RefreshScene(0,0);
            }
            
        }

        private void View_FinishMoving(int dx, int dy)
        {
            depiction.StartPosition = new Point(dx,dy);
            RefreshScene(0, 0);
            SetNumericLines(0,0);
            DrawFunctionsInList();
        }

        private void View_MoveGraph(int dx, int dy)
        {
            RefreshScene(dx,dy);
            SetNumericLines(dx,dy);

        }

        private void View_SetColor(object sender, EventArgs e)
        {
           if( colordialog.ShowDialog()==DialogResult.OK)
            {
                pen.Color = colordialog.Color;
                colorIsSet = true;    
            }
        }

        private void View_SheetMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
           // View.Sheet = depiction.BuildAxes(WhiteColorAxes, 2,0,0);
            
            if (e.Delta>0)
            {
                if(scale<100)
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

            RefreshScene(0,0);
            DrawFunctionsInList();

        }
        private void SetNumericLines(float dx,float dy)
        {
            if(NL)
            {
                if (scale >= 30)
                {
                    View.Sheet = depiction.SetNumericLines(scale, 1, dx, dy);
                }
                else if ((scale < 30) && (scale >= 20))
                {
                    View.Sheet = depiction.SetNumericLines(scale, 2, dx, dy);
                }
                else
                {
                    View.Sheet = depiction.SetNumericLines(scale, 3, dx, dy);
                }
            }
            
        }
        private void View_SheetSizeChanged(object sender, EventArgs e)
        {
            depiction = new Depiction(View.SheetWidth, View.SheetHeight);
            RefreshScene(0,0);
            DrawFunctionsInList();
        }

        private void View_EnterPressed(object sender, EventArgs e)
        {

            try
            {
                if (!Exists(View.InputData))
                {
                    if (!colorIsSet)
                    {
                        pen.Color = GenerateColor();
                    }
                    else
                    {
                        colorIsSet = false;
                    }
                    Postfix = Parser.ConvertToPostfix(View.InputData);
                    View.Sheet = depiction.DrawCurve(pen, Parser.GetValues(Postfix,
                             scale, depiction.CoordinatePlaneLocation.leftEdge, depiction.CoordinatePlaneLocation.rightEdge));

                    FunctionsToDraw.Add(new Curve(View.InputData, Postfix, pen.Color, pen.Width, pen.DashStyle));

                    View.MessageBoard += $"Input Line: \t{View.InputData} \tOutput Line: \t{Postfix}";

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
