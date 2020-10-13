<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="T157547.Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v19.1, Version=19.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script>
        function onExportButtonClick(s, e) {
            clientSpreadSheet.ApplyCellEdit();
        }
    </script>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxSpreadsheet ID="Spreadsheet" runat="server" ClientInstanceName="clientSpreadSheet" WorkDirectory="~/App_Data/WorkDirectory"></dx:ASPxSpreadsheet>
        <dx:ASPxButton ID="ExportButton" runat="server" Text="Export" OnClick="ExportButton_Click">
			<ClientSideEvents Click="onExportButtonClick" />
		</dx:ASPxButton>
    </div>
    </form>
</body>
</html>