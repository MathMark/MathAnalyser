using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathAnalyser.Properties;

namespace MathAnalyser
{
    public interface IMainForm
    {
        string MessageBoard { get; set; }
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

        private void textBox_Function_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.SetIconPadding(textBox_Function,10);
            if ((Convert.ToInt32(e.KeyChar)>=1040)&&(Convert.ToInt32(e.KeyChar) <= 1103))
            {
                 errorProvider1.SetError(textBox_Function, "The line is not supposed to have Cyrillic symbols");
            }
            // if (e.KeyChar == (char)Keys.Enter)
             MessageBoard +=  "Given: "+"3*sin(x+2)/2"+e.KeyChar+"pressed";


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
