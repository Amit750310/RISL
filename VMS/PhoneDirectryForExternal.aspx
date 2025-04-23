<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneDirectryForExternal.aspx.cs" Inherits="vms.PhoneDirectryForExternal" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />
    <title>VMS</title>
    <!-- <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon">
		<link rel="icon" href="images/favicon.ico" type="image/x-icon"> -->
    <!-- Bootstrap CSS -->
    <link rel='stylesheet' href='assets/css/bootstrap.min.css'>
    <link rel='stylesheet' href='assets/css/material.css'>
    <link rel='stylesheet' href='assets/css/style.css'>
    <script src='assets/js/jquery.js'></script>
    <script src='assets/js/app.js'></script>
    <script>
        jQuery(window).load(function () {
            $('.piluku-preloader').addClass('hidden');
        });
    </script>
   <%-- <script type="text/javascript">
        $(document).ready(function () {
            var columnIndex = 7; // Action column index (adjust if needed)

            // Remove the column from the header
            $('#example thead th').eq(columnIndex).remove();
            $('#example tfoot td').eq(columnIndex).remove();

            // Remove the column from each row
            $('#example tbody tr').each(function () {
                $(this).find('td').eq(columnIndex).remove();
            });

            // Initialize DataTables AFTER removing the column
            $('#example').DataTable();
        });
    </script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            var columnIndex = 7; // Adjust index if needed

            // Check if DataTable is already initialized
            if ($.fn.DataTable("#example")) {
                $("#example").DataTable().clear().destroy(); // Properly destroy existing DataTable
                $("#example thead").empty(); // Clear table header
                $("#example tbody").empty(); // Clear table body
            }

            // Remove the column from the header
            $('#example thead th').eq(columnIndex).remove();
            $('#example tfoot td').eq(columnIndex).remove();

            // Remove the column from each row
            $('#example tbody tr').each(function () {
                $(this).find('td').eq(columnIndex).remove();
            });

            // Reinitialize DataTable
            $("#example").DataTable({
                "destroy": true, // Allow reinitialization
                "retrieve": true, // Use existing instance if available
                "processing": true, // Improve performance
                "paging": true,
                "searching": true,
                "ordering": true
            });
        });
    </script>

