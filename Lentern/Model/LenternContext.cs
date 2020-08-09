/*
 * Контекстный класс, для работы EF с бД
 */

using System;
using System.Data.Entity;

namespace Lentern.Model
{
    public class LenternContext : DbContext
    {
        //Наследуем базовый конструктор поключения
        public LenternContext() : base("DBConnection")
        { }
        //Объявляем поля, наборы необходимых нам сущностей
        public DbSet<Acc> Accs { get; set; }
        public DbSet<Intern> Interns { get; set; }
    }
}
