using System;
using System.Drawing;
using System.Windows.Forms;


namespace MathAnalyser
{
    public interface IMainForm
    {
        string MessageBoard { get; set; }
        string InputData { get; }
        Bitmap Sheet { get; set; }
        int SheetWidth { get; }
        int SheetHeight { get; }
        bool TraceMode { get; set; }
        Bitmap ColorLabel { set; }


        void AddfunctionInListBox(string function, Color backgroundColor);

        event EventHandler EnterPressed;
        event EventHandler SheetSizeChanged;
        event MouseEventHandler SheetMouseWheel;
        event EventHandler SetColor;
        event EventHandler SetDashStyle;
        event EventHandler DeleteFunctionsButtonPressed;
        event Action<string> DeleteFunctionButtonPressed;
        event Action<string> ChangeColorButtonPressed;
        
        event Action<int,int> MoveGraph;
        event Action<int, int> FinishMoving;

        event Action<string, decimal> ChildFormOkPressed;
        event Action<string, string> ParametricFunctionFormOkPressed;

        event EventHandler CenterButtonClick;
    }
    public partial class MainForm : Form,IMainForm
    {
        TracingForm tracingForm;
        ParametricFunctionForm parametricFunctionFrom;

        public event EventHandler EnterPressed;
        public event EventHandler SheetSizeChanged;
        public event MouseEventHandler SheetMouseWheel;
        public event EventHandler SetColor;
        public event EventHandler SetDashStyle;
        public event EventHandler DeleteFunctionsButtonPressed;
        public event Action<string> DeleteFunctionButtonPressed;
        public event Action<string> ChangeColorButtonPressed;

        public event Action<int, int> MoveGraph;
        public event Action<int, int> FinishMoving;
        public event Action<string, decimal> ChildFormOkPressed;
        public event Action<string, string> ParametricFunctionFormOkPressed;

        public event EventHandler CenterButtonClick;

        public MainForm()
        {
            InitializeComponent();

            ///signs for panel buttons 
            panelButtonPI.Text = "\u03c0";
            panelButtonMultiplication.Text = "\u00d7";
            ///
            Searcher(this);

            tracingForm = new TracingForm();
            parametricFunctionFrom = new ParametricFunctionForm();


            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            this.Height = 2*screenSize.Size.Height/3;
            this.Width= 2*screenSize.Size.Width / 3;

            Depiction p = new Depiction(pictureBox.Width, pictureBox.Height);
            Sheet = p.BuildAxes(Color.FromArgb(155,121,120,122),2,0,0);
            Sheet = p.BuildNet(Color.FromArgb(10, 121, 120, 122), 25,0,0);

            textBox_Function.KeyPress += TextBox_Function_KeyPress;
            pictureBox.SizeChanged += PictureBox_SizeChanged;
            pictureBox.MouseHover += PictureBox_MouseHover;
            pictureBox.MouseWheel += PictureBox_MouseWheel;
            SetColorButton.Click += SetColorButton_Click;
            SetDashStyleButton.Click += SetDashStyleButton_Click;

            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseMove += PictureBox_MouseMove;

            DeleteFunctionsButton.Click += DeleteFunctionsButton_Click;

            traceButton.Click += TraceButton_Click;
            DeleteFunctionFromListButton.Click += DeleteFunctionFromListButton_Click;
            ChangeColorButton.Click += ChangeColorButton_Click;
            ParametricFunctionButton.Click += ParametricFunctionButton_Click;
            centerButton.Click += CenterButton_Click;

        }

        private void CenterButton_Click(object sender, EventArgs e)
        {
            CenterButtonClick(this, e);
        }

        private void Searcher(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                    Searcher(c);
                var button = c as Button;
                if (button != null)
                {
                    switch(button.Name)
                    {
                        case "enterButton":
                            button.Click += panelButtonEnter_Click;
                            break;
                        case "panelButtonArrow":
                            button.Click += panelButtonArrow_Click;
                            break;
                        case "panelButtonC":
                            button.Click += panelButtonC_Click;
                            break;
                        case "HideWindowButton":
                            break;
                        case "MaximizeWindowButton":
                            break;
                        default: button.Click += PanelButton_Click;
                            break;
                    }
                    
                }
                    
            }
        }

        private void panelButtonC_Click(object sender, EventArgs e)
        {
            textBox_Function.ResetText();
        }

        private void panelButtonArrow_Click(object sender, EventArgs e)
        {
            if (textBox_Function.SelectionStart != 0)
            {
                var selectionIndex = textBox_Function.SelectionStart;
                textBox_Function.Text = textBox_Function.Text.Remove(textBox_Function.SelectionStart - 1, 1);
                textBox_Function.SelectionStart = selectionIndex--;
            }
                
        }

        private void panelButtonEnter_Click(object sender, EventArgs e)
        {
            EnterPressed(this, e);
        }

