using System;

namespace Lentern.Model
{
    public class Acc
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Owner { get; set; }
        public bool Admin { get; set; }
    }
}
