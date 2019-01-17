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
            
        }

        protected void btn_upload_file_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(FileUpload_Log.PostedFile.InputStream);
            string inputContent = sr.ReadToEnd();
            tb_log_raw.Text = inputContent;

            ScriptEngine engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            engine.ExecuteFile(@"C:\Users\Justin Tan\PycharmProjects\ASP_Test\test.py", scope);
            var raw_content = scope.GetVariable("raw_log");
            raw_content(inputContent);
            var raw_content_2 = scope.GetVariable("raw_log_2");
            raw_content_2(inputContent);
        }
    }
}