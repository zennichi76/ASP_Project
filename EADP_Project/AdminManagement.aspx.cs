using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP_Project.BO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace EADP_Project
{
    public partial class AdminManagement : System.Web.UI.Page
    {
        public string ip1, ip2, ip3, ip4, ip5, count1, count2, count3, count4, count5, flag_ips;

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            PopulateGVUsers();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGVUsers();
        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGVUsers();
            }
        }

        void PopulateGVUsers()
        {
            string selectedUsers = tbSearch.Text.Trim();
            UserBO userinfobo = new UserBO();
            DataTable dt = new DataTable();
            dt = userinfobo.getUserInfo(selectedUsers);
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
           
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
            engine.ExecuteFile(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/Python_Scripts/test.py", scope);
            var raw_content = scope.GetVariable("raw_log");
            raw_content(inputContent);

            var scope2 = engine.CreateScope();
            engine.ExecuteFile(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/Python_scripts/test2.py", scope);
            var raw_content_2 = scope.GetVariable("raw_log_2");
            raw_content_2(inputContent);

            StreamReader readPythonIp = new StreamReader(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/App_data/ip_list.txt");
            try
            {
                ip1 = readPythonIp.ReadLine().ToString();
            }
            catch (NullReferenceException)
            {
                ip1 = "";
            }
            try
            {
                ip2 = readPythonIp.ReadLine().ToString();
            }
            catch (NullReferenceException)
            {
                ip2 = "";
            }
            try
            {
                ip3 = readPythonIp.ReadLine().ToString();
            }
            catch (NullReferenceException)
            {
                ip3 = "";
            }
            try
            {
                ip4 = readPythonIp.ReadLine().ToString();
            }
            catch (NullReferenceException)
            {
                ip4 = "";
            }
            try
            {
                ip5 = readPythonIp.ReadLine().ToString();
            }
            catch (NullReferenceException)
            {
                ip5 = "";
            }

            readPythonIp.Close();

            StreamReader readPythonCount = new StreamReader(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/App_data/count_list.txt");
            count1 = readPythonCount.ReadLine();
            count2 = readPythonCount.ReadLine();
            count3 = readPythonCount.ReadLine();
            count4 = readPythonCount.ReadLine();
            count5 = readPythonCount.ReadLine();

            readPythonCount.Close();

            StreamReader readPythonIntruder = new StreamReader(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/App_data/flag_list.txt");
            flag_ips = readPythonIntruder.ReadToEnd().ToString();
            tb_flag.Text = flag_ips;
            readPythonIntruder.Close();
        }
            
    }
}