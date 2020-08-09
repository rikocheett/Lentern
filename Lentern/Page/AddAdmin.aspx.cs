/*
 * Страница добавления администратора даступна долько для администратора.
 * Логика страницы следующая: берем из URL логин пользователя, помечаем в разметке логин пользователя
 * Затем описываем обработчик кнопки добавления новой записи администратора
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
    public partial class AddAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Берем из URL логин, если он есть, то помещаем его на разметки
            //Если его нет, либо url пренадлежит стажеру, то отправляем их на странизу авторизации
            Owner own = new Owner();//см класс owner
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
        //Обработчик кнопки добавления нового администратора
        protected void AddAdm_Click(object sender, EventArgs e)
        {
            //Берем данные из разметки
            String login = Login.Text;
            String password = Password.Text;
            //Проверяем логин на повторение
            bool repeatlogin = false;
            using (LenternContext db = new LenternContext())
            {
                foreach (var a in db.Accs)
                {
                    if (a.Login == login) repeatlogin = true;
                }
            }
            //Если данные не введены, сообщаем об этом
            if (String.IsNullOrEmpty(login) && String.IsNullOrEmpty(password))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите все данные!')", true);
            }
            //Если логин повторился, сообщаем об этом
            else if (repeatlogin) 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Администратор с таким логином уже есть')", true);
            }
            //Иначе, добавляем нового администратора
            else
            {
                Acc a = new Acc
                {
                    Login = login,
                    Password = password,
                    Owner = false,
                    Admin = true
                };
                //Добовляем, созраняем, сообщаем пользователю 
                using (LenternContext db = new LenternContext())
                {
                    db.Accs.Add(a);
                    db.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Администратор добавлен!')", true);
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