<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckIn.aspx.cs" Inherits="vms.CheckIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" class="no-js">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />
    <!--320-->
    <title>VMS || CheckIN</title>
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/material.css">
    <link rel="stylesheet" type="text/css" href="assets/css/signin.css">
    <link rel="stylesheet" type="text/css" href="assets/css/style.css">

    <script type="text/javascript">
        
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;
            return true;
        }
        function Validate() {

            if (document.getElementById('<%=txtfirstname.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtfirstname.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtfirstname.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtfirstname.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtlastname.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtlastname.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtlastname.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtlastname.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtmobilno.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtmobilno.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtmobilno.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtmobilno.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtmailid.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtmailid.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtmailid.ClientID %>').focus();
                return false;
            } else {
                document.getElementById('<%=txtmailid.ClientID %>').style.border = '1px solid #0C82DF';
                var Email = document.getElementById('<%=txtmailid.ClientID %>').value;
                var emailPat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                var EmailmatchArray = Email.match(emailPat);
                if (EmailmatchArray == null) {
                    alert("Your email address seems incorrect. Please try again.");
                    return false;
                }
            }



            if (document.getElementById('<%=txtCompany.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtCompany.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtCompany.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtCompany.ClientID %>').style.border = '1px solid #0C82DF'; }


           if (document.getElementById('<%=txtwhomtomeet.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtwhomtomeet.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtwhomtomeet.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtwhomtomeet.ClientID %>').style.border = '1px solid #0C82DF'; }

            return true;
        }


    </script>
     <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            width: 300px;
            border: 1px solid #ccc;
        }
    </style>
</head>
<body>
    <div class="checkIN">
        <form id="Form1" class="col-md-12 col-sm-12 col-xs-12" runat="server">
            
            <div class="row">
                <div style="background-color: currentcolor;margin: 10% 10% 10% 10%;padding-left: 0%;">
                <div class="center_block">

                    <div class="row" style="padding-top: 2%">
                        <div class="form-group">
                            <div class="col-sm-offset-1 col-sm-2">
                                <div class="col-sm-2 signup-logo">
                                    <img src="assets/images/sisl_4.png" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="form-group">
                            <div class="col-sm-offset-1 col-sm-12">
                                <div class="col-sm-12">
<h3 class="signup-heading-main" style="color: white;">Hey There! </h3>
                                     </div> <div class="col-sm-12">
<h3 class="signup-heading-main" style="color: white;">Welcome to SISL Infotech.</h3>
 </div> <div class="col-sm-12">
