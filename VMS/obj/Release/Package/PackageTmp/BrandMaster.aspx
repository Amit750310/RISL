<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandMaster.aspx.cs" MasterPageFile="~/Site.Master" Inherits="vms.BrandMaster" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function ValidateSave() {
            if (document.getElementById('<%=txtbrand.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtbrand.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtbrand.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtorderby.ClientID %>').style.border = '1px solid #0C82DF'; }
            if (document.getElementById('<%=txtorderby.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtorderby.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtorderby.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtorderby.ClientID %>').style.border = '1px solid #0C82DF'; }
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
                        Brand Master
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
                                                    <th>Brand 
                                                    </th>
                                                    <th>Display Order
                                                    </th>
                                                    <th>Action
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            
                                            <td>
                                                <asp:Label ID="lblbrandname" runat="server" Text='<%#Eval("BrandName") %>'></asp:Label>
                                                <asp:Label ID="lblRolecode" runat="server" Text='<%#Eval("BrandID") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldisplay" runat="server" Text=' <%#Eval("Orderby")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
                                                    runat="server" CommandName="Edit" />
                                                <%--   <asp:Button ID="imgbtnDelete" CssClass="btn btn-red btn-icon-red " runat="server"
                                                Text="Delete" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this Record?");' />--%>
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
                            <label class="col-sm-3 control-label">
                                <asp:HiddenField ID="hfbrandid" runat="server" />
                                Brand :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtbrand" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                Order BY :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtorderby" runat="server" CssClass="form-control" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-6 col-sm-2">
                                <asp:Button ID="btnsave" runat="server" class="btn btn-success" Text="Submit" OnClick="btnsave_Click" OnClientClick="return ValidateSave();" />
                                <asp:Button ID="imgbtnupdate" runat="server" class="btn btn-success" Text="Update"
                                    OnClick="imgbtnupdate_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


