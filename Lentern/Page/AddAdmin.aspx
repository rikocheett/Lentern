<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAdmin.aspx.cs" Inherits="Lentern.Page.AddAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Lentern</title>
    <style type="text/css">
        html,
        body {
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
            width: 97%;
            /* Ширина таблицы */
            border-spacing: 0;
            /* Расстояние между ячейками */
            margin: auto;
            padding: 10px;
        }

            table.text td {
                width: 50%;
                /* Ширина ячеек */
                vertical-align: top;
                /* Выравниaвание по верхнему краю */
            }

        td.rightcol {
            position: relative;
            left: 700px;
        }

        .reg {
            margin: auto;
            margin-top: 50px;
            width: 300px;
            height: 200px;
            border: 1px solid black;
            background: #D7D7D7;
        }

            .reg p,
            input,
            button {
                position: relative;
                top: 20px;
                left: 60px;
            }
    </style>
</head>

<body>
    <form runat="server" method="post">
        <header>
            <table class="text">
                <tr>
                    <td>
                        <p>Lentern - Новый админинистратор</p>
                    </td>
                    <td class="rightcol">
                        <asp:TextBox runat="server" type="text" ID="User" Width="130px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </header>
        <div class="reg">
            <p>Заполните все данные:</p>
            <asp:TextBox runat="server" ID="Login" placeholder="Логин" />
            <asp:TextBox runat="server" ID="Password" placeholder="Пароль" />
            <br />
            <br />
            <asp:Button runat="server" name="AddIdm" ID="AddAdm" Text="Отправить!" OnClick="AddAdm_Click"/>
        </div>
    </form>
</body>

</html>
