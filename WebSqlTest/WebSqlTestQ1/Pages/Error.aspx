<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebSqlTest.Pages.Error" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Word Not Found - WebSqlTest</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="error-section">
                <h2>Word Not Found</h2>
                <div class="error-message">
                    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                </div>
                <div class="error-actions">
                    <asp:Button ID="btnGoBack" runat="server" Text="Try Another Word" 
                               CssClass="btn btn-primary" OnClick="btnGoBack_Click" />
                </div>
                
                <!-- Available words -->
                <div class="available-words-section">
                    <h4>Available words to search:</h4>
                    <asp:Label ID="lblAvailableWords" runat="server" CssClass="available-words"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