<h3 class="signup-heading-main" style="color: white;">Please take a moment to introduce yourself to us </h3>


                                </div>
                                <div class="col-sm-12" style="padding-bottom: 2%">

                                    <asp:Button ID="btncheckin" runat="server" class="btn btn-success" style="background-color: #fb5d5d;  " Text="CHECK IN" OnClick="btncheckin_Click"/>
                                </div>
                               
                            </div>
                        </div>
                    </div>

                </div>
                    </div>
            </div>
            <!-- right_block -->
    </div>
    <!-- row -->
    <!-- Modal -->
    <asp:Panel ID="pnlcheckin" runat="server" Visible="false">
        <div class="modal fade in" id="CHECKIN" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true" style="display: block; padding-left: 17px;">
            <div class="modal-dialog" style="width:80%">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton CssClass="close" data-dismiss="modal" aria-label="Close" ID="lnkcheckinclose" runat="server" OnClick="lnkcheckinclose_Click">
                                <span aria-hidden="true">&times;</span></asp:LinkButton>
                        <h4 class="modal-title" id="myModalLabel">
                            <i class="ion-android-settings"></i>Vendor Information</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-4">
                                <label class="control-label">
                                    First Name <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control" Style="border: 1px solid black;">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Last Name <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control" Style="border: 1px solid black;">
                                </asp:TextBox>
                            </div>
                             <div class="col-sm-4">
                                <label class="control-label">
                                    Mobile No <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtmobilno" runat="server" CssClass="form-control" MaxLength="10" onkeypress="javascript:return isNumber (event)" Style="border: 1px solid black;">
                                </asp:TextBox>
                            </div>

                        </div>
                        <div class="form-group">
                             <div class="col-sm-4">
                                <label class="control-label">
                                    Company <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtCompany" runat="server" AutoCompleteType="disabled" CssClass="form-control" Style="border: 1px solid black;">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Mail Id <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtmailid" runat="server" CssClass="form-control" Style="border: 1px solid black;">
                                </asp:TextBox>
                            </div>
                            
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Gender <span class="red-info">* </span>:</label>
                                <asp:DropDownList ID="ddlgender" runat="server" CssClass="form-control" Style="border: 1px solid black;">
                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                       
                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Address :</label>
                                <asp:TextBox ID="txtaddress" runat="server"  CssClass="form-control" Style="border: 1px solid black;">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="control-label">
                                    whom to meet :<span class="red-info">* </span></label>
                                <asp:TextBox ID="txtwhomtomeet" runat="server"  CssClass="form-control" Style="border: 1px solid black;">
                                </asp:TextBox>
                            </div>
                        </div>
  <%--
                         <div class="form-group">
                           <div class="col-sm-4">
                                 <label class="control-label">
                                    Live Camera :</label>
                                <input type="button" id="btnCapture" value="Capture" />
                               <div id="webcam"></div>
                              
                               </div>
                              <div class="col-sm-4">
                                  <label class="control-label">
                                    Captured Picture :</label>
                                   <input type="button" id="btnUpload" value="Upload" disabled = "disabled" />
                                   <img id = "imgCapture" />
                               
                                  
                               </div>
                             <div class="col-sm-4">
                                 </div>
                        </div>


  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="cameraScript/WebCam.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            Webcam.set({
                width: 320,
                height: 240,
                image_format: 'jpeg',
                jpeg_quality: 90
            });
            Webcam.attach('#webcam');
            $("#btnCapture").click(function () {
                Webcam.snap(function (data_uri) {
                    $("#imgCapture")[0].src = data_uri;
                    $("#btnUpload").removeAttr("disabled");
                });
            });
            $("#btnUpload").click(function () {
               
                $.ajax({
                    type: "POST",
                    url: "CheckIn.aspx/SaveCapturedImage",
                    data: "{data: '" + $("#imgCapture")[0].src + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) { }
                });
            });
        });
    </script>--%>

                    </div>
                    <div class="modal-footer">
                        <div class="form-group">
                            <div class="col-sm-4">
                            </div>
                            <div class="col-sm-4">
                            </div>
                            <div class="col-sm-2">
                           
                                <asp:Button ID="btnproced" runat="server" class="btn btn-success" Text="Save" OnClientClick="return Validate();" OnClick="btnproced_Click" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btncancel" runat="server" CssClass="btn btn-red" data-dismiss="modal" OnClick="btncancel_Click" Text="Cancel" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!-- modal -->
    <!-- Modal -->

    <asp:Panel ID="pnlpop" runat="server" Visible="false">

        <div class="modal fade in" id="CHECKIN_Saved" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true" style="display: block; padding-left: 17px;">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">

                        <asp:LinkButton CssClass="close" data-dismiss="modal" aria-label="Close" ID="btnpopupclose" runat="server" OnClick="btnpopupclose_Click">
                                <span aria-hidden="true">&times;</span></asp:LinkButton>
                        <h4 class="modal-title" id="myModalLabel">
                            <i class="ion-android-settings"></i>Vendor Information</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                   Thank you for visiting us!.</label>
                            </div>
                        </div>




                    </div>
                    <div class="modal-footer">
                        <div class="form-group">
                            <div class="col-sm-4">
                            </div>
                            <div class="col-sm-3">
                            </div>
                            <div class="col-sm-3">
                                <asp:Button ID="btnrecheckin" runat="server" CssClass="btn btn-success" data-dismiss="modal" OnClick="btnrecheckin_Click" Text="RE CHECK IN" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnpopcancel" runat="server" CssClass="btn btn-red" data-dismiss="modal" OnClick="btnpopcancel_Click" Text="Cancel"/>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
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
