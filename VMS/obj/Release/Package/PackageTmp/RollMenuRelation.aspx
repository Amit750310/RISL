<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RollMenuRelation.aspx.cs" Inherits="vms.RollMenuRelation" %>
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
                        Roll Relation Master
                    </div>
                    <div id="divmsg1" class="alert alert-success" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divmsg2" class="alert alert-error" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg2" runat="server" Text=""></asp:Label>
                    </div>
                    
                    <!--form-heading-->
                    <div id="divsavedata" runat="server" class="form form-horizontal" style="display: block;">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                       
                        </div>
                        <div class="clearfix">
                        </div>
                        <div class="form-group">
                           <div class="col-sm-4">
                                <label class="control-label">
                                    Roll Name :</label>
                                <div class="input-group">
                                    <span class="input-group-addon bg"><i class="ion-plus"></i></span>
                                    <asp:DropDownList ID="drdrollname1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drdrollname1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <!-- /input-group -->
                            </div>
                          
                            <div class="col-sm-4">
                                <label class="control-label">
                                    MenuList :</label>
                                <div class="input-group">
                                    <asp:Repeater ID="dtMenumaster" runat="server"  
                    OnItemDataBound="dtMenumaster_ItemDataBound">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkMenu" runat="server" Text='<%#Eval("menuName") %>' />
                        <asp:Label ID="lblMenuId" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                        <asp:CheckBoxList ID="chkchildemenulist" runat="server" RepeatColumns="4" BorderWidth="2px">
                </asp:CheckBoxList>
                    </ItemTemplate>
                </asp:Repeater>
                                </div>
                                <!-- /input-group -->
                            </div>
                        </div>

                        
                     
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-8">
                                <asp:Button ID="btnproced" runat="server" class="btn btn-success" Text="Save" OnClick="btnproced_Click" />
                               
                                <asp:Button ID="btnrest" runat="server" class="btn btn-warning" Text="RESET" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>