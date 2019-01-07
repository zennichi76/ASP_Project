using EADP_Project.BO;
using ImagesComparator;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Project
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool isValidated()
        {
            bool pass = true;
            int number;
            String name = inputNameTB.Text.Trim();
            string firstImageAns = firstImageAnsTB.Text.Trim();
            string secondImageAns = secondImageAnsTB.Text.Trim();
            string thirdImageAns = thirdImageAnsTB.Text.Trim();

            if (int.TryParse(name, out number) == true)
            {
                pass = false;
                errLblForName.Text = "Only alphabets is allowed";
                inputNameTB.BorderColor = System.Drawing.Color.Red;
                errLblForName.Visible = true;

            }
            //for checking if two input is same
            //if (firstImageAns.Equals(secondImageAns))
            //{
            //    pass = false;
            //    errLblForSQ.Text = "No two answer should be the same";
            //    firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    errLblForSQ.Visible = true;
            //}
            //if (firstImageAns.Equals(thirdImageAns))
            //{
            //    pass = false;
            //    errLblForSQ.Text = "No two answer should be the same";
            //    firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    errLblForSQ.Visible = true;
            //}
            //if (secondImageAns.Equals(firstImageAns))
            //{
            //    pass = false;
            //    errLblForSQ.Text = "No two answer should be the same";
            //    firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    errLblForSQ.Visible = true;
            //}
            //if (secondImageAns.Equals(thirdImageAns))
            //{
            //    pass = false;
            //    errLblForSQ.Text = "No two answer should be the same";
            //    thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    errLblForSQ.Visible = true;
            //}
            //if (thirdImageAns.Equals(secondImageAns))
            //{
            //    pass = false;
            //    errLblForSQ.Text = "No two answer should be the same";
            //    thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    secondImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    errLblForSQ.Visible = true;
            //}
            //if (thirdImageAns.Equals(firstImageAns))
            //{
            //    pass = false;
            //    errLblForSQ.Text = "No two answer should be the same";
            //    thirdImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    firstImageAnsTB.BorderColor = System.Drawing.Color.Red;
            //    errLblForSQ.Visible = true;
            //}
            //if (imageUpload.HasFile)
            //{
            //    string filePath = imageUpload.PostedFile.FileName;
            //    string filename = Path.GetFileName(filePath);
            //    string extension = Path.GetExtension(filename);
            //    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
            //    {
            //        pass = true;
            //    }
            //    else
            //    {
            //         pass = false;
            //         errLblForSQ.Text = "Please choose the first file that is .jpg or .png only";
            //         errLblForSQ.Visible = true;
            //    }

            //}
            //if (image2Upload.HasFile)
            //{
            //    string SecfilePath = image2Upload.PostedFile.FileName;
            //    string Secfilename = Path.GetFileName(SecfilePath);
            //    string extension = Path.GetExtension(Secfilename);
            //    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
            //    {
            //        pass = true;
            //    }
            //    else
            //    {
            //        pass = false;
            //        errLblForSQ.Text = "Please choose the second file that is .jpg , .png only";
            //        errLblForSQ.Visible = true;
            //    }

            //}
            //if (image3Upload.HasFile)
            //{
            //    string thirdfilePath = image3Upload.PostedFile.FileName;
            //    string thirdfilename = Path.GetFileName(thirdfilePath);
            //    string extension = Path.GetExtension(thirdfilename);
            //    if (extension != ".jpg" || extension != ".png" || extension != ".jpeg")
            //    {
            //        pass = true;
            //    }
            //    else
            //    {
            //        pass = false;
            //        errLblForSQ.Text = "Please choose the third file that is .jpg , .png only";
            //        errLblForSQ.Visible = true;
            //    }

            //}


            return pass;
        }


        public enum CompareResult
        {
            ciCompareOk,
            ciPixelMismatch,
            ciSizeMismatch
        };

        public static CompareResult Compare(Bitmap bmp1, Bitmap bmp2)
        {
            CompareResult cr = CompareResult.ciCompareOk;

            //Test to see if we have the same size of image
            if (bmp1.Size != bmp2.Size)
            {
                cr = CompareResult.ciSizeMismatch;
            }
            else
            {
                //Convert each image to a byte array
                System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();
                byte[] btImage1 = new byte[1];
                btImage1 = (byte[])ic.ConvertTo(bmp1, btImage1.GetType());
                byte[] btImage2 = new byte[1];
                btImage2 = (byte[])ic.ConvertTo(bmp2, btImage2.GetType());

                //Compute a hash for each image
                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                //Compare the hash values
                for (int i = 0; i < hash1.Length && i < hash2.Length && cr == CompareResult.ciCompareOk; i++)
                {
                    if (hash1[i] != hash2[i])
                        cr = CompareResult.ciPixelMismatch;
                }
                shaM.Clear();
            }

            return cr;
        }
        
        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }


    

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            bool success = isValidated();
            if (success == false)
            {

            }
            else
            {
                string User_ID = inputNRICTB.Text;
                string password = passwordTB.Text;
                string name = inputNameTB.Text;
                string email = emailTB.Text;
                string confirmEmail = "false";
                string role = "Student";
                ////String school_ID, String education_level, String education_class;
                //string firstImageAns = firstImageAnsTB.Text.Trim();
                //string secondImageAns = secondImageAnsTB.Text.Trim();
                //string thirdImageAns = thirdImageAnsTB.Text.Trim();

                //////////////////////////////////////////////////////////////////////////////////////////////////

                //// For 1st SQ: Read the file and convert it to Byte Array
                //string filePath = imageUpload.PostedFile.FileName;
                //string filename = Path.GetFileName(filePath);
                ////string ext = Path.GetExtension(filename);

                //// For 2nd SQ: Read the file and convert it to Byte Array
                //string SecfilePath = image2Upload.PostedFile.FileName;
                //string Secfilename = Path.GetFileName(SecfilePath);

                //// For 3rd SQ: Read the file and convert it to Byte Array
                //string thirdfilePath = image3Upload.PostedFile.FileName;
                //string thirdfilename = Path.GetFileName(thirdfilePath);


                //System.Drawing.Image firstUploaded = System.Drawing.Image.FromStream(imageUpload.PostedFile.InputStream);
                //System.Drawing.Image secUploaded = System.Drawing.Image.FromStream(image2Upload.PostedFile.InputStream);
                //System.Drawing.Image thirdUploaded = System.Drawing.Image.FromStream(image3Upload.PostedFile.InputStream);
                
                //int originalWidth = firstUploaded.Width;
                //int originalHeight = firstUploaded.Height;
                //float percentWidth = (float)256 / (float)originalWidth;
                //float percentHeight = (float)256 / (float)originalHeight;
                //float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                //int newWidth = (int)(originalWidth * percent);
                //int newHeight = (int)(originalHeight * percent);

                //int originalWidth2 = secUploaded.Width;
                //int originalHeight2 = secUploaded.Height;
                //float percentWidth2 = (float)256 / (float)originalWidth2;
                //float percentHeight2 = (float)256 / (float)originalHeight2;
                //float percent2 = percentHeight2 < percentWidth2 ? percentHeight2 : percentWidth2;
                //int newWidth2 = (int)(originalWidth2 * percent2);
                //int newHeight2 = (int)(originalHeight2 * percent2);

                //int originalWidth3 = thirdUploaded.Width;
                //int originalHeight3 = thirdUploaded.Height;
                //float percentWidth3 = (float)256 / (float)originalWidth3;
                //float percentHeight3 = (float)256 / (float)originalHeight3;
                //float percent3 = percentHeight3 < percentWidth3 ? percentHeight3 : percentWidth3;
                //int newWidth3 = (int)(originalWidth3 * percent3);
                //int newHeight3 = (int)(originalHeight3 * percent3);

                //System.Drawing.Image newImage1 = new Bitmap(newWidth, newHeight);
                //using (Graphics g = Graphics.FromImage(newImage1))
                //{
                //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //    g.DrawImage(firstUploaded, 0, 0, newWidth, newHeight);
                //}

                //System.Drawing.Image newImage2 = new Bitmap(newWidth, newHeight);
                //using (Graphics g = Graphics.FromImage(newImage2))
                //{
                //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //    g.DrawImage(secUploaded, 0, 0, newWidth, newHeight);
                //}

                //System.Drawing.Image newImage3 = new Bitmap(newWidth, newHeight);
                //using (Graphics g = Graphics.FromImage(newImage3))
                //{
                //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //    g.DrawImage(thirdUploaded, 0, 0, newWidth, newHeight);
                //}

                //////////////////////////////////////////////////////////////////////////////////////////////////////
                //byte[] results;
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    ImageCodecInfo codec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);
                //    EncoderParameters jpegParms = new EncoderParameters(1);
                //    jpegParms.Param[0] = new EncoderParameter(Encoder.Quality, 95L);
                //    newImage1.Save(ms, codec, jpegParms);
                //    results = ms.ToArray();

                //    for(int i = 0; i < results.Length; i++)
                //    {
                //        //Stream test = firstUploaded;
                //    }

                //    Stream fs = imageUpload.PostedFile.InputStream;
                //    BinaryReader br = new BinaryReader(fs);
                //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                //    Stream secfs = image2Upload.PostedFile.InputStream;
                //    BinaryReader secbr = new BinaryReader(secfs);
                //    Byte[] secbytes = secbr.ReadBytes((Int32)secfs.Length);

                //    Stream thirdfs = image3Upload.PostedFile.InputStream;
                //    BinaryReader thirdbr = new BinaryReader(thirdfs);
                //    Byte[] thirdbytes = thirdbr.ReadBytes((Int32)thirdfs.Length);
                //    //Converting Byte Array To Image And Then Into Bitmap
                //    ImageConverter ic = new ImageConverter();
                //    System.Drawing.Image img = (System.Drawing.Image)ic.ConvertFrom(bytes);
                //    Bitmap bmp1 = new Bitmap(img);
                //    System.Drawing.Image img1 = (System.Drawing.Image)ic.ConvertFrom(secbytes);
                //    Bitmap bmp2 = new Bitmap(img1);
                //    System.Drawing.Image img2 = (System.Drawing.Image)ic.ConvertFrom(thirdbytes);
                //    Bitmap bmp3 = new Bitmap(img2);

                //    List<bool> iHash1 = GetHash(new Bitmap(img));
                //    List<bool> iHash2 = GetHash(new Bitmap(img1));
                //    List<bool> iHash3 = GetHash(new Bitmap(img2));

                //    //determine the number of equal pixel (x of 256)
                //    int equalForOneTwo = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq); //compare img1 and img2 similarity
                //    int equalForOneThree = iHash1.Zip(iHash3, (i, j) => i == j).Count(eq => eq); //compare img1 and img3 similarity
                //    int equalForTwoThree = iHash2.Zip(iHash3, (i, j) => i == j).Count(eq => eq); //compare img2 and img3 similarity
                //                                                                                 //     int equalElements3 = iHash2.Zip(iHash3, (i, j) => i == j).Count(eq => eq);

                //    //    int equalElements4 = iHash3.Zip(iHash1, (i, j) => i == j).Count(eq => eq);
                //    //    int equalElements5 = iHash3.Zip(iHash2, (i, j) => i == j).Count(eq => eq);

                //    if (equalForOneTwo >= 150)
                //    { //check if similarity is more than 60%
                //        Label1.Text = "Please choose a different image For Image one and two";
                //    }
                //    if (equalForOneThree >= 156)
                //    {
                //        Label1.Text = "Please choose a different image For Image one and three";
                //    }
                //    if (equalForTwoThree >= 156)
                //    {
                //        Label1.Text = "Please choose a different image For Image two and three";
                //    }


                //}


              
                ////Calling Compare Function
                //if (Compare(bmp1, bmp2) == CompareResult.ciCompareOk)
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "Images Are Same";
                //}
                //else if (Compare(bmp1, bmp2) == CompareResult.ciPixelMismatch)
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "Pixel not Matching";
                //}
                //else if (Compare(bmp1, bmp2) == CompareResult.ciSizeMismatch)
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "Size Is Not Same";
                //}

              
                //Label1.Text = equalElements.ToString() + " - "+ equalElements1.ToString() + " - " +  equalElements2.ToString();

                

                //////////////////////////////////////////////////////////////////////////////////////////////
                RegistrationBO addUser = new RegistrationBO();
                addUser.insertUser(User_ID, password, name, email, confirmEmail, role);
                //addUser.insertSQ(User_ID, bytes, firstImageAns, secbytes, secondImageAns, thirdbytes, thirdImageAns);
                
                errLblForSQ.Text = "";
                errLblForSQ.Visible = false;
                errLblForName.Text = "";
                errLblForName.Visible = false;

            }
        }





    }
}