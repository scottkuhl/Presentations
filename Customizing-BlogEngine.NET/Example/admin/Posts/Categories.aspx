<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true"
    ValidateRequest="False" CodeFile="Categories.aspx.cs" Inherits="admin_Pages_Categories" %>
<%@ Register src="Menu.ascx" tagname="TabMenu" tagprefix="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <script type="text/javascript" src="../jquery.colorbox.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addNew").colorbox({ width: "500px", inline: true, href: "#frmAddNew" });
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
            <h1><%=Resources.labels.categories %><a href="#" class="addNew"><%=Resources.labels.addNewCategory %></a></h1>
            
            <div style="display:none;">
                <div id="frmAddNew" class="overlaypanel" >
                    <h2><%=Resources.labels.addNewCategory %></h2>
                    <ul class="fl">
                        <li>
                            <asp:Label ID="lblNewCategory" runat="server" AssociatedControlID="txtNewCategory"
                                Text="<%$Resources:labels,title %>" /><br />
                            <asp:TextBox runat="Server" ID="txtNewCategory" Width="200" />
                            <asp:CustomValidator runat="Server" ID="valExist" ValidationGroup="new" ControlToValidate="txtNewCategory"
                                ErrorMessage="<%$Resources:labels,categoryAlreadyExists %>" Display="dynamic" />
                            <asp:RequiredFieldValidator runat="Server" ValidationGroup="new" ControlToValidate="txtNewCategory"
                                ErrorMessage="<%$Resources:labels,enterValidName %>" Display="Dynamic" />
                        </li>
                        <li>
                            <asp:Label ID="lblNewNewDescription" runat="server" AssociatedControlID="txtNewNewDescription"
                                Text="<%$Resources:labels,description %>" /><br />
                            <asp:TextBox runat="Server" ID="txtNewNewDescription" Width="400" TextMode="MultiLine"
                                Rows="4" />
                        </li>
                        <li>
                            <asp:Label ID="lblNewParent" runat="server" AssociatedControlID="ddlNewParent" Text="<%$Resources:labels,parent %>" /><br />
                            <asp:DropDownList ID="ddlNewParent" Width="200" runat="server" />
                        </li>
                    </ul>
                    <asp:Button runat="server" ID="btnAdd" ValidationGroup="new" CssClass="btn primary" OnClientClick="colorboxDialogSubmitClicked('new', 'frmAddNew');" Text="<%$Resources:labels, addNewCategory %>" /> <%=Resources.labels.or %> <a href="#" onclick="closeOverlay();"> <%=Resources.labels.cancel %></a>
                </div>
            </div>

            <asp:GridView runat="server" ID="grid" BorderColor="#f8f8f8" BorderStyle="solid"
                BorderWidth="1px" RowStyle-BorderWidth="0" RowStyle-BorderStyle="None" GridLines="None"
                Width="100%" AlternatingRowStyle-BackColor="#f8f8f8" AlternatingRowStyle-BorderColor="#f8f8f8"
                HeaderStyle-BackColor="#F1F1F1" CellPadding="3" AutoGenerateColumns="False" AutoGenerateDeleteButton="True"
                AutoGenerateEditButton="True">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ Resources:labels, name %>">
                        <ItemTemplate>
                            <%# Server.HtmlEncode(Eval("title").ToString()) %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtTitle" Text='<%# Eval("title") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ Resources:labels, description %>">
                        <ItemTemplate>
                            <%# Server.HtmlEncode(Eval("description").ToString())%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" MaxLength="255" ID="txtDescription" Text='<%# Eval("description") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ Resources:labels, parent %>">
                        <ItemTemplate>
                            <%# GetParentTitle(Container.DataItem) %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlParent" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ Resources:labels, posts %>">
                        <ItemTemplate>
                            <%# ((BlogEngine.Core.Category)Container.DataItem).Posts.Count %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