</head>
<body class="">
  <form id="form1" runat="server">
      <div class="main-content">
        <div class="form form-horizontal">
            <div class="panel">
                <div class="panel-body">
                    <!--form-heading-->
                  <div class="form-heading" style="line-height: 77px; font-size: 40px; font-family: 'Amasis MT Pro Light';">
                        <img class="logo" src="assets/images/logotemp.png" alt="logo">
                        <asp:HiddenField ID="hfid" runat="server" />
                        <span>IP Phone Directory</span>
                    </div>
                    <div id="divmsg1" class="alert alert-success" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg1" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divmsg2" class="alert alert-error" runat="server" style="display: none;">
                        <asp:Label ID="lblmsg2" runat="server" Text=""></asp:Label>
                    </div>
                    <div id="divfillgrid" runat="server" class="form form-horizontal" style="display: block;">
                        <!--toolbar-->
                        <div class="btn-group pull-right" style="margin:4px">
                         <asp:Button ID="BtnDownload" runat="server" Text="Export To Excel" CssClass="btn btn-success" OnClick="BtnDownload_Click"/>
                        </div>
                        <div class="clearfix">
                        </div>
                         <div style="overflow-x: auto; overflow-y: auto; height:auto" id="DivMainContent">
                             <table class="table table-bordered table-hover table-striped display" id="example">
    <thead>
        <tr>
            <tr style="background-color: #6bc2f6;">
            <td>District<br />
                <asp:TextBox ID="txtSearchDistrict" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Enter District" OnTextChanged="txtSearchDistrict_TextChanged" />
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
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Districtname")%></td>
                    <td><%#Eval("BlockName")%></td>
                    <td><%#Eval("Deapartment")%></td>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("OfficeName") %>'></asp:Label>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                    </td>
                    <td><%#Eval("OfficeLocation")%></td>
                    <td><%#Eval("Description")%></td>
                    <td><%#Eval("Extension")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

                            <div class="table-responsive">
                            <%--    <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>District</th>
                                                    <th>Block</th>
                                                    <th>Deapartment</th>
                                                    <th>Office</th>
                                                    <th>Office Location</th>
                                                    <th>Display Name</th>
                                                    <th>IP Phone No.</th>
                                                  
                                                  
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
                                                <%#Eval("Deapartment")%>
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
                                                <%#Eval("Extension")%>
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
                                   </tfoot>--%>
               <div class="btn-group pull-right">
                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
                                <asp:Label ID="lblPageNumber" runat="server" Text="Page 1"></asp:Label>
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
                         </div>

                            </div>
                        </div>
                       <%-- <div style="overflow-x: auto; overflow-y: auto; height:auto" id="DivMainContent">
                            <div class="table-responsive">
    
            
        <table class="table table-bordered table-hover table-striped display" id="example">
                <tr style="background-color: #6bc2f6;">
                    <th>District<br />
                        <asp:TextBox ID="txtSearchDistrict" runat="server" Cssclass="form-control" AutoPostBack="true" placeholder="Enter District" OnTextChanged="txtSearchDistrict_TextChanged" />
                    </th>
                    <th>Block <br />
                        <asp:TextBox ID="txtSearchBlock" runat="server" CssClass="form-control" placeholder="Enter Block" AutoPostBack="true" OnTextChanged="txtSearchBlock_TextChanged" />
                    </th>
                    <th>Department <br />
                        <asp:TextBox ID="txtSearchDepartment" runat="server" CssClass="form-control" placeholder="Enter Department" AutoPostBack="true" OnTextChanged="txtSearchDepartment_TextChanged" />
                    </th>
                    <th>Office <br />
                        <asp:TextBox ID="txtSearchOffice" runat="server" CssClass="form-control" placeholder="Enter Office" AutoPostBack="true" OnTextChanged="txtSearchOffice_TextChanged" />
                    </th>
                    <th>Office Location <br />
                        <asp:TextBox ID="txtSearchLocation" runat="server" CssClass="form-control" placeholder="Enter Office Location" AutoPostBack="true" OnTextChanged="txtSearchLocation_TextChanged" />
                    </th>
                    <th>Display Name <br />
                        <asp:TextBox ID="txtSearchDescription" runat="server" CssClass="form-control" placeholder="Enter Display Name" AutoPostBack="true" OnTextChanged="txtSearchDescription_TextChanged" />
                    </th>
                    <th>IP Phone Number <br />
                        <asp:TextBox ID="txtSearchExtension" runat="server" CssClass="form-control" placeholder="Enter IP Phone Number" AutoPostBack="true" OnTextChanged="txtSearchExtension_TextChanged" />
                    </th>
                </tr>
             <asp:Repeater ID="rptRole" runat="server">
    <ItemTemplate>
        <tr>
            <td><%#Eval("Districtname")%></td>
            <td><%#Eval("BlockName")%></td>
            <td>
                <asp:Label ID="lblName" runat="server" Text='<%#Eval("OfficeName") %>'></asp:Label>
                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
            </td>
            <td><%#Eval("OfficeLocation")%></td>
            <td><%#Eval("Description")%></td>
            <td><%#Eval("Deapartment")%></td>
            <td><%#Eval("Extension")%></td>
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
                        </div>--%>
                        
                    </div>


                    <!--form-heading-->
                    <div id="divsavedata" runat="server" class="form form-horizontal" style="display: none;">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                            <asp:Button ID="imgbtnVrole" runat="server" Text="View " CssClass="  btn-danger"
                                OnClick="imgbtnVbatch_Click" />
                        </div>
                        <div class="clearfix"></div>
                    
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
        
    </form>
    <!-- wrapper -->
    <script src='assets/js/jquery-ui-1.10.3.custom.min.js'></script>
    <script src='assets/js/bootstrap.min.js'></script>
    <script src='assets/js/jquery.nicescroll.min.js'></script>
    <script src='assets/js/wow.min.js'></script>
    <script src='assets/js/jquery.loadmask.min.js'></script>
    <script src='assets/js/jquery.accordion.js'></script>
    <script src='assets/js/materialize.js'></script>
    <script src='assets/js/bic_calendar.js'></script>
    <script src='assets/js/core.js'></script>
    <script src='assets/js/select2.js'></script>
    <script src='assets/js/jquery.multi-select.js'></script>
    <script src='assets/js/bootstrap-filestyle.js'></script>
    <script src='assets/js/bootstrap-datepicker.js'></script>
    <script src='assets/js/bootstrap-colorpicker.js'></script>
    <script src='assets/js/jquery.maskedinput.js'></script>
    <script src='assets/js/jquery.dataTables.min.js'></script>
    <script src='assets/js/bootstrap-datatables.js'></script>
    <script src='assets/js/dataTables-custom.js'></script>
    <script src='assets/js/mindmup-editabletable.js'></script>
    <script src='assets/js/numeric-input-example.js'></script>
    <script src='assets/js/dynamic-tables.js'></script>
    <script src="assets/js/jquery.countTo.js"></script>
    <script src='assets/js/form-elements.js'></script>
</body>
<!-- END JAVASCRIPTS -->
</html>
