using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lentern.Model;

namespace Lentern
{
    public class Owner
    {
        private string OwnerLogin = "Owner";
        private string OwnerPassword = "Owner";

        public Owner() 
        {
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