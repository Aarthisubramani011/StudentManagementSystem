<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="StudentForm.aspx.cs"
    Inherits="StudentManagement.StudentManagement.UI.StudentForm"
    Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            background-color: #d3d3d3;
            font-family: Arial;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            width: 100%;
        }


        .form-container {
            width: 500px;
            margin: auto auto auto auto;
            background: #e6e6e6;
            padding: 30px;
            border-radius: 10px;
        }



        h1 {
            text-align: center;
            margin-bottom: 30px;
        }

        .form-row {
            display: grid;
            grid-template-columns: 150px 1fr;
            align-items: center;
            margin-bottom: 15px;
        }

        .input {
            width: 100%;
            padding: 5px;
        }

        .buttons {
            text-align: center;
            margin-top: 20px;
        }

            .buttons input {
                margin: 10px;
                padding: 10px 20px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">

            <h1>Student Form</h1>

            <div class="form-row">
                <label>Student Name</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="TextBox1" ErrorMessage="required!" ForeColor="blue"></asp:RequiredFieldValidator>
            </div>

            <div class="form-row">
                <label>RollNo</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="input"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rvfrollno" runat="server" ControlToValidate="TextBox1" ErrorMessage="required!" ForeColor="blue"></asp:RequiredFieldValidator>
            </div>

            <div class="form-row">
                <label>Department</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input">
                    <asp:ListItem Value="">Select Department </asp:ListItem>
                    <asp:ListItem>CSE</asp:ListItem>
                    <asp:ListItem>ECE</asp:ListItem>
                    <asp:ListItem>EEE</asp:ListItem>
                    <asp:ListItem>Mech</asp:ListItem>
                    <asp:ListItem>IT</asp:ListItem>
                    <asp:ListItem>Civil</asp:ListItem>
                </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rvfdept" runat="server" ControlToValidate="DropDownList1" ErrorMessage="required!" ForeColor="blue"></asp:RequiredFieldValidator>
            </div>

            <div class="form-row">
                <label>Year</label>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="input">
                   <asp:ListItem Value=""> Select year</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>II</asp:ListItem>
                    <asp:ListItem>III</asp:ListItem>
                    <asp:ListItem>IV</asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rvfyear" runat="server"  InitialValue=""
 ControlToValidate="DropDownList2"  ErrorMessage="required!" ForeColor="blue"></asp:RequiredFieldValidator>
            </div>

            <div class="form-row" style="display: flex; align-items: center; gap: 10px;">
                <label id="rblGender" runat="server">Gender</label>
                <asp:RadioButtonList ID="gender" Style= "margin-left: 84px" runat="server" >
                    <asp:ListItem Text="Male" value="Male"  runat="server" ></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"  runat="server"></asp:ListItem>
                    
                </asp:RadioButtonList>
               <asp:RequiredFieldValidator ID="rvfgender" runat="server" ControlToValidate="gender" ErrorMessage="required!" ForeColor="blue"></asp:RequiredFieldValidator>
          

            </div>

          <div class="form-row">
    <label>DOB</label>
    <asp:TextBox ID="txtDob" runat="server" TextMode="Date" CssClass="input"></asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvdob" 
        runat="server" 
        ControlToValidate="txtDob" 
        ErrorMessage="required!" 
        ForeColor="blue">
    </asp:RequiredFieldValidator>
</div>

            <div class="form-row">
                <label>Country</label>
                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="input">
                    <asp:ListItem Value="">Select country </asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>Nepal</asp:ListItem>
                    <asp:ListItem>Australia</asp:ListItem>
                    <asp:ListItem>France</asp:ListItem>
                    <asp:ListItem>Germany</asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rvfcountry" runat="server" ControlToValidate="DropDownList3" ErrorMessage="required!" ForeColor="blue"></asp:RequiredFieldValidator>
            </div>

            <div class="form-row">
                <label>Address</label>
                <asp:TextBox ID="CommentsTextBox" runat="server" TextMode="MultiLine" CssClass="input"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rvfaddress" runat="server" ControlToValidate="CommentsTextBox" ErrorMessage="required!" ForeColor="blue"></asp:RequiredFieldValidator>
            </div>

            <div class="buttons">
                <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="btn_cancel"/>
                <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="btn_submit" />
            </div>

        </div>



    </form>
</body>
</html>
