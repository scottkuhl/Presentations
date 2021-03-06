<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Admin.Users.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <script type="text/javascript">

        function AddRole() {
            var txtUser = $('#txtUserName').val();

            if (txtUser.length == 0) {
                $('#txtUserNameReq').removeClass('hidden');
                $('#txtUserName').focus().select();
                return false;
            }
            else {
                $('#txtUserNameReq').addClass('hidden');
                var dto = { "roleName": txtUser };

                $.ajax({
                    url: "../../api/RoleService.asmx/Add",
                    data: JSON.stringify(dto),
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        var rt = result.d;
                        if (rt.Success) {
                            LoadRoles();
                            ShowStatus("success", rt.Message);
                        }
                        else {
                            ShowStatus("warning", rt.Message);
                        }
                    }
                });
            }
            closeOverlay();
            return false;
        }

        function OnAdminDataSaved() {
            LoadRoles();
        }
    </script>
    <script type="text/javascript" src="../jquery.colorbox.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addNew").colorbox({ width: "300px", inline: true, href: "#frmAddNew" });
        });

        function closeOverlay() {
            $.colorbox.close();
        }
    </script>

	<div class="content-box-outer">
		<div class="content-box-right">
            <ul>
			    <li><a href="Users.aspx"><%=Resources.labels.users %></a></li>
			    <li class="content-box-selected"><a href="Roles.aspx" class="selected"><%=Resources.labels.roles %></a></li>
            </ul>
		</div>
		<div class="content-box-left">
            <h1><%=Resources.labels.roles %><a href="#" class="addNew"><%=Resources.labels.addNewRole %></a></h1>
            <div  style="display:none;">
            <div id="frmAddNew" class="overlaypanel">
                <h2><%=Resources.labels.addNewRole %></h2>
		        <label for="txtUserName" class="lbl"><%=Resources.labels.name %></label>
		        <input type="text" id="txtUserName" class="txt200" />
		        <span id="txtUserNameReq" class="req hidden">*</span>
		        <br/><br/>
		        <input type="submit" class="btn primary rounded" value="<%=Resources.labels.save %>" onclick="return AddRole();" />
		        <%=Resources.labels.or %> <a href="#" onclick="closeOverlay();"><%=Resources.labels.cancel %></a>
	        </div>
            </div>
            <div id="Container"></div>
		</div>
	</div>
        <script type="text/javascript">
            LoadRoles();
    </script>
</asp:Content>
