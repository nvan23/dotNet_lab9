using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student
{
    public partial class wfrStudent : System.Web.UI.Page
    {
        DataTable t = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
        }

        void loadData()
        {
            grvStudent.DataSource = t;
            grvStudent.DataBind();
        }
        
    }
}
class clsDatabase
{
    public static SqlConnection con;

    public static bool OpenConnection()
    {
        try
        {
            //login with window authentication option, so there are no user name and password
            con = new SqlConnection("Data Source=DESKTOP-E30J54Q\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True");
            con.Open();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

    public static bool CloseConnection()
    {
        try
        {
            con.Close();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }

}