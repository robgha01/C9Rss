using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using C9Rss.Public.Domain.RssReader;
using C9Rss.Public.Domain.RssReader.Model;

namespace C9Rss.Public.Web
{
    public partial class DemoPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if(!IsPostBack)
            {
                BindDisplay();
            }
        }

        protected List<BlogItem> GetBlogItems()
        {
            var rssManager = new C9RssModelManager();

            var items = rssManager.ViewFeed() as List<BlogItem>;

            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items;
        }

        protected void BindDisplay()
        {
            ListViewDisplay.DataSource = GetBlogItems();
            ListViewDisplay.DataBind();
        }

        protected void ListViewDisplay_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPagerDisplay.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            BindDisplay();
        }
    }
}