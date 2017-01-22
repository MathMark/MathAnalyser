using System;
using System.Windows.Forms;

namespace MathAnalyser
{
    public partial class ParametricFunctionForm : Form
    {
        public ParametricFunctionForm()
        {
            InitializeComponent();

            label1.Text = "\u03c6"+"(t)";
            label2.Text = "\u03c8"+"(t)";

            this.OkButton.Click += OkButton_Click1;
        }

        private void OkButton_Click1(object sender, EventArgs e)
        {
            if ((textBox_1.Text != string.Empty) && (textBox_2.Text != string.Empty))
            {
                OkPressed(textBox_1.Text, textBox_2.Text);
            }
            this.Close();
        }

        public event Action<string, string> OkPressed;

        private void ParametricFunctionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
