<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatusMaster.aspx.cs" Inherits="vms.StatusMaster" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="head">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        function ValidateSave() {
           <%-- if (document.getElementById('<%=txtcategory.ClientID %>').value.trim() == "") {
                document.getElementById('<%=txtcategory.ClientID %>').style.border = '1px solid red';
                document.getElementById('<%=txtcategory.ClientID %>').focus();
                return false;
            } return true;--%>
        }
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;

            return true;
        }

        function updateUnitCost(selectElement) {
            const selectedServiceType = selectElement.value;
            debugger;
            const unitCost = selectedServiceType;    // serviceTypeCostMapping[selectedServiceType] || 0; // Default to 0 if no match found
            alert(unitCost);
            // Find the Unit Cost input in the same row and set its value
            const row = selectElement.closest("tr");
            const unitCostInput = row.cells[5].getElementsByTagName("input")[0];
            unitCostInput.value = unitCost;

            // Update the total amount for this row
            updateTotal();
        }
        function addRow() {
            const table = document.getElementById("serviceTable").getElementsByTagName("tbody")[0];
            const rowCount = table.rows.length;
            const row = table.insertRow(rowCount);

            row.innerHTML = `
        <td>${rowCount + 1}</td>
        <td>
            <select class="form-control" onchange="updateUnitCost(this)>
                     <option value="100">Turnkey</option>
                     <option value="200">Led</option>
                     <option value="300">Router</option>
                <!-- Add other options here if needed -->
            </select>
        </td>
        <td><input type="text" class="form-control" /></td>
        <td><input type="number" class="form-control" value="0" oninput="updateTotal()" /></td>
        <td>
            <select class="form-control">
                <option value="Nos">Nos.</option>
                <!-- Add other options here if needed -->
            </select>
        </td>
        <td><input type="text" class="form-control" value="0"  /></td>
        <td><input type="text" class="form-control" value="0"  /></td>
        <td><button type="button" class="btn btn-danger" onclick="removeRow(this)">Delete</button></td>
    `;
        }

        function removeRow(button) {
            const row = button.closest("tr");
            row.remove();
            updateTotal();
        }

        function updateTotal() {
            let total = 0;
            const rows = document.getElementById("serviceTable").getElementsByTagName("tbody")[0].rows;

            for (let i = 0; i < rows.length; i++) {
                const quantity = parseFloat(rows[i].cells[3].getElementsByTagName("input")[0].value) || 0;
                const unitCost = 100 * quantity;
                const totalAmount = quantity * unitCost;

                rows[i].cells[6].getElementsByTagName("input")[0].value = totalAmount.toFixed(2);
                total += totalAmount;
            }

            document.getElementById("totalAmount").textContent = total.toFixed(2);
            document.getElementById("rislCharges").textContent = total.toFixed(2);
            document.getElementById("cgstAmount").textContent = total.toFixed(2);
            // Update other charges based on the total if necessary
        }



    </script>

    <script type="text/javascript">

        function saveServiceItems() {
            const deptNAme = document.getElementById("drddept").value;
            const OICNAme = document.getElementById("txtOIC").value;
            const TO = document.getElementById("txtTo").value;
            const Subject = document.getElementById("TxtSubject").value;
            const Ref = document.getElementById("TxtRef").value;
            const Fileno = document.getElementById("txtFileNo").value;

            const rows = document.getElementById("serviceTable").getElementsByTagName("tbody")[0].rows;
            const serviceItems = [];

            for (let i = 0; i < rows.length; i++) {
                const row = rows[i];
                const serviceItem = {
                    SerialNumber: i + 1,
                    ServiceType: row.cells[1].querySelector("select").value,
                    Description: row.cells[2].querySelector("input").value,
                    Quantity: parseInt(row.cells[3].querySelector("input").value) || 0,
                    Unit: row.cells[4].querySelector("select").value,
                    UnitCost: parseFloat(row.cells[5].querySelector("input").value) || 0,
                    TotalAmount: parseFloat(row.cells[6].querySelector("input").value) || 0
                };
                serviceItems.push(serviceItem);
            }
            debugger;
            // Send data to the server
            $.ajax({
                type: "POST",
                url: "StatusMaster.aspx/SaveServiceItems",
                data: JSON.stringify({
                    serviceItems: serviceItems,
                    deptNAme: deptNAme,
                    OICNAme: OICNAme,
                    TO: TO,
                    Subject: Subject,
                    Ref: Ref,
                    Fileno: Fileno
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    window.location.href = "StatusMaster.aspx";
                    alert(response.d ? "Data saved successfully!" : "Error saving data.");
                },
                error: function (error) {
                    console.error("Error:", error);
                }
            });
        }


    </script>

    <div class="main-content">
        <div class="panel">
            <div class="panel-body" style="min-height: 400px">
                <div class="form form-horizontal">
                    <div class="form-heading">
                        Status Master
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
                            <asp:Button ID="btnAddrole" runat="server" Text="Add" CssClass=" btn-danger" OnClick="btnAddrole_Click" />
                        </div>
                        <div class="clearfix">
                        </div>
                        <div style="overflow-x: auto; overflow-y: auto; height: 450px" id="DivMainContent">
                            <div class="table-responsive">
                                <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-hover table-striped display" id="example">
                                            <thead>
                                                <tr>
                                                    <th>Name 
                                                    </th>
                                                    <th>Action
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>

                                            <td>
                                                <asp:Label ID="lblcategoryname" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                <asp:Label ID="lblcategory_id" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Button ID="imgbtnEdit" class="btn btn-primary btn-icon-primary" Text="Edit"
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
                    <!--form-heading-->
                    <div id="divsavedata" runat="server" class="form form-horizontal" style="display: none;">
                        <div class="btn-group pull-right" style="padding-bottom: 5px;">
                            <asp:Button ID="imgbtnVrole" runat="server" Text="View " CssClass="  btn-danger"
                                OnClick="imgbtnVbatch_Click" />
                        </div>
                        <div class="clearfix"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                <asp:HiddenField ID="hfcategory_ID" runat="server" />
                                Name :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtcategory" runat="server" CssClass="form-control"></asp:TextBox>
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

                   <%-- <div class="clearfix"></div>
                    <div id="div2" class="form form-horizontal" style="display: block;">
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
                    <div id="div1" runat="server" height="Auto" class="form form-horizontal" style="display: block;">
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


                    <input type="button" id="btnsubmit" value="submit" onclick="saveServiceItems()" />--%>


                </div>
            </div>
        </div>
    </div>


</asp:Content>
