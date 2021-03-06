<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Admin.Users.Users" Title="Create new user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <script type="text/javascript">
        function AddUser(obj) {
            var txtUser = $('#txtUserName').val();
            var txtPwd = $('#txtPassword').val();
            var txtPwd2 = $('#txtPassword2').val();
            var txtEmail = $('#txtEmail').val();

            $('#txtUserNameReq').addClass('hidden');
            $('#txtPasswordReq').addClass('hidden');
            $('#txtPasswordMatch').addClass('hidden');
            $('#txtEmailReq').addClass('hidden');

            var roles = new Array();
            var cnt = 0;
            $.each($('.chkRole:checked'), function (i, v) {
                roles[cnt] = v.id;
                cnt++;
            });

            if (txtUser.length == 0) {
                $('#txtUserNameReq').removeClass('hidden');
                $('#txtUserName').focus().select();
                return false;
            }
            else if (txtPwd.length == 0 || txtPwd2.length == 0) {
                $('#txtPasswordReq').removeClass('hidden');
                $('#txtPassword').focus().select();
                return false;
            }
            else if (txtPwd != txtPwd2) {
                $('#txtPasswordMatch').removeClass('hidden');
                $('#txtPassword').focus().select();
                return false;
            }
            else if (txtEmail.length == 0) {
                $('#txtEmailReq').removeClass('hidden');
                $('#txtEmail').focus().select();
                return false;
            }
            else {
                var dto = { "user": txtUser, "pwd": txtPwd, "email": txtEmail, "roles": roles };
                $.ajax({
                    url: "../../api/UserService.asmx/Add",
                    data: JSON.stringify(dto),
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        var rt = result.d;
                        if (rt.Success) {
                            LoadUsers();
                            ShowStatus("success", rt.Message);
                        }
                        else {
                            ShowStatus("warning", rt.Message);
                        }
                    }
                });
            }
            $.colorbox.close();
            return false;
        }

        function OnAdminDataSaved() {
            LoadUsers();
        }
    </script>

    <script type="text/javascript" src="../jquery.colorbox.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".addNew").colorbox({ width: "550px", inline: true, href: "#frmAddNew" });
        });

        function closeOverlay() {
            $.colorbox.close();
        }
    </script>
	<div class="content-box-outer">
		<div class="content-box-right">
            <ul>
			    <li class="content-box-selected"><a href="Users.aspx"><%=Resources.labels.users %></a></li>
			    <li><a href="Roles.aspx" class="selected"><%=Resources.labels.roles %></a></li>
            </ul>
		</div>
		<div class="content-box-left">
            <h1><%=Resources.labels.users %><a href="#" class="addNew"><%=Resources.labels.addNewUser %></a></h1>
            <div style="display:none;">
            <div id="frmAddNew" class="overlaypanel" >
                <h2><%=Resources.labels.addNewUser %></h2>
                <table class="tblForm">
                    <tr>
                        <td>
				            <label for="txtUserName" class="lbl"><%=Resources.labels.name %></label>
				            <input type="text" id="txtUserName" class="txt200"/>
				            <span id="txtUserNameReq" class="req hidden">*</span>
				        </td>
				        <td>
				            <label for="txtEmail" class="lbl"><%=Resources.labels.email %></label>
				            <input type="text" id="txtEmail" class="txt200"/>
				            <span id= "txtEmailReq" class="req hidden">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
				                <label for="txtPassword" class="lbl"><%=Resources.labels.password %></label>
				                <input type="password" id="txtPassword" class="txt200"/>
                        </td>
                        <td>
                                <label for="txtPassword2" class="lbl"><%=Resources.labels.confirmPassword %></label>
				                <input type="password" id="txtPassword2" class="txt200"/>
				                <span  id= "txtPasswordReq" class="req hidden">*</span>
				                <span  id= "txtPasswordMatch" class="req hidden"><%=Resources.labels.passwordAndConfirmPasswordMismatch %></span>
                        </td>
                    </tr>
                </table>
                <asp:PlaceHolder ID="phNewUserRoles" runat="server">
                    <h2><%=Resources.labels.newUserRoles %></h2>
                    <div id="rolelist" style="margin:0 0 20px;"><%=RolesList%></div>
                </asp:PlaceHolder>
				<input type="submit" class="btn primary rounded" value="<%=Resources.labels.save %>" onclick="return AddUser(this);" id="btnNewUser" />
				<%=Resources.labels.or %> <a href="#" onclick="closeOverlay();"><%=Resources.labels.cancel %></a>
			</div>
            </div>
            <div id="Container"></div>
		</div>
	</div>
    <script type="text/javascript">
        LoadUsers();
    </script>
</asp:Content>
