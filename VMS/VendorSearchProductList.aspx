<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="VendorSearchProductList.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="vms.VendorSearchProductList" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
  
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
                  
              
                    <div id="divfillgrid" runat="server" class="form form-horizontal" style="display: block;">
                        <!--toolbar-->
                       
                        <div class="clearfix">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 450px" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server" >
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>Vendor Search Product ID
                                                    </th>
                                                    <th>From EmailId
                                                    </th>
                                                    <th>To Emailids
                                                    </th>
                                                    <th>Subjects
                                                    </th>

                                                    <th>Products
                                                    </th>
                                                    <th>Email Bodys
                                                    </th>
                                                    <th>AttachmentPath
                                                    </th>
                                                  
                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("VendorSearchProductID")%>
                                            </td>
                                          

                                            <td>
                                                <%#Eval("FromEmailId")%>
                                            </td>
                                            <td>
                                                <%#Eval("ToEmailids")%>
                                            </td>

                                            <td>
                                                <%#Eval("Subjects")%>
                                            </td>
                                            <td>
                                                <%#Eval("Products")%>
                                            </td>
                                            <td>
                                                 <asp:TextBox ID="txtemailbodys" runat="server" Text='<%#Eval("EmailBodys")%>' Height="50px" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                                     
                                                     
                                               
                                            </td>
                                            <td>
                                                <a href='<%#Eval("AttachmentPath")%>' id="link" target="_blank" runat="server"> <%#Eval("AttachmentPath")%></a>
                                               
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
                    





                </div>
            </div>
        </div>
    </div>
</asp:Content>


