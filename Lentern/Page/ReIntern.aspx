<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReIntern.aspx.cs" Inherits="Lentern.Page.ReIntern" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            height: 70px;
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
            position: relative;
            left: 700px;
        }

        .reg {
            margin: auto;
            margin-top: 50px;
            width: 300px;
            height: 500px;
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
                    <td>
                        <p>Lentern - Изменение записи стажера</p>
                    </td>
                    <td class="rightcol">
                        <asp:TextBox runat="server" type="text" ID="User" Width="130px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </header>
        <div class="reg">

            <p id="PShow">Введите Email стажера</p>
            <asp:TextBox runat="server" ID="Email" placeholder="Email" />
            <br/>
            <asp:Button runat="server" name="Show" ID="Show" Text="Редактировать" OnClick="Show_Click" />

            <p>Измените необходимы данные:</p>
            <asp:TextBox runat="server" ID="Name" placeholder="ФИО*" />
            <asp:TextBox runat="server" ID="UniversityName" placeholder="Название ВУЗА" />
            <asp:TextBox runat="server" ID="Cours" placeholder="Курс (цифрой)" />
            <asp:TextBox runat="server" ID="Faculty" placeholder="Факультет" />
            <asp:TextBox runat="server" ID="Phone" placeholder="Контактный телефон*" />
            <asp:TextBox runat="server" ID="About" placeholder="О себе" />
            <p>Дата рождения*:</p>
            <asp:TextBox runat="server" class="DateClass1" ID="Day" placeholder="ДД" />
            <asp:TextBox runat="server" class="DateClass1" ID="Month" placeholder="ММ" />
            <asp:TextBox runat="server" class="DateClass2" ID="Year" placeholder="ГГГГ" />
            
            <p id="ApproveShow">Утвердить</p>   
            <asp:checkbox runat="server" ID="Approve"/>
            <br />
            <br />
            <asp:Button runat="server" name="ReInt" ID="ReInt" Text="Изменить" OnClick="ReInt_Click" />
        </div>
    </form>
</body>
</html>
