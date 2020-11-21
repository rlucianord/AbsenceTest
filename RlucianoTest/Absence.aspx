<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Absence.aspx.cs" Inherits="AbsenceTest.Absence" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clearfix"></div>

    <asp:GridView ID="gvPermisos" runat="server" AutoGenerateColumns="False" CellPadding="2"
        ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="25" OnPageIndexChanging="gvPermisos_PageIndexChanging" Height="74px" Width="533px">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton AlternateText="Actualizar" ID="ibtnEdit" runat="server" ImageUrl="Images/edit.gif"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'
                        OnClick="ibtnEdit_Click" />
                </ItemTemplate>
                <HeaderTemplate>
                    <asp:ImageButton AlternateText="Crear Tarifa" ID="ibtnAdd" runat="server" ImageUrl="Images/add.gif"
                        OnClick="ibtnAdd_Click" />
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton AlternateText="Eliminar" ID="ibtnDelete" runat="server" ImageUrl="Images/delete.gif"
                        CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'
                        OnClick="ibtnDelete_Click" />
                    <ajaxToolkit:ConfirmButtonExtender ID="DeleteExtender" runat="server" BehaviorID="DeleteExtender" ConfirmText="Please confirm your action!" TargetControlID="ibtnDelete"></ajaxToolkit:ConfirmButtonExtender>




                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Code" />
            <asp:BoundField DataField="NombreEmpleado" HeaderText="Name" />
            <asp:BoundField DataField="ApellidosEmpleado" HeaderText="Last Name" />
            <asp:BoundField DataField="FechaPermiso" HeaderText="Date" DataFormatString="{0:yyyy/MM/dd}" />
            <asp:BoundField DataField="DescTipoPermiso" HeaderText="Absence For" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" Height="25px" />
        <PagerStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Center" CssClass="pager" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="25px" />
        <EditRowStyle BackColor="#2461BF" CssClass="col-2" />
        <AlternatingRowStyle BackColor="White" />
        <EmptyDataTemplate>
            <div class="col-lg-10">
                Actualmente no existen Permisos en el sistema...<br />
                Si desea crear una haga clic
           <asp:LinkButton ID="lbtnPrimero" runat="server" OnClick="lbtnPrimero_Click">aquí</asp:LinkButton>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>







</asp:Content>
