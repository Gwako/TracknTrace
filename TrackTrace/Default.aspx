<%@ Page Title="" Language="C#" MasterPageFile="~/Source/masterpages/kqcargo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrackTrace.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
  
</asp:Content><asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- header-->
    <header class="header">
        <h2>Registration Form</h2>
    </header>
    <div class="container">
      
        <!-- firstname -->
        <div class="row">
            <div class="col-25">
                <label for="fname">Airway Bill Number [AWB]</label>
            </div>
            <div class="col-75">
                <input type="text" id="awb_number" name="awb_number" placeholder="Enter your number" required="" runat="server" />
            </div>

        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
      
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
