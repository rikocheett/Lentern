using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lentern.Model;
using System.Text;

namespace Lentern.Page
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Owner own = new Owner();
            Encoding enc = new Encoding();
            //string userurl = Request.QueryString["User"];
            string userurl = enc.encode("Owner");
            if (!String.IsNullOrEmpty(userurl))
            {
                string user = enc.decode(userurl);
                User.Text = user;
            }
            else
            {
                User.Text = "Новый пользователь";
            }

            bool adminUser = false;
            using (LenternContext db = new LenternContext()) 
            {
                string user = "";
                if (!String.IsNullOrEmpty(userurl))
                {
                    string decode = enc.decode(userurl);
                    user = decode;
                }
                else
                {
                    Response.Redirect("google.com");
                }
                foreach (var Acc in db.Accs) 
                {
                    if (Acc.Login == user) adminUser = true;
                }
            }
            if (!adminUser) 
            {
                AddIternPage.Visible = false;
                AddAdmin.Visible = false;
            }
        }

        protected void AddIternPage_Click(object sender, EventArgs e)
        {
            //string userurl = Request.QueryString["User"];
            Encoding enc = new Encoding();
            string userurl = enc.encode("Owner");
            Response.Redirect("AddIntern.aspx?User="+userurl);
        }

        protected void EditIntern_Click(object sender, EventArgs e)
        {

        }

        protected void AddAdmin_Click(object sender, EventArgs e)
        {
            //string userurl = Request.QueryString["User"];
            Encoding enc = new Encoding();
            string userurl = enc.encode("Owner");
            Response.Redirect("AddAdmin.aspx?User=" + userurl);
        }

        protected void Exit_Click(object sender, EventArgs e)
        {

        }
        protected string ShowTable() 
        {
            Encoding enc = new Encoding();
            //string userurl = Request.QueryString["User"];
            string userurl = enc.encode("01.sasha.01@mail.ru");

            bool adminUser = false;
            using (LenternContext db = new LenternContext())
            {
                string user = "";
                if (!String.IsNullOrEmpty(userurl))
                {
                    string decode = enc.decode(userurl);
                    user = decode;
                }
                else
                {
                    Response.Redirect("google.com");
                }
                foreach (var Acc in db.Accs)
                {
                    if (Acc.Login == user) adminUser = true;
                }
                StringBuilder html = new StringBuilder();

                if (adminUser)
                {
                    foreach (var I in db.Interns)
                    {
                        html.Append(String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>"
                            , I.CreateDate, I.Name, I.BirthDate, I.Email, I.Phone));
                    }
                }
                else 
                {
                    foreach (var I in db.Interns)
                    {
                        if (I.Email == user) 
                        {
                            html.Append(String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>"
                                , I.CreateDate, I.Name, I.BirthDate, I.Email, I.Phone));
                        }
                    }
                }
                return html.ToString();
            }
        }
    }
}