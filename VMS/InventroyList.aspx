<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="InventroyList.aspx.cs" Inherits="vms.InventroyList" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function ValidateSave() {
            <%-- <%--if (document.getElementById('<%=txtcategory.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtcategory.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtcategory.ClientID %>').focus();
                return false;
            }   return true;--%>
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
                       InventoryList
                    </div>
                    <div id="divmsg1" class="alert alert-success" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divmsg2" class="alert alert-error" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg2" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divfillgrid" runat="server" class="form form-horizontal" style="display: block;">
                        <!--toolbar-->
                       <%-- <div class="btn-group pull-right">
                            <asp:Button ID="btnAddrole" runat="server" Text="Add" CssClass="btn btn-danger" OnClick="btnAddrole_Click" />
                        </div>
                         &nbsp;
                        <div class="btn-group pull-right">
                            <asp:Button ID="BtnUploadExcel" runat="server" Text="Upload Excel" CssClass="btn btn-info" OnClick="BtnUploadExcel_Click" />
                        </div>
                        &nbsp;--%>
                        
                        <div class="clearfix">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height:auto" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>Inventory DB </th>
                                                    <th>Project Name</th>
                                                    <%--<th>LocationName </th>--%>
                                                    <%--<th>DeviceType </th>
                                                    <th>PartCode </th>--%>
                                                    <th>Action
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("InventoryDB") %>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("InventoryDB") %>' Visible="false"></asp:Label>
                                            </td>
                                             <asp:Label ID="lblProjectid" runat="server" Text='<%#Eval("ProjectID") %>' Visible="false"></asp:Label>
                                            <td><%#Eval("ProjectID") %></td>
                                           <%-- <td><%#Eval("LocationName") %></td>--%>
                                            <%--<td><%#Eval("DeviceType") %></td>
                                            <td><%#Eval("PartCode") %></td>--%>
                                            <td>
                                                <asp:Button ID="imgbtnEdit1" class="btn btn-primary btn-icon-primary" Text="View"
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
                        </div>
                   
                     <div runat="server" id="btndown"  style="display: none;">
                           <asp:Button ID="Button11" runat="server" CssClass="btn btn-danger" OnClick="DownloadFile_click" Text="DownLoad"/>
                        </div>
                    <div id="divfillInventry" runat="server" class="form form-horizontal" style="display: block;">
                       <div class="table-responsive">
                                <asp:Repeater ID="RptShowDetails" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <%--<th>Inventory DB </th>--%>
                                                    <th>Project Name</th>
                                                    <th>Location Name </th>
                                                    <th>IPAddress </th>
                                                    <th>Component </th>
                                                    <th>ComponentSerialNO </th>
                                                  <%--  <th>DeviceType </th>
                                                    <th>PartCode </th>--%>
                                                   <%-- <th>Action</th>--%>
                                                    
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
                                            <td><%#Eval("LocationName") %></td>
                                            <td><%#Eval("IPAddress") %></td>
                                            <td><%#Eval("Component") %></td>
                                             <td><%#Eval("ComponentSerialNo") %></td>
                                           
                                           <%-- <td><%#Eval("DeviceType") %></td>
                                            <td><%#Eval("PartCode") %></td>--%>
                                           <%-- <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text=" "
                                                    runat="server" CommandName="Edit" />
                                               </td>--%>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody></table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>

                    </div>
                    
                    <!--form-heading-->
                   <%-- <div id="divsavedata" runat="server" class="form form-horizontal" style="display: none;">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                            <asp:Button ID="imgbtnVrole" runat="server" Text="View " CssClass="  btn-danger"
                                OnClick="imgbtnVbatch_Click" />
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                                <asp:HiddenField ID="hfcategory_ID" runat="server" />
                            </div>
                           <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        InventoryDB <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtInventoryDB" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>

                               <div class="col-sm-4">
                                    <label class="control-label">
                                        ProjectName <span class="red-info">* </span>:</label>
                                    <asp:Dropdownlist ID="drdProjectID" runat="server" CssClass="form-control" >
                                    </asp:Dropdownlist>
                                </div>
                            
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        LocationName <span class="red-info">* </span>:</label>
                                    <asp:Dropdownlist ID="drdLocationName" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="drdLocationName_SelectedIndexChanged" >
                                    </asp:Dropdownlist>
                                </div>
                              

                           </div>
                         <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        SubLocation <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtSubLocation" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        DeviceType <span class="red-info">* </span>:</label>
                                    <asp:Dropdownlist ID="drdDeviceType" runat="server" CssClass="form-control" >
                                    </asp:Dropdownlist>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        PartCode <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtPartCode" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                           </div>

                          <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        PartDescription <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtPartDescription" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        HostName</label>
                                    <asp:TextBox ID="txtHostName" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        IPAddress</label>
                                    <asp:TextBox ID="txtIPAddress" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                           </div>
                         <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        Component <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtComponent" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        ComponentSerialNo <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtComponentSerialNo" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        SubComponent <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtSubComponent" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>

                           </div>
                         <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        ContactName <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        Phone <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        Address <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>

                           </div>
                         <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        Address1<span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        State <span class="red-info">* </span>:</label>
                                    <asp:DropdownList ID="drdState" runat="server" CssClass="form-control" >
                                    </asp:DropdownList>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        District <span class="red-info">* </span>:</label>
                                    <asp:DropdownList ID="drdDistrict" runat="server" CssClass="form-control" >
                                    </asp:DropdownList>
                                </div>

                           </div>
                        <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        PinCode <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        SupportType <span class="red-info">* </span>:</label>
                                    <asp:DropDownList ID="drdSupportType" runat="server" CssClass="form-control">
                                  <asp:ListItem Text="Warranty"></asp:ListItem>
                                  <asp:ListItem Text="AMC"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                       Support Start Date <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtSupportStartdate" runat="server" data-provide="datepicker" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>

                           </div>
                        <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        SupportEndDate <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtSupportEndDate" runat="server" data-provide="datepicker" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4" >
                                    <label class="control-label">
                                       OEMSupport <span class="red-info">* </span>:</label>
                                     <asp:DropDownList ID="drdOEMSupport" runat="server" CssClass="form-control">
                                  <asp:ListItem Text="YES"></asp:ListItem>
                                  <asp:ListItem Text="NO"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                               <div class="col-sm-4" runat="server" id="Divstart">
                                    <label class="control-label" >
                                        OEMStartDate <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtOEMStartDate" runat="server" data-provide="datepicker" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>

                           </div>
                         <div class="form-group">
                                <div class="col-sm-4" runat="server" id="DivEnd">
                                    <label class="control-label">
                                        OEMEndDate <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtOEMEndDate" runat="server" data-provide="datepicker" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                              <div class="col-sm-4">
                                    <label class="control-label">
                                        SubComponentSerialNo <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtSubComponentSerialNo" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
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

                    <div id="UplaodExcel1" runat="server" class="form form-horizontal" style="display: none;">
                         <div class="form-group">
                               <div class="col-sm-6">
                                        <label class="control-label">
                                            Choose:</label>
                                        <div class="input-group">
                                             <asp:FileUpload ID="FileUpload1" CssClass="custom-file-input " runat="server" />
                                        </div>
                                    </div>
                         <div class="col-sm-2">
                                        <label class="control-label">
                                            Upload:</label>
                                        <div class="input-group">
                                          <asp:Button ID="UploadExcel" runat="server" CssClass="btn btn-warning" Text ="Upload" OnClick="UploadExcel_Click1" />
                                        </div>
                                    </div>
                         </div>
                       
                    </div>--%>

                    </div>
                </div>
            </div>
        </div>
  
</asp:Content>
