using EADP_Project.BO;
using EADP_Project.Entities;
using ImagesComparator;
using Newtonsoft.Json.Linq;
using Shipwreck.Phash;
using Shipwreck.Phash.Bitmaps;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                //second check for cookie has the same value as the second session
                if ((Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value)))
                {
                    if (!IsPostBack)
                    {

                    }

                }
            }

            Session["Reset"] = true;
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;

            ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
        }
        

        //remove session if user didn't choose anything
        public void removeSession()
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
            Response.Redirect("LoginPage.aspx");
        }

        //session fixation for timeout
        //session fixation for timeout
        protected void RemoveSessionBtn_OnClick(object Source, EventArgs e)
        {
            errNameLbl.Visible = false;
            errLblForSQ.Text = "";
            errLblForSQ.Visible = false;
            inputNameTB.Text = "";
            inputNRICTB.Text = "";
            emailTB.Text = "";
            passwordTB.Text = "";
            ConfirmPasswordTB.Text = "";
            imageUpload.Dispose();
            image2Upload.Dispose();
            image3Upload.Dispose();
            firstImageAnsTB.Text = "";
            secondImageAnsTB.Text = "";
            thirdImageAnsTB.Text = "";
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
            Response.Redirect("LoginPage.aspx");

        }


        //session reset
        protected void ResetSessionBtn_OnClick(object Source, EventArgs e)
        {
            Session["Reset"] = true;
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
            int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;

            ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);

        }

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }

        public bool isValidated()
        {
            bool pass = true;
            int number;
            string name = inputNameTB.Text.Trim();
            string email = emailTB.Text.Trim();
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
            string passwrd = passwordTB.Text.Trim();
            string cpw = ConfirmPasswordTB.Text.Trim();

            //check for valid characters
            if (int.TryParse(name, out number) == true)
            {
                pass = false;
                errNameLbl.Text = "Only alphabets is allowed";
                inputNameTB.BorderColor = System.Drawing.Color.Red;
                errNameLbl.Visible = true;

            }
            else if (passwrd.Equals(cpw) != true)
            {
                pass = false;
                passwordTB.BorderColor = System.Drawing.Color.Red;
                ConfirmPasswordTB.BorderColor = System.Drawing.Color.Red;
                errNameLbl.Visible = true;
            }
            //for checking if two input is same
            else if (firstImageAns.Equals(secondImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            else if (firstImageAns.Equals(thirdImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            else if (secondImageAns.Equals(firstImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            else if (secondImageAns.Equals(thirdImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            else if (thirdImageAns.Equals(secondImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            else if (thirdImageAns.Equals(firstImageAns))
            {
                pass = false;
                errLblForSQ.Text = "No two answer should be the same";
                thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
                firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
                errLblForSQ.Visible = true;
            }
            //check if image got file
            else if (imageUpload.HasFile)
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
            else if (image2Upload.HasFile)
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
            else if (image3Upload.HasFile)
            {
                thirdfilePath = image3Upload.PostedFile.FileName;
                thirdfilename = Path.GetFileName(thirdfilePath);
                extension = Path.GetExtension(thirdfilename);
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
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

        public bool userExist()
        {
            bool userExist = false;
            bool result = false;
            RegistrationBO addUser = new RegistrationBO();
            string User_ID = inputNRICTB.Text;
            string email = emailTB.Text;
            userExist = addUser.checkIfUserExist(User_ID, email);
            if (userExist == true)
            {
                result = true; //user does not exist
            }
            else if (userExist == false)
            {
                //user  exist
                result = false;
            }

            return result;

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            bool success = isValidated();
            bool userisValid = userExist();
            bool captchaPass = IsReCaptchValid();
            if (success == false)
            {

            }
            else
            {
                try
                {
                    if (captchaPass == true)
                    {
                        if (userisValid == true)
                        {
                            string activationCode;
                            string User_ID = inputNRICTB.Text;
                            string password = passwordTB.Text;
                            string name = inputNameTB.Text;
                            string email = emailTB.Text;
                            string confirmEmail = "False";
                            string role = "Student";
                            string firstImageAns = firstImageAnsTB.Text.Trim();
                            string secondImageAns = secondImageAnsTB.Text.Trim();
                            string thirdImageAns = thirdImageAnsTB.Text.Trim();

                            ////////////////////////////////For activation Email//////////////////////////////////////////////////
                            //generate random code for activation
                            Random random = new Random();
                            activationCode = random.Next(1001, 9999).ToString();

                            string msgSub = "Registration Confirmation";
                            string emailTo = emailTB.Text;
                            string breakTag = "\n";
                            string msgBod = "Hi " + inputNameTB.Text + ", ";

                            msgBod += breakTag + "Thank you for signing up with Orion. You are only one step away from using your newly created account. ";
                            msgBod += breakTag + "Please enter the following code to verify your account: " + activationCode;
                            msgBod += breakTag + "Please note that the code will expired in 3 hours";
                            msgBod += breakTag + "Yours Faithfully," + breakTag + "Orion Team";

                            ////////////////////////////////For SQ Questions///////////////////////////////////
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
                                try
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
                                    //for activationCode
                                    DateTime currDT = DateTime.Now;
                                    DateTime futureDT = currDT.AddHours(3.0);
                                    //add to userdb
                                    addUser.insertUser(User_ID, password, name, email, confirmEmail, role, activationCode, futureDT);
                                    //add to sq
                                    addUser.insertSQ(User_ID, newimg, firstImageAns, newimg2, secondImageAns, newimg3, thirdImageAns);

                                    /////////////////////////////Send Email////////////////////////////////////////////////////

                                    mailService sendMail = new mailService();
                                    sendMail.sendmail(emailTo, msgSub, msgBod);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openRedirectModal();", true);

                                    Session["userName"] = User_ID;
                                    Session["RegistrationPage"] = "Registration";
                                    errNameLbl.Visible = false;
                                    errLblForSQ.Text = "";
                                    errLblForSQ.Visible = false;
                                    inputNameTB.Text = "";
                                    inputNRICTB.Text = "";
                                    emailTB.Text = "";
                                    passwordTB.Text = "";
                                    ConfirmPasswordTB.Text = "";
                                    imageUpload.Dispose();
                                    image2Upload.Dispose();
                                    image3Upload.Dispose();
                                    firstImageAnsTB.Text = "";
                                    secondImageAnsTB.Text = "";
                                    thirdImageAnsTB.Text = "";
                                    Response.AddHeader("refresh", "5;URL=ConfirmAccount.aspx");

                                }
                                catch
                                {
                                    errNameLbl.Visible = true;
                                    errLblForSQ.Visible = true;
                                    //reset session
                                    Session["Reset"] = true;
                                    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                                    SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                                    int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                                    ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAccFModal();", true); //creation fail
                                }

                            }
                            else
                            {
                                errNameLbl.Visible = true;
                                errLblForSQ.Visible = true;
                                //reset session
                                Session["Reset"] = true;
                                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                                int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                                ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                            }
                        }
                        else
                        {
                            //reset session
                            Session["Reset"] = true;
                            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                            SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                            int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                            ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true); //USER EXIST
                        }
                    }
                    else
                    {
                        errCaptcha.Visible = true;
                    }
                }
                catch
                {
                    errNameLbl.Visible = true;
                    errLblForSQ.Visible = true;
                    //reset session
                    Session["Reset"] = true;
                    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                    SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                    int totalTime = (int)section.Timeout.TotalMinutes * 1000 * 60;
                    ClientScript.RegisterStartupScript(this.GetType(), "", "sessionAlert(" + totalTime + ");", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAccFModal();", true); //creation fail
                }


            }
        }






    }





    }
