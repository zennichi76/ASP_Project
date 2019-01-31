using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP_Project.BO;
using EADP_Project.Entities;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Configuration;
using System.Web.Configuration;

namespace EADP_Project
{
    public partial class AdminManagement : System.Web.UI.Page
    {
        private StreamWriter sw;
        public string ip1, ip2, ip3, ip4, ip5, count1, count2, count3, count4, count5, flag_ips;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);

                if (Session["LoginUserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null && Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))  /*End of Session Fixation*/
                    {

                        UserBO userbo = new UserBO();
                        String currentLoggedInUser = Request.Cookies["CurrentLoggedInUser"].Value;
                        user userobj = new user();
                        userobj = userbo.getUserById(currentLoggedInUser);
                        if (userobj.role != "Admin")
                        {
                            //  clear session
                            Session.Clear();
                            Session.Abandon();
                            Session.RemoveAll();
                            if (Request.Cookies["ASP.NET_SessionId"] != null)
                            {
                                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                            }
                            if (Request.Cookies["AuthToken"] != null)
                            {
                                //Empty Cookie
                                Response.Cookies["AuthToken"].Value = string.Empty;
                                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                            }
                            if (Request.Cookies["CurrentLoggedInUser"] != null)
                            {
                                //Empty Cookie
                                Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                                Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                            }
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                            Response.Redirect("LoginPage.aspx");
                        }
                        else
                        {
                         

                        }

                    }
                }
                else
                {
                    //  clear session
                    Session.Clear();
                    Session.Abandon();
                    Session.RemoveAll();
                    if (Request.Cookies["ASP.NET_SessionId"] != null)
                    {
                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                    }
                    if (Request.Cookies["AuthToken"] != null)
                    {
                        //Empty Cookie
                        Response.Cookies["AuthToken"].Value = string.Empty;
                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                    }
                    if (Request.Cookies["CurrentLoggedInUser"] != null)
                    {
                        //Empty Cookie
                        Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                        Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                    Response.Redirect("LoginPage.aspx");
                }
            }
            catch
            {
                //  clear session
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["AuthToken"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["AuthToken"].Value = string.Empty;
                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                    Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                Response.Redirect("LoginPage.aspx");
            }

            tb_blacklist.Text = File.ReadAllText(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\blacklist.txt");
            PopulateGVUsers();
        }
        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            PopulateGVUsers();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateGVUsers();
        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGVUsers();
            }
        }

        protected void btn_upload_file_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(FileUpload_Log.PostedFile.InputStream);
            string inputContent = sr.ReadToEnd();
            tb_log_raw.Text = inputContent;

            ScriptEngine engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            engine.ExecuteFile(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/Python_Scripts/test.py", scope);
            //engine.ExecuteFile(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\Python_Scripts\test.py", scope);
            var raw_content = scope.GetVariable("raw_log");
            raw_content(inputContent);

            var scope2 = engine.CreateScope();
            engine.ExecuteFile(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/Python_Scripts/test2.py", scope2);
            //engine.ExecuteFile(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\Python_Scripts\test2.py", scope2);
            var raw_content_2 = scope2.GetVariable("raw_log_2");
            raw_content_2(inputContent);

            StreamReader readPythonIp = new StreamReader(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/App_data/ip_list.txt");
            //StreamReader readPythonIp = new StreamReader(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\ip_list.txt");
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
            //StreamReader readPythonCount = new StreamReader(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\count_list.txt");
            count1 = readPythonCount.ReadLine();
            count2 = readPythonCount.ReadLine();
            count3 = readPythonCount.ReadLine();
            count4 = readPythonCount.ReadLine();
            count5 = readPythonCount.ReadLine();

            readPythonCount.Close();

            StreamReader readPythonIntruder = new StreamReader(@"C:/Users/Yun/Desktop/ASP_Project/ASP_Project/EADP_Project/App_data/flag_list.txt");
            //StreamReader readPythonIntruder = new StreamReader(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\flag_list.txt");
            flag_ips = readPythonIntruder.ReadToEnd().ToString();
            tb_flag.Text = flag_ips;
            readPythonIntruder.Close();
        }

        protected void btn_begin_trace_Click(object sender, EventArgs e)
        {
            StreamReader sr_iptrace = new StreamReader(FileUpload_iptrace.PostedFile.InputStream);
            var logList = new List<string>();

            while (sr_iptrace.ReadLine() != null)
            {
                if(sr_iptrace.ReadLine() != null)
                {
                    string data = sr_iptrace.ReadLine();
                    if (data.Contains(tb_ip_trace.Text.ToString()))
                    {
                        logList.Add(data);
                    }
                }
            }
            tb_usertraffic.Text = string.Join("\n", logList.ToArray());
        }

        protected void tb_blacklist_TextChanged(object sender, EventArgs e)
        {
            string updated_ip = tb_blacklist.Text;
            File.WriteAllText(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\blacklist.txt", updated_ip);

        }

        protected void btn_apply_Click(object sender, EventArgs e)
        {
            sw = File.AppendText(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\blacklist.txt");
            sw.Write("\n" + tb_crud.Text.ToString().Trim());
            sw.Close();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

            //File.WriteAllText(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt", tb_blacklist.Text);
            //File.WriteAllText(@"~\App_Data\blacklist.txt", tb_blacklist.Text);

            //string path = HttpContext.Current.Server.MapPath("~/App_Data/blacklisk.txt");
            //Stream w = new FileStream(path, FileMode.Create);

            //List<string> updated_ip = new List<string>();
            //updated_ip.Add(tb_blacklist.Text);
            //StreamWriter sw = File.WriteAllLines(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt", updated_ip);
        }

        protected void btn_remove_Click(object sender, EventArgs e)
        {
            //StreamReader sr = File.OpenText(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt");
            //string[] blacklist_data = File.ReadAllLines(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt");
            //if (blacklist_data.Contains(tb_blacklist.Text.ToString().Trim()))
            //{
            //    blacklist_data = blacklist_data.Removeall;
            //    blacklist_data.RemoveAll(u => u.Contains());
            //}
            //sr.Close();

            string search_text = tb_crud.Text.ToString().Trim();
            string old;
            string n = "";
            StreamReader sr = File.OpenText(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\blacklist.txt");
            while ((old = sr.ReadLine()) != null)
            {
                if (!old.Contains(search_text))
                {
                    n += old + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(@"C:\Users\Yun\Desktop\ASP_Project\ASP_Project\EADP_Project\App_Data\blacklist.txt", n.Trim());
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        //session fixation for timeout
        protected void RemoveSessionBtn_OnClick(object Source, EventArgs e)
        {
            try
            {
                //  clear session
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["AuthToken"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["AuthToken"].Value = string.Empty;
                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                }
                if (Request.Cookies["CurrentLoggedInUser"] != null)
                {
                    //Empty Cookie
                    Response.Cookies["CurrentLoggedInUser"].Value = string.Empty;
                    Response.Cookies["CurrentLoggedInUser"].Expires = DateTime.Now.AddMonths(-20);
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "sessionStorage.removeItem(browid);", true);
                Response.Redirect("LoginPage.aspx");
            }
            catch
            {

            }


        }

        //session reset
        protected void ResetSessionBtn_OnClick(object Source, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session["Reset"] = true;
                //Session["Reset"] = true;
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);

            }
            catch
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openFModal();", true);

            }

        }


    }
}