using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lentern.Model;

namespace Lentern.Page
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Owner own = new Owner();
        }

        protected void AddInt_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddIntern.aspx");
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            string login = Login.Text;
            string password = Password.Text;
            string pass = "";
            bool Pass = false;
            bool intern = false;
            using (LenternContext db = new LenternContext())
            {
                foreach (var a in db.Accs) 
                {
                    if (a.Login == login) 
                    {
                        pass = a.Password;
                        Pass = true;
                    }
                }
                foreach (var i in db.Interns) 
                {
                    if (i.Email == login) intern = true;
                }
            }
            if (!string.IsNullOrEmpty(login) && !Pass && string.IsNullOrEmpty(password) && intern)
            {
                Encoding enc = new Encoding();
                string userurl = enc.encode(login);
                Response.Redirect("Main.aspx?User=" + userurl);
            }
            else if (!string.IsNullOrEmpty(login) && Pass && string.IsNullOrEmpty(password) && !intern)
            {
                Password.Enabled = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите пароль!')", true);
            }
            else if (!string.IsNullOrEmpty(login) && Pass && !string.IsNullOrEmpty(password) && !intern && (password == pass))
            {
                Encoding enc = new Encoding();
                string userurl = enc.encode(login);
                Response.Redirect("Main.aspx?User=" + userurl);
            }
            else if (!string.IsNullOrEmpty(login) && Pass && !string.IsNullOrEmpty(password) && !intern && !(password == pass))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Неверный пароль!')", true);
            }
            else 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Непрвильно выполненный вход!')", true);
            }
        }
    }
}