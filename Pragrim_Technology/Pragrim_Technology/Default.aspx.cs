using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int clickcount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            txt.Text = "0";
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        if (ViewState["click"] != null)
        {
            clickcount = (int)ViewState["click"] + 1;
        }
        txt.Text = Convert.ToString(clickcount);
        ViewState["click"] = clickcount;
    }


}
