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
                string desc = frAddress.txtAddDesc.Text;
                string address = frAddress.txtAddress.Text;
                string city = frAddress.txtCity.Text;
                string province = frAddress.txtProvince.Text;
                string remarks = frAddress.txtRemarks.Text;


                supClass.address(addressID, desc, address, city, province, remarks);

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
            cbInfoCat.DisplayMember = "infoCatDesc";
            cbInfoCat.ValueMember = "infoCatID";
            cbInfoCat.DataSource = dt;

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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            frmListOfAddress addList = new frmListOfAddress();
            addList.Show();
            this.Hide();


            //if (addList.ShowDialog() == DialogResult.OK)
            //{
            //    //string[] data = new string[] {Id.id, Id.description, Id.address, Id.date_created };
            //    //dgvAddress.Rows.Insert(0, data);
            //}
        }
    }
}