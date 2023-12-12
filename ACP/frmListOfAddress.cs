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
    public partial class frmListOfAddress : Form
    {
        supplierClass supClass = new supplierClass();
        public frmListOfAddress()
        {
            InitializeComponent();
            fetchAddress();
        }

        public void address()
        {

            DataTable dt = supClass.fetch_address();
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvList.DataSource = source;
        }

        private void frmListOfAddress_Load(object sender, EventArgs e)
        {
            address();
        }
        public void fetchAddress()
        {
            
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAddSupplier addSupp = new frmAddSupplier();
            supClass.insertMultiAddress(Id.suppID, Id.addressID);
            this.DialogResult = DialogResult.OK;
            this.Close();
                
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];

            Id.addressID = row.Cells["Address ID"].Value.ToString();
        }
    }
}
