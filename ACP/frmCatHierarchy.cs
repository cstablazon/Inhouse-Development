using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ACP
{
    public partial class frmCatHierarchy : Form
    {

        private TreeNode lastAddedNode = null;
        CatHierarchyClass cat = new CatHierarchyClass();
        int status = 1;
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string desc = txtDesc.Text.ToUpper();
            string rtype = lbCode.Text;
            string rid = cat.autoIncrementRid().ToString().Trim();
            if (!string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(desc))
            {
                int result = cat.insertCatHierarchy(rid, code, desc, rtype);
                if (result != 1)
                {
                    PopulateTreeView();
                    if (lastAddedNode != null)
                    {
                        tvCatHierarchy.SelectedNode = lastAddedNode;
                        lastAddedNode.EnsureVisible();
                    }
                }
                else
                {
                    MessageBox.Show("Code is already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please provide values for all fields.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cleartext();
        }
        private void btnNewHierachy_Click(object sender, EventArgs e)
        {
           
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string desc = txtDesc.Text.ToUpper();
            string rtype = lbCode.Text;
            string rid = lbRID.Text;
            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(desc))
            {
                int result = cat.updateHierarchy(code, desc, rid, status);
                if (result != 1)
                {
                    PopulateTreeView();
                    rbYes.Enabled = false;
                    rbNo.Enabled = false;
                    cleartext();
                }
                else
                {
                    MessageBox.Show("Code is already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              }else 
                {
                    MessageBox.Show("Please provide values for all fields.","Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateTreeView();
            btnUpdate.Enabled = false;
            btnCreate.Enabled = false;
            cleartext();
        }
  
        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                DataTable tbl = cat.fetchRecord(lbCode.Text);
                foreach (DataRow row in tbl.Rows)
                {
                    txtCode.Text = row["code"].ToString();
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
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + tvCatHierarchy.SelectedNode.Text + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (tvCatHierarchy.SelectedNode != null)
                    {
                        cat.deleteCatHierarchy(lbCode.Text);
                        tvCatHierarchy.SelectedNode.Remove();
                    }
                    else
                    {
                        MessageBox.Show("Please Select the node before removal.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            btnCreate.Enabled = true;
            btnUpdate.Enabled = false;

            rbYes.Enabled = false;
            rbNo.Enabled = false;
            cleartext();
            rbYes.Checked = true;
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            PopulateTreeView();
            btnUpdate.Enabled = false;
            btnCreate.Enabled = false;
            cleartext();
        }
    }
     



}




        