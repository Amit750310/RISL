<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="VendorList.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="vms.VendorList" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;
            return true;
        }
        function Validate() {

            if (document.getElementById('<%=txtVendorName.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtVendorName.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtVendorName.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtVendorName.ClientID %>').style.border = '1px solid #0C82DF'; }



            if (document.getElementById('<%=txtmobilno.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtmobilno.ClientID %>').style.border = '1px solid red';
                 document.getElementById('<%=txtmobilno.ClientID %>').focus();
                 return false;
             } else { document.getElementById('<%=txtmobilno.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtEmail.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtEmail.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtEmail.ClientID %>').focus();
                return false;
            } else {
                document.getElementById('<%=txtEmail.ClientID %>').style.border = '1px solid #0C82DF';
                var Email = document.getElementById('<%=txtEmail.ClientID %>').value;
                var emailPat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                var EmailmatchArray = Email.match(emailPat);
                if (EmailmatchArray == null) {
                    alert("Your email address seems incorrect. Please try again.");
                    return false;
                }
            }



            if (document.getElementById('<%=txtPanNo.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtPanNo.ClientID %>').style.border = '1px solid red';
                  document.getElementById('<%=txtPanNo.ClientID %>').focus();
                  return false;
              } else { document.getElementById('<%=txtPanNo.ClientID %>').style.border = '1px solid #0C82DF'; }


            if (document.getElementById('<%=txtContactPersonName.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtContactPersonName.ClientID %>').style.border = '1px solid red';
                 document.getElementById('<%=txtContactPersonName.ClientID %>').focus();
                 return false;
             } else { document.getElementById('<%=txtContactPersonName.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtGSTRegistrationNo.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtGSTRegistrationNo.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtGSTRegistrationNo.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtGSTRegistrationNo.ClientID %>').style.border = '1px solid #0C82DF'; }


            return true;
        }
    </script>
    <div class="page_header">
    </div>
    <div class="main-content">
        <div class="panel">
            <div class="panel-body">
                <div class="form form-horizontal">
                    <div class="form-heading">
                        Vendor List
                                  <asp:HiddenField ID="hfid" runat="server" />
                    </div>
                    <div class="form-group">

                        <div class="col-sm-2">
                            <label class="control-label" style="font-weight: bold;">Vendor Name :</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtCompanySearch" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-2">
                            <label class="control-label" style="font-weight: bold;">From Date :</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" data-provide="datepicker"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-2">
                            <label class="control-label" style="font-weight: bold;">Todate :</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" data-provide="datepicker"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-sm-2">
                            <label class="control-label"></label>
                            <div class="input-group">
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-success"
                                    Text="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <label class="control-label"></label>
                            <div class="input-group">
                                <asp:Button ID="btnexport" runat="server" class="btn btn-red" Text="Export to Excel"
                                    OnClick="btnexport_Click" Visible="false"/>
                            </div>
                        </div>

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
                                                    <th>vendor Id
                                                    </th>
                                                    <th>vendor Name
                                                    </th>
                                                    <th>Mobile No
                                                    </th>
                                                    <th>Email
                                                    </th>

                                                    <th>PanNo
                                                    </th>
                                                    <th>Contact Person Name
                                                    </th>
                                                    <th>GSTRegistrationNo
                                                    </th>
                                                    <th>status
                                                    </th>
                                                    <th>Added</th>
                                                    <th>Action
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("Vendor_Id")%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblVendorName" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>

                                                <asp:Label ID="lblvendor_Id" runat="server" Text='<%#Eval("vendor_Id") %>' Visible="false"></asp:Label>
                                            </td>

                                            <td>
                                                <%#Eval("MobileNo")%>
                                            </td>
                                            <td>
                                                <%#Eval("Email")%>
                                            </td>

                                            <td>
                                                <%#Eval("PanNo")%>
                                            </td>
                                            <td>
                                                <%#Eval("ContactPersonName")%>
                                            </td>
                                            <td>
                                                <%#Eval("GSTRegistrationNo")%>
                                            </td>
                                            <td>
                                                <%#Eval("status")%>
                                            </td>
                                            <td>
                                                <%#Eval("Added")%>
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
                                    Vendor Name <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtVendorName" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Mobile No <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtmobilno" runat="server" CssClass="form-control" MaxLength="10" onkeypress="javascript:return isNumber (event)">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Email Id <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>

                        </div>
                        <div class="form-group">



                            <div class="col-sm-4">
                                <label class="control-label">
                                    Pan No <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtPanNo" runat="server" AutoCompleteType="disabled" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Contact Person Name <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtContactPersonName" runat="server" AutoCompleteType="disabled" CssClass="form-control">
                                </asp:TextBox>

                            </div>

                            <div class="col-sm-4">
                                <label class="control-label">
                                    GST Registration No <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtGSTRegistrationNo" runat="server" AutoCompleteType="disabled" CssClass="form-control">
                                </asp:TextBox>
                            </div>

                        </div>
                        <div class="form-group">

                            <div class="col-sm-12">
                                <asp:Repeater ID="dtMenumaster" runat="server" 
                                    OnItemDataBound="dtMenumaster_ItemDataBound" >
                                     <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>category and Product
                                                    </th>
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                        <asp:CheckBox ID="chkcategoryname" runat="server" 
                                            Text='<%#Eval("categoryname") %>' Width="90%" OnCheckedChanged="chkcategoryname_CheckedChanged" AutoPostBack="true"
                                            style="background-color:#6bc2f6;margin-left:5%;"/>
                                        <asp:Label ID="lblcategory_id" runat="server" Text='<%#Eval("category_id") %>' Visible="false"></asp:Label>
                                        <asp:CheckBoxList ID="chksubcategory" runat="server" RepeatColumns="4"  Width="80%" style="background-color:yellow;text-align:center;margin-left:10%;" Enabled="false">
                                        </asp:CheckBoxList>
                                   

                                        
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody></table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-sm-offset-8 col-sm-4">
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


