using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Data.SqlClient;


namespace Register
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            
            try
            {
                string strInsert = "Insert into TaiKhoan values(@Ten_TK,@MatKhau_TK,@Email_KH,@HoTen_KH,@NgaySinh_KH,@GioiTinh_KH,@ThuNhap_KH)";
                clsDatabase.OpenConnection();
                SqlCommand com = new SqlCommand(strInsert, clsDatabase.con);

                SqlParameter p0 = new SqlParameter("@Ten_TK", SqlDbType.NVarChar);
                p0.Value = txtTenDN.Text;
                SqlParameter p1 = new SqlParameter("@MatKhau_TK", SqlDbType.NVarChar);
                p1.Value = txtMK.Text;
                SqlParameter p2 = new SqlParameter("@Email_KH", SqlDbType.NVarChar);
                p2.Value = txtEmail.Text;
                SqlParameter p3 = new SqlParameter("@HoTen_KH", SqlDbType.NVarChar);
                p3.Value = txtKH.Text;
                SqlParameter p4 = new SqlParameter("@NgaySinh_KH", SqlDbType.DateTime);
                p4.Value = txtNgaySinh.Text;
                SqlParameter p5 = new SqlParameter("@GioiTinh_KH", SqlDbType.NVarChar);
                if (radNam.Checked)
                {
                    p5.Value = radNam.Text;
                }
                else
                {
                    p5.Value = radNu.Text;
                }
                
                SqlParameter p6 = new SqlParameter("@ThuNhap_KH", SqlDbType.Money);
                p6.Value = txtThuNhap.Text;

                com.Parameters.Add(p0);
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.Parameters.Add(p4);
                com.Parameters.Add(p5);
                com.Parameters.Add(p6);
                com.ExecuteNonQuery();

                lblThongBao.Text = "Đăng ký thành công";
                clsDatabase.CloseConnection();
            }

            catch (Exception)
            {
                lblThongBao.Text = "Đăng ký không thành công";
            }
        }

        protected void radNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radNu_CheckedChanged(object sender, EventArgs e)
        {

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
            con = new SqlConnection("Data Source=DESKTOP-E30J54Q\\SQLEXPRESS;Initial Catalog=QLKhachHang;Integrated Security=True");
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