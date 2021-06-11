<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="MySQLProyecto.Menu" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="font-style: normal; background-color: #FF5050; color: #FFFF81">SELECCIONE UNA OPCIÓN</h1>
            <p>
                <asp:Button Text="LIBRO" runat="server" Id="btnLibro" OnClick="btnLibro_Click" BackColor="#FF5050" Font-Bold="True" ForeColor="#FFFF99"/>
            </p>
            <p>
                <asp:Button Text="AUTOR" runat="server" Id="btnAutor" OnClick="btnAutor_Click" BackColor="#FF5050" Font-Bold="True" ForeColor="#FFFF99" />
            </p>
            <p>
                <asp:Button Text="PRESTAMO" runat="server" Id="btnPrestamo" OnClick="btnPrestamo_Click" BackColor="#FF5050" Font-Bold="True" ForeColor="#FFFF99" />
            </p>
        </div>
    </form>
</body>
</html>
