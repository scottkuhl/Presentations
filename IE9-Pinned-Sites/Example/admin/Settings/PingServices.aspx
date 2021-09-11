﻿<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true"
    CodeFile="PingServices.aspx.cs" Inherits="admin_Pages_PingServices" Title="Ping services" %>
<%@ Register src="Menu.ascx" tagname="TabMenu" tagprefix="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
	<div class="content-box-outer">
		<div class="content-box-right">
			<menu:TabMenu ID="TabMenu1" runat="server" />
		</div>
		<div class="content-box-left">
            <h1><%=Resources.labels.pingService %></h1>
            <ul class="fl">
                <li>
                    <label for="<%=txtNewCategory.ClientID %>" class="lbl"><%=Resources.labels.pingServiceUrl %></label>
                    <asp:TextBox runat="Server" ID="txtNewCategory" Width="300" MaxLength="255" />
                    <asp:Button runat="server" ID="btnAdd" ValidationGroup="new" CssClass="btn" Text="<%$Resources:labels, add %>" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ValidationGroup="new"
                        ControlToValidate="txtNewCategory" ErrorMessage="<%$Resources:labels,specifyPingService %>" />
                    <br />
                </li>
            </ul>
            <asp:GridView runat="server" ID="grid" BorderColor="#f8f8f8" BorderStyle="solid"
                BorderWidth="1px" RowStyle-BorderWidth="0" RowStyle-BorderStyle="None" GridLines="None"
                Width="100%" AlternatingRowStyle-BackColor="#f8f8f8" AlternatingRowStyle-BorderColor="#f8f8f8"
                HeaderStyle-BackColor="#F1F1F1" CellPadding="3" UseAccessibleHeader="true" AutoGenerateColumns="false"
                AutoGenerateDeleteButton="true" AutoGenerateEditButton="true">
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="<%$ Resources:labels, name %>">
                        <ItemTemplate>
                            <%# Eval("value") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="txtName" Width="100%" MaxLength="255" Text='<%# Eval("value") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
