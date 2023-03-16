<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="DashTrack.Register" %>

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
			Register For DashTrack
		</div>
            

        <div class="input_wrap">
	<label for="input_text">Name</label>
		<div class="input_field">
			<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</div>
</div>

<div class="input_wrap">
	<label for="input_text">User Name</label>
		<div class="input_field">
			<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</div>
</div>

<div class="input_wrap">
	<label for="input_text">Password</label>
		<div class="input_field">
			<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</div>
</div>

<div class="input_wrap">
	<label for="input_text">Email</label>
		<div class="input_field">
			<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
</div>
</div>

<div class="input_wrap">
	<label for="input_text">Phone</label>
		<div class="input_field">
			<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
</div>
</div>

<div class="input_wrap">
	<label for="input_text">Security Question</label>
		<div class="input_field">
			<asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Please select a question</asp:ListItem>
                            <asp:ListItem>What is the name of your first pet? </asp:ListItem>
                            <asp:ListItem>What city you were born in?</asp:ListItem>
                            <asp:ListItem>What is your mother&#39;s maden name?</asp:ListItem>
                        </asp:DropDownList>
</div>
</div>

<div class="input_wrap">
	<label for="input_text">Security Answer</label>
		<div class="input_field">
			<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
</div>
</div>




                    <div class="input_wrap">
                        <asp:Button ID="Button1" runat="server" Text="Register" />
                    </div>
                    <td>&nbsp;</td>
                </tr>
                
                    <div class="input_wrap">
                        <asp:LinkButton ID="LinkButton1" runat="server">Back To Login Page</asp:LinkButton>
                    </div>
                    <td>&nbsp;</td>
               
    </form>
    </body>
</html>
