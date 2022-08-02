<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AkashNProject.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="fullname" runat="server" Text="FullName"></asp:Label>
            <asp:TextBox ID="txtfullname" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfullname" ErrorMessage="Name Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:Label ID="lblmobileno" runat="server" Text="MobileNo"></asp:Label>
            <asp:TextBox ID="txtmobileno" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmobileno" ErrorMessage="MobileNo Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:Label ID="lblemail" runat="server" Text="EmailID"></asp:Label>
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" ErrorMessage="Email Is Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:Label ID="lblcomapny" runat="server" Text="CompanyName"></asp:Label>
            <asp:TextBox ID="txtcomapny" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcomapny" ErrorMessage="Company Name Is Mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />

            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <tr>
                                <td>EmployeeId</td>
                                <td>
                                    <asp:Label ID="id" runat="server" Text='<%#Eval("EmpID")%>' />
                                </td>
                            </tr>
                        </tr>

                        <tr>
                            <td>FullName</td>
                            <td>
                                <asp:Label ID="lblfullname" runat="server" Text='<%#Eval("FullName")%>' />
                                <asp:TextBox ID="txtfullname" runat="server" Text='<%#Eval("FullName")%>' Visible="false" />
                            </td>
                        </tr>

                        <tr>
                            <td>MobileNo</td>
                            <td>
                                <asp:Label ID="lblmobileno" runat="server" Text='<%#Eval("MobileNo")%>' />
                                <asp:TextBox ID="txtmobileno" runat="server" Text='<%#Eval("MobileNo")%>' Visible="false" />
                            </td>
                        </tr>

                        <tr>
                            <td>EmailId</td>
                            <td>
                                <asp:Label ID="lblemail" runat="server" Text='<%#Eval("EmailId")%>' />
                                <asp:TextBox ID="txtemail" runat="server" Text='<%#Eval("EmailId")%>' Visible="false" />
                            </td>
                        </tr>

                        <tr>
                            <td>CompanyName</td>
                            <td>
                                <asp:Label ID="lblcompany" runat="server" Text='<%#Eval("CompanyName")%>' />
                                <asp:TextBox ID="txtcompany" runat="server" Text='<%#Eval("CompanyName")%>' Visible="false" />
                            </td>   
                        </tr>




                    </table>
                    <asp:LinkButton ID="linedit" runat="server" OnClick="linedit_Click">Edit</asp:LinkButton>
                    <asp:LinkButton ID="lknupdate" runat="server" OnClick="lknupdate_Click">Update</asp:LinkButton>
                    <asp:LinkButton ID="lkndelete" runat="server" OnClick="lkndelete_Click">Delete</asp:LinkButton>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
