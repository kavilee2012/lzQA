using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImageView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Request.QueryString["url"].ToString();
        this.Image1.ImageUrl = path;
    }
}
