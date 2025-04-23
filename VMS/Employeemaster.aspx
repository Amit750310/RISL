<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Employeemaster.aspx.cs"
    Inherits="vms.Employeemaster" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;
            return true;
        
        function Validate() {
            if (document.getElementById('<%=txtempcode.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtempcode.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtempcode.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtempcode.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=drdrollname1.ClientID %>').selectedIndex == 0) {
                document.getElementById('<%=drdrollname1.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=drdrollname1.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=drdrollname1.ClientID %>').style.border = '1px solid #0C82DF'; }

          

            if (document.getElementById('<%=ddlhilevel.ClientID %>').selectedIndex == 0) {
                document.getElementById('<%=ddlhilevel.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=ddlhilevel.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=ddlhilevel.ClientID %>').style.border = '1px solid #0C82DF'; }

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


                   if (document.getElementById('<%=txtdoj.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtdoj.ClientID %>').style.border = '1px solid red';
                  document.getElementById('<%=txtdoj.ClientID %>').focus();
                  return false;
              } else { document.getElementById('<%=txtdoj.ClientID %>').style.border = '1px solid #0C82DF'; }

              if (document.getElementById('<%=txtDesignation.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtDesignation.ClientID %>').style.border = '1px solid red';
                 document.getElementById('<%=txtDesignation.ClientID %>').focus();
                 return false;
             } else { document.getElementById('<%=txtDesignation.ClientID %>').style.border = '1px solid #0C82DF'; }

             if (document.getElementById('<%=txtpassword.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtpassword.ClientID %>').style.border = '1px solid red';
                 document.getElementById('<%=txtpassword.ClientID %>').focus();
                 return false;
             } else { document.getElementById('<%=txtpassword.ClientID %>').style.border = '1px solid #0C82DF'; }

             if (document.getElementById('<%=txtdob.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtdob.ClientID %>').style.border = '1px solid red';
                 document.getElementById('<%=txtdob.ClientID %>').focus();
                 return false;
             } else { document.getElementById('<%=txtdob.ClientID %>').style.border = '1px solid #0C82DF'; }

             if (document.getElementById('<%=txtaddress.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtaddress.ClientID %>').style.border = '1px solid red';
                 document.getElementById('<%=txtaddress.ClientID %>').focus();
                 return false;
             } else { document.getElementById('<%=txtaddress.ClientID %>').style.border = '1px solid #0C82DF'; }

             return true;
         }
    </script>
    <div class="page_header">
    </div>
    <div class="main-content">
        <div class="form form-horizontal">
            <div class="panel">
                <div class="panel-body">
                    <!--form-heading-->
                    <div class="form-heading">
                        <asp:HiddenField ID="hfid" runat="server" />
                        User Master
                    </div>
                    <div id="divmsg1" class="alert alert-success" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divmsg2" class="alert alert-error" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg2" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divfillgrid" runat="server" class="form form-horizontal" style="display: block;">
                        <!--toolbar-->
                        <div class="btn-group pull-right">
                            <asp:Button ID="btnAddrole" runat="server" Text="Add" CssClass=" btn-danger" OnClick="btnAddrole_Click" />
                        </div>
                        <div class="clearfix">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 450px" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                               
                                                    <th>Name
                                                    </th>
                                               
                                                    <th>Mobile No
                                                    </th>
                                                    <th>Mail ID
                                                    </th>
                                                    
                                                    <th>Action
                                                    </th>

<%--                                                    <th>Emp Code
                                                    </th>
                                                    <th>Name
                                                    </th>
                                                    <th>Designation
                                                    </th>
                                                    <th>Mobile No
                                                    </th>
                                                    <th>Mail ID
                                                    </th>
                                                    <th>Date of Join
                                                    </th>
                                                    <th>Action
                                                    </th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                           
                                            <td>
                                                <asp:Label ID="lblfirstname" runat="server" Text='<%#Eval("First_Name") %>'></asp:Label>
                                                &nbsp;<asp:Label ID="lblsecondname" runat="server" Text='<%#Eval("Last_Name") %>'></asp:Label>
                                                <asp:Label ID="lblRolecode" runat="server" Text='<%#Eval("emp_Id") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <%#Eval("mobile")%>
                                            </td>
                                            <td>
                                                <%#Eval("Email_Id")%>
                                            </td>


                                            <%--<td>
                                                <%#Eval("Employee_code")%>
                                            </td>
                                            

                                            <td>
                                                <%#Eval("Designation")%>
                                            </td>
                                            
                                            
                                            <td>
                                                <%#Eval("DOJ")%>
                                            </td>--%>
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
                                                    runat="server" CommandName="Edit" />
                                              
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody></table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <!--form-heading-->
                    <div id="divsavedata" runat="server" class="form form-horizontal" style="display: none;">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                            <asp:Button ID="imgbtnVrole" runat="server" Text="View " CssClass="  btn-danger"
                                OnClick="imgbtnVbatch_Click" />
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <div class="col-sm-3"  style="display:none;">
                                <label class="control-label">
                                    Emp Code <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtempcode" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">
                                    Role Name <span class="red-info">* </span>:</label>
                                <div class="input-group">
                                    <span class="input-group-addon bg"><i class="ion-plus"></i></span>
                                    <asp:DropDownList ID="drdrollname1" runat="server" CssClass="form-control" AppendDataBoundItems="True">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /input-group -->
                            </div>
                          
                            <div class="col-sm-3"  style="display:none;">
                                <label class="control-label">
                                    Level <span class="red-info">* </span>:</label>
                                <div class="input-group">
                                    <span class="input-group-addon bg"><i class="ion-plus"></i></span>
                                    <asp:DropDownList ID="ddlhilevel" runat="server" CssClass="form-control" AppendDataBoundItems="True" >
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /input-group -->
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-4">
                                <label class="control-label">
                                    First Name <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Last Name <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Mobile No <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtmobilno" runat="server" CssClass="form-control" MaxLength="10" onkeypress="javascript:return isNumber (event)">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Mail Id <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtmailid" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4" style="display:none;">
                                <label class="control-label">
                                    Date of Join <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtdoj" runat="server" data-provide="datepicker" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4" style="display:none;" >
                                <label class="control-label" >
                                    Gender <span class="red-info">* </span>:</label>
                                <asp:DropDownList ID="ddlgender" runat="server" CssClass="form-control" Visible="false">
                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4" style="display:none;">
                                <label class="control-label" >
                                    Designation <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtDesignation" runat="server" AutoCompleteType="disabled" CssClass="form-control" >
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Password :</label>
                                <asp:TextBox TextMode="password" ID="txtpassword" runat="server" AutoCompleteType="disabled" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4" style="display:none;">
                                <label class="control-label">
                                    Date of birth <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtdob" runat="server" CssClass="form-control" data-provide="datepicker" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group"style="display:none;">
                            <div class="col-sm-12">
                                <label class="control-label">
                                    Address <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" CssClass="form-control" >
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-8 col-sm-2">
                                <asp:Button ID="btnproced" runat="server" class="btn btn-success" Text="Save" OnClick="btnproced_Click" OnClientClick="return Validate();" />
                                <asp:Button ID="imgbtnupdate" runat="server" class="btn btn-success" Text="Update" OnClientClick="return Validate();"
                                    OnClick="imgbtnupdate_Click" />
                                <asp:Button ID="btnrest" runat="server" class="btn btn-warning" Text="RESET" OnClick="btnrest_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
