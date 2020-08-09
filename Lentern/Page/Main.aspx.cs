/*
 * Главная страница имеет 3 части
 * -определение пользователя
 * -перенаправление на другие страницы
 * -функция отображения таблицы с данными
 */

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
            //-------------- 1 часть
            //Декодируем URL
            Owner own = new Owner();//см класс owner
            Encoding enc = new Encoding();
            string userurl = Request.QueryString["User"];
            if (!String.IsNullOrEmpty(userurl))
            {
                //Добавляем на страницу информаци о пользователе
                string user = enc.decode(userurl);
                User.Text = user;
            }
            else
            {
                User.Text = "Новый пользователь";
            }
            //Проверяем является ли пользователь администратором
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
                    Response.Redirect("Default.aspx");
                }
                foreach (var Acc in db.Accs) 
                {
                    if (Acc.Login == user) adminUser = true;
                }
            }
            //Если пользователь не администратор, скрываем кнопки перехода на страницу добавления нового администратора
            //и на страницу добавления нового стажера
            if (!adminUser) 
            {
                AddIternPage.Visible = false;
                AddAdmin.Visible = false;
            }
        }
        //----------------------2 часть
        //Кнопки для перехода на ругие страницы
        //Кнопка перехода на страницу добавления нового стажера
        protected void AddIternPage_Click(object sender, EventArgs e)
        {
            string userurl = Request.QueryString["User"];
            Response.Redirect("AddIntern.aspx?User="+userurl);
        }
        //Кнопка перехода на страницу изменения записи стажера
        protected void EditIntern_Click(object sender, EventArgs e)
        {
            string userurl = Request.QueryString["User"];
            Response.Redirect("ReIntern.aspx?User=" + userurl);
        }
        //Кнопка перехода на страницу добавления нового администратора
        protected void AddAdmin_Click(object sender, EventArgs e)
        {
            string userurl = Request.QueryString["User"];
            Response.Redirect("AddAdmin.aspx?User=" + userurl);
        }
        //Кнопка выхода на страницу авторизации
        protected void Exit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        //-----------------3 часть
        //Если на странице находится администратор, то отображаем всех стажеров
        //Если же на странице стажер, то отображаем только его запись
        protected string ShowTable() 
        {
            //Получем URL
            Encoding enc = new Encoding();
            string userurl = Request.QueryString["User"];
            //Декадируем URL и проверяем является ли пользователь администратором
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
                //Если пользователь администратор, то записываем в строку, все данные в таблице со стадерами 
                if (adminUser)
                {
                    foreach (var I in db.Interns)
                    {
                        html.Append(String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>"
                            , I.CreateDate, I.Name, I.BirthDate, I.Email, I.Phone));
                    }
                }
                //Иначе, записываем в строку только запись стажера 
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