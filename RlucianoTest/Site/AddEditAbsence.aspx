<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditAbsence.aspx.cs" Inherits="AbsenceTest.AddEditAbsence" MasterPageFile="~/Site/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-5">

            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="TbxName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ControlToValidate="TbxName"
                    Display="Static"
                    ErrorMessage="Name Field is required."
                    ID="ValidateNombres"
                    Text="Name Field is required"
                    ForeColor="Red"
                    CssClass="danger"
                    runat="Server" />
            </div>
            <div class="form-group">

                <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>

                <asp:TextBox ID="TbxLastName" runat="server" CssClass="form-control" MaxLength="150"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ControlToValidate="TbxLastName"
                    Display="Static"
                    ForeColor="Red"
                    CssClass="danger"
                    ErrorMessage="Last Name Field is required."
                    ID="rfvApellidos"
                    Text="El apellido es requerido"
                    runat="Server" />

            </div>

            <div class="form-group">

                <asp:Label ID="Label3" runat="server" Text="Absence Type" MaxLength="150"></asp:Label>

                <asp:DropDownList ID="ddlapbsencetaype" runat="server" CssClass="form-control dropdown"></asp:DropDownList>

            </div>
            <div class="form-group">

                <asp:Label ID="Label4" runat="server" Text="Date"></asp:Label>

                <asp:TextBox ID="AbsenceDate" runat="server" CssClass="form-control" placeholder="MM/dd/yyyy" ReadOnly="false" autocomplete="off" onkeydown="return false;"></asp:TextBox>

                <ajaxToolkit:CalendarExtender ID="AbsenceDate_CalendarExtender" runat="server" BehaviorID="AbsenceDate_CalendarExtender"
                    TargetControlID="AbsenceDate" Format="dd/MM/yyyy" FirstDayOfWeek="Monday" CssClass="MyCalendar" />

                <asp:RequiredFieldValidator
                    ControlToValidate="AbsenceDate"
                    Display="Static"
                    ForeColor="Red"
                    CssClass="danger"
                    ErrorMessage="Date Field is required."
                    ID="RequiredFieldValidator1"
                    Text="Fecha es Requerido"
                    runat="Server" />


                <asp:RangeValidator
                    runat="server"
                    ID="RangeValidator1"
                    Type="Date"
                    ForeColor="Red"
                    CssClass="danger"
                    ControlToValidate="AbsenceDate"
                    MaximumValue="9999/12/30"
                    MinimumValue="2020/01/01"
                    ErrorMessage="Date Field is not  a valid value"
                    Display="None" />
            </div>


            <div></div>
            <div>
                <br />
            </div>
            <div class="btn btn-group">
                <asp:Button ID="ibtnOk" runat="server" Text="Save" CausesValidation="true" CssClass="btn btn-primary" OnClick="ibtnOk_Click" />
                <ajaxToolkit:ConfirmButtonExtender ID="ibtnOk_ConfirmButtonExtender" runat="server" BehaviorID="ibtnOk_ConfirmButtonExtender" ConfirmText="Please confirm your action!" TargetControlID="ibtnOk"></ajaxToolkit:ConfirmButtonExtender>

                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" CssClass="btn btn-warning" OnClick="btnCancel_Click" />
            </div>
            <div style="height: 150px;">
            </div>
        </div>

    </div>


</asp:Content>
