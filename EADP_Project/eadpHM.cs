using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EADP_Project.App_Start
{
    public class eadpHM : IHttpModule
    {
        private StreamWriter sw;
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            if (!File.Exists("logger.txt"))
            {
                sw = new StreamWriter(@"C:\Users\Justin Tan\Documents\GitHub\ASP_Project\EADP_Project\logger.txt");
            }
            else
            {
                sw = File.AppendText("logger.txt");
            }
            sw.WriteLine("User sends request at {0}", DateTime.Now);
            sw.Close();
        }
    }
}