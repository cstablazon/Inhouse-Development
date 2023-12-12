using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ACP
{
    public class CatHierarchyClass
    {
        dbClass db = new dbClass();
        public DataTable fetchCatHierarchy()
        {
            return db.getRecord("sp_catHierarchy 'FETCHDATA'");
        }
        public DataTable fetchRecord(string code)
        {
            return db.getRecord("sp_catHierarchy 'FETCHRECORD', '" + code + "'");
        }

        public void deleteCatHierarchy(string code)
        {
            db.selectRecord("sp_catHierarchy 'DELETE', '" + code + "'");
        }
       public int autoIncrementRid()
       {
           int currentMaxValue = 0;
           currentMaxValue = db.autoIncrement("SELECT ISNULL(MAX(RID), 0) FROM categoryHierarchy");
           return currentMaxValue;
       }
       public int insertCatHierarchy(string rid, string code, string desc, string rtype)
       {
           int result = 0;
           try
           {
               //result = db.setRecord("sp_catHierarchy 'INSERT','" + code + "','" + rid + "','" + desc + "','" + rtype + "','WI'");
               SqlConnection conn = db.getConnection();
               conn.Open();
               SqlCommand cmd = new SqlCommand("sp_catHierarchy", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@Action", "INSERT");
               cmd.Parameters.AddWithValue("@Code", code);
               cmd.Parameters.AddWithValue("@Rid", rid);
               cmd.Parameters.AddWithValue("@Desc", desc);
               cmd.Parameters.AddWithValue("@rtype", rtype);
               cmd.Parameters.AddWithValue("@process", "WI");
               result = (int)cmd.ExecuteScalar();
               conn.Close();

           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           return result;
       }

        public int updateHierarchy(string code, string desc,string rid,int status) {
            int result = 0;
            try
            {
               // result = db.setRecord("sp_catHierarchy 'UPDATE','" + code + "','" + rid + "','" + desc + "','','WI','" + status + "'");
                SqlConnection conn = db.getConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_catHierarchy", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@Rid", rid);
                cmd.Parameters.AddWithValue("@Desc", desc);
                cmd.Parameters.AddWithValue("@process", "WI");
                cmd.Parameters.AddWithValue("@status", status);
                result = (int)cmd.ExecuteScalar();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
