<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSqlTest.Pages.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Words - WebSqlTest</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
    <script src="../Scripts/site.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <header>
                <h1>Words Application</h1>
            </header>

            <div class="stats-section">
                <asp:Label ID="lblStats" runat="server" CssClass="stats-info"></asp:Label>
            </div>

            <!-- Search Section -->
            <div class="search-section">
                <div class="search-box">
                    <label for="txtEnglishWord">English word</label>
                    <asp:TextBox ID="txtEnglishWord" runat="server" CssClass="form-input" placeholder="Enter word to search"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>

            <!-- Add Word Section -->
            <asp:Panel ID="pnlAddWord" runat="server" Visible="false" CssClass="add-word-section">
                <table class="word-table">
                    <tr>
                        <th>Word</th>
                        <th>Translation</th>
                        <th>Action</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFoundWord" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTranslation" runat="server" CssClass="form-input" placeholder="Enter translation"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnAddToMyWords" runat="server" Text="Add to My words" 
                                       CssClass="btn btn-success" OnClick="btnAddToMyWords_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <!-- Message Panel -->
            <asp:Panel ID="pnlMessage" runat="server" Visible="false">
                <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            </asp:Panel>

            <!-- My Words Section -->
            <div class="my-words-section">
                <h3>My words</h3>
                <asp:GridView ID="gvMyWords" runat="server" AutoGenerateColumns="false" 
                             CssClass="words-grid" EmptyDataText="No words added yet.">
                    <Columns>
                        <asp:BoundField DataField="EnglishWord" HeaderText="Word" />
                        <asp:BoundField DataField="Translation" HeaderText="Translation" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
