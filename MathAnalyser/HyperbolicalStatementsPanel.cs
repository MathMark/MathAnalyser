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
    public partial class HyperbolicalStatementsPanel : Form
    {
        IMainForm View;
        public HyperbolicalStatementsPanel()
        {
            InitializeComponent();
        }
        public HyperbolicalStatementsPanel(IMainForm View)
        {
            InitializeComponent();
            this.View = View;
        }
    }
}
