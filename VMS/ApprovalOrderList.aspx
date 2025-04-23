<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApprovalOrderList.aspx.cs" Inherits="vms.ApprovalOrderList" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
   
    <div class="main-content">
        <div class="panel">
            <div class="panel-body" style="min-height: 400px">
                <div class="form form-horizontal">
                    <div class="form-heading">
                        Order List
                    </div>
                    <div id="divmsg1" class="alert alert-success" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divmsg2" class="alert alert-error" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg2" runat="server" Text=""></asp:Label>
                    </div>
                     <div id="divfillgrid" runat="server" class="form form-horizontal" style="display: block;">
                         <asp:HiddenField ID="hfcategory_ID" runat="server" />
                        <!--toolbar-->
                        <div class="btn-group pull-right">
                            <asp:Button ID="btnAddrole" runat="server" Text="Add" CssClass=" btn-danger" OnClick="btnAddrole_Click" />
                        </div>
                        <div class="clearfix">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 450px" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptBind" runat="server" OnItemCommand="rptBind_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>Department <br />Name</th>
                                                    <th>ToEmail</th>
                                                    <th>Refrence</th>
                                                    <th>InformationEmail</th>
                                                    <th>ProjectOICName</th>
                                                    <th>Subject</th>
                                                    <th>Fileno</th>
                                                    <th>Status</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>

                                            <td>
                                                <asp:Label ID="lblcategoryname" runat="server" Text='<%#Eval("DepartmentName") %>'></asp:Label>
                                                <asp:Label ID="lblcategory_id" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td><%#Eval("ToEmail")%></td>
                                            <td><%#Eval("Refrence")%></td>
                                            <td><%#Eval("InformationEmail")%></td>
                                            <td><%#Eval("ProjectOICNAme")%></td>
                                            <td><%#Eval("Subject")%></td>
                                            <td><%#Eval("Fileno")%></td>
                                            <td>Pending</td>
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="ShowDetails"
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
                    <div class="clearfix">
                     <div style="overflow-x: auto;  overflow-y: auto; height: 450px" id="ShowDetails" runat="server">
                            <div class="table-responsive">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>ServiceType</th>
                                                    <th>Discription_of_work</th>
                                                    <th>Quantity</th>
                                                    <th>UnitCost</th>
                                                    <th>TotalAmount</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>

                                            <td>
                                                <asp:Label ID="lblcategoryname" runat="server" Text='<%#Eval("ServiceType") %>'></asp:Label>
                                                <asp:Label ID="lblcategory_id" runat="server" Text='<%#Eval("Oid") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td><%#Eval("Discription_of_work")%></td>
                                            <td><%#Eval("Quantity")%></td>
                                            <td><%#Eval("UnitCost")%></td>
                                            <td><%#Eval("TotalAmount")%></td>
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="ShowDetails"
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

                          <div class="btn-group pull-right">
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <label class="control-label">
                                            Status :</label>
                                        <div class="input-group">
                                            <span class="input-group-addon bg"><i class="ion-plus"></i></span>
                                            <asp:DropDownList ID="drdApprovedStatus" runat="server" CssClass="name_search form-control" AppendDataBoundItems="True">
                                                <asp:ListItem Text="Select" Value="Select">Select</asp:ListItem>
                                                <asp:ListItem Text="Pending" Value="Pending">Pending</asp:ListItem>
                                                <asp:ListItem Text="Approved" Value="Approved">Approved</asp:ListItem>
                                                <asp:ListItem Text="Reject" Value="Reject">Reject</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <!-- /input-group -->
                                    </div>
                                    <div class="col-sm-6">
                                        <label class="control-label">
                                            Remarks <span class="red-info">* </span>:</label>
                                        <asp:TextBox ID="txtApprovedRemarks" runat="server" CssClass="form-control" TextMode="MultiLine">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-2">
                                         <label class="control-label">  </label>
                                        <div class="input-group">
                                            <asp:Button ID="BtnAddStatus" runat="server" Text="Save" CssClass=" btn btn-warning" OnClick="BtnAddStatus_Click" />
                                            <asp:Button ID="BtnCancelStatus" runat="server" Text="Cancel" CssClass=" btn btn-danger"  OnClick="BtnCancelStatus_Click"/>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                       
                    <div class="clearfix"></div>
                    <div id="div2" class="form form-horizontal" runat="server" visible="false">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                            <asp:Button ID="imgbtnVrole" runat="server" Text="View " CssClass="  btn-danger"
                                OnClick="imgbtnVbatch_Click" />
                        </div>
                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Department Name <span class="red-info">* </span>:
                                </label>
                                <select id="drddept" class="form-control">
                                    <option value="DD">DD</option>
                                    <option value="MM">MM</option>
                                </select>
                            </div>
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Project OIC Name <span class="red-info">* </span>:
                                </label>
                                <input type="text" id="txtOIC" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                    To <span class="red-info">* </span>:
                                </label>
                                <input type="text" id="txtTo" class="form-control" />
                            </div>
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Subject <span class="red-info">* </span>:
                                </label>
                                <input type="text" id="TxtSubject" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Reference <span class="red-info">* </span>:
                                </label>
                                <input type="text" id="TxtRef" class="form-control" />
                            </div>
                            <div class="col-sm-6">
                                <label class="control-label">
                                    File NO <span class="red-info">* </span>:
                                </label>
                                <input type="text" id="txtFileNo" class="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Information Mail <span class="red-info">* </span>:
                                </label>
                                <input type="text" id="txtinfromation" class="form-control" />
                            </div>
                        </div>
                    </div>

                    <div class="clearfix"></div>
                    <div id="div1" runat="server" height="Auto" class="form form-horizontal" style="display:none;">
                        <table id="serviceTable" class="table">
                            <thead>
                                <tr>
                                    <th>S.No.</th>
                                    <th>Service Type</th>
                                    <th>Description of Work</th>
                                    <th>Quantity</th>
                                    <th>Unit</th>
                                    <th>Unit Cost (Incl. all Taxes)</th>
                                    <th>Total Amount</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>
                                        <select class="form-control" onchange="updateUnitCost(this)">
                                            <option value="100">Turnkey</option>
                                            <option value="200">Led</option>
                                            <option value="300">Router</option>
                                            <!-- Add other options here if needed -->
                                        </select>
                                    </td>
                                    <td>
                                        <input type="text" class="form-control" placeholder="VC End Point" /></td>
                                    <td>
                                        <input type="number" class="form-control" value="0" oninput="updateTotal()" /></td>
                                    <td>
                                        <select class="form-control">
                                            <option value="Nos">Nos.</option>
                                            <!-- Add other options here if needed -->
                                        </select>
                                    </td>
                                    <td>
                                        <input type="text" class="form-control" value="0" /></td>
                                    <td>
                                        <input type="text" class="form-control" value="0" /></td>
                                    <td>
                                        <button type="button" class="btn btn-danger" onclick="removeRow(this)">Delete</button></td>
                                </tr>
                                <!-- Add more rows here dynamically -->
                            </tbody>
                        </table>
                        <button type="button" class="btn btn-primary" onclick="addRow()">Add Row</button>

                        <div>
                            <label>Total (₹):</label>
                            <span id="totalAmount"></span>
                        </div>
                        <div>
                            <label>RISL Service Charges (₹):</label>
                            <span id="rislCharges"></span>
                        </div>
                        <div>
                            <label>CGST @9% on RISL Service Charges (₹):</label>
                            <span id="cgstAmount"></span>
                        </div>
                    </div>

                    <div id="div3" runat="server" height="Auto" class="form form-horizontal" style="display:none;">
                    <input type="button" id="btnsubmit" value="submit" onclick="saveServiceItems()" />
                   </div>



                </div>
            </div>
        </div>
    </div>


</asp:Content>