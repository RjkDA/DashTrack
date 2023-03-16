<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ForgotPassword.aspx.vb" Inherits="DashTrack.Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/DashTrack.css" runat="server" rel="stylesheet" type="text/css" media="screen" />

    <title>DashTrack</title>
</head>

<body style='background-image: linear-gradient(to right, red , yellow)'>
 
    <form id="form1" runat="server">
        
<div class="wrapper">
	<div class="form">
		<div class="title">
			Enter New Password Twice
		</div>
		<div class="input_wrap">
				<label for="input_text">Email</label>
				<div class="input_field">
					<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
				</div>
			</div>
			<div class="input_wrap">
				<label for="input_password">New Password</label>
				<div class="input_field">
					<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
				</div>
			</div>

		<div class="input_wrap">
				<label for="input_password">New Password</label>
				<div class="input_field">
					<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
				</div>
			</div>
			<div class="input_wrap">
				<span class="error_msg">Incorrect username or password. Please try again</span>
					<asp:Button ID="Button1" runat="server" Text="Change Password" />
			</div>
		<div class="input_wrap">
                        <asp:LinkButton ID="LinkButton1" runat="server">Back To Login Page</asp:LinkButton>
                    </div>
		</form>
    </body>
</html>
