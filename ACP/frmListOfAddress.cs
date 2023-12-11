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
            DataGridViewRow row = this.dgvList.Rows[e.RowIndex];
            //DataGridViewRow rows = (DataGridViewRow)addSupp.dgvAddress.Rows[1].Clone();
            //rows.Cells["Address ID"].Value = row.Cells["Address ID"].Value.ToString();
            //rows.Cells["Description"].Value = row.Cells["Description"].Value.ToString();
            //rows.Cells["Address"].Value = row.Cells["Address"].Value.ToString();
            //rows.Cells["Date Created"].Value = row.Cells["Date Created"].Value.ToString();
            //////addSupp.dgvAddress.Rows.Add(rows);
            //Id.id = row.Cells["Address ID"].Value.ToString();
            //Id.description = row.Cells["Description"].Value.ToString();
            //Id.address = row.Cells["Address"].Value.ToString();
            //Id.date_created = row.Cells["Date Created"].Value.ToString();
            addSupp.dgvAddress.Rows.Add(row.Cells["Address ID"].Value.ToString(), row.Cells["Description"].Value.ToString(), row.Cells["Address"].Value.ToString(), row.Cells["Date Created"].Value.ToString());
            addSupp.dgvAddress.Refresh();

            //string[] data = new string[] { Id.id, Id.description, Id.address, Id.date_created };
            //addSupp.dgvAddress.Rows.Insert(0, data);
            addSupp.Show();
            this.Hide();
                
        }
    }
}
