using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionFixationExample
{
    public partial class SecureLogin : System.Web.UI.Page
    {
        //This is the page load event. 
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.ForeColor = System.Drawing.Color.DarkKhaki;
            lblMessage.Text = " username and password: [admin/admin], [test/test] ";

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //When user enter valid credentials in username and password field
            if ((txtUsername.Text.Trim().Equals("admin") && txtPassword.Text.Trim().Equals("admin")) ||
               (txtUsername.Text.Trim().Equals("test") && txtPassword.Text.Trim().Equals("test")))
            {
                //Creating a Session for that user
                Session["userLoggedin"] = txtUsername.Text.Trim();

                string guid = Guid.NewGuid().ToString();
                //Creating second session for the same user and assigning a randmon GUID
                Session["AuthToken"] = guid;
                
                //Creating cookie and storing the same value of second session in the cookie
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                //Redirecting user to Logout Page
                Response.Redirect("~/SecureLoginFunc/SecureLogout.aspx");
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid username or password";
            }
        }
    }
}