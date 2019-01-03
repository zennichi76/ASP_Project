using EADP_Project.BO;
using EADP_Project.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{


    public partial class ResetSecurityQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void cancelButton()
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void submitEmailBtn_Click(object sender, EventArgs e)
        {
            passwordPanel.Visible = true;
            emailPanel.Visible = false;
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            //revert back to original
            Response.Redirect("LoginPage.aspx");
        }

        private static Random rng = new Random();
        public static void Shuffle<T>(IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            //var random = new Random();
            //for (int index = list.Count - 1; index >= 1; index--)
            //{
            //    int other = random.Next(0, index + 1);
            //    T temp = list[index];
            //    list[index] = list[other];
            //    list[other] = temp;
            //}
        }

        protected void submitPasswordBtn_Click(object sender, EventArgs e)
        {
            //move to reset sec q 
            answerSecurityQ.Visible = true;
            passwordPanel.Visible = false;
            emailPanel.Visible = false;
            string userId = inputIdTB.Text;


            RegistrationBO getQuestions = new RegistrationBO();
            // SecurityQuestions sqObj = new SecurityQuestions();
            SecurityQuestions sqObj = getQuestions.GetSQById(userId);
            List<String> templist = new List<String>();
            List<Byte[]> getlist = new List<Byte[]>();

            var tupleList = new List<Tuple<Byte[], String>>();
            tupleList.Add(new Tuple<Byte[], String>(sqObj.firstSecurityQ, sqObj.firstSecurityQA.ToString()));
            tupleList.Add(new Tuple<Byte[], String>(sqObj.secondSecurityQ, sqObj.secondSecurityQA.ToString()));
            tupleList.Add(new Tuple<Byte[], String>(sqObj.thirdSecurityQ, sqObj.thirdSecurityQA.ToString()));
      
            Shuffle(tupleList);


            for (int i = 0; i < 2; i++)
            {
                byte[] questionOne = tupleList[0].Item1;
                string questionOneAns = tupleList[0].Item2;
                byte[] questionTwo = tupleList[1].Item1;
                string questionTwoAns = tupleList[1].Item2;
             //   byte[] secBytes = (byte[])sqObj.secondSecurityQ;

                Image1.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionOne);
                Image2.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionTwo);

            }

        }

        protected void submitAnsweredSQBtn_Click(object sender, EventArgs e)
        {
            resetSeurityPanel.Visible = true;
            answerSecurityQ.Visible = false;
            passwordPanel.Visible = false;
            emailPanel.Visible = false;
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            cancelButton();
        }

        protected void submitSQBtn_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Your Security Questions have been updated!');window.location ='LoginPage.aspx';", true);
            //string display = "Your Security Questions have been updated!";
            //ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('" + display + "');", true);

            //Response.Redirect("LoginPage.aspx");
        }
    }
}