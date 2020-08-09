using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lentern.Model;

namespace Lentern.Page
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Owner own = new Owner();
            string userurl = Request.QueryString["User"];
            bool admin = false;
            if (!String.IsNullOrEmpty(userurl))
            {
                Encoding enc = new Encoding();
                string user = enc.decode(userurl);
                User.Text = user;
                using (LenternContext db = new LenternContext())
                {
                    foreach (var a in db.Accs)
                    {
                        if (a.Login == user) admin = true;
                    }
                }
                if (!admin) Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void AddAdm_Click(object sender, EventArgs e)
        {
            String login = Login.Text;
            String password = Password.Text;
            bool repeatlogin = false;
            using (LenternContext db = new LenternContext())
            {
                foreach (var a in db.Accs)
                {
                    if (a.Login == login) repeatlogin = true;
                }
            }

            if (String.IsNullOrEmpty(login) && String.IsNullOrEmpty(password))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите все данные!')", true);
            }
            else if (repeatlogin) 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Администратор с таким логином уже есть')", true);
            }
            else
            {
                Acc a = new Acc
                {
                    Login = login,
                    Password = password,
                    Owner = false,
                    Admin = true
                };
                using (LenternContext db = new LenternContext())
                {
                    db.Accs.Add(a);
                    db.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Администратор добавлен!')", true);
                }
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            string userurl = Request.QueryString["User"];
            Response.Redirect("Main.aspx?User=" + userurl);
        }
    }
}