        private void PanelButton_Click(object sender, EventArgs e)
        {
            string buttonText = sender.ToString();
            string insertText = buttonText.Substring(buttonText .IndexOf(": ")+2);

            var selectionIndex = textBox_Function.SelectionStart;
            textBox_Function.Text = textBox_Function.Text.Insert(selectionIndex, insertText);
            textBox_Function.SelectionStart = selectionIndex + insertText.Length;
        }

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            if (functionListBox.SelectedItems.Count != 0)
            {
                ChangeColorButtonPressed(functionListBox.SelectedItems[0].Text);
            }
        }

        private void DeleteFunctionFromListButton_Click(object sender, EventArgs e)
        {
            if (functionListBox.SelectedItems.Count != 0)
            {
                DeleteFunctionButtonPressed(functionListBox.SelectedItems[0].Text);
                functionListBox.Items.Remove(functionListBox.SelectedItems[0]);
            }
        }

        private void FunctionsForTrace_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBoard += "ww";
        }
   

        private void TraceButton_Click(object sender, EventArgs e)
        {
            this.Focus();

            if ((functionListBox.Items.Count != 0)&&
                (!TraceMode)&&(CheckExplicitFunctionInFunctionListBox()))
            {
                tracingForm = new TracingForm(this, functionListBox.Items);
                tracingForm.OkPressed += TracingForm_OkPressed;

                TraceMode = true;

                tracingForm.Show();
            }
            else
            {
                MessageBoard += "Nothing to trace";
            }
        }
        bool CheckExplicitFunctionInFunctionListBox()
        {
            int counter = 0;
            foreach(ListViewItem item in functionListBox.Items)
            {
                if(!item.Text.Contains("["))
                {
                    counter++;
                }
            }
            if (counter != 0) return true;
            return false;
        }

        private void TracingForm_OkPressed(string function, decimal step)
        {
            ChildFormOkPressed(function, step);
        }
        private void ParametricFunctionButton_Click(object sender, EventArgs e)
        {
            parametricFunctionFrom = new ParametricFunctionForm();
            parametricFunctionFrom.OkPressed += ParametricFunctionFrom_OkPressed;
            parametricFunctionFrom.Show();
        }

        private void ParametricFunctionFrom_OkPressed(string function_1, string function_2)
        {
            ParametricFunctionFormOkPressed(function_1, function_2);
        }
        #region Functions which changes controls on the main form

        public void AddfunctionInListBox(string function,Color backgroundColor)
        {
            functionListBox.Items.Add(function);

            foreach (ListViewItem item in functionListBox.Items)
            {
                if (item.Text == function)
                {
                    item.BackColor = backgroundColor;
                }
            }
            functionListBox.EnsureVisible(functionListBox.Items.Count - 1);
        }


        #endregion


        private void DeleteFunctionsButton_Click(object sender, EventArgs e)
        {
            functionListBox.Items.Clear();
            DeleteFunctionsButtonPressed(this, e);
        }

        bool IsPressed;
        int MouseX;
        int MouseY;
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsPressed)
            {
                MoveGraph(e.X-MouseX, e.Y - MouseY);
            }
        }
        
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            IsPressed = false;
            FinishMoving(e.X - MouseX, e.Y - MouseY);
            
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            IsPressed = true;
            MouseX = e.X;
            MouseY = e.Y;
        }

        private void SetDashStyleButton_Click(object sender, EventArgs e)
        {
            SetDashStyle(this, e);

        }

        private void SetColorButton_Click(object sender, EventArgs e)
        {
            SetColor(this, e);
        }

        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            pictureBox.Focus();
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            SheetMouseWheel(this, e);
        }

        private void PictureBox_SizeChanged(object sender, EventArgs e)
        {
            SheetSizeChanged(this, e);
        }

        //occurs when user presses some button in case if textBox is focused
        private void TextBox_Function_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EnterPressed(this, EventArgs.Empty);

            }
            
        }

        

        bool traceMode = false;
        public bool TraceMode
        {
            get
            {
                return traceMode;
            }
            set
            {
                traceMode = value;
            }
        }

        public bool IsFocused
        {
            get
            {
                return Focused;
            }
        }
        public Bitmap Sheet
        {
            get
            {
                return (Bitmap)pictureBox.Image;
            }
            set
            {
                pictureBox.Image = value;
            }
        }
        public int SheetWidth
        {
            get
            {
                return pictureBox.Width;
            }
        }
        public int SheetHeight
        {
            get
            {
                return pictureBox.Height;
            }
        }
        public string MessageBoard
        {
            get
            {
                return messageBoard.Text;
            }
            set
            {
                messageBoard.Text=value+"\n";
                messageBoard.SelectionStart = messageBoard.Text.Length;
                messageBoard.ScrollToCaret();
            }
        }
        public string InputData
        {
            get
            {
                return textBox_Function.Text;
            }
        }
        public Bitmap ColorLabel
        {
            set
            {
                colorLabel.Image = value;
            }
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void TrigonometryStatementsButton_Click(object sender, EventArgs e)
        {
           // TrigonometryStatementsPanel statementsPanel = new TrigonometryStatementsPanel(this);
            //statementsPanel.Show();
        }

        private void HyperbolicalStatementsButton_Click(object sender, EventArgs e)
        {
           // HyperbolicalStatementsPanel hyperbolicalPanel = new HyperbolicalStatementsPanel(this);
           // hyperbolicalPanel.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HideWindowButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MaximizeWindowButton_Click(object sender, EventArgs e)
        {
            if(this.WindowState== FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            
        }

        bool TogMove;
        int MValX;
        int MValY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X-MValX, MousePosition.Y - MValY);
            }
        }

        private void ClearMessageBoardButton_Click(object sender, EventArgs e)
        {
            MessageBoard = string.Empty;
        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
