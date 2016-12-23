using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathAnalyser
{

    public partial class TracingForm : Form
    {
        IMainForm View;

        string ChosenFunction;
        decimal Increment;

        public TracingForm()
        {
            InitializeComponent();
        }
        public TracingForm(IMainForm View,ListView.ListViewItemCollection items)
        {
            InitializeComponent();

            ChosenFunction = string.Empty;

            this.View = View;

            foreach (ListViewItem item in items)
            {
                comboBox.Items.Add(item.Text);
            }
            this.comboBox.SelectedItem = comboBox.Items[0];

            this.OkButton.Click += OkButton_Click;
            this.CancelButton.Click += CancelButton_Click;

            this.MouseDown += TracingForm_MouseDown;
            this.MouseUp += TracingForm_MouseUp;
            this.MouseMove += TracingForm_MouseMove;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            View.TraceMode = false;
            this.Close();
        }

        public event Action<string,decimal> OkPressed;

        bool TogMove;
        int MValX;
        int MValY;
        private void TracingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void TracingForm_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void TracingForm_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }


        private void OkButton_Click(object sender, EventArgs e)
        {
            ChosenFunction = comboBox.SelectedItem.ToString();
            Increment = Step.Value;


            OkPressed(ChosenFunction, Increment);

            

            this.Close();
        }
    }
}
