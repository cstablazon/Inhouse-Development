using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmCatHierarchy : Form
    {
        private TreeNode lastAddedNode = null;
        CatHierarchyClass cat = new CatHierarchyClass();
        int status = 1;
        TextInfo txtInfo = CultureInfo.CurrentCulture.TextInfo;
        public frmCatHierarchy()
        {
            InitializeComponent();
           tvCatHierarchy.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tvCatHierarchy.DrawNode += tvCatHierarchy_DrawNode;
            PopulateTreeView();
            btDelete.Enabled = false;
            btEdit.Enabled = false;
        }
        public void cleartext() {
            txtDesc.Clear();
            txtCode.Clear();
            lbRID.Text = "";
            rbYes.Checked = false;
            rbNo.Checked = false;
        }
        private void PopulateTreeView()
        {
            tvCatHierarchy.Nodes.Clear();
            lastAddedNode = null;
            DataTable dataTable = cat.fetchCatHierarchy();
            foreach (DataRow row in dataTable.Rows)
            {
                string code = row["code"].ToString();
                string desc = row["desc"].ToString();
                string lbl = Regex.Replace(row["code"].ToString(),@"\s+","");
                string rtype = Convert.IsDBNull(row["rType"]) ? "0" : row["rType"].ToString();
                TreeNode node = new TreeNode(lbl+" "+desc);
                 node.Tag = code;
                if (rtype == "0")
                {
                    tvCatHierarchy.Nodes.Add(node);
                }
                else
                {
                    TreeNode parentNode = FindNodeById(tvCatHierarchy.Nodes, rtype);
                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(node);
                    }
                }
                lastAddedNode = node;
            }
        }
        private TreeNode FindNodeById(TreeNodeCollection nodes, string code)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag.Equals(code))
                {
                    return node;
                }

                TreeNode foundNode = FindNodeById(node.Nodes, code);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }
            return null;
        }

        private void frmCatHierarchy_Load(object sender, EventArgs e)
        {
            rbYes.Enabled = false;
            rbNo.Enabled = false;
            tvCatHierarchy.Focus();
           
        }
        private void tvCatHierarchy_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            treeview tree = new treeview();
            tree._treeview(e);
        }
        private void tvCatHierarchy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = tvCatHierarchy.SelectedNode;
            string selectedNodeID = selectedNode.Tag.ToString();
            lbCode.Text = selectedNodeID;
            if (tvCatHierarchy.SelectedNode.Text == "001 ACP")
            {
                btDelete.Enabled = false;
                btEdit.Enabled = false;
            }
            else
            {
                btDelete.Enabled = true;
                btEdit.Enabled = true;
            }
            rbYes.Enabled = false;
            rbNo.Enabled = false;
            cleartext();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateTreeView();
            cleartext();
        }
  
        private void btEdit_Click(object sender, EventArgs e)
        {
            btn.Text = "Update";
            try
            {
               
                DataTable tbl = cat.fetchRecord(lbCode.Text);
                foreach (DataRow row in tbl.Rows)
                {
                 
                    txtCode.Text = Regex.Replace(row["code"].ToString(), @"\s+", " ");
                    txtDesc.Text = row["desc"].ToString();
                    lbRID.Text = row["RID"].ToString();
                    int status = Convert.ToInt32(row["isActive"]);
                    if (status == 1)
                    {
                        rbYes.Checked = true;
                    }
                    else if (status == 0) {

                        rbNo.Checked = true;
                    }
                    rbYes.Enabled = true;
                    rbNo.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            string code = lbCode.Text.Trim();
            string desc = txtDesc.Text.ToUpper();
            string rtype = lbCode.Text;
            string ID = lbRID.Text;
          

              DialogResult result = MessageBox.Show("Are you sure you want to perform this action?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

              if (result == DialogResult.Yes)
              {
                  cat.CatHierarchyCrud(ID, code, desc, rtype, status, code);
                  tvCatHierarchy.SelectedNode.Remove();
                

              }

        }
        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYes.Checked)
            {
                status = 1; 
            }
        }
        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNo.Checked)
            {
                status = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btn.Text = "Create";
            rbYes.Enabled = false;
            rbNo.Enabled = false;
            cleartext();
            rbYes.Checked = true;
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            PopulateTreeView();
            cleartext();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
          
            string code = txtCode.Text;
            string ID = lbRID.Text;
            errorProvider1.Clear();
            btn.Enabled = true;
            DataTable dt = cat.CheckRecord(code, ID);
            foreach (DataRow item in dt.Rows)
            {
                string lbl = Regex.Replace(item["code"].ToString(), @"\s+", " ");
                if (lbl== code)
                {
                    btn.Enabled = true;
                }
                else {
                    errorProvider1.SetError(txtCode,"Code is Already Exist");
                    btn.Enabled = false;
                }
            
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string action = btn.Text;
            string code = txtCode.Text;
            string desc = txtDesc.Text;
            string rtype = lbCode.Text;
            string rid = cat.autoIncrementRid().ToString().Trim();
            string ID = lbRID.Text;
            DataTable dt = cat.CheckRecord(code, ID);
            string cap = txtInfo.ToTitleCase(desc);
            if (action.Equals("Create"))
            {
               //Start

                if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(desc))
                {

                    if (dt.Rows.Count > 0)
                    {
                        // errorProvider1.SetError(txtCode, "Code already exist");
                        MessageBox.Show("Code is Already Exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        cat.CatHierarchyCrud(rid, code, cap, rtype, status, "");
                        PopulateTreeView();
                        if (lastAddedNode != null)
                        {
                            tvCatHierarchy.SelectedNode = lastAddedNode;
                            lastAddedNode.EnsureVisible();
                        }
                        cleartext();
                       

                    }
                }else{

                    MessageBox.Show("Please provde values for all fields.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
               //End
            }
            else if (action.Equals("Update"))
            {
                if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(desc))
                     {

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Code is Already Exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cat.CatHierarchyCrud(ID, code, cap, rtype, status, lbCode.Text);
                        PopulateTreeView();
                        rbNo.Enabled = false;
                        rbYes.Enabled = false;
                        cleartext();
                    }
                }
                else {
                    MessageBox.Show("Please provde values for all fields.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e) {
           
          
        }
    }
     



}




        