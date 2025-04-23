<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VC_Inventry_Master.aspx.cs" Inherits="vms.VC_Inventry_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            function validateFile() {
        // Get the file input element and the selected file
                var fileInput = document.getElementById("<%= FileUpload2.ClientID %>");
                var label = document.getElementById("<%= StatusLabel.ClientID %>");
            var filePath = fileInput.value;

            // Allowed extensions
            var allowedExtensions = /(\.pdf)$/i;
            // Check if the file extension is valid
            if (!allowedExtensions.exec(filePath)) {
                label.innerText = "Invalid file type. Only PDF files are allowed.";
            fileInput.value = ''; // Clear the input
            return false;
        } else {
            // File extension is valid
               label.innerText = "";
            return true;
        }
    }

     </script>

    <div class="main-content">
        <div class="panel">
            <div class="panel-body" style="min-height: 400px">
                <div class="form form-horizontal">
                    <div class="form-heading">
                      VC Inventory Master
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
                            <asp:Button ID="btnAddrole" runat="server" Text="Add" CssClass="btn btn-danger" OnClick="btnAddrole_Click" />
                        </div>
                         &nbsp;
                        <div class="btn-group pull-right">
                            <asp:Button ID="BtnUploadExcel" runat="server" Text="Upload" CssClass="btn btn-info" OnClick="BtnUploadExcel_Click" />
                        </div>
                        &nbsp;
                         <div class="btn-group pull-right">
                           <asp:Button ID="Button11" runat="server" CssClass="btn btn-danger" OnClick="DownloadFile_click" Text="Template Excel" />
                          </div>
                         <div class="btn-group pull-right">
                           <asp:Button ID="BtnAllinventroy" runat="server" CssClass="btn btn-info" Text="All Inventroy"  OnClick="BtnAllinventroy_Click"/>
                          </div>
                        <div class="btn-group pull-left">
                        
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                      
                          </div>
                        <div class="btn-group pull-left">
                                 <asp:Button ID="Button2" runat="server" CssClass="btn btn-info" Text="Search" OnClick="Button2_Click"/>
                            </div>
                        <div class="btn-group pull-left">
                            <asp:Button ID="Button3" runat="server" CssClass="btn btn-info" Text="DownLoad" Enabled="false" OnClick="Button3_Click"/>
                          
                        </div>
                        <div class="clearfix">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height: auto" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                   
                                                    <th>Project Name</th>
                                                    <%--<th>DeviceType </th>--%>
                                                     <%--<th>Partcode </th>--%>
                                                    <th>District</th>
                                                     <th>Block</th>
                                                    <th>Location Name </th>
                                                    <th>Component</th>
                                                     <th>Component<br />SerialNO</th>
                                                    <th>Action
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%--<%#Eval("InventoryDB") %>--%>
                                                <%#Eval("ProjectID") %>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td><%#Eval("District") %></td>
                                            <td><%#Eval("Block") %></td>
                                            <td><%#Eval("LocationName") %></td>
                                            <td><%#Eval("Component") %></td>
                                             <td><%#Eval("ComponentSerialNo") %></td>
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
                                                    runat="server" CommandName="Edit" />
                                                <asp:Button ID="btnView" class="btn btn-primary btn-icon-primary" Text="View Log"
                                                    runat="server" CommandName="View" />
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
                     <div class="clearfix">
                        </div>
                   
                     <div runat="server" id="btndown"  style="display:none;">
                           <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" OnClick="DownloadFile_click" Text="DownLoad"  />
                        </div>
                    <div id="divfillInventry" runat="server" class="form form-horizontal" style="display: none;">
                       <div class="table-responsive">
                                <asp:Repeater ID="RptShowDetails" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>Inventory DB </th>
                                                    <th>Project Name</th>
                                                    <th>Location Name </th>
                                                     <th>IPAddress </th>
                                                    <th>Component </th>

<%--                                                    <th>DeviceType </th>
                                                    <th>PartCode </th>--%>
                                                   <%-- <th>Action
                                                    </th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                             <%#Eval("InventoryDB") %>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("InventroyID") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td><%#Eval("ProjectID") %></td>
                                            <td><%#Eval("LocationName") %></td>
                                            <td><%#Eval("IPAddress") %></td>
                                            <td><%#Eval("Component") %></td>
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
                    
                     <div class="clearfix">
                        </div>
                    <!--form-heading-->
                    <div id="divsavedata" runat="server" class="form form-horizontal" style="display: none;">
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
                                    <asp:TextBox ID="txtInventoryDB" runat="server" placeholder="RISL"  Enabled="false" CssClass="form-control" >
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
                                    <asp:Dropdownlist ID="drdLocationName" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="drdLocationName_SelectedIndexChanged">
                                    </asp:Dropdownlist>
                                </div>
                              

                           </div>
                         <div class="form-group">
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        Department Name <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="txtSubLocation" runat="server" CssClass="form-control" >
                                    </asp:TextBox>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        DeviceType <span class="red-info">* </span>:</label>
                                    <asp:Dropdownlist ID="drdDeviceType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drdDeviceType_SelectedIndexChanged"></asp:Dropdownlist>
                                </div>
                               <div class="col-sm-4">
                                    <label class="control-label">
                                        PartCode <span class="red-info">* </span>:</label>
                                    <%--<asp:TextBox ID="txtPartCode" runat="server" CssClass="form-control" >
                                    </asp:TextBox>--%>
                                 <asp:Dropdownlist runat="server" ID="drdPartCode" CssClass="form-control" AutoPostBack="true" ></asp:Dropdownlist>
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
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        Catagry <span class="red-info">* </span>:</label>
                                    <asp:Dropdownlist ID="drdStatus"  runat="server" CssClass="form-control">
                                    </asp:Dropdownlist>
                                </div>
                           </div>

                         <div class="form-group">
                                <div class="col-sm-4" runat="server" id="Div1">
                                    <label class="control-label">
                                       Inventry Verification <span class="red-info">* </span>:</label>
                                    <asp:dropdownlist ID="DrdVerification" runat="server" CssClass="form-control" OnSelectedIndexChanged="DrdVerification_SelectedIndexChanged" >
                                    <asp:ListItem Text="Yes"></asp:ListItem>
                                    <asp:ListItem Text="NO"></asp:ListItem>
                                    <asp:ListItem Text="Inventry initating"></asp:ListItem>
                                    </asp:dropdownlist>
                                </div>
                                <div class="col-sm-4">
                                    <label class="control-label">
                                        Data Of Verification <span class="red-info">* </span>:</label>
                                    <asp:TextBox ID="Dateveri" runat="server" data-provide="datepicker" enable="False" CssClass="form-control" >
                                    </asp:TextBox>

                                </div>

                              <div class="col-sm-3">
                                    <label class="control-label">
                                       Upload Certificate <span class="red-info">* </span>:</label>
                                     <asp:FileUpload ID="FileUpload2" CssClass="custom-file-input " runat="server" onchange="validateFile()" />
                                    <asp:Label ID="StatusLabel" runat="server" Text="" />
                                
                              </div>
                             
                              <div class="col-sm-1">
                                  
                                        <label class="control-label" runat="server" id="lblCertificate" visible="false">
                                         <i class="bi bi-eye"><a id="dynamiclink" runat="server" target="_blank">view</a></i>
                                         </label>
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
                       
                    </div>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
