using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace EADP_Project
{
    public partial class AdminManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string number = "OnError hundred";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btn_python_Click(object sender, EventArgs e)
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.ExecuteFile(@"C:\Users\Justin Tan\PycharmProjects\ASP_Test\test.py");
        }
        
    }
}