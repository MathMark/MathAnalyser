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
    public partial class TrigonometryStatementsPanel : Form
    {
        IMainForm View;
        public TrigonometryStatementsPanel()
        {
            InitializeComponent();
        }
        public TrigonometryStatementsPanel(IMainForm View)
        {
            InitializeComponent();
            this.View = View;
        }
    }
}
