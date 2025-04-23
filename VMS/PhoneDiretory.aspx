<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneDiretory.aspx.cs" Inherits="vms.PhoneDiretory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <script type="text/javascript">
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;
            return true;
        }
       </script>
    <div class="page_header">
    </div>
    <div class="main-content">
        <div class="form form-horizontal">
            <div class="panel">
                <div class="panel-body">
                    <!--form-heading-->
                    <div class="form-heading">
                        <asp:HiddenField ID="hfid" runat="server" />
                        Phone Directray
                    </div>
                    <div id="divmsg1" class="alert alert-success" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divmsg2" class="alert alert-error" runat="server" visible="false">
                        <asp:Label ID="lblmsg2" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divfillgrid" runat="server" class="form form-horizontal" visible="false">
                        <!--toolbar-->
                        <div class="btn-group pull-right">
                            <asp:Button ID="btnAddrole" runat="server" Text="Add" CssClass=" btn btn-danger" OnClick="btnAddrole_Click" />
                        </div>

                         <div class="btn-group pull-right">
                         <asp:Button ID="BtnUploadExcel" runat="server" Text="Upload" CssClass="btn btn-info" OnClick="BtnUploadExcel_Click"/>
                        </div>

                        <div class="btn-group pull-right">
                         <asp:Button ID="BtnDownload" runat="server" Text="Download" CssClass="btn btn-Warning" OnClick="BtnDownload_Click"/>
                        </div>

                        <div class="clearfix">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height:Auto" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>Districtname</th>
                                                    <th>BlockName</th>
                                                    <th>OfficeName </th>
                                                    <th>OfficeLocation</th>
                                                    <th>Description</th>
                                                    <th>Deapartment</th>
                                                    <th>Extension</th>
                                                    <th>Action</th>
                                                   <%-- <th>Location <br />Name</th>--%>
                                                    <%--<th>Address1</th>
                                                    <th>State<br /> Name </th>--%>
                                                    <%-- <th>Contact<br />Person</th>
                                                     <th>Contact<br />Number</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("Districtname")%>
                                            </td>
                                            <td>
                                                <%#Eval("BlockName")%>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("OfficeName") %>'></asp:Label>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                            </td>
                                            <td>
                                                <%#Eval("OfficeLocation")%>
                                            </td>
                                            <td>
                                                <%#Eval("Description")%>
                                            </td>
                                             <td>
                                                <%#Eval("Deapartment")%>
                                            </td>
                                             <td>
                                                <%#Eval("Extension")%>
                                            </td>
                                            
                                            
                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
                                                    runat="server" CommandName="Edit" />
                                              
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                               <tfoot>
                 <tr style="background-color: #6bc2f6;">
                    <td>District<br />
                        <asp:TextBox ID="txtSearchDistrict" runat="server" Cssclass="form-control" AutoPostBack="true" placeholder="Enter District" OnTextChanged="txtSearchDistrict_TextChanged" />
                    </td>
                    <td>Block <br />
                        <asp:TextBox ID="txtSearchBlock" runat="server" CssClass="form-control" placeholder="Enter Block" AutoPostBack="true" OnTextChanged="txtSearchBlock_TextChanged" />
                    </td>
                    <td>Department <br />
                        <asp:TextBox ID="txtSearchDepartment" runat="server" CssClass="form-control" placeholder="Enter Department" AutoPostBack="true" OnTextChanged="txtSearchDepartment_TextChanged" />
                    </td>
                    <td>Office <br />
                        <asp:TextBox ID="txtSearchOffice" runat="server" CssClass="form-control" placeholder="Enter Office" AutoPostBack="true" OnTextChanged="txtSearchOffice_TextChanged" />
                    </td>
                    <td>Office Location <br />
                        <asp:TextBox ID="txtSearchLocation" runat="server" CssClass="form-control" placeholder="Enter Office Location" AutoPostBack="true" OnTextChanged="txtSearchLocation_TextChanged" />
                    </td>
                    <td>Display Name <br />
                        <asp:TextBox ID="txtSearchDescription" runat="server" CssClass="form-control" placeholder="Enter Display Name" AutoPostBack="true" OnTextChanged="txtSearchDescription_TextChanged" />
                    </td>
                    <td>IP Phone Number <br />
                        <asp:TextBox ID="txtSearchExtension" runat="server" CssClass="form-control" placeholder="Enter IP Phone Number" AutoPostBack="true" OnTextChanged="txtSearchExtension_TextChanged" />
                    </td>
                </tr>
                                   </tfoot>
                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
                                <asp:Label ID="lblPageNumber" runat="server" Text="Page 1"></asp:Label>
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                            </div>
                        </div>
                    </div>
                   <div class="clearfix"></div>
                    <!--form-heading-->
                    <div id="divsavedata" runat="server" class="form form-horizontal" visible="false">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                            <asp:Button ID="imgbtnVrole" runat="server" Text="View " CssClass="  btn-danger"
                                OnClick="imgbtnVbatch_Click" />
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-4">
                                <label class="control-label">
                                    District <span class="red-info">* </span>:</label>
                                   <asp:TextBox ID="TXTDistict" runat="server" CssClass="form-control">
                                </asp:TextBox>
                                <%--<asp:DropDownList ID="DrdDistict" runat="server" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="DrdDistict_SelectedIndexChanged">
                                </asp:DropDownList>--%>

                            </div>
                            
                             <div class="col-sm-4">
                                <label class="control-label">
                                    Block <span class="red-info">* </span>:</label>
                              <%--  <asp:DropdownList ID="drdblock" runat="server" CssClass="form-control">
                                </asp:DropdownList>--%>
                                   <asp:TextBox ID="TXTblock" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                           
                        </div>
                        <div class="form-group">
                            
                             <div class="col-sm-4">
                                <label class="control-label">
                                    OfficeName <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtofficename" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <label class="control-label">
                                    OfficeLocation <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtOfficeLocation" runat="server" CssClass="form-control">
                                </asp:TextBox>
                            </div>
                             <div class="col-sm-4">
                                <label class="control-label">
                                    Description <span class="red-info">* </span>:</label>
                                <div class="input-group">
                                    <span class="input-group-addon bg"><i class="ion-plus"></i></span>
                                     <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine">
                                </asp:TextBox>
                                </div>
                                <!-- /input-group -->
                            </div>
                           
                        </div>
                        <div class="form-group">
                             <div class="col-sm-6">
                                <label class="control-label">
                                    Department <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtDepartment" runat="server"  CssClass="form-control">
                                </asp:TextBox>
                            </div>
                             <div class="col-sm-6">
                                <label class="control-label">
                                    Extension Number <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtExtension" runat="server"  CssClass="form-control">
                                </asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-sm-offset-8 col-sm-2">
                                <asp:Button ID="btnproced" runat="server" class="btn btn-success" Text="Save" OnClick="btnproced_Click" OnClientClick="return Validate();" />
                                <asp:Button ID="imgbtnupdate" runat="server" class="btn btn-success" Text="Update" OnClientClick="return Validate();"
                                    OnClick="imgbtnupdate_Click" />
                                <asp:Button ID="btnrest" runat="server" class="btn btn-warning" Text="RESET" OnClick="btnrest_Click" />
                            </div>
                        </div>
                    </div>

                      <div id="UplaodExcel1" runat="server" class="form form-horizontal" visible="false">
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
