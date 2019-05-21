using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK.GKICMP.Entities;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using Newtonsoft.Json.Linq;


namespace GK.GKICMP.Common
{
    public class Face
    {
        //测试用
        private const string apikey = "Kn0uVbTRUOr0d0DvdUuJQ4C2-daLr6fS";
        private const string apisecret = "p_SBvljOURSvr5MbZ160Ry1nRKS8BFjQ";
        //田家炳
        //private const string apikey = "HEipCHtN4f2KY8fTVL3Er9ol8uz3V-4v";
        //private const string apisecret = "hGOp7TFAT-M9KmzAo3Gyyn8ca0jjE3kO";
        //城南实验中学
        //private const string apikey = "6D5IgOTxECA82M4WrPg0-z-5LR8ZjVKF";
        //private const string apisecret = "yY-geCiVW0mqgdn0AQcSsqR6avhb8u0Y";

        public static string Detect(string imagepath)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);

            Bitmap bmp = new Bitmap(imagepath); // 图片地址
            byte[] fileImage;
            using (Stream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Jpeg);
                byte[] arr = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(arr, 0, (int)stream.Length);
                stream.Close();
                fileImage = arr;
            }

            //添加图片参数
            verifyPostParameters.Add("image_file", new HttpHelper4MultipartForm.FileParameter(fileImage, DateTime.Now.ToString("yyyyMMddHHmmss") + "_FaceImage.jpg", "application/octet-stream"));

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/detect", "", verifyPostParameters);


            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);

            string facetoken = "";
            try
            {
                // Newtonsoft.Json.Linq.JObject facetokenja = (Newtonsoft.Json.Linq.JObject)ja["faces"];
                facetoken = (((Newtonsoft.Json.Linq.JArray)ja["faces"])[0])["face_token"].ToString();
            }
            catch
            {
                facetoken = "$error:" + ja["error_message"].ToString();
            }
            return facetoken;
        }


        public static JArray DetectAll(string imagepath)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);

            Bitmap bmp = new Bitmap(imagepath); // 图片地址
            byte[] fileImage;
            using (Stream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Jpeg);
                byte[] arr = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(arr, 0, (int)stream.Length);
                stream.Close();
                fileImage = arr;
            }

            //添加图片参数
            verifyPostParameters.Add("image_file", new HttpHelper4MultipartForm.FileParameter(fileImage, DateTime.Now.ToString("yyyyMMddHHmmss") + "_FaceImage.jpg", "application/octet-stream"));

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/detect", "", verifyPostParameters);


            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);

            JArray jarray = new JArray();
            try
            {
                jarray = (Newtonsoft.Json.Linq.JArray)ja["faces"];
            }
            catch
            {

            }
            return jarray;
        }



        public static JArray BodyDetect(string imagepath)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);

            Bitmap bmp = new Bitmap(imagepath); // 图片地址
            byte[] fileImage;
            using (Stream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Jpeg);
                byte[] arr = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(arr, 0, (int)stream.Length);
                stream.Close();
                fileImage = arr;
            }

            //添加图片参数
            verifyPostParameters.Add("image_file", new HttpHelper4MultipartForm.FileParameter(fileImage, DateTime.Now.ToString("yyyyMMddHHmmss") + "_BodyImage.jpg", "application/octet-stream"));

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/humanbodypp/beta/detect", "", verifyPostParameters);


            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);
            Newtonsoft.Json.Linq.JArray jaresult = new JArray();
            try
            {
                jaresult = (Newtonsoft.Json.Linq.JArray)ja["humanbodies"];
            }
            catch
            {

            }

            return jaresult;
        }

        public static float Compare(string imagepath, string facetoken)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);

            Bitmap bmp = new Bitmap(imagepath); // 图片地址
            byte[] fileImage;
            using (Stream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Jpeg);
                byte[] arr = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(arr, 0, (int)stream.Length);
                stream.Close();
                fileImage = arr;
            }

            //添加图片参数
            verifyPostParameters.Add("image_file1", new HttpHelper4MultipartForm.FileParameter(fileImage, DateTime.Now.ToString("yyyyMMddHHmmss") + "_FaceImage.jpg", "application/octet-stream"));
            verifyPostParameters.Add("face_token2", facetoken);

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/compare", "", verifyPostParameters);


            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);

            float confidence = 0;
            try
            {
                float.TryParse(ja["confidence"].ToString(), out confidence);
            }
            catch
            {
                confidence = -1;
            }
            return confidence;
        }



        public static string Search(string imagepath, string facesettoken)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);

            Bitmap bmp = new Bitmap(imagepath); // 图片地址
            byte[] fileImage;
            using (Stream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Jpeg);
                byte[] arr = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(arr, 0, (int)stream.Length);
                stream.Close();
                fileImage = arr;
            }

            //添加图片参数
            verifyPostParameters.Add("image_file", new HttpHelper4MultipartForm.FileParameter(fileImage, DateTime.Now.ToString("yyyyMMddHHmmss") + "_FaceImage.jpg", "application/octet-stream"));
            verifyPostParameters.Add("faceset_token", facesettoken);

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/search", "", verifyPostParameters);


            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);
            string result = "";
            float ie3 = 0, ie4 = 0, ie5 = 0;

            Newtonsoft.Json.Linq.JObject iearray = (Newtonsoft.Json.Linq.JObject)ja["thresholds"];


            Newtonsoft.Json.Linq.JArray jaresult = (Newtonsoft.Json.Linq.JArray)ja["results"];
            try
            {
                if (jaresult != null && jaresult.Count > 0)
                {
                    float maxconfidence = 0;
                    float.TryParse(iearray["1e-3"].ToString(), out ie3);
                    float.TryParse(iearray["1e-4"].ToString(), out ie4);
                    float.TryParse(iearray["1e-5"].ToString(), out ie5);

                    foreach (var face in jaresult)
                    {
                        float confidence = 0;
                        float.TryParse(face["confidence"].ToString(), out confidence);
                        if (confidence > maxconfidence && confidence > ie5)
                        {
                            result = face["face_token"].ToString();
                            float.TryParse(face["confidence"].ToString(), out maxconfidence);
                        }
                    }
                }
                else
                {
                    result = "No Result";
                }

            }
            catch
            {
                result = "$error:" + ja["error_message"].ToString();
            }

            return result;
        }


        public static string Search(Bitmap bmp, string facesettoken)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);

            byte[] fileImage;
            using (Stream stream = new MemoryStream())
            {
                bmp.Save(stream, ImageFormat.Jpeg);
                byte[] arr = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(arr, 0, (int)stream.Length);
                stream.Close();
                fileImage = arr;
            }

            //添加图片参数
            verifyPostParameters.Add("image_file", new HttpHelper4MultipartForm.FileParameter(fileImage, DateTime.Now.ToString("yyyyMMddHHmmss") + "_FaceImage.jpg", "application/octet-stream"));
            verifyPostParameters.Add("faceset_token", facesettoken);

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/search", "", verifyPostParameters);


            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);
            string result = "";
            float ie3 = 0, ie4 = 0, ie5 = 0;

            try
            {
                if (ja["error_message"].ToString() != "")
                {
                    return "$error:" + ja["error_message"].ToString();
                }

            }
            catch
            {

            }

            Newtonsoft.Json.Linq.JObject iearray = (Newtonsoft.Json.Linq.JObject)ja["thresholds"];


            try
            {
                Newtonsoft.Json.Linq.JArray jaresult = (Newtonsoft.Json.Linq.JArray)ja["results"];

                if (jaresult != null && jaresult.Count > 0)
                {
                    float maxconfidence = 0;
                    float.TryParse(iearray["1e-3"].ToString(), out ie3);
                    float.TryParse(iearray["1e-4"].ToString(), out ie4);
                    float.TryParse(iearray["1e-5"].ToString(), out ie5);

                    foreach (var face in jaresult)
                    {
                        float confidence = 0;
                        float.TryParse(face["confidence"].ToString(), out confidence);
                        if (confidence > maxconfidence && confidence > ie4)
                        {
                            result = face["face_token"].ToString();
                            float.TryParse(face["confidence"].ToString(), out maxconfidence);
                        }
                    }
                }
                else
                {
                    result = "No Result";
                }

            }
            catch
            {
                result = "$error:" + ja["error_message"].ToString();
            }

            return result;
        }

        public static string CreateFaceSet(string displayname, string outerid)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);
            verifyPostParameters.Add("display_name", displayname);
            verifyPostParameters.Add("outer_id", outerid);

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/faceset/create", "", verifyPostParameters);

            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);

            string facesettoken = "";
            try
            {
                facesettoken = ja["faceset_token"].ToString();
            }
            catch
            {
                facesettoken = "$error:" + ja["error_message"].ToString();
            }

            return facesettoken;
        }

        public static int AddFaceSet(string facesettoken, string facetokens)
        {
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", apikey);
            verifyPostParameters.Add("api_secret", apisecret);
            verifyPostParameters.Add("faceset_token", facesettoken);
            verifyPostParameters.Add("face_tokens", facetokens);

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/faceset/addface", "", verifyPostParameters);

            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();

            Newtonsoft.Json.Linq.JObject ja = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(retString);

            int addcount = 0;
            try
            {
                addcount = Convert.ToInt32(ja["face_added"]);
            }
            catch
            {
                addcount = -1;
            }

            return addcount;
        }


        public void Test()
        {
            //参数字典
            Dictionary<string, object> verifyPostParameters = new Dictionary<string, object>();
            verifyPostParameters.Add("api_key", "Kn0uVbTRUOr0d0DvdUuJQ4C2-daLr6fS");
            verifyPostParameters.Add("api_secret", "p_SBvljOURSvr5MbZ160Ry1nRKS8BFjQ");

            verifyPostParameters.Add("display_name", "testface1");
            verifyPostParameters.Add("outer_id", "testface1");


            Bitmap bmp = new Bitmap("d:/lbj1.jpg"); // 图片地址
            byte[] fileImage;
            using (Stream stream1 = new MemoryStream())
            {
                bmp.Save(stream1, ImageFormat.Jpeg);
                byte[] arr = new byte[stream1.Length];
                stream1.Position = 0;
                stream1.Read(arr, 0, (int)stream1.Length);
                stream1.Close();
                fileImage = arr;
            }

            Bitmap bmp2 = new Bitmap("d:/allstar1.jpg"); // 图片地址
            byte[] fileImage2;
            using (Stream stream1 = new MemoryStream())
            {
                bmp2.Save(stream1, ImageFormat.Jpeg);
                byte[] arr = new byte[stream1.Length];
                stream1.Position = 0;
                stream1.Read(arr, 0, (int)stream1.Length);
                stream1.Close();
                fileImage2 = arr;
            }

            //添加图片参数
            //verifyPostParameters.Add("image_file1", new HttpHelper4MultipartForm.FileParameter(fileImage, "test1.jpg", "application/octet-stream"));
            //verifyPostParameters.Add("image_file2", new HttpHelper4MultipartForm.FileParameter(fileImage2, "test2.jpg", "application/octet-stream"));

            HttpWebResponse verifyResponse = HttpHelper4MultipartForm.MultipartFormDataPost("https://api-cn.faceplusplus.com/facepp/v3/faceset/create", "", verifyPostParameters);


            Stream myResponseStream = verifyResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();
        }
    }
}
