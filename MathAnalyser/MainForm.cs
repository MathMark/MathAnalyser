using System;
using System.Drawing;
using System.Windows.Forms;
using MathAnalyser.Properties;

namespace MathAnalyser
{
    public interface IMainForm
    {
        string MessageBoard { get; set; }
        string InputBoard { get; }

        event KeyPressEventHandler EnterPressed;
    }
    public partial class MainForm : Form,IMainForm
    {
        TrigonometryStatementsPanel statementsPanel;

        public MainForm()
        {
            InitializeComponent();

            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            this.Height = 2*screenSize.Size.Height/3;
            this.Width= 2*screenSize.Size.Width / 3;

            GetTheme((string)Settings.Default["Theme"]);

            statementsPanel = new TrigonometryStatementsPanel(this);
            statementsPanel.Show();

            textBox_Function.KeyPress += TextBox_Function_KeyPress;
        }

        private void TextBox_Function_KeyPress(object sender, KeyPressEventArgs e)
        {
           // throw new NotImplementedException();
           // errorProvider1.SetIconPadding(textBox_Function, 10);
           /// if ((Convert.ToInt32(e.KeyChar) >= 1040) && (Convert.ToInt32(e.KeyChar) <= 1103))
           /// {
             //   errorProvider1.SetError(textBox_Function, "The line is not supposed to have Cyrillic symbols");
           // }
            if (e.KeyChar == (char)Keys.Enter)
            {
                EnterPressed(this, e);
            }
            
        }

        public event KeyPressEventHandler EnterPressed;
        public string MessageBoard
        {
            get
            {
                return messageBoard.Text;
            }
            set
            {
                messageBoard.Text=value+"\n";
            }
        }
        public string InputBoard
        {
            get
            {
                return textBox_Function.Text;
            }
        }
        private void Theme_White_Button_Click(object sender, EventArgs e)
        {
            Settings.Default["Theme"] = "White";
            Settings.Default.Save();
            GetTheme((string)Settings.Default["Theme"]);
        }

        private void Theme_Black_Button_Click(object sender, EventArgs e)
        {
            Settings.Default["Theme"] = "Black";
            Settings.Default.Save();
            GetTheme((string)Settings.Default["Theme"]);
        }

        private void Theme_BlackBlue_Button_Click(object sender, EventArgs e)
        {
            Settings.Default["Theme"] = "BlackBlue";
            Settings.Default.Save();
            GetTheme((string)Settings.Default["Theme"]);
        }

        private void GetTheme(string Parameter)
        {
            switch(Parameter)
            {
                case "White":
                    this.BackColor = Color.White;
                    this.textBox_Function.BackColor = Color.White;
                    this.textBox_Function.ForeColor = Color.Black;

                    toolStrip1.BackColor = Color.White;

                    foreach (ToolStripItem item in toolStrip1.Items)
                    {
                        if (item is ToolStripDropDownButton)
                        {
                            item.ForeColor = Color.Black;
                        }
                    }

                    messageBoard.BackColor = Color.FromArgb(255, 255, 255);
                    messageBoard.ForeColor = Color.Gray;

                    break;
                case "Black":
                    this.BackColor = Color.FromArgb(40, 40, 40);

                    this.textBox_Function.BackColor = Color.FromArgb(50, 50, 50);
                    this.textBox_Function.ForeColor = Color.White;

                    toolStrip1.BackColor = Color.FromArgb(20, 20, 20); 

                    foreach(ToolStripItem item in toolStrip1.Items)
                    {
                        if(item is ToolStripDropDownButton)
                        {
                            item.ForeColor = Color.White;
                        }
                    }

                    messageBoard.BackColor= Color.FromArgb(20, 20, 20);
                    messageBoard.ForeColor = Color.Gray;

                    break;
                case "BlackBlue":
                    break;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void TrigonometryStatementsButton_Click(object sender, EventArgs e)
        {
           // TrigonometryStatementsPanel statementsPanel = new TrigonometryStatementsPanel(this);
            statementsPanel.Show();
        }

        private void HyperbolicalStatementsButton_Click(object sender, EventArgs e)
        {
            HyperbolicalStatementsPanel hyperbolicalPanel = new HyperbolicalStatementsPanel(this);
            hyperbolicalPanel.Show();
        }
    }
}
