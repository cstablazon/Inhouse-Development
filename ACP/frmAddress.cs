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
    public partial class frmAddress : Form
    {
        supplierClass suppClass = new supplierClass();
        
        public frmAddress()
        {
            InitializeComponent();
            fetchPurpose();
           
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
           
            string addressID = suppClass.addressID().ToString();
            string purpose = cbPurpose.SelectedValue.ToString(); ;
            string desc = txtAddDesc.Text;
            string address =txtAddress.Text;
            string city = txtCity.Text;
            string province =txtProvince.Text;
            string remarks = txtRemarks.Text;

            if ((!string.IsNullOrEmpty(addressID)) && (!string.IsNullOrEmpty(purpose)) && (!string.IsNullOrEmpty(desc)) && (!string.IsNullOrEmpty(address)) && (!string.IsNullOrEmpty(city)) && (!string.IsNullOrEmpty(province)) &&
                 (!string.IsNullOrEmpty(remarks)))
            {
                supplierClass.FetchStatus = "Insert";
                this.DialogResult = DialogResult.OK;
               
            }
            else
            {

                MessageBox.Show("Field is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void fetchPurpose() {

            DataTable dt = suppClass.purpose();
            DataRow row = dt.NewRow();
            row["pDesc"] = "";
            row["PID"] = DBNull.Value;
            dt.Rows.InsertAt(row, 0);
            cbPurpose.DisplayMember = "pDesc";
            cbPurpose.ValueMember = "PID";
            cbPurpose.DataSource = dt;
        }

        public void address()
        {
            DataTable dt = suppClass.fetch_address();
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvListAdd.DataSource = source;
        }
        private void frmAddress_Load(object sender, EventArgs e)
        {
            address();
        }

        private void dgvListAdd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            supplierClass.FetchStatus = "fetch";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
