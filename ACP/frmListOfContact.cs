using System.Data;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmListOfContact : Form
    {
        supplierClass suppClass = new supplierClass();
        public frmListOfContact()
        {
            InitializeComponent();
        }

        public void fetch_contact() {

            DataTable dt = suppClass.fetch_contact();

            foreach (DataRow row in dt.Rows)
            {
                dgv_Contact.Rows.Add(row["addressID"]).ToString();;
            }
        }
    }
}
