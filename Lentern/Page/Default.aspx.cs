/*
 * Страница авторизации работает по следующему алгоритму:
 * Пользователь вводит логин и надимает на кнопку "Вход"
 * Кнопка Вход, проверяет чей это логин, администратора или стажера
 * Если логин стажера, то пользователь перенаправляется, на главную траницу
 * Если же логин принадлежит администратору, то тогда становится доступным поле ввода
 * Пароля и высплывает уведомление, о том, что необходимо ввести пароль
 * Затем Администратор нажимает на кнопку Вход, данные проверяются
 * И пользователь перенаправляется на главную страницу
 * Так же на страницы есть кнопка для создания новой записи стажера без авторизации
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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //См. данный класс
            Owner own = new Owner();
        }

        protected void AddInt_Click(object sender, EventArgs e)
        {
            //Создание стажера без авторизации
            Response.Redirect("AddIntern.aspx");
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            //Получаем данный
            string login = Login.Text;
            string password = Password.Text;
            string pass = "";
            bool Pass = false;
            bool intern = false;
            //Проверяем является ли пользователь администратором либо стажером
            //Если пользователь администратор, то запоминаем его пароль
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
            //Если пользователь стажер, перенаправляем его на главную страницу, с нужным URL
            if (!string.IsNullOrEmpty(login) && !Pass && string.IsNullOrEmpty(password) && intern)
            {
                Encoding enc = new Encoding();
                string userurl = enc.encode(login);
                Response.Redirect("Main.aspx?User=" + userurl);
            }
            //Если пользователь администратор, но пароль еще не введен, делаем поле ввода пароля доступным
            //И просим пользователя ввести пароль
            else if (!string.IsNullOrEmpty(login) && Pass && string.IsNullOrEmpty(password) && !intern)
            {
                Password.Enabled = true;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Введите пароль!')", true);
            }
            //Если пользователь администратор, и пароль уже введен, то сравниваем, правильный ли пароль
            //И перенаправляем его на главную страницу с необходимым URL
            else if (!string.IsNullOrEmpty(login) && Pass && !string.IsNullOrEmpty(password) && !intern && (password == pass))
            {
                Encoding enc = new Encoding();
                string userurl = enc.encode(login);
                Response.Redirect("Main.aspx?User=" + userurl);
            }
            //Если пользователь администратор, и пароль уже введен, но пароль неверный, сообщаем об этом
            else if (!string.IsNullOrEmpty(login) && Pass && !string.IsNullOrEmpty(password) && !intern && !(password == pass))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Неверный пароль!')", true);
            }
            //Во всех остальных случаях, что-то пользователь сделал не так
            else 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Неправильно выполненный вход!')", true);
            }
        }
    }
}