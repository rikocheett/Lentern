<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddIntern.aspx.cs" Inherits="Lentern.Page.AddIntern" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html" />
    <title>Lentern</title>
    <style type="text/css">
        html, body {
            margin: 0;
            padding: 0;
        }

        body {
            background: white;
        }

        header {
            width: 100%;
            background: #80A6FF;
        }

        table.text {
            width: 97%; /* Ширина таблицы */
            border-spacing: 0; /* Расстояние между ячейками */
            margin: auto;
            padding: 10px;
        }

            table.text td {
                width: 50%; /* Ширина ячеек */
                vertical-align: top; /* Выравниaвание по верхнему краю */
            }

                td.rightcol { /* Правая ячейка */
                    text-align: right; /* Выравнивание по правому краю */
                }

        .reg {
            margin: auto;
            margin-top: 50px;
            width: 300px;
            height: 400px;
            border: 1px solid black;
            background: #D7D7D7;
        }

            .reg p, input, button {
                position: relative;
                top: 20px;
                left: 60px;
            }

            .reg input.DateClass1 {
                width: 25px;
            }

            .reg input.DateClass2 {
                width: 40px;
            }
    </style>
</head>
<body>
    <form runat="server" method="post">
    <header>
        <table class="text">
            <tr>
                <td>Lentern</td>
                <td runat="server" class="rightcol"><asp:textbox runat="server" type="text" ID="User">Добавление нового стажера</asp:textbox></td>
            </tr>
        </table>
    </header>    
        <div class="reg">
            <p>Заполните все данные:</p>
            <asp:textbox runat="server" id="Name" placeholder="ФИО*" />
            <asp:textbox runat="server" id="UniversityName" placeholder="Название ВУЗА" />
            <asp:textbox runat="server" id="Cours" placeholder="Курс (цифрой)" />
            <asp:textbox runat="server" id="Faculty" placeholder="Факультет" />
            <asp:textbox runat="server" id="Phone" placeholder="Контактный телефон*" />
            <asp:textbox runat="server" id="Email" placeholder="Почта*" />
            <asp:textbox runat="server" id="About" placeholder="О себе" />
            <p>Дата рождения*:</p>
            <asp:textbox runat="server" class="DateClass1" id="Day" placeholder="ДД" />
            <asp:textbox runat="server" class="DateClass1" id="Month" placeholder="ММ" />
            <asp:textbox runat="server" class="DateClass2" id="Year" placeholder="ГГГГ" />
            <br />
            <br />
            <asp:button runat="server" name="AddInt" id="AddInt" text="Отправить!" OnClick="AddIntern_Click"/>
        </div>
    </form>
</body>
</html>
