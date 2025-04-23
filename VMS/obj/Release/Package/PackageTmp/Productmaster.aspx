<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Productmaster.aspx.cs" Inherits="vms.Productmaster" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function ValidateSave() {
            if (document.getElementById('<%=ddlbrand.ClientID %>').selectedIndex == 0) {
                document.getElementById('<%=ddlbrand.ClientID %>').style.border = '1px solid red ';
                return false;
            } else { document.getElementById('<%=ddlbrand.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtprodcode.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtprodcode.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtprodcode.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtprodcode.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtprodname.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtprodname.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtprodname.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtprodname.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtshortdesc.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtshortdesc.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtshortdesc.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtshortdesc.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtfulldesc.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtfulldesc.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtfulldesc.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtfulldesc.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtdisplyorder.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtdisplyorder.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtdisplyorder.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtdisplyorder.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtprodgroup.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtprodgroup.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtprodgroup.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtprodgroup.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtprodtype.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtprodtype.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtprodtype.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtprodtype.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtvalidityperiod.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtvalidityperiod.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtvalidityperiod.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtvalidityperiod.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtunitprice.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtunitprice.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtunitprice.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtunitprice.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtissuance.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtissuance.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtissuance.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtissuance.ClientID %>').style.border = '1px solid #0C82DF'; }


            return true;
        }
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;

            return true;
        }
    </script>
    <div class="main-content">
        <div class="panel">
            <div class="panel-body" style="min-height: 400px">
                <div class="form form-horizontal">
                    <div class="form-heading">
                        Product  Master
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
                                                    <th>Action
                                                    </th>
                                                    <th>Brand 
                                                    </th>
                                                    <th>Product Code  </th>
                                                    <th>Product Name</th>
                                                    <th>Short Description</th>
                                                    <th>Full Description</th>
                                                    <th>Display Order</th>
                                                    <th>Product Group</th>
                                                    <th>Product Type</th>
                                                    <th>Validity Period</th>
                                                    <th>Unit Price</th>
                                                    <th>Issuance</th>
                                                    <th>SGC</th>
                                                    <th>SAN</th>
                                                    <th>Approved</th>
                                                    <th>code signer</th>
                                                    <th>Site Seal</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
                                                    runat="server" CommandName="Edit" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lblbrandname" runat="server" Text='<%#Eval("ProductBrand") %>'></asp:Label>
                                                <asp:Label ID="lblRolecode" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td><%#Eval("ProductCode")%> </td>
                                            <td><%#Eval("ProductName")%></td>
                                            <td><%#Eval("ShortDescription")%></td>
                                            <td><%#Eval("FullDescription")%></td>
                                            <td><%#Eval("DisplayOrder")%></td>
                                            <td><%#Eval("ProductGroup")%></td>
                                            <td><%#Eval("ProductType")%></td>
                                            <td><%#Eval("ValidityPeriod")%></td>
                                            <td><%#Eval("UnitPrice")%></td>
                                            <td><%#Eval("Issuance")%></td>
                                            <td><%#Eval("SGC")%></td>
                                            <td><%#Eval("SanName")%></td>
                                            <td><%#Eval("Approved")%></td>
                                            <td><%#Eval("codesigner")%> </td>
                                            <td><%#Eval("Site_Seal")%> </td>
                                            
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
                            <div class="col-sm-3">
                                <asp:HiddenField ID="hfid" runat="server" />
                                <label class="control-label">Brnad </label>
                                <div class="input-group">
                                    <span class="input-group-addon bg"><i class="ion-plus"></i></span>
                                    <asp:DropDownList ID="ddlbrand" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">Product Code </label>
                                <asp:TextBox ID="txtprodcode" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">Product Name </label>
                                <asp:TextBox ID="txtprodname" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">Short Description</label>
                                <asp:TextBox ID="txtshortdesc" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">

                            <div class="col-sm-3">
                                <label class="control-label">Full Description</label>
                                <asp:TextBox ID="txtfulldesc" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">Display Order</label>
                                <asp:TextBox ID="txtdisplyorder" runat="server" CssClass="form-control" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">Product Group</label>
                                <asp:TextBox ID="txtprodgroup" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <div class="col-sm-3">
                                <label class="control-label">Product Type</label>
                                <asp:TextBox ID="txtprodtype" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label class="control-label">Validity Period</label>
                                <asp:TextBox ID="txtvalidityperiod" runat="server" CssClass="form-control" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">Unit Price</label>
                                <asp:TextBox ID="txtunitprice" runat="server" CssClass="form-control" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">Issuance</label>
                                <asp:TextBox ID="txtissuance" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <div class="col-sm-3">
                                <label class="control-label">SGC</label>
                                <asp:RadioButtonList ID="rdsgc" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text=" Yes " Value="Yes" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text=" NO " Value="No"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label class="control-label">Approver</label>
                                <asp:RadioButtonList ID="rdApprover" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text=" Yes " Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text=" NO " Value="No" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">SanName</label>
                                <asp:RadioButtonList ID="rdSanName" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text=" Yes " Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text=" NO " Value="No" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>

                            <div class="col-sm-3">
                                <label class="control-label">Code Signer</label>
                                <asp:RadioButtonList ID="rdCodeSigner" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text=" Yes " Value="Yes"></asp:ListItem>
                                    <asp:ListItem Text=" NO " Value="No" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                             <div class="col-sm-3">
                                <label class="control-label">Site Seal</label>
                                <asp:TextBox ID="txtSite_Seal" runat="server" CssClass="form-control">
                                  
                                </asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-3">
                                <label class="control-label">San Name</label>
                                <asp:TextBox ID="txtsanname" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label">San Price</label>
                                <asp:TextBox ID="txtsanprice" runat="server" Text="0" CssClass="form-control" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                            </div>
                              <div class="col-sm-3">
                                <label class="control-label">Product Specification</label>
                                <asp:TextBox ID="txtProduct_Specification" runat="server"  CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="clearfix">
                            </div>
                            <div class="col-sm-12" style="text-align: right;">
                                <asp:Button ID="btnsave" runat="server" Text="SUBMIT" CssClass="btn btn-primary "
                                    OnClick="btnsave_Click" OnClientClick="return ValidateSave();" />
                                <asp:Button ID="imgbtnupdate" runat="server" class="btn btn-success" Text="Update"
                                    OnClick="imgbtnupdate_Click" />
                                <asp:Button ID="btn_reset" CssClass="btn btn-warning" runat="server" Text="RESET" OnClick="btn_reset_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
