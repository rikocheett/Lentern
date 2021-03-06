# Lentern

https://docs.google.com/document/d/1vhmjB0q5zwZYTVD-weddsJ2AvHPSolC1LaJFOCFgU_M/edit?usp=sharing

Для решения тестового задания я решил выбрать следующие технологии:
   * ASP.NET WebForms
   * Entity Framework
   * MS SQL
   * LINQ
   * HTML
   * XMLNS
   * CSS
### Entity Framework и MS SQL
В решении тестового задания Entity Framework и MS SQL отвечают за хранение и управление данными.
В программе существуют две независимые сущности: Acc и Intern.
Сущность Acc представляет из себя учетную запись администратора или владельца и содержит следующие атрибуты:
   - IdAcc, int
   - Login, str
   - Password, str
   - Owner, bool
   - Admin, bool
   
Сущность Intern представляет из себя запись стажера и содержит следующие атрибуты:
   - IdIntern, int
   - Name, str
   - BirthDate, datetime
   - UniversityName, str
   - Course, int
   - Faculty, str
   - Phone, str
   - Email, str
   - About, str
   - CreateDate, datetime
   - EditDate, datetime
   - CreateName, str
   - EditName, str
   - Approve, bool
   
При разработке этой части программы использовался подход Code First. Основные шаги в разработке этого подхода:
   - Установка Entity Framework через NuGet-пакеты
   - Создание БД и подключение его в файле WebConfig
   - Написания классов сущностей, Acc и Intern
   - Написания класса контекста, LenternContext
После проделывания данных шагов, при первом запуске создаются необходимые таблицы согласно классам сущностей, и, используя класс LenternContext, можно исполнять дальнейшую работу.
Также в некоторых моментах удобный доступ к данным можно получить через LINQ запросы.
Классы, описанные выше, располагаются в папке Model, подробнее с работой каждого вышеописанного элемента можно ознакомиться непосредственно в комментариях к коду.

### HTML и ASP.NET WebForms
В данном приложении присутствуют 5 страниц:
   + Default.aspx - страница регистрации
   + Main.aspx - главная страница
   + AddAdmin.aspx - страница добавления администратора
   + AddIntern.aspx - страница добавления стажера
   + ReIntern.aspx - Страница изменений записи стажера
Изначально я сверстал все страницы используя HTML и CSS. Затем в папке Page создал WebForm'ы для каждой страницы. При переходе с HTML некоторые элементы верстки необходимо было реализовать через разметку XMLNS.
Подробнее с работой каждого вышеописанного элемента можно ознакомиться непосредственно в комментариях к коду.

## Авторизация и уровни доступа
Согласно ТЗ необходимо реализовать авторизацию и уровни доступа, я это сделал используя URL. То есть, после авторизации пользователя, при перенаправлении на другую страницу, я указываю в URL что это за пользователь.
Затем каждая отдельная страница после перенаправления, зная, что это за пользователь, решает, что для него отображать или можно ли вообще этому пользователю здесь находиться.
Но, просто в URL писать логин или id пользователя было бы не безопасно, поэтому я использовал класс кодирования Encoding.
Также в программе существует класс Owner, который инициализируется при запуске любой из страниц, этот класс добавляет сущность с полными правами и указанным в нем логином и паролем, если такой сущности еще нет. Этот класс необходим для гарантии, что при запуске программы на новом сервере, будет хотя бы один пользователь с полными правами.
По ТЗ необходимо, чтобы каждый стажер мог отредактировать свою запись, а администратор может редактировать все записи, для этого неободимо, чтобы и тот, и тот мог авторизоваться, именно поэтому я реализовал двухфазную авторизацию.

### Двухфазная авторизация
При попадании на страницу авторизации, пользователь видит перед собой два поля: логин и пароль, но поле ввода пароль изначально недоступно. 
Сделано это для того, чтобы, если пользователем является стажер, он мог просто ввести свою почту и попасть на главную страницу.
А если же в поле логин ввести логин администратора или владельца, потребуется ввести пароль.

### Класс кодирования Encoding
Этот класс представляет из себя два массива, равных по длине, в одном - буквы латинского алфавита и некоторые символы, в другом - код из двух цифр. 
Также в классе присутствуют два метода для кодирования и декодирования.
То есть, каждой букве, либо символу из первого массива, противопоставлен код из 2х цифр второго массива, и при кодировании каждая буква заменяется соответствующей цифрой.
Конечно же, это не гарантирует полной безопасности, но от пользователей, захотевших подобрать логин администратора, это защитит.
Подробнее с работой каждого вышеописанного элемента можно ознакомиться непосредственно в комментариях к коду.

## Запуск
Для запуска и тестирования разработанного сайта, я использовал встроенное в Visual Studio средство IIS Express.
Если вы хотите также посмотреть на работу сайта, вам необходимо, скачать данный репозиторий, либо архив, открыть файл Lentern.sln и запустить проект.

P.S. Пожалуйста, не ругайтесь на верстку, я исправлюсь)
