﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrackTrace
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;

        }

        protected void SubmitButton_Click(object sender, EventArgs e)

        {
            //display output
            Response.Redirect("/Track-and-Trace.aspx?awb=" + awb_number.Value);
        }
    }
}