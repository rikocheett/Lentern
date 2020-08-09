using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lentern.Model;

namespace Lentern.Page
{
    public partial class ReIntern : System.Web.UI.Page
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
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            if (!admin)
            {
                Email.Text = User.Text;
                Email.Enabled = false;
                Show.Visible = false;
                Approve.Enabled = false;
                Show_Click(sender, e);
            }
        }

        protected void ReInt_Click(object sender, EventArgs e)
        {

            string email = Email.Text;
            bool flag = false;
            string name = Name.Text;
            string universityName = UniversityName.Text;
            string cours = Cours.Text;
            string faculty = Faculty.Text;
            string phone = Phone.Text;
            string about = About.Text;
            string day = Day.Text;
            string month = Month.Text;
            string year = Year.Text;
            bool approve = Approve.Checked;
            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(phone) && String.IsNullOrEmpty(email) && String.IsNullOrEmpty(day) &&
                String.IsNullOrEmpty(month) && String.IsNullOrEmpty(year) && Int32.TryParse(cours, out int a) && Int32.TryParse(day, out int u) &&
                Int32.TryParse(month, out int b) && Int32.TryParse(year, out int c))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите все обязательные поля! Либо поля с цифровым значением введены некорректно!')", true);
            }
            else
            {
                string editorName = User.Text;
                DateTime time = DateTime.Now;
                DateTime birthDate = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                using (LenternContext db = new LenternContext())
                {
                    foreach (var i in db.Interns)
                    {
                        if (i.Email == email)
                        {
                            flag = true;
                            i.Name = name;
                            i.BirthDate = birthDate;
                            i.UniversityName = universityName;
                            i.Course = Int32.Parse(cours);
                            i.Faculty = faculty;
                            i.Phone = phone;
                            i.About = about;
                            i.EditDate = time;
                            i.EditName = editorName;
                            i.Approve = approve;
                        }
                    }
                    db.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Данные изменены!')", true);
                }
                if (!flag) ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Данный пользователь не найден')", true);
            }
        }

        protected void Show_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            bool flag = false;
            using (LenternContext db = new LenternContext())
            {
                foreach (var i in db.Interns)
                {
                    if (i.Email == email)
                    {
                        flag = true;
                        Name.Text = i.Name;
                        UniversityName.Text = i.UniversityName;
                        Cours.Text = i.Course.ToString();
                        Faculty.Text = i.Faculty;
                        Phone.Text = i.Phone;
                        About.Text = i.About;
                        Day.Text = i.BirthDate.Day.ToString();
                        Month.Text = i.BirthDate.Month.ToString();
                        Year.Text = i.BirthDate.Year.ToString();
                        Approve.Checked = i.Approve;
                    }
                }
            }
            if (!flag) ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Данный пользователь не найден')", true);
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            string userurl = Request.QueryString["User"];
            Response.Redirect("Main.aspx?User=" + userurl);
        }
    }
}