<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Location_Master.aspx.cs" Inherits="vms.Location_Master" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;
            return true;
        }
       <%-- function Validate() {
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
         }--%>
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
                        Location Master
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
                                                    <th>Department</th>
                                                    <th>Display_Name</th>
                                                    <th>Address </th>
                                                    <th>District</th>
                                                    <th>City</th>
                                                    <th>PINCode</th>
                                                    <th>Action</th>
                                                   <%-- <th>Location <br />Name</th>--%>
                                                    <%--<th>Address1</th>
                                                    <th>State<br /> Name </th>--%>
                                                    <%-- <th>Contact<br />Person</th>
                                                     <th>Contact<br />Number</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("Department")%>
                                            </td>
                                            <td>
                                                <%#Eval("Display_Name")%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <%#Eval("DistrictName")%>
                                            </td>
                                            <td>
                                                <%#Eval("City")%>
                                            </td>
                                             <td>
                                                <%#Eval("PINCode")%>
                                            </td>
                                            
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
                            <div class="col-sm-4">
                                <label class="control-label">
                                    State <span class="red-info">* </span>:</label>
                                <asp:DropDownList ID="DrdState" runat="server" CssClass="form-control"  AutoPostBack="true"  OnSelectedIndexChanged="DrdState_SelectedIndexChanged" AppendDataBoundItems="True">
                                 </asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    District <span class="red-info">* </span>:</label>
                                <asp:DropDownList ID="DrdDistict" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DrdDistict_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            
                             <div class="col-sm-4">
                                <label class="control-label">
                                    Block <span class="red-info">* </span>:</label>
                                <asp:DropdownList ID="drdblock" runat="server" CssClass="form-control">
                                </asp:DropdownList>
                            </div>
                           
                        </div>
                        <div class="form-group">
                            
                             <div class="col-sm-4">
                                <label class="control-label">
                                    City <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtcITY" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            
                           
                            <div class="col-sm-4">
                                <label class="control-label">
                                    PINCode <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtPINCode" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                             <div class="col-sm-4">
                                <label class="control-label">
                                    Address <span class="red-info">* </span>:</label>
                                <div class="input-group">
                                    <span class="input-group-addon bg"><i class="ion-plus"></i></span>
                                     <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine">
                                </asp:TextBox>
                                </div>
                                <!-- /input-group -->
                            </div>
                           
                        </div>
                        <div class="form-group">
                             <div class="col-sm-6">
                                <label class="control-label">
                                    Department <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtDepartment" runat="server"  CssClass="form-control">
                                </asp:TextBox>
                            </div>
                             <div class="col-sm-6">
                                <label class="control-label">
                                    Display Name <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtDisplay" runat="server"  CssClass="form-control">
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