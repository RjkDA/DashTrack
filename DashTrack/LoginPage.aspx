<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginPage.aspx.vb" Inherits="DashTrack.Login_Page" %>

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
			Login To DashTrack
		</div>
		<form method="post" action="successpage.html" onsubmit="return validation();">
			<div class="input_wrap">
				<label for="input_text">Email</label>
				<div class="input_field">
					<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
				</div>
			</div>
			<div class="input_wrap">
				<label for="input_password">Password</label>
				<div class="input_field">
					<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
				</div>
			</div>
			<div class="input_wrap">
				<span class="error_msg">Incorrect username or password. Please try again</span>
				 <asp:Button ID="Button1" runat="server" Text="Login" />
				<asp:Button ID="Button2" runat="server" Text="Register" />
				<asp:Button ID="Button3" runat="server" Text="Forgot Password" />
			</div>
		</form>
	</div>
</div>

    </form>
</body>
</html>
