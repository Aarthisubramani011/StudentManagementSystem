<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentTable.aspx.cs" Inherits="StudentManagement.StudentManagement.UI.StudentTable" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Management System</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }

        body {
            background-color: #e8e8e8;
            font-family: Arial, sans-serif;
            padding: 30px;
        }

        h1 {
            font-size: 22px;
            color: #333;
            margin-bottom: 16px;
            text-align:center;
        }

        .container {
            background: #fff;
            border-radius: 8px;
            padding: 20px;
            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
        }

        .top-bar {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 16px;
        }

        .btn-add input[type="submit"],
        .btn-add button {
            background-color: #666;
            color: #fff;
            border: none;
            padding: 8px 16px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 13px;
        }

        .btn-add input[type="submit"]:hover,
        .btn-add button:hover {
            background-color: #555;
        }

        #GridView1 {
            width: 100%;
            border-collapse: collapse;
            font-size: 13px;
        }

        #GridView1 th {
            background-color: #777 !important;
            color: #fff !important;
            padding: 10px 12px !important;
            text-align: left;
            font-weight: bold;
        }

        #GridView1 td {
            padding: 9px 12px !important;
            color: #333 !important;
            border-bottom: 1px solid #ddd !important;
            background: #fff !important;
        }

        #GridView1 tr:hover td {
            background-color: #f2f2f2 !important;
        }

        #GridView1 tr:last-child td {
            border-bottom: none !important;
        }

        
        #GridView1 input[type="submit"],
        #GridView1 button {
            padding: 5px 11px;
            border-radius: 4px;
            border: 1px solid #bbb;
            cursor: pointer;
            font-size: 12px;
            background-color: #f0f0f0;
            color: #444;
            margin-right: 4px;
        }

        #GridView1 input[type="submit"]:hover,
        #GridView1 button:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Student Management System</h1>
        <div class="container">
            <div class="top-bar">
                <span style="font-size:14px; color:#666;">All Students</span>
                <div class="btn-add">
                    <asp:Button ID="Button1" runat="server" Text="+ Add Student"  OnClick="Addform"/>
                </div>
            </div>

            <asp:GridView ID="GridView1" runat="server"
                CellPadding="0"
                GridLines="None"
                Width="100%"
                AutoGenerateColumns="False"
                HeaderStyle-BackColor="#777777"
                HeaderStyle-ForeColor="White"
                HeaderStyle-Font-Bold="true"
                RowStyle-BackColor="#ffffff"
                AlternatingRowStyle-BackColor="#f7f7f7">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Rollno"      HeaderText="Roll No" />
                    <asp:BoundField DataField="Department"  HeaderText="Department" />
                    <asp:BoundField DataField="Year"       HeaderText="Year" />
                    <asp:BoundField DataField="Gender"      HeaderText="Gender" />
                    <asp:BoundField DataField="DOB"         HeaderText="DOB" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Country"     HeaderText="Country" />
                    <asp:BoundField DataField="Address"     HeaderText="Address" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Edit"
     CommandArgument='<%# Eval("Rollno") %>' OnClick="EditStudentClick" />
                          <asp:Button runat="server" Text="Delete"
     CommandArgument='<%# Eval("Rollno") %>' OnClick="DeleteStudentClick" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
