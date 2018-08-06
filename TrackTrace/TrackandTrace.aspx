<%@ Page Title="" Language="C#" MasterPageFile="~/Source/masterpages/kqcargo.Master" AutoEventWireup="true" CodeBehind="TrackandTrace.aspx.cs" Inherits="TrackTrace.TrackandTrace" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- header-->
    <header class="header">
        <h2>Registration Form</h2>
    </header>
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <!-- firstname -->
        <div class="row">
            <div class="col-25">
                <label for="fname">First Name</label>
            </div>
            <div class="col-75">
                <input type="text" id="fname" name="firstname" placeholder="Enter first name" required="" runat="server" />
            </div>
        </div>
        <%--<!-- lastname -->
        <div class="row">
            <div class="col-25">
                <label for="lname">Last Name</label>
            </div>
            <div class="col-75">
                <input type="text" id="lname" name="lastname" placeholder="Enter last name" required="" runat="server" />
            </div>
        </div>--%>
       <%-- <!-- password -->
        <div class="row">
            <div class="col-25">
                <label for="password">Password</label>
            </div>
            <div class="col-75">
                <input type="password" id="password" name="password" placeholder="Enter password" required="" runat="server" />
            </div>
        </div>
        <!-- Email-->

        <div class="row">
            <div class="col-25">
                <label for="email">Email</label>
            </div>
            <div class="col-75">
                <input type="text" id="email" name="email" placeholder="Enter email" required="" runat="server" />
            </div>
        </div>--%>
        <!--submit button-->
        <div class="row">
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" CssClass="btn-button" OnClick="SubmitButton_Click" />
        </div>
    </div>
    <!-- footer -->

    <footer class="footer">
        <p>&copy;All Rights Reserved 2018</p>
    </footer>
</asp:Content>
