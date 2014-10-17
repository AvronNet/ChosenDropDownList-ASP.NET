<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestDdl.aspx.cs" Inherits="TestDdl" %>

<%@ Register Assembly="ChosenDropDownList" Namespace="ChosenDropDownList" TagPrefix ="uc1"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test chosen ddl</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="smTest" runat="server"></asp:ScriptManager>
        <div>
            <asp:Label Text="Test Chosen DropDownList" Font-Bold="true" Font-Size="Larger" runat="server" />
            <br />
            <table>
                <tr>
                    <th><asp:Label Text="Regular DropDown" runat="server" /></th>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTest">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnCddl" runat="server" />
            <%--<uc1:ChosenDropDownList runat="server" ID="cddlTest" Width="400px" NoResultsText="Nema rezultata" 
                PlaceholderTextMultiple="Odaberite neke opcije" OnDataBinding="cddlTest_DataBinding" HiddenFieldID="hdnCddl"
                 DefaultSelectedValues="5,4"/>--%>
            <br />
            
            <br />
        </div>
        <br />
        <uc1:ChosenDropDownList ID="cddl" runat="server" Width="400px" />
        <br />
        <br />
        <asp:Button Text="Action" runat="server" ID="btnAction" OnClick="btnAction_Click"/>
        <br />
        <asp:Label Text="End of page" runat="server" />
    </form>
</body>
    
</html>
