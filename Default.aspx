<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="valo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <br />
        <div style="width: 34%; float: left;">
        <asp:Label ID="Label1" runat="server" Text="Language: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>English</asp:ListItem>
            <asp:ListItem>中文</asp:ListItem>
        </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Type: "></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Skin: "></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" Height="108px" Width="257px" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="51px" OnClick="Button1_Click1" Text="Add to List" Width="256px" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Generate Image" Width="253px" Height="39px" />
        </div>
        <div style="float: left; width: 33%; height: 390px;">
            <asp:ListBox ID="ListBox1" runat="server" Height="362px" Width="253px"></asp:ListBox>
        </div>
        <div style="float: left; width: 27%; height: 387px;">
            <asp:Button ID="Button3" runat="server" Height="47px" Text="Delete Selected Skin" Width="308px" />
            <br />
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>

    </asp:Content>
