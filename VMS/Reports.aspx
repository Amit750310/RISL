<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="vms.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <div class="main-content">
        <div class="panel">
            <div class="panel-body" style="min-height: 400px">
                <div class="form form-horizontal">
                    <div class="form-heading">
                       Reports
                    </div>
                    <div id="divmsg1" class="alert alert-success" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divmsg2" class="alert alert-error" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg2" runat="server" Text=""></asp:Label>
                    </div>

                     <div class="btn-group pull-right">
                            <asp:Button ID="BtnUploadExcel" runat="server" Text="DownLoad" CssClass="btn btn-info" OnClick="BtnUploadExcel_Click" />
                        </div>
                    <div>
                        <label class="control-label">
                        TYPE <span class="red-info">* </span>:</label>
                        <asp:DropDownList runat="server" id="drdinventryselection" OnSelectedIndexChanged="drdinventryselection_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true">
                                  <asp:ListItem Text="RISL-VC"></asp:ListItem>
                                  <asp:ListItem Text="RISL-IP PHONE"></asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div id="divfillgrid" runat="server" class="form form-horizontal" visible="false">
                        <!--toolbar-->
                        <div style="overflow-x: auto; overflow-y: auto; height: auto" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <%--<th>Inventory DB </th>--%>
                                                    <th>Project Name</th>
                                                    <th>Location Name </th>
                                                    <%--<th>DeviceType </th>--%>
                                                     <%--<th>Partcode </th>--%>
                                                    <th>District</th>
                                                     <th>Block</th>
                                                    <th>Component</th>
                                                     <th>ComponentSerialNo</th>
                                                  
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("ProjectID") %>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                            </td>
                                          <%--  <td><%#Eval("ProjectID") %></td>--%>
                                            <td><%#Eval("LocationName") %></td>
                                            <td><%#Eval("District") %></td>
                                            <td><%#Eval("Block") %></td>
                                            <td><%#Eval("Component") %></td>
                                            <td><%#Eval("ComponentSerialNo") %></td>
                                           <%-- <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
                                                    runat="server" CommandName="Edit" />
                                                <asp:Button ID="btnView" class="btn btn-primary btn-icon-primary" Text="View Log"
                                                    runat="server" CommandName="View" />--%>
                                                <%--   <asp:Button ID="imgbtnDelete" CssClass="btn btn-red btn-icon-red " runat="server"
                                                Text="Delete" CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this Record?");' />--%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody></table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
                                <asp:Label ID="lblPageNumber" runat="server" Text="Page 1"></asp:Label>
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      </div>
</asp:Content>
