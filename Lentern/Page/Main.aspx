<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Lentern.Page.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

        table.button {
            width: 100%;
            /* Ширина таблицы */
            border-spacing: 0;
            /* Расстояние между ячейками */
            margin: auto;
            padding: 10px;
        }
         td.rightcol {
            position: relative;
            left: 700px;
        }

        table.inf {
            border: 1px solid black;
            margin: auto;
            background: white;
            border-collapse: collapse;
        }

        table.inf td,
        th {
            padding: 5px;
        }

        table.inf th {
            background: #D7D7D7;
            border-bottom: 1px solid black;
        }
        .Exit {
            position: relative;
            left: 50px;
        }
    </style>
</head>

<body>
    <form runat="server">
        <header>
            <table class="text">
                <tr>
                    <td>
                        <p>Lentern - главная страница</p>
                    </td>
                    <td class="rightcol">
                         <br/><asp:TextBox runat="server" type="text" ID="User" Width="130px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </header>
        <table class="button">
            <tr>
                <td>
                    <asp:Button runat="server" name="AddIternPage" ID="AddIternPage" Text="Добавить запись" OnClick="AddIternPage_Click"/>
                    <asp:Button runat="server" name="EditIntern" ID="EditIntern" Text="Редактировать запись" OnClick="EditIntern_Click" />            
                    <asp:Button runat="server" name="AddAdmin" ID="AddAdmin" Text="Добавить администратора" OnClick="AddAdmin_Click" />
                </td>
                <td >
                    <asp:Button CssClass="Exit" runat="server" name="Exit" ID="Exit" Text="Выход" OnClick="Exit_Click" />                
                </td>
            </tr>
        </table>
    
        <table class="inf">
            <tr>
                <th>Дата создания</th>
                <th>ФИО</th>
                <th>Дата рождения</th>
                <th>Email</th>
                <th>Контактный телефон</th>
            </tr>
            <%=ShowTable() %>
        </table>
    </form>
</body>
    

</html>
