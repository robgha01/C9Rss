<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoPage.aspx.cs" Inherits="C9Rss.Public.Web.DemoPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo Page Display data as simple website</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListViewDisplay" OnPagePropertiesChanging="ListViewDisplay_PagePropertiesChanging" runat="server">
                <ItemTemplate>
                    <h3><%# ((BlogItem)Container.DataItem).Title%></h3>
                    <h3><%# ((BlogItem)Container.DataItem).Summery%></h3>
                    <hr />
                    <br />
                </ItemTemplate>
            </asp:ListView>
            <asp:DataPager ID="DataPagerDisplay" runat="server" PagedControlID="ListViewDisplay" PageSize="5" QueryStringField="p">
                <Fields>
                    <asp:NumericPagerField ButtonType="Link" />
                </Fields>
        </asp:DataPager>
        </div>
    </form>
</body>
</html>