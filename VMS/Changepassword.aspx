<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs"
    MasterPageFile="~/Site.Master" Inherits="vms.Changepassword" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function Validate() {
            if (document.getElementById('<%=txtoldpwd.ClientID %>').value.trim() == "") {
                //alert("Please Enter Role");
                document.getElementById('<%=txtoldpwd.ClientID %>').style.border = '1px solid red';
                return false;
            }
            else { document.getElementById('<%=txtoldpwd.ClientID %>').style.border = '1px solid Black'; }
            if (document.getElementById('<%=txtnewpwd.ClientID %>').value.trim() == "") {
                //alert("Please Enter Role");
                document.getElementById('<%=txtnewpwd.ClientID %>').style.border = '1px solid red';
                return false;
            }
            else { document.getElementById('<%=txtnewpwd.ClientID %>').style.border = '1px solid Black'; }
            if (document.getElementById('<%=txtconfirmpwd.ClientID %>').value.trim() == "") {
                //alert("Please Enter Role");
                document.getElementById('<%=txtconfirmpwd.ClientID %>').style.border = '1px solid red';
                return false;
            }
            else { document.getElementById('<%=txtconfirmpwd.ClientID %>').style.border = '1px solid Black'; }

            if (document.getElementById('<%=txtconfirmpwd.ClientID %>').value.trim() != document.getElementById('<%=txtnewpwd.ClientID %>').value.trim()) {
                document.getElementById('<%=txtconfirmpwd.ClientID %>').style.border = '1px solid red';
                return false;
            } else { document.getElementById('<%=txtconfirmpwd.ClientID %>').style.border = '1px solid Black'; }

            return true;
        }
    </script>
    <div class="page_header">
        <div class="pull-left">
            <i class="icon ti-layout-grid2-thumb page_header_icon"></i><span class="main-text">Change
                Password</span>
        </div>
        <div class="right pull-right">
        </div>
    </div>
    <!-- /pageheader -->
    <!--main content-->
    <div class="main-content">
        <!--theme panel-->
        <div class="panel">
            <div class="panel-body">
                <!--form-heading-->
                <div class="form-heading">
                    Change Password Detail
                </div>
                <!--form-heading-->
                <div class="form form-horizontal">
                    <!--Default Horizontal Form-->
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            Current Password:</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtoldpwd" runat="server" TextMode="Password" CssClass="form-control"
                                placeholder="Current Password"></asp:TextBox>
                        </div>
                    </div>
                    <!--Default Horizontal Form-->
                    <!--Default Horizontal Form with password-->
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            New Password:</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtnewpwd" runat="server" TextMode="Password" CssClass="form-control"
                                placeholder="New Password"></asp:TextBox>
                        </div>
                    </div>
                    <!--Default Horizontal Form with password-->
                    <!--disabled-->
                    <div class="form-group">
                        <label class="col-sm-3 control-label">
                            Confirm Password:</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtconfirmpwd" runat="server" TextMode="Password" CssClass="form-control"
                                placeholder="Confirm Password"></asp:TextBox>
                        </div>
                    </div>
                    <!--disabled-->
                    <!-- xinput group-->
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-8">
                            <asp:Button ID="btnsubmit" CssClass="btn btn-success" Text="Submit" runat="server"
                                OnClick="btnSubmit_Click" OnClientClick="return Validate();" />
                            <asp:Button ID="btnreset" CssClass="btn btn-warning" Text="Reset" OnClick="btnCancel_Click"
                                runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--theme panel-->
    </div>
</asp:Content>
