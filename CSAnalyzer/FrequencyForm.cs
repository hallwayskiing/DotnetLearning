using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAnalyzer
{
    public partial class FrequencyForm : Form
    {
        public FrequencyForm(DataTable dataTable)
        {
            InitializeComponent();
            dataGridView.DataSource = dataTable;
        }
    }
}
