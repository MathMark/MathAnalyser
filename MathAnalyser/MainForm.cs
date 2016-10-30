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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            this.Height = 2*screenSize.Size.Height/3;
            this.Width= 2*screenSize.Size.Width / 3;
        }
    }
}
