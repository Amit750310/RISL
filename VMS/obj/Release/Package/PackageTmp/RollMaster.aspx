<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RollMaster.aspx.cs" Inherits="vms.RollMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <div class="page_header">
    </div>
    <div class="main-content">
        <div class="form form-horizontal">
            <div class="panel">
                <div class="panel-body">
                    <!--form-heading-->
                    <div class="form-heading">
                        <asp:HiddenField ID="hfid" runat="server" />
                        Roll Master
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
                                                    <th>
                                                       
                                                        Roll Name
                                                    </th>
                                                    <th>
                                                        Status
                                                    </th>
                                                   
                                                    <th>
                                                        Action
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                 <asp:Label ID="lblRollID" runat="server" Text='<%#Eval("RollId") %>' Visible="false"></asp:Label>
                                                <%#Eval("RollName")%>
                                            </td>
                                            <td>
                                              <asp:CheckBox ID="chkroll" Enabled="false" runat="server" Text="Active" Checked= '<%#Eval("active") %>' />
                                            </td>
                                          
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
                                                    runat="server" CommandName="Edit"  CommandArgument='<%#Eval("rollid")%>' />
                                                <%--   <asp:Button ID="imgbtnDelete" CssClass="btn btn-red btn-icon-red " runat="server"
                                                Text="Delete" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this Record?");' />--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody></table></FooterTemplate>
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
                        <div class="clearfix">
                        </div>
                        <div class="form-group">
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Roll Name :</label>
                           
                                 <asp:TextBox ID="txtrollName" runat="server" CssClass="form-control"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                   ControlToValidate="txtrollName" ErrorMessage="please Enter Roll Name" 
                   ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                          
                            <div class="col-sm-4">
                                <label class="control-label">
                                    Status :</label>
                                <div class="input-group">
                                    <asp:CheckBox ID="chkActive" runat="server" Text="Active/Deactive"   CssClass="form-control"/>
                                </div>
                                <!-- /input-group -->
                            </div>
                        </div>

                        
                     
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-8">
                                <asp:Button ID="btnproced" runat="server" class="btn btn-success" Text="Save" OnClick="btnproced_Click" />
                                <asp:Button ID="imgbtnupdate" runat="server" class="btn btn-success" Text="Update"
                                    OnClick="imgbtnupdate_Click" />
                                <asp:Button ID="btnrest" runat="server" class="btn btn-warning" Text="RESET" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
