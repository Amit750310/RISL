<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" MasterPageFile="~/Site.Master" Inherits="vms.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"  
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %> 
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
    <div class="main-content">
        <div class="row">
            <div class="col-md-3 col-sm-6 col-xs-12 nopad-right">
                <div class="dashboard-stats">
                    <a href="#">
                        <div class="left">
                            <h3 class="flatOrangec">
                                <asp:Label ID="lbltotalvendors" Text="" runat="server"></asp:Label>
                            </h3>
                            <h4>Test No</h4>
                        </div>
                    </a>
                    <div class="right flatOrange">
                        <i class="fa fa-tree"></i>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12 nopad-right">

                <div class="dashboard-stats">

                    <a href="#">
                        <div class="left">
                            <h3 class="flatRedc">
                                <asp:Label ID="lbltodayVendors" runat="server"></asp:Label>
                            </h3>
                            <h4>Test No
                            </h4>
                        </div>
                    </a>
                    <div class="right flatRed">
                        <i class="fa  fa-angle-double-down"></i>
                    </div>
                </div>

            </div>

        </div>

        <div class="form-group">
            <asp:DropDownList runat="server" ID="Projectname" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="Projectname_SelectedIndexChanged"></asp:DropDownList>

        </div>
        <div class="row" style="margin:2px">
      
        <asp:Chart ID="Chart1" runat="server" Height="520px" Width="520px">
            <Titles> 
            <asp:Title ShadowOffset="10" Name="Items" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
        </Legends>  
            <Series>
                <asp:Series Name="Deafult"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"  BorderWidth="0"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
           

        <asp:Chart ID="Chart2" runat="server" Height="520px" Width="520">
            <Titles> 
            <asp:Title ShadowOffset="10" Name="Items" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
        </Legends>  
            <Series>
                <asp:Series Name="Deafult"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea2"  BorderWidth="0"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
       
           </div>

         <div class="row" style="margin:2px">
            
                 <asp:Chart ID="Chart3" runat="server" Height="1000px" Width="1040px">
            <Titles> 
            <asp:Title ShadowOffset="10" Name="Items" />  
        </Titles>  
        <Legends>  
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"  
                LegendStyle="Row" />  
        </Legends>  
            <Series>
                <asp:Series Name="Deafult"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea3"  BorderWidth="0"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

               
           
        </div>


        <%--<script type="text/javascript">
            function HighlightSegment(segment) {
                segment.style.opacity = "0.7"; // Reduce opacity on hover
                segment.style.stroke = "black"; // Add a border effect
                segment.style.strokeWidth = "5";
            }

            function ResetSegment(segment) {
                segment.style.opacity = "1"; // Reset opacity
                segment.style.stroke = "none"; // Remove border effect
            }
</script>--%>

    </div>
   

</asp:Content>


