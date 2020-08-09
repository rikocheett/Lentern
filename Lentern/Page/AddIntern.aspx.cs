/*
 * Страница добавления стажера почти не отличается видом для нового пользователя(стажера), и для администратора.
 * Логика страницы следующая: берем из URL логин пользователя, помечаем в разметке логин пользователя
 * Затем описываем обработчик кнопки добавления новой записи стажера
 */

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
            //Берем из URL логин, если он есть, то помещаем его на разметки
            //Если его нет, то пишим что зашел новый пользователь
            Owner own = new Owner();//см класс owenr
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
        //Обработчик кнопки добавления нового стажера
        protected void AddIntern_Click(object sender, EventArgs e)
        {
            //Берем данные из разметки
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
            //Проверяем Email на повторение
            bool repeatlogin = false;
            using (LenternContext db = new LenternContext()) 
            {
                foreach (var i in db.Interns) 
                {
                    if (i.Email == email) repeatlogin = true;
                }
            }
            //Проверяем данные на пустоту, и чиловые значения, если что-то не так, выводим сообщение
            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(phone) && String.IsNullOrEmpty(email) && String.IsNullOrEmpty(day) &&
                String.IsNullOrEmpty(month) && String.IsNullOrEmpty(year) && Int32.TryParse(cours, out int a) && Int32.TryParse(day, out int u) &&
                Int32.TryParse(month, out int b) && Int32.TryParse(year, out int c))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите все обязательные поля! Либо поля с цифровым значением введены некорректно!')", true);
            }
            //Если Email повторился, сообщаем об этом
            else if (repeatlogin) 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Пользователь с таким Email уже существует')", true);
            }
            //Иначе добавляем данные в БД
            else
            {
                //Для этого необходимо получить дополнительные поля, дата создания и имя пользователя
                //Если на странице новый пользователь, то, ставим в поле createName Email который был введен
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
                //Добавляем и сохраняем ланные, выводим сообщение об удачном добавлении стажера
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
                        EditName = createName,
                        Approve = false
                    };
                    db.Interns.Add(i);
                    db.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Запись стажера добавлена!')", true);
                    Response.Redirect("Default.aspx");
                }
            }
        }
        //Кнопка возврата на главную страницу
        protected void Home_Click(object sender, EventArgs e)
        {
            string userurl = Request.QueryString["User"];
            Response.Redirect("Main.aspx?User=" + userurl);
        }
    }
}