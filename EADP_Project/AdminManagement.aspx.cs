using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        public string ip1, ip2, ip3, ip4, ip5, count1, count2, count3, count4, count5, flag_ips;

        protected void Page_Load(object sender, EventArgs e)
        {
            tb_blacklist.Text = File.ReadAllText(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt");
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

            var scope2 = engine.CreateScope();
            engine.ExecuteFile(@"C:\Users\Justin Tan\PycharmProjects\ASP_Test\test2.py", scope);
            var raw_content_2 = scope.GetVariable("raw_log_2");
            raw_content_2(inputContent);

            StreamReader readPythonIp = new StreamReader(@"C:\Users\Justin Tan\PycharmProjects\ASP_Test\ip_list.txt");
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

            StreamReader readPythonCount = new StreamReader(@"C:\Users\Justin Tan\PycharmProjects\ASP_Test\count_list.txt");
            count1 = readPythonCount.ReadLine();
            count2 = readPythonCount.ReadLine();
            count3 = readPythonCount.ReadLine();
            count4 = readPythonCount.ReadLine();
            count5 = readPythonCount.ReadLine();

            readPythonCount.Close();

            StreamReader readPythonIntruder = new StreamReader(@"C:\Users\Justin Tan\PycharmProjects\ASP_Test\flag_list.txt");
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
            File.WriteAllText(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt", updated_ip);

        }

        protected void btn_apply_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt", tb_blacklist.Text);

            //List<string> updated_ip = new List<string>();
            //updated_ip.Add(tb_blacklist.Text);
            //StreamWriter sw = File.WriteAllLines(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\App_Data\blacklist.txt", updated_ip);
        }

    }
}