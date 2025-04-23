<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="vms.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" class="no-js">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />
    <!--320-->
    <title>VMS || Home</title>
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/material.css">
    <link rel="stylesheet" type="text/css" href="assets/css/signin.css">
    <link rel="stylesheet" type="text/css" href="assets/css/style.css">
    <script type="text/javascript">
        function LoginCheck() {

            if (document.getElementById('<%=txtUsername.ClientID %>').value == "") {
                //alert("Please Enter Email Address");
                document.getElementById('<%=txtUsername.ClientID %>').style.border = '1px solid red';
                return false;
            }
            if (document.getElementById('<%=txtPassword.ClientID %>').value == "") {
                //alert("Please Enter Email Address");
                document.getElementById('<%=txtPassword.ClientID %>').style.border = '1px solid red';
                return false;
            }
            return true;
        }
     
    </script>
   
</head>
<body>
    <div class="signin_wrapper">
        <form id="Form1" class="col-md-12 col-sm-12 col-xs-12" runat="server">
            <div class="row">
                <div class="right_block">
                    <div class="row">
                        <div class="col-sm-12 signup-logo">
                            <%--<img src="assets/images/sisl_4.png" />--%>
                        </div>
                        <h1 class="signup-heading-main">Welcome to RISL Asset MANAGEMENT SYSTEM</h1>
                        <h2 class="signup-heading">Sign in</h2>
                          <div class="row">
                            <div class="input-field col-md-12 col-sm-12 col-xs-12">
                                <i class="ion-ios-contact prefix"></i>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="validate"></asp:TextBox>
                                <label for="icon_prefix-2" style="margin-top: -30px;">
                                    Username</label>
                            </div>
                            <div class="input-field col-md-12 col-sm-12 col-xs-12">
                                <i class="ion-key prefix"></i>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="validate" TextMode="Password"
                                    autocomplete="off"></asp:TextBox>
                                <label for="icon_prefix-3" style="margin-top: -30px;">
                                    Password</label>
                            </div>
                        </div>
                        <div class="bottom_info">
                            <a href="#" class="pull-right" data-toggle="modal" data-target="#forgot">forgot password?</a>
                        </div>
                        <div class="clearfix">
                        </div>
                        <asp:Button ID="btnLogin" runat="server" CausesValidation="false" Text="Sign In"
                            CssClass="btn btn-primary btn-block" OnClientClick="return LoginCheck();" OnClick="btnLogin_Click1" />
                    </div>

                </div>
                <!-- right_block -->
            </div>
            <!-- row -->
            <!-- Modal -->
            <div class="modal fade" id="forgot" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true" style="">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">
                                <i class="ion-android-settings"></i>Forgot password</h4>
                        </div>
                        <div class="modal-body">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email here"></asp:TextBox>
                                <h6 class="note">
                                    <i class="ion-android-mail"></i>Password will be sent to your email</h6>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-red" data-dismiss="modal">
                                Close</button>
                            <asp:Button ID="btnsend" runat="server" Text="Send" OnClick="btnFSubmit_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- modal -->
        </form>
    </div>
    <!-- wrapper -->
    <!-- jQuery -->
    <script src="assets/js/jquery.js"></script>
    <!-- Bootstrap JavaScript -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- custom scrollbar plugin -->
    <!-- Compiled and minified JavaScript -->
    <script src="assets/js/materialize.js"></script>
</body>
</html>
