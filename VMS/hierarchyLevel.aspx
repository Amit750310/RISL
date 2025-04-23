<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hierarchyLevel.aspx.cs" MasterPageFile="~/Site.Master" Inherits="vms.hierarchyLevel" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
    <div class="page_header">
    </div>
    <div class="main-content">
        <div class="panel">
            <div class="panel-body">
                <div class="form form-horizontal">
                    <div class="form-heading">
                        Hierarchy Level List
                    </div>
                    <div class="table-responsive">
                        <asp:Repeater ID="rptdisptch" runat="server" OnItemDataBound="rptdisptch_ItemDataBound">
                            <HeaderTemplate>
                                <table class="table table-bordered table-striped display" id="example">
                                    <thead>
                                        <tr>
                                            <th>Emp ID</th>
                                            <th>Emp Name --> Level</th>
                                          
                                          
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td> <asp:Label ID="lblemp_Id" runat="server" Text='<%#Eval("emp_Id")%>'></asp:Label></td>
                                    <td>
                                 <asp:Label ID="lblname" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                                    </td>
                                 </tr>
                                  <tr> <td colspan="3">
                                      <asp:CheckBoxList ID="chkemplist" runat="server" RepeatColumns="4" ></asp:CheckBoxList></td>
                                       </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </div> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-8">
                            <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-green" Text="Update Hierarchy Level" OnClientClick='return confirm("Are You Sure You Want To Update  Hierarchy Level ?");' OnClick="btnupdate_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


