using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmProdMgt : Form
    {
        public frmProdMgt()
        {
            InitializeComponent();
        }

        private void frmProdMgt_Load(object sender, EventArgs e)
        {
            dgvProd.Focus();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            frmAddProduct addprod = new frmAddProduct();
            addprod.ShowDialog();
        }
    }
}
