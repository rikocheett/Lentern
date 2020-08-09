<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lentern.Page.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

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

        td.rightcol1 {
            position: relative;
            left: 700px;
        }

        td.rightcol { /* Правая ячейка */
            text-align: right; /* Выравнивание по правому краю */
        }

        .reg {
            margin: auto;
            margin-top: 50px;
            width: 300px;
            height: 170px;
            border: 1px solid black;
            background: #D7D7D7;
        }

            .reg p, input {
                position: relative;
                top: 20px;
                left: 60px;
            }

            .reg table {
                position: relative;
                top: 20px;
            }

        table.button {
            width: 100%; /* Ширина таблицы */
            border-spacing: 0; /* Расстояние между ячейками */
            margin: auto;
            padding: 10px;
        }
        .FuckinckButtons {
            margin: 0;
            padding: 0;
            position: relative;
            top: 0px;
            left: 0px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <header>
            <table class="text">
                <tr>
                    <td><p>Lentern - Авторизация</p></td>
                    <td class="rightcol1">
                    </td>
                </tr>
            </table>
        </header>
        <div class="reg">
            <p>Введите логин или почту:</p>
            <asp:TextBox runat="server" ID="Login" placeholder="Login or Email" /><br/><br/>
            <asp:TextBox runat="server" ID="Password" placeholder="Password" Enabled="false"/><br/>            
            <table class="button">
                <tr>
                    <td>
                        <asp:Button runat="server" name="AddInt" ID="AddInt" Text="Новый стажер!" OnClick="AddInt_Click" CssClass="FuckinckButtons"/>
                    </td>
                    <td class="rightcol">
                        <asp:Button runat="server" name="Exit" ID="Exit" Text="Вход!" OnClick="Exit_Click" CssClass="FuckinckButtons"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
