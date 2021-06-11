<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrestamo.aspx.cs" Inherits="MySQLProyecto.frmPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 8px;
        }
        .auto-style2 {
            margin-left: 7px;
        }
        .auto-style3 {
            margin-left: 6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>CodAutor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; <asp:TextBox runat="server" Id="txtCodAutor" Columns="20" CssClass="auto-style2" /> </p>
            <p>CodLibro&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; <asp:TextBox runat="server" Id="txtCodLibro" Columns="20" Width="120px" CssClass="auto-style1" /> </p>
            <p>Fecha Prestamo&nbsp;&nbsp;&nbsp; :&nbsp; <asp:TextBox runat="server" Id="txtFecha" Columns="20" Width="120px" CssClass="auto-style3" /> </p>
            <p>
                <asp:Button Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click" BackColor="#FFFBD6" Font-Bold="True" ForeColor="#990000" />
                <asp:Button Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click" BackColor="#FFFBD6" Font-Bold="True" ForeColor="#990000" />
                <asp:Button ID="btnBuscarLibro" runat="server" BackColor="#FFFBD6" Font-Bold="True" ForeColor="#990000" OnClick="btnBuscarLibro_Click" Text="Buscar Libro" />
                <asp:Button ID="btnBuscarAutor" runat="server" BackColor="#FFFBD6" Font-Bold="True" ForeColor="#990000" OnClick="btnBuscarAutor_Click" Text="Buscar Autor" />
            </p>
            <asp:GridView runat="server" ID="gvPrestamo" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
        <p>
            <asp:Button ID="btnMenu" runat="server" BackColor="#FFFBD6" Font-Bold="True" ForeColor="#990000" OnClick="btnMenu_Click" Text="Volver al menu" />
        </p>
    </form>
</body>
</html>