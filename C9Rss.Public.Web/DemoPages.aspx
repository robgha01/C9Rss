<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoPages.aspx.cs" Inherits="C9Rss.Public.Web.DemoPages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Demo pages</h1>
        <ul>
            <li>1. <a href="DemoPage.aspx?p=1">View rss as simple website</a></li>
            <li>2. <a href="FeedDemoPage.aspx?p=1">View rss as atom feed</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
