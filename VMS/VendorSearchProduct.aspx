<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="VendorSearchProduct.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="vms.VendorSearchProduct" %>

<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">

     <link href="css/demo.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery-te-1.4.0.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;
            return true;
        }
        function Validate() {

            if (document.getElementById('<%=txtFrom.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtFrom.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtFrom.ClientID %>').focus();
                return false;
            } else { document.getElementById('<%=txtFrom.ClientID %>').style.border = '1px solid #0C82DF'; }



            if (document.getElementById('<%=txtTo.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtTo.ClientID %>').style.border = '1px solid red';
                 document.getElementById('<%=txtTo.ClientID %>').focus();
                 return false;
             } else { document.getElementById('<%=txtTo.ClientID %>').style.border = '1px solid #0C82DF'; }

            if (document.getElementById('<%=txtSubject.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtSubject.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtSubject.ClientID %>').focus();
                return false;
            } else {
                document.getElementById('<%=txtSubject.ClientID %>').style.border = '1px solid #0C82DF';
              
            }



           

            return true;
        }
    </script>
    <div class="page_header">
    </div>
    <div class="main-content">
        <div class="panel">
            <div class="panel-body">
                <div class="form form-horizontal">
                    <div class="form-heading">
                        Vendor Product Search
                                  
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
                            <asp:Button ID="btnAddrole" runat="server" Text="Next" CssClass=" btn-danger" OnClick="btnAddrole_Click" />
                        </div>
                        <div class="clearfix">
                        </div>
                        
                        <div class="form-group">
                        <div class="col-sm-6">
                            <label class="control-label" style="font-weight: bold;">search Product :</label>
                            <div class="input-group" style="width:100%">
                                <asp:TextBox ID="txtsearchProduct" runat="server" CssClass="form-control" ></asp:TextBox>
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

                        
                        <div style="overflow-x: auto; overflow-y: auto; height: 450px" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server" >
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example1">
                                            <thead>
                                                <tr>
                                                    
                                                  
                                                    <th>Product Name
                                                    </th>
                                                    <th>Vendor Name
                                                    </th>
                                                     <th>Contact Person
                                                    </th>
                                                     <th>MobileNo
                                                    </th>
                                                    <th> Email
                                                    </th>
                                                    
                                                    
                                                  
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                         <td>
                                                <asp:Label ID="lblsubcategoryName" runat="server" Text='<%#Eval("subcategoryName") %>'></asp:Label>
                                           </td>
                                            <td>
                                                <asp:Label ID="lblVendorName" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>
                                           </td>
                                            <td>
                                                <asp:Label ID="lblContactPersonName" runat="server" Text='<%#Eval("ContactPersonName") %>'></asp:Label>
                                           </td>
                                               <td>
                                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                           </td>
                                               <td>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
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
                    <div id="divsavedata" runat="server" class="form form-horizontal" style="display: none;">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                            <asp:Button ID="imgbtnVrole" runat="server" Text="Back " CssClass="  btn-danger"
                                OnClick="imgbtnVbatch_Click" />
                        </div>
                        <div class="clearfix"></div>

                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                    From <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" Text="procurement@sislinfotech.com" ReadOnly="true">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="control-label">
                                    To <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control"  ReadOnly="true">
                                </asp:TextBox>
                            </div>
                            </div>

                        <div class="form-group">
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Subject <span class="red-info">* </span>:</label>
                                <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" Text="Enquiry for ">
                                </asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="control-label">
                                    Attachment :</label>
                                <asp:FileUpload ID="fileupload" runat="server" CssClass="form-control" >
                                </asp:FileUpload>
                            </div>
                            </div>
                            <div class="form-group">
                             <div class="col-sm-12">
                                <label class="control-label">
                                    Body <span class="red-info">* </span>:</label>
                               <asp:TextBox ID="txtEditor" TextMode="MultiLine" runat="server" CssClass="textEditor"
            onblur="Test()"></asp:TextBox>
        
        <asp:HiddenField ID="hdText" runat="server" />
<asp:HiddenField ID="hdProduct" runat="server" />
                            </div>

                        </div>
                      


                        <div class="form-group">
                            <div class="col-sm-offset-8 col-sm-4">
                                <asp:Button ID="btnproced" runat="server" class="btn btn-success" Text="Save" OnClick="btnproced_Click" OnClientClick="return Validate();" />
                                <asp:Button ID="imgbtnupdate" runat="server" class="btn btn-success" Text="Update" OnClientClick="return Validate();"
                                    OnClick="imgbtnupdate_Click" />
                                <asp:Button ID="btnrest" runat="server" class="btn btn-warning" Text="RESET" OnClick="btnrest_Click" />
                            </div>
                        </div>
                    </div>





                </div>
            </div>
        </div>
    </div>

    <script src="js/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="js/jquery-te-1.4.0.min.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $('.textEditor1').jqte();
    $(".textEditor").jqte({
        blur: function () {
            document.getElementById('<%=hdText.ClientID %>').value = document.getElementById('<%=txtEditor.ClientID %>').value;
    }
    });
</script>
    <Style type="text/css">
        a.jqte_tool_label.unselectable {
    height: 10% !important;
}
    </Style>
</asp:Content>


