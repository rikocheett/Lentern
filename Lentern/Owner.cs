/*
 * Данный класс иннициализируется при загрузке каждой страницы сайта, и гарантирует, что всегда в базе данных
 * будет хотя бы 1 пользователь с полными полями
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lentern.Model;

namespace Lentern
{
    public class Owner
    {
        //Поля содержащии Логин и пароль
        private string OwnerLogin = "Owner";
        private string OwnerPassword = "Owner";

        public Owner() 
        {
            //Перебераем все записи в таблице Acc, если нет ниодной записи с полными правами, то создаем ее
            //С указанными выше логином и паролем
            using (LenternContext db = new LenternContext()) 
            {
                var selectOwner = from acc in db.Accs
                             where acc.Owner == true
                             select acc;

                int i = 0;
                foreach (Acc a in selectOwner) 
                {
                    if (a.Owner == true) i++;
                }

                if (i == 0) 
                {
                    Acc own = new Acc { Login = OwnerLogin, Password = OwnerPassword, Admin = true, Owner = true };
                    db.Accs.Add(own);
                    db.SaveChanges();
                }
            }
        }
    }
}