using EADP_Project.BO;
using EADP_Project.Entities;
using Shipwreck.Phash;
using Shipwreck.Phash.Bitmaps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
            if (!IsPostBack)
            {
                getImages(inputIdTB.Text.ToString());
            }
        }

        public void cancelButton()
        {
            inputIdTB.Text = null;
            inputPasswordTB.Text = null;
            securityQntAnsTB.Text = null;
            firstImageAnsTB.Text = null;
            secondImageAnsTB.Text = null;
            thirdImageAnsTB.Text = null;
            Response.Redirect("LoginPage.aspx");
        }

        public bool getUser()
        {
            string inputId = inputIdTB.Text.ToString();
            user returnedObj = new user();
            UserBO login_bo = new UserBO();
            returnedObj = login_bo.getUserById(inputId);
            if(returnedObj == null)
            {
                return false; //user No exist
            }
            else
            {
                return true;
            }
        }

        //check if user input password is correct
        public bool checkPW()
        {
            user returnedObj = new user();
            string inputId = inputIdTB.Text.ToString();
            String input_password = inputPasswordTB.Text;
            UserBO login_bo = new UserBO();
            returnedObj = new user();
            returnedObj = login_bo.login_validation(inputId, input_password);
            if (returnedObj == null)
            {
                return false; //pw wrong
            }
            else
            {
                return true;
            }

        }


        protected void submitIdBtn_Click(object sender, EventArgs e)
        {
            bool userExist = getUser();
            if(userExist == false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('User Does Not Exist!');", true);
                inputIdTB.Text = null;
            }
            else
            {
                passwordPanel.Visible = true;
                emailPanel.Visible = false;
            }

           
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            //revert back to original
            inputIdTB.Text = null;
            inputPasswordTB.Text = null;
            securityQntAnsTB.Text = null;
            firstImageAnsTB.Text = null;
            secondImageAnsTB.Text = null;
            thirdImageAnsTB.Text = null;
            Response.Redirect("LoginPage.aspx");

        }

      

        public void getImages(string userId)
        {
            try
            {
                RegistrationBO getQuestions = new RegistrationBO();
                SecurityQuestions sqObj = getQuestions.GetSQById(userId);

                //load image into dropdown
                List<String> templist = new List<String>();

                var tupleList = new List<Tuple<Byte[], String>>();
                tupleList.Add(new Tuple<Byte[], String>(sqObj.firstSecurityQ, sqObj.firstSecurityQA.ToString()));
                tupleList.Add(new Tuple<Byte[], String>(sqObj.secondSecurityQ, sqObj.secondSecurityQA.ToString()));
                tupleList.Add(new Tuple<Byte[], String>(sqObj.thirdSecurityQ, sqObj.thirdSecurityQA.ToString()));

                byte[] questionOne = tupleList[0].Item1;
                string questionOneAns = tupleList[0].Item2;
                byte[] questionTwo = tupleList[1].Item1;
                string questionTwoAns = tupleList[1].Item2;
                byte[] questionThree = tupleList[2].Item1;
                string questionThreeAns = tupleList[2].Item2;

                imageDDL.Items.Insert(0, new ListItem("--Select--", ""));
                imageDDL.Items.Insert(1, new ListItem("Image 1", Convert.ToBase64String(questionOne)));
                imageDDL.Items.Insert(2, new ListItem("Image 2", Convert.ToBase64String(questionTwo)));
                imageDDL.Items.Insert(3, new ListItem("Image 3", Convert.ToBase64String(questionThree)));
            }
            catch
            {

            }
          
        }


        protected void submitAnsweredSQBtn_Click(object sender, EventArgs e)
        {
            string userId = inputIdTB.Text;
            resetSeurityPanel.Visible = true;
            answerSecurityQ.Visible = false;
            passwordPanel.Visible = false;
            emailPanel.Visible = false;

            RegistrationBO getQuestions = new RegistrationBO();
            SecurityQuestions sqObj = getQuestions.GetSQById(userId);

            //load image into dropdown
            List<String> templist = new List<String>();

            var tupleList = new List<Tuple<Byte[], String>>();
            tupleList.Add(new Tuple<Byte[], String>(sqObj.firstSecurityQ, sqObj.firstSecurityQA.ToString()));
            tupleList.Add(new Tuple<Byte[], String>(sqObj.secondSecurityQ, sqObj.secondSecurityQA.ToString()));
            tupleList.Add(new Tuple<Byte[], String>(sqObj.thirdSecurityQ, sqObj.thirdSecurityQA.ToString()));

            byte[] questionOne = tupleList[0].Item1;
            string questionOneAns = tupleList[0].Item2;
            byte[] questionTwo = tupleList[1].Item1;
            string questionTwoAns = tupleList[1].Item2;
            byte[] questionThree = tupleList[2].Item1;
            string questionThreeAns = tupleList[2].Item2;

            Image1.ImageUrl = "data:Image/;base64," + imageDDL.SelectedValue;
            string ans = securityQntAnsTB.Text;
            if (imageDDL.SelectedIndex == 1) //first imge
            {
                errLbl.Text = null;
                if (ans.Equals(questionOneAns) == false)
                {
                    //wrong ans
                    errLbl.Text = "Wrong asnwer input";
                    resetSeurityPanel.Visible = false;
                    answerSecurityQ.Visible = true;
                    passwordPanel.Visible = false;
                    emailPanel.Visible = false;
                }
                else
                {
                    //pass
                    errLbl.Text = null;
                    resetSeurityPanel.Visible = true;
                    answerSecurityQ.Visible = false;
                    passwordPanel.Visible = false;
                    emailPanel.Visible = false;
                }
            }
            else if (imageDDL.SelectedIndex == 2)
            {
                errLbl.Text = null;
                if (ans.Equals(questionTwoAns) == false)
                {
                    //wrong ans
                    errLbl.Text = "Wrong asnwer input";
                    resetSeurityPanel.Visible = false;
                    answerSecurityQ.Visible = true;
                    passwordPanel.Visible = false;
                    emailPanel.Visible = false;
                }
                else
                {
                    //pass
                    errLbl.Text = null;
                    resetSeurityPanel.Visible = true;
                    answerSecurityQ.Visible = false;
                    passwordPanel.Visible = false;
                    emailPanel.Visible = false;
                }
            }
            else if (imageDDL.SelectedIndex == 3)
            {
                errLbl.Text = null;
                if (ans.Equals(questionThreeAns) == false)
                {
                    //wrong ans
                    errLbl.Text = "Wrong asnwer input";
                    resetSeurityPanel.Visible = false;
                    answerSecurityQ.Visible = true;
                    passwordPanel.Visible = false;
                    emailPanel.Visible = false;
                }
                else
                {
                    //pass
                    errLbl.Text = null;
                    resetSeurityPanel.Visible = true;
                    answerSecurityQ.Visible = false;
                    passwordPanel.Visible = false;
                    emailPanel.Visible = false;
                }
            }

        }

        protected void imageDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userId = inputIdTB.Text;
            RegistrationBO getQuestions = new RegistrationBO();
            SecurityQuestions sqObj = getQuestions.GetSQById(userId);

            //load image into dropdown
            Image1.ImageUrl = "data:Image/;base64," + imageDDL.SelectedValue;


        }

        protected void submitPasswordBtn_Click(object sender, EventArgs e)
        {
            bool userExist = checkPW();
            if (userExist == false)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('Wrong PW!');", true);
            }
            else
            {
                //move to reset sec q 
                answerSecurityQ.Visible = true;
                passwordPanel.Visible = false;
                emailPanel.Visible = false;
                string userId = inputIdTB.Text;

                getImages(userId);
            }
        }

    

        protected void cancel_Click(object sender, EventArgs e)
        {
            cancelButton();
        }

        public bool SQvalid()
        {
            bool pass = true;
            string firstImageAns = firstImageAnsTB.Text.Trim();
            string secondImageAns = secondImageAnsTB.Text.Trim();
            string thirdImageAns = thirdImageAnsTB.Text.Trim();
            string filePath;
            string filename;
            string extension;
            string SecfilePath;
            string Secfilename;
            string thirdfilePath;
            string thirdfilename;
            //for checking if two input is same
            if (firstImageAns.Equals(secondImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            if (firstImageAns.Equals(thirdImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            if (secondImageAns.Equals(firstImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            if (secondImageAns.Equals(thirdImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            if (thirdImageAns.Equals(secondImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            if (thirdImageAns.Equals(firstImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            //check if image got file
            if (imageUpload.HasFile)
            {
                filePath = imageUpload.PostedFile.FileName;
                filename = Path.GetFileName(filePath);
                extension = Path.GetExtension(filename);
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                    errLblForSQ.Text = "Please choose the first file that is .jpg or .png only";
                    errLblForSQ.Visible = true;
                }

            }
            if (image2Upload.HasFile)
            {
                SecfilePath = image2Upload.PostedFile.FileName;
                Secfilename = Path.GetFileName(SecfilePath);
                extension = Path.GetExtension(Secfilename);
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                    errLblForSQ.Text = "Please choose the second file that is .jpg , .png only";
                    errLblForSQ.Visible = true;
                }

            }
            if (image3Upload.HasFile)
            {
                thirdfilePath = image3Upload.PostedFile.FileName;
                thirdfilename = Path.GetFileName(thirdfilePath);
                extension = Path.GetExtension(thirdfilename);
                if (extension != ".jpg" || extension != ".png" || extension != ".jpeg")
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                    errLblForSQ.Text = "Please choose the third file that is .jpg , .png only";
                    errLblForSQ.Visible = true;
                }

            }


            return pass;
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (System.Drawing.Image)b;
        }

        //convert image back to byte
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        //check if image is the same
        public bool checkSameImage(Byte[] bytes, Byte[] secbytes, Byte[] thirdbytes)
        {
            bool pass = true;

            //Converting Byte Array To Image And Then Into Bitmap
            ImageConverter ic = new ImageConverter();
            System.Drawing.Image img = (System.Drawing.Image)ic.ConvertFrom(bytes);
            System.Drawing.Image img2 = (System.Drawing.Image)ic.ConvertFrom(secbytes);
            System.Drawing.Image img3 = (System.Drawing.Image)ic.ConvertFrom(thirdbytes);

            //resize image
            Size currsize = new Size();
            currsize.Height = 600;
            currsize.Width = 600;
            System.Drawing.Image ResizeImg = resizeImage(img, currsize);
            System.Drawing.Image ResizeImg2 = resizeImage(img2, currsize);
            System.Drawing.Image ResizeImg3 = resizeImage(img3, currsize);

            var bitmap = (Bitmap)ResizeImg;
            var hash = ImagePhash.ComputeDigest(bitmap.ToLuminanceImage());

            var bitmap2 = (Bitmap)ResizeImg2;
            var hash2 = ImagePhash.ComputeDigest(bitmap2.ToLuminanceImage());

            var bitmap3 = (Bitmap)ResizeImg3;
            var hash3 = ImagePhash.ComputeDigest(bitmap3.ToLuminanceImage());

            var score = ImagePhash.GetCrossCorrelation(hash, hash2); //check for image 1 and 2
            var score2 = ImagePhash.GetCrossCorrelation(hash, hash3); //check for image 1 and 3
            var score3 = ImagePhash.GetCrossCorrelation(hash2, hash3); //check for image 2 and 3


            if (score > 0.7)
            {
                errLblForSQ.Text = " Please choose a different image for Q1 and Q2";
                pass = false;
            }

            if (score2 > 0.7)
            {
                errLblForSQ.Text = " Please choose a different image for Q1 and Q3";
                pass = false;
            }

            if (score3 > 0.7)
            {
                errLblForSQ.Text = " Please choose a different image for Q2 and Q3";
                pass = false;
            }

            return pass;
        }


        protected void submitSQBtn_Click(object sender, EventArgs e)
        {
            bool success = SQvalid();

            if(success == false)
            {

            }
            else
            {
                string userId = inputIdTB.Text;
                Stream fs = imageUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                Stream secfs = image2Upload.PostedFile.InputStream;
                BinaryReader secbr = new BinaryReader(secfs);
                Byte[] secbytes = secbr.ReadBytes((Int32)secfs.Length);

                Stream thirdfs = image3Upload.PostedFile.InputStream;
                BinaryReader thirdbr = new BinaryReader(thirdfs);
                Byte[] thirdbytes = thirdbr.ReadBytes((Int32)thirdfs.Length);
                bool pass = checkSameImage(bytes, secbytes, thirdbytes);
                if (pass == true)
                {
                    //Converting Byte Array To Image And Then Into Bitmap
                    ImageConverter ic = new ImageConverter();
                    System.Drawing.Image img = (System.Drawing.Image)ic.ConvertFrom(bytes);
                    System.Drawing.Image img2 = (System.Drawing.Image)ic.ConvertFrom(secbytes);
                    System.Drawing.Image img3 = (System.Drawing.Image)ic.ConvertFrom(thirdbytes);

                    //resize image
                    Size currsize = new Size();
                    currsize.Height = 500;
                    currsize.Width = 500;
                    System.Drawing.Image ResizeImg = resizeImage(img, currsize);
                    System.Drawing.Image ResizeImg2 = resizeImage(img2, currsize);
                    System.Drawing.Image ResizeImg3 = resizeImage(img3, currsize);
                    Byte[] newimg = ImageToByte(ResizeImg);
                    Byte[] newimg2 = ImageToByte(ResizeImg2);
                    Byte[] newimg3 = ImageToByte(ResizeImg3);
                    //////////////////////////////////////////////////////////////////////////////////////////////
                    RegistrationBO addUser = new RegistrationBO();
                    //update
                    string firstImageAns = firstImageAnsTB.Text.Trim();
                    string secondImageAns = secondImageAnsTB.Text.Trim();
                    string thirdImageAns = thirdImageAnsTB.Text.Trim();
                    try
                    {
                        addUser.updateSQ(userId, newimg, firstImageAns, newimg2, secondImageAns, newimg3, thirdImageAns);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Your Security Questions have been updated!');window.location ='LoginPage.aspx';", true);
                      //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Your Security Questions have been updated!');window.location ='LoginPage.aspx';", true);
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true); //USER EXIST
                    }


                }
                else
                {
                    
                }
            }

           
            //string display = "Your Security Questions have been updated!";
            //ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('" + display + "');", true);

            //Response.Redirect("LoginPage.aspx");
        }

    }
}


//this is for randomizing sq
//RegistrationBO getQuestions = new RegistrationBO();
//// SecurityQuestions sqObj = new SecurityQuestions();
//SecurityQuestions sqObj = getQuestions.GetSQById(userId);
//List<String> templist = new List<String>();
//List<Byte[]> getlist = new List<Byte[]>();

//var tupleList = new List<Tuple<Byte[], String>>();
//tupleList.Add(new Tuple<Byte[], String>(sqObj.firstSecurityQ, sqObj.firstSecurityQA.ToString()));
//                tupleList.Add(new Tuple<Byte[], String>(sqObj.secondSecurityQ, sqObj.secondSecurityQA.ToString()));
//                tupleList.Add(new Tuple<Byte[], String>(sqObj.thirdSecurityQ, sqObj.thirdSecurityQA.ToString()));

//                Shuffle(tupleList);

//                for (int i = 0; i< 2; i++)
//                {
//                    byte[] questionOne = tupleList[0].Item1;
//string questionOneAns = tupleList[0].Item2;
//byte[] questionTwo = tupleList[1].Item1;
//string questionTwoAns = tupleList[1].Item2;
////   byte[] secBytes = (byte[])sqObj.secondSecurityQ;

//Image1.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionOne);
//                    Image2.ImageUrl = "data:Image/;base64," + Convert.ToBase64String(questionTwo);

//                }