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
            if (!String.IsNullOrEmpty(userurl))
            {
                Encoding enc = new Encoding();
                string user = enc.decode(userurl);
                User.Text = user;
            }
            else
            {
                User.Text = "Новый пользователь";
            }
        }

        protected void AddAdm_Click(object sender, EventArgs e)
        {
            String login = Login.Text;
            String password = Password.Text;

            if (String.IsNullOrEmpty(login) && String.IsNullOrEmpty(password))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите все данные!')", true);
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
    }
}