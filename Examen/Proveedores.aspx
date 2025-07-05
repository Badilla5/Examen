<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Proveedores.aspx.vb" Inherits="Examen.Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="row mb-3">
        <div class="col-md-4">

            <div class="form-group mb-3">
                <label for="NombreEmpresa">Nombre Empresa</label>
                <asp:TextBox ID="TxtNombreEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="form-group mb-3">
                <label for="TxtContacto">Contacto</label>
                <asp:TextBox ID="TxtContacto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="TxtTelefono">Telefono</label>
                <asp:TextBox  ID="TxtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>

            <div class="form-group mb-3 ">
                <asp:Button ID="btnCancelar" CssClass="btn btn-primary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
            <div class="form-group mb-3 ">
                <asp:Button ID="btnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            </div>
            <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>

        </div>
     </div>

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProveedorId"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        OnRowDeleted="GridView1_RowDeleted"
        DataSourceID="SqlDataSource1" Width="794px" Height="189px">

        <Columns>
            <asp:CommandField ShowSelectButton ="true" />
            <asp:BoundField DataField="ProveedorId" HeaderText="ProveedorId" InsertVisible="False" ReadOnly="True" SortExpression="ProveedorId" />
            <asp:BoundField DataField="NombreEmpresa" HeaderText="NombreEmpresa" SortExpression="NombreEmpresa" />
            <asp:BoundField DataField="Contacto" HeaderText="Contacto" SortExpression="Contacto" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:CommandField ShowDeleteButton ="true" />

        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Proveedores]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:conexionDB %>"
        SelectCommand="SELECT * FROM [Proveedores]"></asp:SqlDataSource>



</asp:Content>
