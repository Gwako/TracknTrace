<%@ Page Title="" Language="C#" MasterPageFile="~/Source/masterpages/kqcargo.Master" AutoEventWireup="true" CodeBehind="TrackandTrace.aspx.cs" Inherits="TrackTrace.TrackandTrace" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- header-->
    <header class="header">
        <h2>Registration Form</h2>
    </header>
    <div class="container">
        <asp:MultiView ID="MvSideBar" runat="server">
            <asp:View ID="VwBlank" runat="server">
                <uc:trackingblank runat="server" id="TrackingBlank" />
            </asp:View>
            <asp:View ID="VwSearch" runat="server">
                <asp:PlaceHolder ID="Pxs" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <div class="tab-content">
                    <asp:PlaceHolder ID="pContent" runat="server"></asp:PlaceHolder>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
    <!-- footer -->

    <footer class="footer">
        <p>&copy;All Rights Reserved 2018</p>
    </footer>
</asp:Content>
