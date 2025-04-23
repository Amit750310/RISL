<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="levelMaster.aspx.cs" MasterPageFile="~/Site.Master" Inherits="vms.levelMaster" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function ValidateSave() {
            if (document.getElementById('<%=txthiLevel.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txthiLevel.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txthiLevel.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txthiLevel.ClientID %>').style.border = '1px solid #0C82DF'; }
            return true;
        }
       
    </script>

    <div class="main-content">
        <div class="panel">
            <div class="panel-body" style="min-height: 400px">
                <div class="form form-horizontal">
                    <div class="form-heading">
                        Level Master
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
                                                    <th>Level 
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
                                                <asp:Label ID="lblhiLevel" runat="server" Text='<%#Eval("hiLevel") %>'></asp:Label>
                                                <asp:Label ID="lbllevel_ID" runat="server" Text='<%#Eval("level_ID") %>' Visible="false"></asp:Label>
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
                            <label class="col-sm-3 control-label">
                                <asp:HiddenField ID="hflevel_ID" runat="server" />
                                Level :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txthiLevel" runat="server" CssClass="form-control"></asp:TextBox>
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


