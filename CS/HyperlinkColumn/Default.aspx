<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HyperlinkColumn._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.2, Version=8.2.3.0, Culture=neutral, PublicKeyToken=9b171c9fd64da1d1"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" 
            onload="ASPxGridView1_Load">
        </dxwgv:ASPxGridView>
    </div>
    </form>
</body>
</html>
