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
    public partial class frmAddSupplier : Form
    {
        supplierClass supClass = new supplierClass();
        public frmAddSupplier()
        {
            InitializeComponent();
            dgvAddress.Focus();
           
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

        private void lbNew_Click(object sender, EventArgs e)
        {
            frmRecordType record = new frmRecordType();

            if (record.ShowDialog() == DialogResult.OK)
            {
                string TID = supClass.TID().ToString();
                string desc = record.txtDesc.Text;
                string Pdesc = record.txtPdesc.Text;
                string rtype = record.txtRType.Text;
                supClass.insertRecordType(TID, desc, rtype, Pdesc);
                fetchRtype();
            }
        }

        public void fetchRtype()
        {

            DataTable dt = supClass.fetchRType();
            DataRow row = dt.NewRow();
            row["tDesc"] = "";
            row["TID"] = DBNull.Value;
            dt.Rows.InsertAt(row, 0);
            cbType.DisplayMember = "tDesc";
            cbType.ValueMember = "TID";
            cbType.DataSource = dt;

        }
        public void InfoCategory()
        {
            DataTable dt = supClass.InfotCat();
            DataRow row = dt.NewRow();
            row["infoCatDesc"] = "";
            row["infoCatID"] = DBNull.Value;
            dt.Rows.InsertAt(row, 0);
         //   cbInfoCat.DisplayMember = "infoCatDesc";
        //    cbInfoCat.ValueMember = "infoCatID";
         //   cbInfoCat.DataSource = dt;

        }

        //public void fetchAddress() {
        //    DataTable dt = supClass.fetch_address();
        //    dgvAddress.DataSource = dt;
        //}

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {
            fetchRtype();
            InfoCategory();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           // this.DialogResult = DialogResult.OK;
          //  this.Close();

            
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            frmListOfAddress addList = new frmListOfAddress();
         
            if (addList.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow row in addList.dgvList.SelectedRows)
                {
                    string id = row.Cells[0].Value.ToString();

                    bool idExists = dgvAddress.Rows.Cast<DataGridViewRow>()
                           .Any(r => r.Cells[0].Value.ToString() == id);
                    if (!idExists)
                    {
                        DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            clonedRow.Cells[cell.ColumnIndex].Value = cell.Value;
                        }

                        dgvAddress.Rows.Add(clonedRow);
                    }
                }
            }
        }
    }
}