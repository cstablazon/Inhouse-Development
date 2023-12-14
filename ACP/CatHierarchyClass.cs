using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ACP
{
    public class CatHierarchyClass
    {
        dbClass db = new dbClass();
        public static string code = "",rid = "";
        
        public DataTable fetchCatHierarchy()
        {
            return db.getRecord("sp_catHierarchy 'FETCHDATA'");
        }
        public DataTable fetchRecord(string code)
        {
            return db.getRecord("sp_catHierarchy 'FETCHRECORD', '" + code + "'");
        }
        public DataTable CheckRecord(string code, string rid)
        {
            return db.getRecord("SELECT code,RID from vwCatHierarchy WHERE code = '" + code + "' AND RID != '" + rid + "'");
        }
       public int autoIncrementRid()
       {
           int currentMaxValue = 0;
           currentMaxValue = db.autoIncrement("SELECT COUNT(*) FROM categoryHierarchy;");
           return currentMaxValue;
       }
       public void CatHierarchyCrud(string rid, string code, string desc, string rtype,int status, string code2)
       {
           try
           {
               SqlConnection conn = db.getConnection();
               conn.Open();
               SqlCommand cmd = new SqlCommand("sp_catHierarchy", conn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@Action", "CRUD");
               cmd.Parameters.AddWithValue("@Code", code);
               cmd.Parameters.AddWithValue("@Rid", rid);
               cmd.Parameters.AddWithValue("@Desc", desc);
               cmd.Parameters.AddWithValue("@rtype", rtype);
               cmd.Parameters.AddWithValue("@process", "WI");
               cmd.Parameters.AddWithValue("@status", status);
               cmd.Parameters.AddWithValue("@Code2", code2);
               cmd.ExecuteNonQuery();
               conn.Close();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
          
       }

      

      
    }
}
