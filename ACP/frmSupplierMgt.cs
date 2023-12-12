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
    public partial class frmSupplierMgt : Form
    {
        supplierClass supClass = new supplierClass();
        public frmSupplierMgt()
        {
            InitializeComponent();
        }


        private void frmSupplierMgt_Load(object sender, EventArgs e)
        {
            dgvSupplier.Focus();
            fetchRecord();
        }

        public void fetchRecord()
        {
            DataTable dt = supClass.fetchRecord();
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvSupplier.DataSource = source;
        }

      

        private void btadd_Click(object sender, EventArgs e)
        {
            frmAddSupplier supplier = new frmAddSupplier();
            if (supplier.ShowDialog() == DialogResult.OK)
            {
                    string TID = supplier.cbType.SelectedValue.ToString();
                    string SuppID = supplier.txtSupCode.Text;
                    string suppDesc = supplier.txtSuppDesc.Text;
                    string agent = supplier.txtAgent.Text;
                    string infoCatID = supplier.cbType.SelectedValue.ToString();
                    //string addressID = supplier.lblAddressID.Text;
                    supClass.insertSupplier(SuppID, TID, suppDesc, agent);
                    fetchRecord();
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                string suppID = selectedRow.Cells["supplier ID"].Value.ToString();
                frmAddSupplier supplier = new frmAddSupplier();
               
                DataTable dt = supClass.getSuppByID(suppID);

                foreach (DataRow rows in dt.Rows)
                {
                     supplier.txtSupCode.Text = rows["supplier ID"].ToString();
                     supplier.txtAgent.Text = rows["Agent"].ToString();
                     supplier.txtSuppDesc.Text = rows["Name"].ToString();
                     supplier.cbType.SelectedIndex = supplier.cbType.FindStringExact(rows["Record Type"].ToString());
                }

                if (supplier.ShowDialog() == DialogResult.OK)
                {
                   
                   
                    
                }
            }
            else
            {
                MessageBox.Show("Please Select the Supplier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataGridViewRow selectedRow;
        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
            Id.suppID = row.Cells["Supplier ID"].Value.ToString();
            if (e.RowIndex >= 0)
            {
                selectedRow = dgvSupplier.Rows[e.RowIndex];
            }
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                Id.suppID = selectedRow.Cells["supplier ID"].Value.ToString();
                btnDelete vSupplier = new btnDelete();
                DataTable dt = supClass.getSuppByID(Id.suppID);

                foreach (DataRow rows in dt.Rows)
                {
                    vSupplier.lblSuppCode.Text = rows["supplier ID"].ToString();
                    vSupplier.lblType.Text = rows["Record Type"].ToString();
                    vSupplier.lblAgent.Text = rows["Agent"].ToString();
                    vSupplier.lblDesc.Text = rows["Name"].ToString();
                }

                

                if (vSupplier.ShowDialog() == DialogResult.OK)
                {
                    
                }

            }
        }

        private void dgvSupplier_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSupplier.ClearSelection();
        }
    }
}
