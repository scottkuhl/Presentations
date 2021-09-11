<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Widgets_Login" Title="Login" %>
<%@ Register src="Menu.ascx" tagname="TabMenu" tagprefix="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <script type="text/javascript" src="../jquery.colorbox.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".showSettings").colorbox({ width: "600px", inline: true, href: "#blogrollSettings" });
            $(".addNew").colorbox({ width: "620px", inline: true, href: "#addBlogroll" });
        });

        function closeOverlay() {
            $.colorbox.close();
        }
    </script>
	<div class="content-box-outer">
		<div class="content-box-right">
			<menu:TabMenu ID="TabMenu" runat="server" />
		</div>
		<div class="content-box-left">

            <!-- Your Content -->

            <h1>Login</h1>

            <p>
                Show User Name: <asp:CheckBox ID="ShowUserName" runat="server" />
                <asp:Button ID="Save" runat="server" Text="Save" onclick="Save_Click" />
            </p>

        </div>
    </div>
</asp:Content>
