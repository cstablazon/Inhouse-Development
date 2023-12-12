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
    public partial class btnDelete : Form
    {
        supplierClass supClass = new supplierClass();
        public btnDelete()
        {
            InitializeComponent();
        }

        public void fetch_sAddress()
        {
            DataTable dtAddress = supClass.fetch_suppAddress();
            BindingSource source = new BindingSource();
            source.DataSource = dtAddress;
            dgvAddress.DataSource = source;
        }

        private void frmviewSupplier_Load(object sender, EventArgs e)
        {
            fetch_sAddress();
        }

        private void dgvAddress_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAddress.ClearSelection();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmAddress frAddress = new frmAddress();
            if (frAddress.ShowDialog() == DialogResult.OK)
            {
                string addressID = supClass.addressID().ToString();
                string purpose = frAddress.cbPurpose.SelectedValue.ToString(); ;
                string desc = frAddress.txtAddDesc.Text;
                string address = frAddress.txtAddress.Text;
                string city = frAddress.txtCity.Text;
                string province = frAddress.txtProvince.Text;
                string remarks = frAddress.txtRemarks.Text;

                supClass.address(addressID, purpose, desc, address, city, province, remarks);
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            frmListOfAddress addList = new frmListOfAddress();

            if (addList.ShowDialog() == DialogResult.OK)
            {
                fetch_sAddress();
                //foreach (DataGridViewRow row in addList.dgvList.SelectedRows)
                //{
                //    string id = row.Cells[3].Value.ToString();

                //    bool idExists = dgvAddress.Rows.Cast<DataGridViewRow>()
                //           .Any(r => r.Cells[0].Value.ToString() == id);
                //    if (!idExists)
                //    {
                //        DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
                //        foreach (DataGridViewCell cell in row.Cells)
                //        {
                //            clonedRow.Cells[cell.ColumnIndex].Value = cell.Value;
                //        }

                //        dgvAddress.Rows.Add(clonedRow);
                //    }
                //}
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            supClass.delete_suppAddress(lblSuppCode.Text, Id.addressID); 
            fetch_sAddress();
        }

        private void dgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvAddress.Rows[e.RowIndex];
            
            Id.addressID = row.Cells["Address ID"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }


    
    }
}
