using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lentern.Model;

namespace Lentern.Page
{
    public partial class AddIntern : System.Web.UI.Page
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

        protected void AddIntern_Click(object sender, EventArgs e)
        {


            String name = Name.Text;
            String universityName = UniversityName.Text;
            String cours = Cours.Text;
            String faculty = Faculty.Text;
            String phone = Phone.Text;
            String email = Email.Text;
            String about = About.Text;
            String day = Day.Text;
            String month = Month.Text;
            String year = Year.Text;

            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(phone) && String.IsNullOrEmpty(email) && String.IsNullOrEmpty(day) &&
                String.IsNullOrEmpty(month) && String.IsNullOrEmpty(year) && Int32.TryParse(cours, out int a) && Int32.TryParse(day, out int u) &&
                Int32.TryParse(month, out int b) && Int32.TryParse(year, out int c))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите все обязательные поля! Либо поля с цифровым значением введины некоректно!')", true);
            }
            else
            {
                string userurl = Request.QueryString["User"];
                String createName;
                if (!String.IsNullOrEmpty(userurl))
                {
                    Encoding enc = new Encoding();
                    string user = enc.decode(userurl);
                    createName = user;
                }
                else createName = email;
                DateTime time = DateTime.Now;
                DateTime birthDate = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                using (LenternContext db = new LenternContext())
                {
                    Intern i = new Intern
                    {
                        Name = name,
                        BirthDate = birthDate,
                        UniversityName = universityName,
                        Course = Int32.Parse(cours),
                        Faculty = faculty,
                        Phone = phone,
                        Email = email,
                        About = about,
                        CreateDate = time,
                        EditDate = time,
                        CreateName = createName,
                        EditName = createName
                    };
                    db.Interns.Add(i);
                    db.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Запись стажера добавлена!')", true);
                }
            }
        }
    }
}